using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] GameObject levelLoaderGameObject;
    [SerializeField] LoadingBar slider;
    [SerializeField] SceneController sceneController;

    private void Start()
    {
        Assert.IsNotNull(levelLoaderGameObject);
        Assert.IsNotNull(slider);
        Assert.IsNotNull(sceneController);

    }

    public void LoadLevel(int id)
    {
        string levelName = Config.LevelScene + id.ToString();
        levelLoaderGameObject.SetActive(true);
        sceneController.LoadScene(levelName, slider);
    }
}
