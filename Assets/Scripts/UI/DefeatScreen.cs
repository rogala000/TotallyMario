using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DefeatScreen : MonoBehaviour
{

    SceneController sceneController;

    [SerializeField] Button tryAgainButton;
    [SerializeField] Button continueButton;
    [SerializeField] LoadingBar loadingSlider;
    [SerializeField] GameObject screenView;
    [SerializeField] GameObject loadingView;

    private void Start()
    {
        sceneController = FindObjectOfType<SceneController>();
        continueButton.onClick.AddListener(Continue);
        tryAgainButton.onClick.AddListener(Restart);
        screenView.SetActive(false);
        loadingView.SetActive(false);
    }


    public void Defeat()
    {
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
        sceneController.LoadScene(Config.MainScene, loadingSlider);
    }
}
