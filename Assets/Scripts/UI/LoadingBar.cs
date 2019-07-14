using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    void Start()
    {
        Assert.IsNotNull(slider);
        slider.value = 0;
    }

    public void SetValue(float value)
    {
        slider.value = value;
    }
}
