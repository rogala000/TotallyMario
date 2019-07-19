using UnityEngine;
using UnityEngine.Assertions;


[RequireComponent(typeof(AudioSource))]
public class Enemy : MonoBehaviour
{

    [SerializeField] float impactForce = 1f;
    [SerializeField] Transform startRoute;
    [SerializeField] Transform endRoute;
    [SerializeField] private float speed = 1.0f;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Collider2D collider;
    private AudioSource audioSource;
    private bool dirRight = true;
    private bool isDead = false;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
        collider = GetComponentInChildren<Collider2D>();

        #region Assertions
        Assert.IsNotNull(startRoute);
        Assert.IsNotNull(endRoute);
        Assert.IsNotNull(spriteRenderer);
        Assert.IsNotNull(animator);
        Assert.IsNotNull(collider);
        Assert.IsNotNull(audioSource);
        #endregion
    }

    void Update()
    {
        if(isDead)
        {
            return;
        }

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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            audioSource.Play();
            collider.enabled = false;
            isDead = true;
            animator.SetTrigger("Die");
            Destroy(this.gameObject, 2);
        }
    }


}
