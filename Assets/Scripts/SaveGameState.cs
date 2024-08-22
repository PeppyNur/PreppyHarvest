using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameState : MonoBehaviour
{
    public PlayerController playerController;
    public TreeController treeController;
    void SGameState()
    {
        //Karakter pozisyonu 
        PlayerPrefs.SetFloat("PlayerPosX",playerController.transform.position.x);
        PlayerPrefs.SetFloat("PlayerPosZ",playerController.transform.position.z);

        //Aðaçlarýn aþamalarý
        int currentStage = PlayerPrefs.GetInt("TreeStage");
    }
}
