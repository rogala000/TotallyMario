using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour
{
    private PlayerHealth playerHealth;
    int remainingLives;
    int maxLives;
    SceneController sceneController;

    [SerializeField] Button tryAgainButton;
    [SerializeField] Button continueButton;
    [SerializeField] List<Image> stars;
    [SerializeField] Color32 unlockedStarColor;
    [SerializeField] Color32 lockedStarColor;
    [SerializeField] LoadingBar loadingSlider;
    [SerializeField] GameObject screenView;
    [SerializeField] GameObject loadingView;

    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        sceneController = FindObjectOfType<SceneController>();
        continueButton.onClick.AddListener(Continue);
        tryAgainButton.onClick.AddListener(Restart);
        screenView.SetActive(false);
        loadingView.SetActive(false);
    }


    public void WinGame()
    {
        remainingLives = playerHealth.RemainingLives;
        maxLives = playerHealth.MaxLives;

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
        loadingView.SetActive(true);
        sceneController.LoadScene(SceneManager.GetActiveScene().name, loadingSlider);
    }

    private void Continue()
    {
        loadingView.SetActive(true);
        PlayerPrefsLevels.SaveLevel(SceneManager.GetActiveScene().name, remainingLives);
        sceneController.LoadScene(Config.MainScene, loadingSlider);
    }




}
