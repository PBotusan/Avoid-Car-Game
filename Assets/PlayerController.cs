using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    GameManager gameManager;

    public Rigidbody2D playerRigidbody;

    public float playerSpeed = 10f;

    private void Start()
    {
        GameObject gameManagerAsGameobject = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = gameManagerAsGameobject.GetComponent<GameManager>();
    }


    private void FixedUpdate()
    {
        /*
        if (gameManager.currentGameState == GameManager.GameState.LevelRunning)
        {
            playerRigidbody.velocity = transform.forward * playerSpeed * Time.deltaTime;
        }*/



        if (gameManager.currentGameState == GameManager.GameState.GameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }


}
