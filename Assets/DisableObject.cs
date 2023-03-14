using UnityEngine;

public class DisableObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
