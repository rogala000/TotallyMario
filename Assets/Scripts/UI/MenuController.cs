using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Assertions;
using GameAnalyticsSDK;

public class MenuController : MonoBehaviour
{

    [SerializeField] Button levelSelectButton;
    [SerializeField] Button optionsButton;
    [SerializeField] Button creditsButton;
    [SerializeField] Button exitButton;

    [SerializeField] PopupController levelSelectPopup;
    [SerializeField] PopupController optionsPopup;
    [SerializeField] PopupController creditsPopup;

    // Use this for initialization
    void Start()
    {
        Assert.IsNotNull(levelSelectButton);
        Assert.IsNotNull(optionsButton);
        Assert.IsNotNull(creditsButton);
        Assert.IsNotNull(exitButton);
        Assert.IsNotNull(levelSelectPopup);
        Assert.IsNotNull(optionsPopup);
        Assert.IsNotNull(creditsPopup);

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
