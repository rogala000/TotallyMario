using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private Button soundButton;
    [SerializeField] private GameObject checkmark;
    [SerializeField] private Button clearDataButton;

    private AudioListener listener;
    private bool soundsOff;

    void Start()
    {
        listener = FindObjectOfType<AudioListener>();

        #region Assertions
        Assert.IsNotNull(listener);
        Assert.IsNotNull(soundButton);
        Assert.IsNotNull(checkmark);
        Assert.IsNotNull(clearDataButton);
        #endregion

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
            if (Application.platform == RuntimePlatform.Android)
            {
                AudioListener.volume = 0;
            }
            listener.enabled = false;
            checkmark.SetActive(false);
        }
        else
        {
            listener.enabled = true;
            checkmark.SetActive(true);
            if (Application.platform == RuntimePlatform.Android)
            {
                AudioListener.volume = 1;
            }
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
