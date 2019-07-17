using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions;

public class PlayerHealth : MonoBehaviour
{
    List<GameObject> hearts;
    private int remainingLives = 3;
    [SerializeField] private int maxLives = 3;
    private PlayerController playerController;
    [SerializeField] int iFrames = 30;
    private int currentFrames = 0;
    private bool canGetHit = true;
    private PlayerControlsCanvas playerControlsCanvas;
    public int RemainingLives { get => remainingLives;}
    public int MaxLives { get => maxLives;}

    void Start()
    {
        playerControlsCanvas = FindObjectOfType<PlayerControlsCanvas>();
        hearts = playerControlsCanvas.Hearts;
        playerController = GetComponent<PlayerController>();
        Assert.IsNotNull(hearts);
        remainingLives = maxLives;
        SetLives(remainingLives);
        currentFrames = 0;
    }

    private void Update()
    {
        if(canGetHit == false)
        {
            currentFrames++;
        }
        if (currentFrames == iFrames)
        {
            canGetHit = true;
            currentFrames = 0;
        }
    }

    public void GetHit()
    {
        if(!canGetHit)
        {
            return;
        }

        remainingLives-=1;
        if(remainingLives == 0)
        {
            Die();
        }
        SetLives(remainingLives);
        canGetHit = false;
    }

    private void Die()
    {
        playerController.Die();
    }

    private void SetLives(int remainingLives)
    {
        for (int i = 0; i < maxLives; i++)
        {
            if(remainingLives > i)
            {
                hearts[i].SetActive(true);
            }
            else
            {
                hearts[i].SetActive(false);
            }

        }

    }

}
