using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TreeController : MonoBehaviour
{
    public Sprite[] Trees;
    public float stageDuration = 2f;
    public float fruitableDuration = 2f;


    public GameObject fruitableIcon;
    public GameObject notfruitableIcon;
    public MiniGameManager gameManager;
   

    private SpriteRenderer spriteRenderer;
    public int currentStage = 0;
    private bool isFruitable = false;
    private bool iconActive = false;

    public Vector3 lastPoint;

    public PlayerController playerController;

    public SceneAsset sceneToLoad;
    private string sceneName;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(TreeGrowthCycle());

        lastPoint= transform.position;

    }

    public void OnMouseDown()
    {
        if (iconActive == false)
        {
            if (isFruitable == true)
            {
                fruitableIcon.SetActive(true);
                iconActive = true;

                
            }
            else
            {
                notfruitableIcon.SetActive(true);
                iconActive = true;
            }

        }
  
    }
    void Update()
    {
        if (playerController != null && playerController.movement != Vector3.zero)
        {
            fruitableIcon.SetActive(false);
            notfruitableIcon.SetActive(false);
            iconActive = false;
        }
    }

    public IEnumerator TreeGrowthCycle()
    {
        while (true)
        {
            switch (currentStage)
            {
                case 0:
                    yield return new WaitForSeconds(stageDuration);
                    spriteRenderer.sprite = Trees[0];
                    isFruitable = false;
                    currentStage++;
                break;

                case 1:
                    yield return new WaitForSeconds(stageDuration);
                    spriteRenderer.sprite= Trees[1];
                    isFruitable = false;
                    currentStage++;
                break;

                case 2:
                    yield return new WaitForSeconds(gameManager.gameDuration);
                    spriteRenderer.sprite = Trees[2];
                    isFruitable = true;
                    currentStage++;
                break;

                case 3:
                    yield return new WaitForSeconds(fruitableDuration);
                    spriteRenderer.sprite = Trees[3];
                    isFruitable = false;
                    currentStage--;
                break;
            }

        }
    }
 
    public void StartMiniGame() 
    {
        sceneName = sceneToLoad.name;

        if (isFruitable)
        {
            SceneManager.LoadScene(sceneName); 
        }

    }

    public void AutoHarvest()
    {
        if(isFruitable) 
        {
            Debug.Log("Meyveler Toplandý");
            isFruitable= false;

            fruitableIcon.SetActive(false);
            notfruitableIcon.SetActive(false);

            StartCoroutine(TreeGrowthCycle());
        }
    }

}
