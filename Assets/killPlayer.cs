using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killPlayer : MonoBehaviour
{

    GameManager gameManager;

    private void Start()
    {
        GameObject gameManagerAsGameobject = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = gameManagerAsGameobject.GetComponent<GameManager>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameManager.currentGameState = GameManager.GameState.GameOver;
        }
    }
}
