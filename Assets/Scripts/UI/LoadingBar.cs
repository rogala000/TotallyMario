using UnityEngine;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    void Start()
    {
        slider.value = 0;
    }

    public void SetValue(float value)
    {
        slider.value = value;
    }
}
