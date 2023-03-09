using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGameStates : MonoBehaviour
{
    [SerializeField] GameObject startGameCanvas;
    [SerializeField] GameObject GameOverCanvas;
    [SerializeField] GameObject score;

    GameManager gameManager;


    private void Start()
    {
        GameObject gamemanagerAsGameobject = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = gamemanagerAsGameobject.GetComponent<GameManager>();
    }


    private void Update()
    {
        if (gameManager.currentGameState == GameManager.GameState.GetReady)
        {
            score.SetActive(false);
            startGameCanvas.SetActive(true);
            GameOverCanvas.SetActive(false);
        }

        if (gameManager.currentGameState == GameManager.GameState.LevelRunning)
        {
            score.SetActive(true);
            startGameCanvas.SetActive(false);
            GameOverCanvas.SetActive(false);
        }

        if (gameManager.currentGameState == GameManager.GameState.GameOver)
        {
            startGameCanvas.SetActive(false);
            GameOverCanvas.SetActive(true);
        }
    }
}
