using System;
using UnityEngine;

public class SetAnimatorBoolean : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string boolKeyToSet;
    private static int keyHash;

    private void Awake()
    {
        keyHash = Animator.StringToHash(boolKeyToSet);
    }

    public void SetValue(bool value)
    {
        animator.SetBool(keyHash, value);
    }
}
