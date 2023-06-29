using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunGameReturn : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("11");
            RunGameManager.instance.isClear = true;
            other.gameObject.SetActive(false);
            GameManager.instance.playerGrape = GameManager.instance.playerGrape + RunGameManager.instance.Score1;
            GameManager.instance.playerShine = GameManager.instance.playerShine + RunGameManager.instance.Score2;
            
            Invoke("ReturnMain", 3);
        }
       
    }
    void ReturnMain() 
    {
        SceneManager.LoadScene("Main");
    }
}
