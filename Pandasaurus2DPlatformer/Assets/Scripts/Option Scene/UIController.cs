using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider;

    private bool musicMuted;
    private bool sfxMuted;

    private void Start()
    {
        _musicSlider.value = AudioManager.musicVolume;
        _sfxSlider.value = AudioManager.sfxVolume;

        musicMuted = AudioManager.Instance.musicSource.mute;
        sfxMuted = AudioManager.Instance.sfxSource.mute;
    }

    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
        musicMuted = !musicMuted;

        if (musicMuted)
        {
            _musicSlider.value = 0;
        }
        else
        {
            _musicSlider.value = 1;
        }
    }

    public void ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX();
        sfxMuted = !sfxMuted;

        if (sfxMuted)
        {
            _sfxSlider.value = 0;
        }
        else
        {
            _sfxSlider.value = 1;
        }
    }

    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(_musicSlider.value);

        if(_musicSlider.value > 0.0f && musicMuted)
        {
            musicMuted = !musicMuted;
            AudioManager.Instance.ToggleMusic();
        }
    }

    public void SFXVolume()
    {
        AudioManager.Instance.SFXVolume(_sfxSlider.value);
        if (_sfxSlider.value > 0.0f && sfxMuted)
        {
            sfxMuted = !sfxMuted;
            AudioManager.Instance.ToggleSFX();
        }
    }
}
