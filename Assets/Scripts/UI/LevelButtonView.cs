using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class LevelButtonView : MonoBehaviour
{

    [SerializeField] private Button button;
    [SerializeField] private List<GameObject> stars;
    [SerializeField] private TextMeshProUGUI levelNumber;

    public Button Button { get => button;}
    public List<GameObject> Stars { get => stars;}
    public TextMeshProUGUI LevelNumber { get => levelNumber; }

    private void Start()
    {
        #region Assertions
        Assert.IsNotNull(button);
        Assert.IsNotNull(stars);
        Assert.IsNotNull(levelNumber);
        #endregion

    }
}
