using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
    [Header("Music")]
    public AudioSource audioSource;
    public AudioSource main;
    [SerializeField] public AudioClip levelMusic;

    private void OnTriggerEnter2D(Collider2D other)
    {
        main.Stop();
        audioSource.PlayOneShot(levelMusic);
    }
}
