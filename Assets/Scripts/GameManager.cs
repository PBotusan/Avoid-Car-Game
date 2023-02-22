using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public enum GameState
    {
        FirstStartScreen,
        GetReady,
        LevelRunning,
        Paused,
        GameOver,
    }

    public GameState currentGameState;

    public float currentScore;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("GAMEMANAGER IS NULL");
            }

            return _instance;
        }
    }


    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        currentGameState = GameState.GetReady;
        currentScore = 0;
    }




}