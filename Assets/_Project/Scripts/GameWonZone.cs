using System;
using UnityEngine;

public class GameWonZone : MonoBehaviour
{
    [SerializeField] LayerMask playerLayerMask;
    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & playerLayerMask) != 0)
        {
            GameState.UserWon();
        }
    }
}
