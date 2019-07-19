using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class InGameOptions : MonoBehaviour
{
    [SerializeField] Button returnButton;
    [SerializeField] Button exitButton;
    [SerializeField] GameObject optionsView;
    private SceneController sceneController;

    void Start()
    {
        sceneController = FindObjectOfType<SceneController>();

        #region Assertions
        Assert.IsNotNull(returnButton);
        Assert.IsNotNull(exitButton);
        Assert.IsNotNull(optionsView);
        Assert.IsNotNull(sceneController);
        #endregion

        returnButton.onClick.AddListener(Return);
        exitButton.onClick.AddListener(Quit);

        optionsView.SetActive(false);
    }


    public void GoToOptions()
    {
        Time.timeScale = 0;
        optionsView.SetActive(true);
    }

    public void Quit()
    {
        Time.timeScale = 1;
        sceneController.LoadScene(Config.MainScene);
    }

    public void Return()
    {
        Time.timeScale = 1;
        optionsView.SetActive(false);
    }

}
