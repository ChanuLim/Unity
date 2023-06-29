using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MazeTimer : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Camera playerCam;
    [SerializeField] GameObject count5;
    [SerializeField] GameObject count4;
    [SerializeField] GameObject count3;
    [SerializeField] GameObject count2;
    [SerializeField] GameObject count1;
    [SerializeField] GameObject start;
    [SerializeField] GameObject StartPanel;
    
    void Start()
    {
        playerCam.enabled = false;
        if (GameManager.instance.isFirst) StartPanel.gameObject.SetActive(true);
        if (GameManager.instance.isFirst==false)StartCoroutine(TimeStart());
    }
    private void Update()
    {
        if (GameManager.instance.MazeCount == 1)
        {
            firstStart();
        }
        else
        {
            StartPanel.gameObject.SetActive(false);
            Invoke("anotherTimeStart", 5);
        }
    }

    IEnumerator TimeStart()
    {
            count5.gameObject.SetActive(true);
            yield return new WaitForSeconds(1.0f);
            count5.gameObject.SetActive(false);
            count4.gameObject.SetActive(true);
            yield return new WaitForSeconds(1.0f);
            count4.gameObject.SetActive(false);
            count3.gameObject.SetActive(true);
            yield return new WaitForSeconds(1.0f);
            count3.gameObject.SetActive(false);
            count2.gameObject.SetActive(true);
            yield return new WaitForSeconds(1.0f);
            count2.gameObject.SetActive(false);
            count1.gameObject.SetActive(true);
            yield return new WaitForSeconds(1.0f);
            count1.gameObject.SetActive(false);
            start.gameObject.SetActive(true);
            yield return new WaitForSeconds(1.0f);
            start.gameObject.SetActive(false);
            cam.enabled = false;
            playerCam.enabled = true;
            MazeGameManager.instance.isStart = true;
            gameObject.SetActive(false);
    }
    void anotherTimeStart()
    {
        cam.enabled = false;
        playerCam.enabled = true;
        MazeGameManager.instance.isStart = true;
    }
    void firstStart() 
    {
        if (GameManager.instance.isFirst&&Input.GetKeyDown(KeyCode.Escape)) 
        {
            StartPanel.gameObject.SetActive(false);
            GameManager.instance.isFirst = false;
            StartCoroutine(TimeStart());
        }
    }
}
