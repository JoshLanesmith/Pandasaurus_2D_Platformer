using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    public static float musicVolume, sfxVolume;

    private const string MUSIC_VOLUME = "MusicVolume";
    private const string SFX_VOLUME = "SFXVolume";
    private const string MUSIC_MUTE = "musicMute";
    private const string SFX_MUTE = "sfxMute";

    int sceneIndex;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            InitializeVolumes();
        }
        else
        {
            Destroy(gameObject);
        }


        if (PlayerPrefs.HasKey(MUSIC_VOLUME) && PlayerPrefs.HasKey(SFX_VOLUME))
        {
            musicVolume = PlayerPrefs.GetFloat(MUSIC_VOLUME);
            sfxVolume = PlayerPrefs.GetFloat(SFX_VOLUME);
        }

        if (PlayerPrefs.HasKey(MUSIC_MUTE))
        {
            musicSource.mute = true;
        }

        if (PlayerPrefs.HasKey(SFX_MUTE))
        {
            sfxSource.mute = false;
        }
    }

    private void InitializeVolumes()
    {
        musicVolume = 1f;
        PlayerPrefs.SetFloat(MUSIC_VOLUME, musicVolume);

        sfxVolume = 1f;
        PlayerPrefs.SetFloat(SFX_VOLUME, sfxVolume);

        musicSource.mute = false;
        PlayerPrefs.DeleteKey(MUSIC_MUTE);

        sfxSource.mute = false;
        PlayerPrefs.DeleteKey(SFX_MUTE);
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        PlayMusic("Background");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        return;
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
        if (musicSource.mute)
        {
            PlayerPrefs.SetFloat(MUSIC_VOLUME, 0f);
            PlayerPrefs.SetFloat(MUSIC_MUTE, 0f);
        }
        else
        {
            PlayerPrefs.SetFloat(MUSIC_VOLUME, 1f);
            PlayerPrefs.DeleteKey(MUSIC_MUTE);
        }
    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
        if (sfxSource.mute)
        {
            PlayerPrefs.SetFloat(SFX_VOLUME, 0f);
        }
        else
        {
            PlayerPrefs.SetFloat(SFX_VOLUME, 1f);
            PlayerPrefs.DeleteKey(SFX_VOLUME);
        }
    }

    public void MusicVolume(float volume)
    {
        musicVolume = volume;
        musicSource.volume = musicVolume;

        PlayerPrefs.SetFloat(MUSIC_VOLUME, musicVolume);
    }

    public void SFXVolume(float volume)
    {
        sfxVolume = volume;
        sfxSource.volume = sfxVolume;

        PlayerPrefs.SetFloat(SFX_VOLUME, sfxVolume);
    }
}
