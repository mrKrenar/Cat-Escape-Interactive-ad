using DG.Tweening;
using UnityEngine;

public class StopPatrolingOnGameOver : MonoBehaviour
{
    [SerializeField] private DOTweenPath tweenPath;
    private void Awake()
    {
        GameState.OnGameStateChanged += GameState_OnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameState.OnGameStateChanged -= GameState_OnGameStateChanged;
    }

    private void GameState_OnGameStateChanged(StateOfGame stateOfGame)
    {
        if (stateOfGame == StateOfGame.lost || stateOfGame == StateOfGame.won)
        {
            tweenPath.DOPause();
        }
    }
}
