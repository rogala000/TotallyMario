using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))] 
public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] List<AudioClip> songs;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
       // audioSource.loop = true;
        StartCoroutine(playFirstSong());
        DontDestroyOnLoad(this);
    }

    IEnumerator playFirstSong()
    {
        audioSource.clip = songs[0];
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        StartCoroutine(playRandomSong ());
    }


    IEnumerator playRandomSong()
    {
        audioSource.clip = songs[Random.Range(0, songs.Count)];
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        StartCoroutine(playRandomSong());

    }
}
