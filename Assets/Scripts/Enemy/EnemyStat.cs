using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    [SerializeField] private float health = 100;
    public float Health { get => health; set => health = value; }
    [SerializeField] private TMP_Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        healthText.text = Health.ToString();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bullet")
        {
            Bullet bullet = collision.GetComponent<Bullet>();
            if (bullet != null)
            {
                Health -= bullet.Damage; // Giảm máu dựa trên sát thương của đạn
                healthText.text = Health.ToString("F0");
                Destroy(collision.gameObject); // Hủy đạn sau khi bắn trúng
            }
            if (Health <= 0)
            {
                Score.Instance.AddScore(10); // Thêm điểm khi kẻ địch bị tiêu diệt
                Destroy(gameObject); // Hủy đối tượng khi máu bằng 0
            }
        }
        if (collision.tag == "player")
        {
            Destroy(gameObject); // Hủy kẻ địch sau khi va chạm với người chơi

        }
    }
}
