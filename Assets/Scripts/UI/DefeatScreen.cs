using GameAnalyticsSDK;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DefeatScreen : MonoBehaviour
{

    SceneController sceneController;

    [SerializeField] Button tryAgainButton;
    [SerializeField] Button continueButton;
    [SerializeField] GameObject screenView;

    private void Start()
    {
        sceneController = FindObjectOfType<SceneController>();
        continueButton.onClick.AddListener(Continue);
        tryAgainButton.onClick.AddListener(Restart);
        screenView.SetActive(false);
    }


    public void Defeat()
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, SceneManager.GetActiveScene().name);
        screenView.SetActive(true);
    }


    private void Restart()
    {
        sceneController.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Continue()
    {
        sceneController.LoadScene(Config.MainScene);
    }
}
