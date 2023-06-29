using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CreateRockFall : MonoBehaviour
{
    public GameObject RockFall;
    public GameObject RockFallLeft;
    public GameObject RockFallRight;


    public GameObject BackRockFall;
    public GameObject BackRockFallLeft;
    public GameObject BackRockFallRight;

    public Image Warning;
    public Image WarningLeft;
    public Image WarningRight;

    public int RockCount;
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(CreateRock());
        Rfall();
    }
    IEnumerator CreateRock()
    {
        if (RunGameManager.instance.isRock)
        {
            RockCount = Random.Range(0, 5);
            yield return new WaitForSeconds(3.0f);
        }
    }
    void Rfall() 
    {
        if (RockCount == 0) 
        {
            RockFall.gameObject.SetActive(true);
            RockFall.gameObject.SetActive(false);
        }
        if (RockCount == 1) 
        {
            RockFallLeft.gameObject.SetActive(true);
            RockFallLeft.gameObject.SetActive(false);
        }
        if (RockCount == 2) 
        {
            RockFallRight.gameObject.SetActive(true);
            RockFallRight.gameObject.SetActive(false);
        }
        if (RockCount == 3) 
        {
            BackRockFall.gameObject.SetActive(true);
            BackRockFall.gameObject.SetActive(false);
        }
        if (RockCount == 4) 
        {
            BackRockFallLeft.gameObject.SetActive(true);
            BackRockFallLeft.gameObject.SetActive(false);
        }
        if (RockCount == 5) 
        {
            BackRockFallRight.gameObject.SetActive(true);
            BackRockFallRight.gameObject.SetActive(false);
        }


    }
}
