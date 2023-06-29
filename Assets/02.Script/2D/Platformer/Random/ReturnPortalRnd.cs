using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnPortalRnd : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PfRndManager.instance.isClear = true;
            other.gameObject.SetActive(false);
            GameManager.instance.playerGrape = GameManager.instance.playerGrape + PfRndManager.instance.Score1;
            GameManager.instance.playerShine = GameManager.instance.playerShine + PfRndManager.instance.Score2;

            Invoke("ReturnMain", 3);
        }
    }
    void ReturnMain()
    {
        SceneManager.LoadScene("2D Platformer Main");
    }
}
