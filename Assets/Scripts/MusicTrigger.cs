using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
    [Header("Sources")]
    public AudioSource audioSource;
    public AudioSource prevLevel;
    public AudioSource mainSource;

    [Header("Music")]
    [SerializeField] public AudioClip levelMusic;

    private void OnTriggerEnter2D(Collider2D other)
    {
        SoundManager.Instance.ShutMain();
        mainSource.Stop();
        prevLevel.Stop();
        audioSource.PlayOneShot(levelMusic);
    }
}
