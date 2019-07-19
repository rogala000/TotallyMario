using UnityEngine;
using UnityEngine.Assertions;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private GameObject levelLoaderGameObject;

    private SceneController sceneController;

    private void Start()
    {
        sceneController = FindObjectOfType<SceneController>();

        #region Assertions
        Assert.IsNotNull(levelLoaderGameObject);
        Assert.IsNotNull(sceneController);
        #endregion

    }

    public void LoadLevel(int id)
    {
        string levelName = Config.LevelScene + id.ToString();
        levelLoaderGameObject.SetActive(true);
        sceneController.LoadScene(levelName);
    }
}
