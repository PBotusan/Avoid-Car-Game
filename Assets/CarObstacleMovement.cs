using UnityEngine;

public class CarObstacleMovement : MonoBehaviour
{

    [SerializeField] GameObject startPos;

    [SerializeField] float speed;

    public Rigidbody2D car;


    GameManager gameManager;


    float forceMagnitude = 0.1f;

    public float duration = 1f;
    private float timeLeft = 0f;


    // Start is called before the first frame update
    void Start()
    {
        GameObject gamemanagerAsGameobject = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = gamemanagerAsGameobject.GetComponent<GameManager>();

        timeLeft = duration;
    }

    private void OnEnable()
    {
        //reset pos
        car.position = startPos.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.currentGameState == GameManager.GameState.GameOver)
        {
            car.velocity = transform.up * 0 * Time.deltaTime;
            //todo make the car crash
            /*
            if (timeLeft > 0f)
            {
                car.AddForce(-Vector2.up * forceMagnitude, ForceMode2D.Impulse);
                timeLeft -= Time.deltaTime;
            }
            else
            {
                car.velocity -= Vector2.zero;
            }*/
        }
        else
        {
            car.velocity = transform.up * speed * Time.deltaTime;
        }
    }
}
