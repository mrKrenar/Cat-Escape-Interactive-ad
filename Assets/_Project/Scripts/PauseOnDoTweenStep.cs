using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[RequireComponent(typeof(DOTweenPath))]
public class PauseOnDoTweenStep : MonoBehaviour
{
    [SerializeField] private DOTweenPath doTweenPath;
    
    [Range(1,2)][SerializeField] private int pauseStepCount = 2;
    [SerializeField] private float pauseDuration = 1;
    
    public UnityEvent<bool> Moving;

    private int step = 1;

    private bool isRunning;
    private bool IsRunning
    {
        get => isRunning;
        set
        {
            isRunning = value;
            Moving?.Invoke(isRunning);
        }
    }

    private void Awake()
    {
        if (!doTweenPath)
        {
            doTweenPath = GetComponent<DOTweenPath>();
        }

        if (!doTweenPath.hasOnStepComplete)
        {
            Debug.LogError("Rotation won't work until OnStep is enabled in DotweenPath's inspector");
        }
        
        if (doTweenPath && doTweenPath.hasOnStepComplete)
        {
            doTweenPath.onStepComplete.AddListener(StepCompleteHandler);
        }
        
        Resume();
    }
    
    private void OnDestroy()
    {
        if (doTweenPath && doTweenPath.hasOnStepComplete)
        {
            doTweenPath.onStepComplete.RemoveListener(StepCompleteHandler);
        }
    }

    private void StepCompleteHandler()
    {
        if (step++ % pauseStepCount == 0)
        {
            Pause();
        }
    }
    
    void Pause()
    {
        doTweenPath.DOPause();
        
        IsRunning = false;
        
        Invoke(nameof(Resume), pauseDuration);
    }
    void Resume()
    {
        if (GameState.StateOfGame != StateOfGame.playing)
        {
            return;
        }
        
        doTweenPath.DOPlay();

        IsRunning = true;
    }
}
