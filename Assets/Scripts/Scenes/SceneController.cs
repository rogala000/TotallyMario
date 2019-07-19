using GameAnalyticsSDK;
using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private LoadingBar slider;
    [SerializeField] private GameObject sliderView;

    private void Start()
    {
        #region Assertions
        Assert.IsNotNull(slider);
        Assert.IsNotNull(sliderView);
        #endregion

        DontDestroyOnLoad(this);
        sliderView.SetActive(false);
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadNewScene(sceneName));
        GameAnalytics.NewDesignEvent(Config.LevelStarted + sceneName);
    }



    IEnumerator LoadNewScene(string sceneName)
    {
        sliderView.SetActive(true);
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        while (!async.isDone)
        {
            float progress = Mathf.Clamp01(async.progress / 1f);
            slider.SetValue(progress);
            yield return null;

        }
        sliderView.SetActive(false);
    }

}
