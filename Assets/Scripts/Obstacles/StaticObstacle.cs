using UnityEngine;
using System.Collections;

public class StaticObstacle : MonoBehaviour
{

    [SerializeField] float impactForce = 1f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Rigidbody2D rigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            rigidbody.AddForce(new Vector2(0, impactForce), ForceMode2D.Impulse);
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.GetHit();
        }
    }
}
