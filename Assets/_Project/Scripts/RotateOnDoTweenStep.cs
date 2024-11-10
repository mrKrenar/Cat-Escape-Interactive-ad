using System;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(DOTweenPath))]
public class RotateOnDoTweenStep : MonoBehaviour
{
    [SerializeField] private DOTweenPath doTweenPath;
    
    [SerializeField] private Transform transformToRotate;
    
    [SerializeField] float rotationToAddOnStep = 180;
    [SerializeField] float rotateSpeed = .5f;
    [SerializeField] private RotateMode rotateMode = RotateMode.LocalAxisAdd;

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
        transformToRotate.DOLocalRotate(Vector3.up * rotationToAddOnStep, rotateSpeed, rotateMode);
    }
}
