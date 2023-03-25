using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    float speed;

    GameManager gameManager;

    float elapsedTime = 1f;

    float lastPlayerPos;

    bool changePos;

    private void Start()
    {
        GameObject gameManagerAsGameobject = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = gameManagerAsGameobject.GetComponent<GameManager>();
    }

    private void Update()
    {
        speed = gameManager.playerSpeed;

        // Calculate direction from enemy to player
        Vector3 direction = player.position - transform.position;
        direction.Normalize();

        // Move towards player in the Y direction
        float calculatedSpeed = speed - 4 * Time.deltaTime;

       

        if (player.position.x != lastPlayerPos)
        {
            elapsedTime -= Time.deltaTime;

            changePos = true;
        }

        if (changePos)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, player.position.y - 5, transform.position.z), calculatedSpeed);
            elapsedTime = 1;

            lastPlayerPos = player.position.x;

            changePos = false;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, player.position.y - 5, transform.position.z), calculatedSpeed);
        }
       
    }
}
