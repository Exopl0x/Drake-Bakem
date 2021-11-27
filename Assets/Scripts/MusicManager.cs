using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource[] musics;
    public AudioClip intro;

    void Awake()
    {
        musics = gameObject.GetComponents<AudioSource>();
        StartCoroutine(PlayMusic());
    }

    IEnumerator PlayMusic()
    {
        // 1 second buffer time for the loop to start
        yield return new WaitForSecondsRealtime(1.0f);

        // Halts Coroutine until the intro is done playing, then plays the loop.
        yield return new WaitUntil(() => !musics[1].isPlaying);
        musics[0].Play();

        yield return null;
    }
}
