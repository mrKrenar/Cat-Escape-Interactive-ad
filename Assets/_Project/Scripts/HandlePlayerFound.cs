using System;
using System.Collections.Generic;
using UnityEngine;

public class HandlePlayerFound : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private Transform playerFound;
    
    public void PlayerFound(Transform playerFound)
    {
        this.playerFound = playerFound;
        
        GameState.UserCaught();
        
        animator.SetTrigger("tr_attack");
    }

    public void CatchPlayer()
    {
        playerFound.gameObject.SetActive(false);
    }
}
