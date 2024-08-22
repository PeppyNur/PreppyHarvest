using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject treeType;
    private string treeTypeName;

   private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void OnEnabled()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisabled()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;

    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        treeTypeName=treeType.name;

        if (scene.name == "World")
        {
            GameObject[]
        }
    }
}
