using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject fruit;
    public float spawnInterval;
    public float spawnRangeX;

    public MiniGameManager gameManager;
    void Start()
    {
        gameManager=FindAnyObjectByType<GameManager>();
        StartCoroutine(SpawnFruit());
    }

    IEnumerator SpawnFruit()
    {
        while (true)
        {
            if (gameManager.isGameRunning && !gameManager.isPaused)
            {
                float xPos = Random.Range(-spawnRangeX, spawnRangeX);
                Vector3 spawnPosition = new Vector3(xPos, transform.position.y, transform.position.z);
                Instantiate(fruit, spawnPosition, Quaternion.identity);
            }

            yield return new WaitForSeconds(spawnInterval);
        }


    }
}
