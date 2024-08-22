using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGameState : MonoBehaviour
{
    public PlayerController playerController;
    public TreeController treeController;
   void LGameState()
    {
        //karakter konumunu y�kle
        float x = PlayerPrefs.GetFloat("PlayerPosX");
        float z = PlayerPrefs.GetFloat("PlayerPosZ");
        playerController.transform.position = new Vector3 (x,0,z);

        //A�a� a�amalar�n� y�kle
        int currentStage = PlayerPrefs.GetInt("TreeStage");
        treeController.currentStage = currentStage;
        treeController.StopAllCoroutines();
        StartCoroutine(ResumeTreeGrowthCycle());
    }

    private IEnumerator ResumeTreeGrowthCycle()
    {
        yield return treeController.StartCoroutine(treeController.TreeGrowthCycle());
    }
}
