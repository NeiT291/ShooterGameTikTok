using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector3 targetPosition;
    private bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {

        targetPosition = transform.position;
        HandleTouch(new Vector2(Screen.width / 2f - 0.25f, Screen.height / 2f));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                HandleTouch(touch.position);
            }
        }

        // Chuột trái để test trên máy tính
        if (Input.GetMouseButtonDown(0))
        {
            HandleTouch(Input.mousePosition);
        }

        // Di chuyển dần dần tới target
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                isMoving = false;
            }
        }
    }
    void HandleTouch(Vector2 screenPosition)
    {
        float halfScreen = Screen.width / 2f;

        if (screenPosition.x < halfScreen)
        {
            // Chạm bên trái → giữa nửa trái (x = 0.25)
            targetPosition = Camera.main.ViewportToWorldPoint(new Vector3(0.25f, 0.5f, 10f));
        }
        else
        {
            // Chạm bên phải → giữa nửa phải (x = 0.75)
            targetPosition = Camera.main.ViewportToWorldPoint(new Vector3(0.75f, 0.5f, 10f));
        }

        // Giữ nguyên trục Z nếu cần
        targetPosition.z = transform.position.z;
        targetPosition.y = transform.position.y;

        isMoving = true;
    }
}
