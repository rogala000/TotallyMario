using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config
{
    #region scenes
    public static readonly string StartupScene = "Startup";
    public static readonly string MainScene = "Main";
    public static readonly string LevelScene = "Level_";
    #endregion

    #region GA Events
    public static readonly string GoToLevelSelect = "GoToLevelSelect";
    public static readonly string GoToOptions = "GoToOptions";
    public static readonly string GoToCredits = "GoToCredits";
    public static readonly string AppExitMenu = "AppExitMenu";
    public static readonly string LevelStarted = "LevelStarted_";
    #endregion


    public static readonly string level = "Level";
}
