using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeReturn : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            MazeGameManager.instance.isClear = true;
            other.gameObject.SetActive(false);
            GameManager.instance.playerGrape = GameManager.instance.playerGrape + MazeGameManager.instance.Score1;
            GameManager.instance.playerShine = GameManager.instance.playerShine + MazeGameManager.instance.Score2;
            
            Invoke("NextStage", 1);
        }
       
    }
    void NextStage() 
    {
        SceneManager.LoadScene(gameObject.scene.name);
    }
}
