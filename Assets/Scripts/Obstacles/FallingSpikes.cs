using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpikes : MonoBehaviour
{

    [SerializeField] Transform spikesTransform;
    bool isTrapTriggered = false;
    [SerializeField] private float speed = 0.3f;
    

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
