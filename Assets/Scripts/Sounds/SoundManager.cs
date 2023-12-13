using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;

    [Header ("Music")]
    [SerializeField] public AudioClip main;

    [Header ("Sound FX")]
    [SerializeField] public AudioClip notification;
    [SerializeField] public AudioClip error;
    [SerializeField] public AudioClip success;
    [SerializeField] public AudioClip purchase;
    [SerializeField] public AudioClip useitem;



    public void Notify()
    {
        audioSource.PlayOneShot(notification);
    }

    public void Success()
    {
        audioSource.PlayOneShot(success);
    }

    public void Purchase()
    {
        audioSource.PlayOneShot(purchase);
    }

    public void UseItem()
    {
        audioSource.PlayOneShot(useitem);
    }
}
