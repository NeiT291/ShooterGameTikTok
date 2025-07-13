using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float xLimit, yLimit;
    [SerializeField] private float speed = 10f;

    [SerializeField] private float damage = 10f; // Sát thương của viên đạn
    private PlayerStat playerStat;
    public float Damage { get => damage; set => damage = value; }
    // Start is called before the first frame update
    private void Start()
    {
        playerStat = GetComponentInParent<PlayerStat>();
        if (playerStat != null)
        {
            damage = playerStat.Damage; // Lấy sát thương từ PlayerStat
        }
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        xLimit = screenBounds.x + 1f;
        yLimit = screenBounds.y + 1f;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (Mathf.Abs(transform.position.x) > xLimit || Mathf.Abs(transform.position.y) > yLimit)
        {
            Destroy(gameObject);
        }
    }

}
