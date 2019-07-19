using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class ButtonSounds : MonoBehaviour
{
    private Button button;
    private AudioSource audio;


    void Start()
    {
        button = GetComponent<Button>();
        audio = GetComponent<AudioSource>();

        #region Assertions
        Assert.IsNotNull(button);
        Assert.IsNotNull(audio);
        #endregion

        button.onClick.AddListener(PlaySound);
    }

    void PlaySound()
    {
        audio.Play();
    }

}
