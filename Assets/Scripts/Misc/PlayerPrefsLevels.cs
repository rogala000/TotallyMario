using UnityEngine;

public class PlayerPrefsLevels
{
    public static void SaveLevel(int levelID, int numberOfStars)
    {
        string levelName = Config.LevelScene + levelID.ToString();
        PlayerPrefs.SetInt(levelName, numberOfStars);
    }

    public static int GetLevelStars(int levelID)
    {
        string levelName = Config.LevelScene + levelID.ToString();
        int levelStars = PlayerPrefs.GetInt(levelName);
        return levelStars;
    }
}


