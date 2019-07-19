using UnityEngine;
using UnityEngine.Assertions;

public class Fall : MonoBehaviour
{

    [SerializeField] private Transform respawnPosition;

    private void Start()
    {
        #region Assertions
        Assert.IsNotNull(respawnPosition);
        #endregion
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = respawnPosition.position;
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.GetHit();
        }
    }
}
