using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RunGameTimer : MonoBehaviour
{
    [SerializeField] GameObject count5;
    [SerializeField] GameObject count4;
    [SerializeField] GameObject count3;
    [SerializeField] GameObject count2;
    [SerializeField] GameObject count1;
    [SerializeField] GameObject start;
    [SerializeField] GameObject StartPanel;

    void Start()
    {
        if (GameManager.instance.isFirst) StartPanel.gameObject.SetActive(true);
        if (GameManager.instance.isFirst == false) StartCoroutine(TimeStart());
    }
    private void Update()
    {
            firstStart();

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

        RunGameManager.instance.isStart = true;
        yield return new WaitForSeconds(15.0f);
        RunGameManager.instance.isRock = true;
    }
    void firstStart()
    {
        if (GameManager.instance.isFirst && Input.GetKeyDown(KeyCode.Escape))
        {
            StartPanel.gameObject.SetActive(false);
            GameManager.instance.isFirst = false;
            StartCoroutine(TimeStart());
        }
    }
}
