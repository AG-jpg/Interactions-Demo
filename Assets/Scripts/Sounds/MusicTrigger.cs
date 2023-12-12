using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
    [SerializeField] private SoundManager sm;

    [Header("Music")]
    public AudioSource audioSource;
    [SerializeField] public AudioClip levelMusic;

    private void OnTriggerEnter(Collider other)
    {
        sm.stopMusic();
        audioSource.PlayOneShot(levelMusic);
    }
}
