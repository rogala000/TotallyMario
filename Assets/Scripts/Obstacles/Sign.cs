using UnityEngine;
using UnityEngine.Assertions;

public class Sign : MonoBehaviour
{
    [SerializeField] private GameObject message;

    private void Start()
    {
        #region Assertions
        Assert.IsNotNull(message);
        #endregion
        message.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            message.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            message.SetActive(false);
        }
    }
}
