using System;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(DOTweenPath))]
public class PauseOnDoTweenStep : MonoBehaviour
{
    [Range(1,2)][SerializeField] private int pauseStepCount = 2;
    [SerializeField] private float pauseDuration = 1;
    
    private int step = 1;

    
    [SerializeField] private DOTweenPath doTweenPath;

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
        
        Invoke(nameof(Resume), pauseDuration);
    }
    void Resume()
    {
        doTweenPath.DOPlay();
    }
}
