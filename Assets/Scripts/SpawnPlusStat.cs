using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlusStat : MonoBehaviour
{
    [SerializeField] private GameObject plusStatPrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnPlusStat", 3f, 7.2f);
    }

    private void spawnPlusStat()
    {
        float xViewportOne = 0.25f;
        float xViewportTwo = 0.75f;
        float yViewport = 1f;

        float depth = Mathf.Abs(Camera.main.transform.position.z);

        Vector3 spawnPosOne = Camera.main.ViewportToWorldPoint(new Vector3(xViewportOne, yViewport, depth));
        Vector3 spawnPosTwo = Camera.main.ViewportToWorldPoint(new Vector3(xViewportTwo, yViewport, depth));

        spawnPosOne.z = 0f;
        spawnPosTwo.z = 0f;
        Instantiate(plusStatPrefab, spawnPosOne, Quaternion.identity);
        Instantiate(plusStatPrefab, spawnPosTwo, Quaternion.identity);
    }
}
