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
            ComText.text = "�̵� ���������� �����ؼ� �̴ϸ��� Ȱ��ȭ�Ǿ���!";
            PlatfromCam.gameObject.SetActive(true);
        }
    }
}
