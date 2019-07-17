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


    #region animation 
    public static readonly string Jump = "Jump";
    public static readonly string JumpLoop = "JumpLoop";
    public static readonly string Attack = "Attack";
    public static readonly string Run = "Run";
    public static readonly string Die = "Die";
    public static readonly string Idle = "Idle";
    public static readonly string Fall = "Fall";
    public static readonly string GetHit = "GetHit";
    public static readonly string IsDead = "IsDead";
    public static readonly string Goal = "ReachGoal";
    #endregion

    public static readonly string level = "Level";
    public static readonly string sounds = "sounds";

}
