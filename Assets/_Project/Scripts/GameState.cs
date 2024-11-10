using System;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static StateOfGame StateOfGame = StateOfGame.playing;
    public static event Action<StateOfGame> OnGameStateChanged;
    
    public static void UserCaught()
    {
        if (StateOfGame == StateOfGame.lost) return;

        SetGameState(StateOfGame.lost);
    }
    
    
    public static void UserWon()
    {
        if (StateOfGame == StateOfGame.won) return;
        
        SetGameState(StateOfGame.won);
    }

    static void SetGameState(StateOfGame gameState)
    {
        StateOfGame = gameState;
        OnGameStateChanged?.Invoke(gameState);
    }
}

public enum StateOfGame{playing, won, lost}
