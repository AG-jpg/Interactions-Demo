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
    [SerializeField] public AudioClip button;

    [Header("Music")]
    [SerializeField] public AudioSource mainMusic;
    [SerializeField] public AudioClip neonGaming;
    [SerializeField] public AudioClip labMusic;

    #region Sound Effects
    public void ShutMain()
    {
        mainMusic.Stop();
    }

    public void PlayCity()
    {
        mainMusic.Stop();
        audioSource.PlayOneShot(neonGaming);
    }

    public void PlayLab()
    {
        mainMusic.Stop();
        audioSource.PlayOneShot(labMusic);
    }

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

    public void ButtonSound()
    {
        audioSource.PlayOneShot(button);
    }
    #endregion
}
