using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class LevelButtonView : MonoBehaviour
{

    [SerializeField] Button button;
    [SerializeField] List<GameObject> stars;
    [SerializeField] TextMeshProUGUI levelNumber;

    public Button Button { get => button;}
    public List<GameObject> Stars { get => stars;}
    public TextMeshProUGUI LevelNumber { get => levelNumber; }

    private void Start()
    {
        Assert.IsNotNull(button);
        Assert.IsNotNull(stars);
        Assert.IsNotNull(levelNumber);

    }
}
