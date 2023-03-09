using UnityEngine.SceneManagement;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public InputSwipeManager swipeManager;

    public PlayerController player;

    private Vector3 desiredPosition;

    public float changeDir;

    [SerializeField] WheelTrails trailRenderer;

    GameManager gameManager;



    // Start is called before the first frame update
    void Start()
    {
        //start pos player
        desiredPosition = player.transform.position;
        GameObject gameManagerAsGameobject = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = gameManagerAsGameobject.GetComponent<GameManager>();
    }
    void Update()
    {
        if (swipeManager.SwipeLeft)
        {
            if (desiredPosition.x > -2)
            {
                desiredPosition += Vector3.left * changeDir;
                trailRenderer.turning = true;
                trailRenderer.resetTimer = 0.4f;
            }
        }
        if (swipeManager.SwipeRight)
        {
            if (desiredPosition.x < 2)
            {
                desiredPosition += Vector3.right * changeDir;
                trailRenderer.turning = true;
                trailRenderer.resetTimer = 0.4f;
            }
        }

        /*
        if (swipeManager.SwipeUp)
        {
            if (desiredPosition.y < 9)
            {
                desiredPosition += Vector3.up * changeDir;
            }
        }
        if (swipeManager.SwipeDown)
        {
            if (desiredPosition.y > 0)
            {
                desiredPosition += Vector3.down * changeDir;
            }
        }
        */

        // go faster after time
       

        if (gameManager.currentGameState == GameManager.GameState.LevelRunning)
        {
            if (player.playerSpeed < 30)
            {
                player.playerSpeed += 0.001f;
            }

            desiredPosition.y = player.transform.position.y + changeDir;

            player.transform.position = Vector3.MoveTowards(player.transform.position, desiredPosition, player.playerSpeed * Time.deltaTime);

        }

        if (gameManager.currentGameState == GameManager.GameState.GameOver)
        {
            if (swipeManager.SwipeLeft || swipeManager.SwipeRight)
            {  //todo after seconds
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        else if (gameManager.currentGameState == GameManager.GameState.GetReady)
        {
            if (swipeManager.SwipeLeft || swipeManager.SwipeRight)
            {
                gameManager.currentGameState = GameManager.GameState.LevelRunning;
            }
        }
    }
}
