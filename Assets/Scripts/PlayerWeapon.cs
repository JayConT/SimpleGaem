using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public AudioPlayerScript audioPlayer;
    public Transform firePoint;
    public KeyCode fireKey = KeyCode.Space;
    public GameObject firedProjectile;
    private float fireCooldown = 0.4f;

    void Start()
    {
        audioPlayer = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioPlayerScript>();
    }

    void Update()
    {
        fireCooldown -= Time.deltaTime;
        if (Input.GetKeyDown(fireKey) && fireCooldown <= 0.0)
        {
            FireWeapon();
            fireCooldown = 0.4f;
        }
    }

    void FireWeapon()
    {
        GameObject bullet = Instantiate(firedProjectile, firePoint.position, firePoint.rotation);
        audioPlayer.sfxLaser();
        Destroy(bullet, 1f);
    }
}
