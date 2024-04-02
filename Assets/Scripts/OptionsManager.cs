using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider masterSlider, musicSlider, sfxSlider;
    [SerializeField] private InputField moveSpeed, focusSpeed;

    void Start()
    {
        loadPlayerPrefs();
    }

    public void SetMaster()
    {
        float volume = masterSlider.value;
        audioMixer.SetFloat("volMaster", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("masterVolume", volume);
    }

    public void SetMusic()
    {
        float volume = musicSlider.value;
        audioMixer.SetFloat("volMusic", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetSFX()
    {
        float volume = sfxSlider.value;
        audioMixer.SetFloat("volSFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }

    public void SetMove()
    {
        bool parseable = int.TryParse(moveSpeed.text, out int speed);
        if (parseable && speed <= 15 && speed >= 6)
        {
            speed = int.Parse(moveSpeed.text);
            PlayerPrefs.SetInt("moveSpeed", speed);
        } else {
            moveSpeed.text = "6";
            PlayerPrefs.SetInt("moveSpeed", 6);
        }
    }

    public void SetFocus()
    {
        bool parseable = int.TryParse(focusSpeed.text, out int speed);
        if (parseable && speed <= 6 && speed >= 1)
        {
            speed = int.Parse(focusSpeed.text);
            PlayerPrefs.SetInt("focusSpeed", speed);
        } else {
            focusSpeed.text = "1";
            PlayerPrefs.SetInt("focusSpeed", 1);
        }
    }

    public void loadPlayerPrefs()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        masterSlider.value = PlayerPrefs.GetFloat("masterVolume");
        moveSpeed.text = PlayerPrefs.GetInt("moveSpeed").ToString();
        focusSpeed.text = PlayerPrefs.GetInt("focusSpeed").ToString();

        SaveOptions();
    }

    public void SaveOptions()
    {
        SetMaster();
        SetMusic();
        SetSFX();
        SetMove();
        SetFocus();
    }
}
