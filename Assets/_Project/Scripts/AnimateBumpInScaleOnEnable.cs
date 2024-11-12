using System;
using DG.Tweening;
using UnityEngine;

public class AnimateBumpInScaleOnEnable : MonoBehaviour
{
    [SerializeField] private float startSize;
    [SerializeField] private float animationDuration;
    
    private void OnEnable()
    {
        transform.localScale = Vector3.one * startSize;
        transform.DOScale(Vector3.one, animationDuration)
            .SetEase(Ease.OutBack);
    }
}
