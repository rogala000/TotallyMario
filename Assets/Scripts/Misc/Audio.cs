using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(AudioSource))]
public class Audio : MonoBehaviour
{
    private AudioListener listener;

    void Start()
    {
        listener = FindObjectOfType<AudioListener>();
        Assert.IsNotNull(listener);
        int sound = PlayerPrefs.GetInt(Config.sounds);
        if (sound == 1)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                AudioListener.volume = 0;
            }
            listener.enabled = false;
        }
        else
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                AudioListener.volume = 1;
            }
            listener.enabled = true;
        }
    }


}
