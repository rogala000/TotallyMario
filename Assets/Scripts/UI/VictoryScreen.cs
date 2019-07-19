using GameAnalyticsSDK;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class VictoryScreen : MonoBehaviour
{ 
    [SerializeField] private Button tryAgainButton;
    [SerializeField] private Button continueButton;
    [SerializeField] private List<Image> stars;
    [SerializeField] private Color32 unlockedStarColor;
    [SerializeField] private Color32 lockedStarColor;
    [SerializeField] private GameObject screenView;

    private PlayerHealth playerHealth;
    private int remainingLives;
    private int maxLives;
    private AudioSource audioSource;
    private SceneController sceneController;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerHealth = FindObjectOfType<PlayerHealth>();
        sceneController = FindObjectOfType<SceneController>();

        #region Assertions
        Assert.IsNotNull(audioSource);
        Assert.IsNotNull(playerHealth);
        Assert.IsNotNull(sceneController);
        Assert.IsNotNull(tryAgainButton);
        Assert.IsNotNull(continueButton);
        Assert.IsNotNull(stars);
        Assert.IsNotNull(screenView);
        #endregion

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
