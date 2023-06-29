using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ComText;
    [SerializeField] GameObject BGM;
     AudioSource myAud;
    private void Awake()
    {
        myAud = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Grape") && MazeGameManager.instance.Score1 < 10)
        {
            MazeGameManager.instance.Score1 = MazeGameManager.instance.Score1 + 1;
            ComText.text = "Æ÷µµ¸¦ 1°³ È¹µæÇß¾î!";
            myAud.Play();
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Grape") && MazeGameManager.instance.Score1 >= 10)
        {
            MazeGameManager.instance.Score1 = MazeGameManager.instance.Score1 - 10;
            MazeGameManager.instance.Score2 = MazeGameManager.instance.Score2 + 1;
            ComText.text = "Æ÷µµ¸¦ 10°³ È¹µæÇØ¼­ »þÀÎ¸Ó½ºÄÏ 1°³·Î ±³È¯Çß¾î!";
            myAud.Play();
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Shine"))
        {
            MazeGameManager.instance.Score2 = MazeGameManager.instance.Score2 + 1;
            ComText.text = "»þÀÎ¸Ó½ºÄÏ 1°³¸¦ È¹µæÇß¾î!";
            myAud.Play();
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Portal") && GameManager.instance.MazeCount < 3)
        {
            other.gameObject.SetActive(false);
            GameManager.instance.playerGrape = GameManager.instance.playerGrape + MazeGameManager.instance.Score1;
            GameManager.instance.playerShine = GameManager.instance.playerShine + MazeGameManager.instance.Score2;
            MazeGameManager.instance.isClear = true;
            Invoke("NextStage", 3);
        }
        if (other.gameObject.CompareTag("Portal") && GameManager.instance.MazeCount >= 3)
        {
            other.gameObject.SetActive(false);
            GameManager.instance.playerGrape = GameManager.instance.playerGrape + MazeGameManager.instance.Score1;
            GameManager.instance.playerShine = GameManager.instance.playerShine + MazeGameManager.instance.Score2;
            MazeGameManager.instance.isClear = true;
            GameManager.instance.isFirst = true;
            Invoke("ReturnMain", 3);
        }

    }
    void NextStage()
    {
        SceneManager.LoadScene("3D Maze Map1");
        GameManager.instance.MazeCount++;
        
    }
    void ReturnMain() 
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Main");
        GameManager.instance.MazeCount=0;
        GameManager.instance.isFirst = true;
        Destroy(BGM);
    }
}
