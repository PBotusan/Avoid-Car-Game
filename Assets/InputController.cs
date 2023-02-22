using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public InputSwipeManager swipeManager;

    public PlayerController player;

    private Vector3 desiredPosition;

    public int changeDir;



    // Start is called before the first frame update
    void Start()
    {
        //start pos player
        desiredPosition = player.transform.position;
    }
    void Update()
    {
        if (swipeManager.SwipeLeft)
        {
            if (desiredPosition.x > -3)
            {
                desiredPosition += Vector3.left * changeDir;
            }
        }
        if (swipeManager.SwipeRight)
        {
            if (desiredPosition.x < 3)
            {
                desiredPosition += Vector3.right * changeDir;
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

        desiredPosition.y = player.transform.position.y + changeDir;

        player.transform.position = Vector3.MoveTowards(player.transform.position, desiredPosition, 15f * Time.deltaTime);

    }
}
