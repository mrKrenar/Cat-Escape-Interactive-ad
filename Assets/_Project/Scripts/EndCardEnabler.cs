using System;
using System.Collections;
using UnityEngine;

public class EndCardEnabler : MonoBehaviour
{
    [SerializeField] private GameObject gameOverEndCard, gameWonEndCard;
    
    private void Start()
    {
        GameState.OnGameStateChanged += GameState_OnGameStateChangedHandler;
    }

    private void OnDestroy()
    {
        GameState.OnGameStateChanged -= GameState_OnGameStateChangedHandler;
    }

    private void GameState_OnGameStateChangedHandler(StateOfGame newState)
    {

        StartCoroutine(EnableEndCardWithDelay());
        
        IEnumerator EnableEndCardWithDelay()
        {
            yield return new WaitForSeconds(.8f);
            
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
