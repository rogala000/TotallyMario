using UnityEngine;

public class GameLoader : MonoBehaviour
{

    SceneController sceneController;

    void Start()
    {
        sceneController = FindObjectOfType<SceneController>();
        GameAnalyticsSDK.GameAnalytics.Initialize();
        sceneController.LoadScene(Config.MainScene);
    }

}
