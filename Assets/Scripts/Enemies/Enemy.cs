using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float impactForce = 1f;
    [SerializeField] Transform startRoute;
    [SerializeField] Transform endRoute;
    private SpriteRenderer spriteRenderer;

    public float speed = 1.0f;
    private bool dirRight = true;

    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if (dirRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            spriteRenderer.flipX = false;
        }
        else
        {
            transform.Translate(-Vector2.right * speed * Time.deltaTime);
            spriteRenderer.flipX = true;
        }

        if (transform.position.x >= endRoute.position.x)
        {
            dirRight = false;
        }

        if (transform.position.x <= startRoute.position.x)
        {
            dirRight = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Rigidbody2D rigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            rigidbody.AddForce(new Vector2(0, impactForce), ForceMode2D.Impulse);
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.GetHit();
        }
        else if (collision.gameObject.tag == "Weapon")
        {
            Destroy(this.gameObject);
        }
    }




}
