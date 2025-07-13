using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private float xLimit, yLimit;
    [SerializeField] private float moveSpeed = 1.5f;

    void Start()
    {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        xLimit = screenBounds.x + 1f;
        yLimit = screenBounds.y + 1f;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        if (Mathf.Abs(transform.position.x) > xLimit || Mathf.Abs(transform.position.y) > yLimit)
        {
            Destroy(gameObject);
        }
    }
}
