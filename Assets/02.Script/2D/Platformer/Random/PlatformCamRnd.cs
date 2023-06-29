using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlatformCamRnd : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ComText;
    [SerializeField] Camera PlatfromCam;
    [SerializeField] GameObject frontCam1;
    [SerializeField] GameObject frontCam2;
    bool isAwake = false;

    private void Start()
    {
        frontCam1.gameObject.SetActive(false); 
        PlatfromCam.gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")&&isAwake==false)
        {
            ComText.text = "이동 발판지형에 진입해서 미니맵이 활성화되었어!";
            isAwake = true;
            PlatfromCam.gameObject.SetActive(true);
        }
    }
}
