using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource[] musics;
    public GameObject deathCanvas;
    private bool notDead = true;

    void Awake()
    {
        musics = gameObject.GetComponents<AudioSource>();
        deathCanvas = GameObject.Find("DeathCanvas");
        StartCoroutine(PlayMusic());
    }

    void Update()
    {
        if (notDead && deathCanvas.activeSelf)
        {
            StartCoroutine(DeathMusic());
            notDead = false;
        }
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

    IEnumerator DeathMusic()
    {
        musics[0].Stop();
        musics[2].Play();
        Time.timeScale = 0.1f;
        yield return null;
    }
}
