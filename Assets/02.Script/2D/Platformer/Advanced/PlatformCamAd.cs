using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlatformCamAd : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ComText;
    [SerializeField] Camera PlatfromCam;

    private void Start()
    {
        PlatfromCam.gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ComText.text = "이동 발판지형에 진입해서 미니맵이 활성화되었어!";
            PlatfromCam.gameObject.SetActive(true);
        }
    }
}
