using System;
using System.Collections.Generic;
using UnityEngine;

public class HandlePlayerCaughtByGuards : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private Transform caughtPlayer;
    
    public void PlayerFound(Transform caughtPlayer)
    {
        this.caughtPlayer = caughtPlayer;
        
        GameState.PlayerCaught();
        
        animator.SetTrigger("tr_attack");
    }

    //animation event
    public void CatchPlayer()
    {
        caughtPlayer.gameObject.SetActive(false);
    }
}
