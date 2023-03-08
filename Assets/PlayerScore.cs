using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        GameObject gamemanagerAsGameobject = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = gamemanagerAsGameobject.GetComponent<GameManager>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.currentScore++;
        }
    }
}
