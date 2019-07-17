using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InGameOptions : MonoBehaviour
{
    [SerializeField] Button returnButton;
    [SerializeField] Button exitButton;
    [SerializeField] GameObject optionsView;
    private SceneController sceneController;

    void Start()
    {
        returnButton.onClick.AddListener(Return);
        exitButton.onClick.AddListener(Quit);
        sceneController = FindObjectOfType<SceneController>();
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
