using UnityEngine;
using UnityEngine.Assertions;

public class GameLoader : MonoBehaviour
{

    private SceneController sceneController;

    void Start()
    {
        sceneController = FindObjectOfType<SceneController>();

        #region Assertions
        Assert.IsNotNull(sceneController);
        #endregion

        GameAnalyticsSDK.GameAnalytics.Initialize();
        sceneController.LoadScene(Config.MainScene);
    }

}
