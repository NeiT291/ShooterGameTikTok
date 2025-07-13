using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FitBackgroundToScreen();
        // Ensure the background is always behind other objects
        transform.position = new Vector3(transform.position.x, transform.position.y, 10f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FitBackgroundToScreen()
    {
        SpriteRenderer sr = GetComponentInChildren<SpriteRenderer>();
        if (sr == null) return;

        float screenHeight = Camera.main.orthographicSize * 2f;
        float screenWidth = screenHeight * Screen.width / Screen.height;

        float spriteWidth = sr.sprite.bounds.size.x;

        // Tính tỉ lệ scale cho chiều rộng (X), giữ nguyên chiều cao (Y)
        float scaleX = screenWidth / spriteWidth;
        transform.localScale = new Vector3(scaleX, transform.localScale.y, 1f);
    }
}
