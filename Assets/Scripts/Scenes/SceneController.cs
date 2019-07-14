using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{

    public void LoadScene(string sceneName, LoadingBar slider)
    {
        StartCoroutine(LoadNewScene(sceneName, slider));
    }



    IEnumerator LoadNewScene(string sceneName, LoadingBar sliderBar)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        while (!async.isDone)
        {
            float progress = Mathf.Clamp01(async.progress / 1f);
            sliderBar.SetValue(progress);
            yield return null;

        }

    }

}
