using UnityEngine;

public class CarObstacleMovement : MonoBehaviour
{

    [SerializeField] GameObject startPos;

    [SerializeField] float speed;

    public Rigidbody2D car;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        //reset pos
        car.position = startPos.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        car.velocity = transform.up * speed * Time.deltaTime;
    }
}
