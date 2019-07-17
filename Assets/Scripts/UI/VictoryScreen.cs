using GameAnalyticsSDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class VictoryScreen : MonoBehaviour
{
    private PlayerHealth playerHealth;
    int remainingLives;
    int maxLives;
    private AudioSource audioSource;
    SceneController sceneController;

    [SerializeField] Button tryAgainButton;
    [SerializeField] Button continueButton;
    [SerializeField] List<Image> stars;
    [SerializeField] Color32 unlockedStarColor;
    [SerializeField] Color32 lockedStarColor;
    [SerializeField] GameObject screenView;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerHealth = FindObjectOfType<PlayerHealth>();
        sceneController = FindObjectOfType<SceneController>();
        continueButton.onClick.AddListener(Continue);
        tryAgainButton.onClick.AddListener(Restart);
        screenView.SetActive(false);
    }


    public void WinGame()
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, SceneManager.GetActiveScene().name);
        remainingLives = playerHealth.RemainingLives;
        maxLives = playerHealth.MaxLives;
        audioSource.Play();
        for (int i = 0; i < maxLives; i++)
        {
            if (remainingLives > i)
            {
                stars[i].color = unlockedStarColor;
            }
            else
            {
                stars[i].color = lockedStarColor;
            }

        }
        screenView.SetActive(true);
    }



    private void Restart()
    {
        sceneController.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Continue()
    {
        PlayerPrefsLevels.SaveLevel(SceneManager.GetActiveScene().name, remainingLives);
        sceneController.LoadScene(Config.MainScene);
    }
    
}
