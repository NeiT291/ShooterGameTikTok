using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopGround : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 2f;
    [SerializeField] private float backgroundWidth = 20f; // chiều rộng của 1 background

    void Update()
    {
        transform.Translate(Vector3.down * scrollSpeed * Time.deltaTime);

        if (transform.position.x <= -backgroundWidth)
        {
            transform.position += new Vector3(0, backgroundWidth * 2f, 0);
        }
    }
}
