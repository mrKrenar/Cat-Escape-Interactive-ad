using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class StopPatrolingOnLevelComplete : MonoBehaviour
{
    [SerializeField] private DOTweenPath tweenPath;
    [SerializeField] private Animator animator;
    
    private readonly int WalkBoolHash = Animator.StringToHash("bo_walk");

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
            animator.SetBool(WalkBoolHash,false);
        }
    }
}
