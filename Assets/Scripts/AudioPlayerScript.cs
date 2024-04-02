using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements.Experimental;

public class AudioPlayerScript : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;
    public AudioClip musicAudio, laserFire, playerDie, enemyDie, playerDamaged;

    void Start()
    {
        musicSource.clip = musicAudio;
        musicSource.Play();
        unduckAudio();
    }

    public void sfxLaser()
    {
        sfxSource.PlayOneShot(laserFire);
    }

    public void sfxEnemyDie()
    {
        sfxSource.PlayOneShot(enemyDie);
    }

    public void sfxPlayerDie()
    {
        sfxSource.PlayOneShot(playerDie);
    }

    public void sfxPlayerDamaged()
    {
        sfxSource.PlayOneShot(playerDamaged);
    }

    public void duckAudio()
    {
        audioMixer.DOSetFloat("cutoffMaster", 500, 0.5f);
    }

    public void unduckAudio()
    {
        audioMixer.DOSetFloat("cutoffMaster", 22000, 0.5f);
    }
}
