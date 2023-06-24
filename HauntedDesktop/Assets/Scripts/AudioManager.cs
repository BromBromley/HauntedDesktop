using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;

    public float sfxVolume;
    public float musicVolume;

    [SerializeField] private AudioClip mouseClick;
    [SerializeField] private AudioClip notificationSound;

    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider musicSlider;

    void Awake()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();

        sfxVolume = 0.5f;
        musicVolume = 0.5f;
    }

    public void UpdateSFXVolume()
    {
        sfxVolume = sfxSlider.value;
    }

    public void UpdateMusicVolume()
    {
        musicVolume = musicSlider.value;
    }

    public void PlayMouseClick()
    {
        audioSource.PlayOneShot(mouseClick, sfxVolume);
    }

    public void PlayNotificationSound()
    {
        audioSource.PlayOneShot(notificationSound, sfxVolume);
    }
}
