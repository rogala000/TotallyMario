using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpikes : MonoBehaviour
{

    [SerializeField] Transform spikesTransform;
    bool isTrapTriggered = false;
    [SerializeField] private int speed = 1;
    

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
    }
}
