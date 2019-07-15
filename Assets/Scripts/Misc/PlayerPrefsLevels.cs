using UnityEngine;

public class PlayerPrefsLevels
{
    public static void SaveLevel(string levelName, int numberOfStars)
    {
        int oldStars = GetLevelStars(levelName);

        if(oldStars > numberOfStars)
        {
            return;
        }
        PlayerPrefs.SetInt(levelName, numberOfStars);
    }

    public static int GetLevelStars(string levelName)
    {
        int levelStars = PlayerPrefs.GetInt(levelName);
        return levelStars;
    }
}


