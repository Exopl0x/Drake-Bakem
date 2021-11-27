using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource[] musics;

    void Awake()
    {
        StartCoroutine(PlayMusic());
    }
    // Start is called before the first frame update
    void Start()
    {
        musics = gameObject.GetComponents<AudioSource>();
    }

    IEnumerator PlayMusic()
    {
        yield return new WaitForSecondsRealtime(3.34f);
        musics[0].Play();
        yield return null;
    }
}
