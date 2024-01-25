using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public AudioSource audioSource;

    [Header("Sound FX")]
    [SerializeField] public AudioClip notification;
    [SerializeField] public AudioClip error;
    [SerializeField] public AudioClip success;
    [SerializeField] public AudioClip purchase;
    [SerializeField] public AudioClip useitem;
    [SerializeField] public AudioClip openDoors;
    [SerializeField] public AudioClip readMessage;
    [SerializeField] public AudioClip saving;

#region Sound Effects
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

    public void OpenDoors()
    {
        audioSource.PlayOneShot(openDoors);
    }

    public void ReadMessage()
    {
        audioSource.PlayOneShot(readMessage);
    }

    public void Saving()
    {
        audioSource.PlayOneShot(saving);
    }

#endregion
}
