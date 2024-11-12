using System;
using UnityEngine;

public class SetAnimatorBoolean : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string boolKeyToSet;

    public void SetValue(bool value)
    {
        animator.SetBool(boolKeyToSet, value);
    }
}
