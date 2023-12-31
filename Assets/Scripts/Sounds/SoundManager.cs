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

#endregion
}
