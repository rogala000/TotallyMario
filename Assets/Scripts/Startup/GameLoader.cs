using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : MonoBehaviour
{

    [SerializeField] LoadingBar loadingBar;
    [SerializeField] SceneController sceneController;
    // Start is called before the first frame update
    void Start()
    {
        sceneController.LoadScene(Config.MainScene, loadingBar);
    }

}
