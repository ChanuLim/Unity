using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartTimerEasy : MonoBehaviour
{
    [SerializeField] GameObject cam;
    [SerializeField] GameObject player;
    [SerializeField] GameObject count5;
    [SerializeField] GameObject count4;
    [SerializeField] GameObject count3;
    [SerializeField] GameObject count2;
    [SerializeField] GameObject count1;
    [SerializeField] GameObject start;
    
    void Start()
    {
        cam.gameObject.GetComponent<CamTarget>().SetEnable(false);
        player.gameObject.SetActive(false);
        StartCoroutine(TimeStart());
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
        cam.gameObject.GetComponent<CamTarget>().SetEnable(true);
        player.gameObject.SetActive(true);
        PfEasyManager.instance.isStart = true;
        Destroy(gameObject);
    }

}
