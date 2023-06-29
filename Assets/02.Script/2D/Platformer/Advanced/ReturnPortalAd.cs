using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnPortalAd : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PfAdManager.instance.isClear = true;
            other.gameObject.SetActive(false);
            GameManager.instance.playerGrape = GameManager.instance.playerGrape + PfAdManager.instance.Score1;
            GameManager.instance.playerShine = GameManager.instance.playerShine + PfAdManager.instance.Score2;

            Invoke("ReturnMain", 3);
        }
    }
    void ReturnMain()
    {
        SceneManager.LoadScene("2D Platformer Main");
    }
}
