using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject prefab; // object cần spawn

    public float spawnZ = 0f; // độ sâu (Z) cho game 2D

    void Start()
    {
        InvokeRepeating("SpawnAtRandomSide", 1f, 5f);
    }

    void SpawnAtRandomSide()
    {
        // Chọn nửa trái (0) hoặc nửa phải (1)
        int side = Random.Range(0, 2); // 0 = trái, 1 = phải

        float xViewport = (side == 0) ? 0.25f : 0.75f; // trái hoặc phải
        float yViewport = 1f; // chính giữa chiều cao

        // Độ sâu tính từ camera đến object, thường dùng độ sâu tuyệt đối
        float depth = Mathf.Abs(Camera.main.transform.position.z);

        Vector3 spawnPos = Camera.main.ViewportToWorldPoint(new Vector3(xViewport, yViewport, depth));
        spawnPos.z = 0f; // z = 0 cho game 2D

        Instantiate(prefab, spawnPos, Quaternion.identity);
    }

}
