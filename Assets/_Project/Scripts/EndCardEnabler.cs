using System;
using System.Collections;
using UnityEngine;

public class EndCardEnabler : MonoBehaviour
{
    [SerializeField] private GameObject gameOverEndCard, gameWonEndCard;
    
    private void Start()
    {
        GameState.OnGameStateChanged += GameState_OnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameState.OnGameStateChanged -= GameState_OnGameStateChanged;
    }

    private void GameState_OnGameStateChanged(StateOfGame newState)
    {

        StartCoroutine(EnableEndCardWithDelay());
        
        IEnumerator EnableEndCardWithDelay()
        {
            yield return new WaitForSeconds(1);
            
            switch (newState)
            {
                case StateOfGame.lost:
                    gameOverEndCard.SetActive(true);
                    break;
                case StateOfGame.won:
                    gameWonEndCard.SetActive(true);
                    break;
            }
        }
        
    }
}
