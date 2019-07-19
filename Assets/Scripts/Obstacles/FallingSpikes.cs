using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;

public class FallingSpikes : MonoBehaviour
{

    [SerializeField] private Transform spikesTransform;
    [SerializeField] private float speed = 0.3f;

    bool isTrapTriggered = false;

    private void Start()
    {
        #region Assertions
        Assert.IsNotNull(spikesTransform);
        #endregion
    }

    void Update()
    {
        if(isTrapTriggered)
        {
            spikesTransform.Translate(Vector3.down * speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isTrapTriggered = true;
        StartCoroutine(DisableTrap());
    }

    IEnumerator DisableTrap()
    {
        yield return new WaitForSeconds(5);
        isTrapTriggered = false;
    }
}
