using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class StopPatrolingOnLevelComplete : MonoBehaviour
{
    [SerializeField] private DOTweenPath tweenPath;
    [SerializeField] private Animator animator;
    
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
            tweenPath.enabled = false;
            animator.SetBool("bo_walk",false);
        }
    }
}
