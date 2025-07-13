using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    private AudioManager audioManager;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private float health = 100f;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private float damage = 10f;
    [SerializeField] private TMP_Text healthText;
    public float Health { get => health; set => health = value; }
    public float FireRate { get => fireRate; set => fireRate = value; }
    public float Damage { get => damage; set => damage = value; }
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
        healthText.text = Health.ToString("F0");
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
        {
            EnemyStat enemy = collision.GetComponent<EnemyStat>();
            if (enemy != null)
            {
                audioManager.PlayVFX(audioManager.playerHitClip); // Phát âm thanh khi bị trúng đạn
                Health -= enemy.Health; // Giảm máu dựa trên máu của kẻ địch
                healthText.text = Health.ToString("F0");
                if (Health <= 0)
                {
                    gameOver.SetActive(true); // Hiển thị Game Over
                    Destroy(gameObject); // Hủy đối tượng khi máu bằng 0
                }
            }
        }
        if (collision.tag == "plusStat")
        {
            PlusStat plusStat = collision.GetComponent<PlusStat>();
            if (plusStat != null)
            {
                switch (plusStat.EffectTypeIndex)
                {
                    case 0: // Health
                        Health += plusStat.EffectValue;
                        healthText.text = Health.ToString("F0");
                        break;
                    case 1: // FireRate
                        FireRate -= plusStat.EffectValue / 100;
                        break;
                    case 2: // Damage
                        Damage += plusStat.EffectValue;
                        break;
                }
                Destroy(collision.gameObject); // Hủy PlusStat sau khi áp dụng
            }
        }
    }
}
