using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    // this script manages the sound effects and music

    [SerializeField] AudioSource sfxSource;
    [SerializeField] AudioSource musicSource;

    public float sfxVolume;
    public float musicVolume;
    private float fadeDuration = 10f;

    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider musicSlider;

    [SerializeField] private AudioClip mouseClick;
    [SerializeField] private AudioClip notificationSound;

    [SerializeField] private AudioClip phase1;
    [SerializeField] private AudioClip phase2;
    [SerializeField] private AudioClip phase3;

    void Awake()
    {
        sfxVolume = 0.5f;
        musicVolume = 0.5f;
    }

    void Start()
    {
        PlayMusicPhase1();
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
        sfxSource.PlayOneShot(mouseClick, sfxVolume);
    }

    public void PlayNotificationSound()
    {
        sfxSource.PlayOneShot(notificationSound, sfxVolume);
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void PlayMusicPhase1()
    {
        musicSource.clip = phase1;
        StartCoroutine(FadeIn(musicSource, fadeDuration));
    }

    public void PlayMusicPhase2()
    {
        musicSource.clip = phase2;
        StartCoroutine(FadeIn(musicSource, fadeDuration));
    }

    public void PlayMusicPhase3()
    {
        musicSource.clip = phase3;
        StartCoroutine(FadeIn(musicSource, fadeDuration));
    }

    public void FadeOutMusic()
    {
        StartCoroutine(FadeOut(musicSource, fadeDuration));
    }

    IEnumerator FadeIn(AudioSource musicSource, float fadeDuration)
    {
        musicSource.Play();
        musicSource.volume = 0f;
        while (musicSource.volume < musicVolume)
        {
            musicSource.volume += Time.deltaTime / fadeDuration;
            print(musicSource.volume);
            yield return null;
        }
    }

    IEnumerator FadeOut(AudioSource musicSource, float fadeDuration)
    {
        musicSource.volume = musicVolume;
        while (musicSource.volume > 0)
        {
            musicSource.volume -= Time.deltaTime / fadeDuration;
            //print(musicSource.volume);
            yield return null;
        }
    }
}
