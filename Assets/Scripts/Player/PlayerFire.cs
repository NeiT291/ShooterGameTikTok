using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireRate;
    private PlayerStat playerStat;
    private float nextFireTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
        playerStat = GetComponent<PlayerStat>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStat != null)
        {
            fireRate = playerStat.FireRate; // Lấy tỉ lệ bắn từ PlayerStat
        }
        if (Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + fireRate;
        }

    }
    private void Fire()
    {
        audioManager.PlayVFX(audioManager.shootClip); // Phát âm thanh bắn
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation, transform);
    }
}
