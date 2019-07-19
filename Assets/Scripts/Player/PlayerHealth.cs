using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Assertions;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] private int maxLives = 3;
    [SerializeField] private int iFrames = 30;

    private List<GameObject> hearts;
    private PlayerController playerController;
    private PlayerControlsCanvas playerControlsCanvas;
    private AudioSource audioSource;

    private int remainingLives = 3;
    private int currentFrames = 0;
    private bool canGetHit = true;

    public int RemainingLives { get => remainingLives;}
    public int MaxLives { get => maxLives;}

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerControlsCanvas = FindObjectOfType<PlayerControlsCanvas>();
        hearts = playerControlsCanvas.Hearts;
        playerController = GetComponent<PlayerController>();

        #region Assertions
        Assert.IsNotNull(hearts);
        Assert.IsNotNull(audioSource);
        Assert.IsNotNull(playerControlsCanvas);
        Assert.IsNotNull(hearts);
        Assert.IsNotNull(playerController);
        #endregion

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
        if(!canGetHit || (remainingLives == 0))
        {
            return;
        }

        remainingLives-=1;
        audioSource.Play();
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
