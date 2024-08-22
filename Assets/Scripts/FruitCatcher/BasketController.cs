using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class BasketController : MonoBehaviour
{
    public int score = 0;
    public float xRange;
    public float speed;
    private float horizontalInput;
    public MiniGameManager gameManager;
    private string fruitName;
    public FruitSpawner fruitSpawner;

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        
        if(gameManager.isGameRunning&& !gameManager.isPaused)
        {
            if (transform.position.x < -xRange)
            {
                transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
            }

            if (transform.position.x > xRange)
            {
                transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
            }

            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("fruit"))
        {
            Destroy(other.gameObject);
            score++;

            gameManager.IncreaseScore(1);

            fruitName = fruitSpawner.fruit.name;

            
        }
    }

    
}
