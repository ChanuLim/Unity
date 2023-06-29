using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlatformCamRnd2 : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ComText;
    [SerializeField] Camera PlatfromCam;
    [SerializeField] GameObject latestCam;
    [SerializeField] GameObject latestRnd;
    [SerializeField] GameObject CreateRnd;
    bool isAwake = false;

    private void Start()
    {
        PlatfromCam.gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && isAwake == false)
        {
            {
                latestRnd.gameObject.SetActive(false);
                latestCam.gameObject.SetActive(false);
                CreateRnd.gameObject.SetActive(true);
                ComText.text = "����° �̵� ���������� �����ؼ� ����° �̴ϸ��� Ȱ��ȭ�Ǿ���!";
                isAwake = true;
                PlatfromCam.gameObject.SetActive(true);
            }
        }
    }
}
