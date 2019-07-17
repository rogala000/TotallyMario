using UnityEngine;

public class Audio : MonoBehaviour
{
    private AudioListener listener;

    void Start()
    {
        listener = FindObjectOfType<AudioListener>();

        int sound = PlayerPrefs.GetInt(Config.sounds);
        if (sound == 1)
        {
            listener.enabled = false;
        }
        else
        {
            listener.enabled = true;
        }
    }


}
