using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using GameAnalyticsSDK;

public class MenuController : MonoBehaviour
{

    [SerializeField] private Button levelSelectButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private Button exitButton;

    [SerializeField] private PopupController levelSelectPopup;
    [SerializeField] private PopupController optionsPopup;
    [SerializeField] private PopupController creditsPopup;

    void Start()
    {
        #region Assertions
        Assert.IsNotNull(levelSelectButton);
        Assert.IsNotNull(optionsButton);
        Assert.IsNotNull(creditsButton);
        Assert.IsNotNull(exitButton);
        Assert.IsNotNull(levelSelectPopup);
        Assert.IsNotNull(optionsPopup);
        Assert.IsNotNull(creditsPopup);
        #endregion

        levelSelectButton.onClick.AddListener(GoToLevelSelect);
        optionsButton.onClick.AddListener(GoToOptions);
        creditsButton.onClick.AddListener(GoToCredits);
        exitButton.onClick.AddListener(() => Application.Quit());
    }


    void GoToLevelSelect()
    {
        GameAnalytics.NewDesignEvent(Config.GoToLevelSelect);
        levelSelectPopup.ShowPopup();
    }

    void GoToCredits()
    {
        GameAnalytics.NewDesignEvent(Config.GoToCredits);
        creditsPopup.ShowPopup();
    }

    void GoToOptions()
    {
        GameAnalytics.NewDesignEvent(Config.GoToOptions);
        optionsPopup.ShowPopup();
    }



}
