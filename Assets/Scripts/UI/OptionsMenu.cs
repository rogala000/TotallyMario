using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] Button soundButton;
    [SerializeField] GameObject checkmark;
    [SerializeField] Button clearDataButton;

    private AudioListener listener;
    private bool soundsOff;

    void Start()
    {
        listener = FindObjectOfType<AudioListener>();
        CheckSounds();
        clearDataButton.onClick.AddListener(ClearData);
        soundButton.onClick.AddListener(ChangeSound);

    }

    private void ClearData()
    {
        PlayerPrefs.DeleteAll();
        CheckSounds();
    }

    private void CheckSounds()
    {
        int sound = PlayerPrefs.GetInt(Config.sounds);
        if (sound == 1)
        {
            soundsOff = true;
        }
        else
        {
            soundsOff = false;
        }

        if (soundsOff)
        {
            listener.enabled = false;
            checkmark.SetActive(false);
        }
        else
        {
            listener.enabled = true;
            checkmark.SetActive(true);
        }

    }

    private void ChangeSound()
    {
        if(soundsOff)
        {
            PlayerPrefs.SetInt(Config.sounds, 0);
        }
        else
        {
            PlayerPrefs.SetInt(Config.sounds, 1);
        }

        CheckSounds();
    }

}
