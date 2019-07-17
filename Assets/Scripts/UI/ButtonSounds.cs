using UnityEngine;
using UnityEngine.UI;

public class ButtonSounds : MonoBehaviour
{
    private Button button;
    private AudioSource audio;


    void Start()
    {
        button = GetComponent<Button>();
        audio = GetComponent<AudioSource>();
        button.onClick.AddListener(PlaySound);
    }

    void PlaySound()
    {
        audio.Play();
    }

}
