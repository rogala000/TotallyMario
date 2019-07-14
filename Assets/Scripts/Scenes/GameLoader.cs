using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameLoader : MonoBehaviour
{

    [SerializeField] LoadingBar loadingBar;
    [SerializeField] SceneController sceneController;
    // Start is called before the first frame update
    void Start()
    {
        Assert.IsNotNull(loadingBar);
        Assert.IsNotNull(sceneController);

        sceneController.LoadScene(Config.MainScene, loadingBar);
    }

}
