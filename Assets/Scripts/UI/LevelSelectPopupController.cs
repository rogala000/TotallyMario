using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class LevelSelectPopupController : MonoBehaviour
{

    [SerializeField] List<LevelButtonView> levelButtons;
    [SerializeField] LevelLoader levelLoader;
    void Start()
    {
        Assert.IsNotNull(levelLoader);
        Assert.IsNotNull(levelButtons);

        for (int i = 0; i < levelButtons.Count; i++)
        {
            int level = i+1;
            levelButtons[i].Button.onClick.AddListener(() => LoadLevel(level));

            levelButtons[i].LevelNumber.SetText(Config.level + " " + level);
        }
    }

    private void OnEnable()
    {
        int stars = 0;
        for (int i = 0; i < levelButtons.Count; i++)
        {
            int levelNumber = i + 1;
            string levelName = Config.LevelScene + levelNumber.ToString();
            stars = PlayerPrefsLevels.GetLevelStars(levelName);
            ShowLevelStars(levelButtons[i], stars);
        }

    }

    void LoadLevel(int levelID)
    {
        levelLoader.LoadLevel(levelID);
    }


    void ShowLevelStars(LevelButtonView button, int number)
    {
        for(int i = 0; i < button.Stars.Count; i ++)
        {
            if (i < number)
            {
                button.Stars[i].SetActive(true);
            } else
            {
                button.Stars[i].SetActive(false);
            }
        }
    }

}
