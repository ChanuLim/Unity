using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GrapeScoreAd : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ComText;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && PfAdManager.instance.Score1 < 10)
        {
            PfAdManager.instance.Score1 = PfAdManager.instance.Score1 + 1;
            ComText.text = "������ 1�� ȹ���߾�!";
            gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Player") && PfAdManager.instance.Score1 >= 10)
        {
            PfAdManager.instance.Score1 = PfAdManager.instance.Score1 - 10;
            PfAdManager.instance.Score2 = PfAdManager.instance.Score2 + 1;
            ComText.text = "������ 10�� ȹ���ؼ� ���θӽ��� 1���� ��ȯ�߾�!";
            gameObject.SetActive(false);
        }
    }
}
