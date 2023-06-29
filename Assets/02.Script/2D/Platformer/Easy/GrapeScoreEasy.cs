using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GrapeScoreEasy : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ComText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && PfEasyManager.instance.Score1 < 10)
        {
           
            PfEasyManager.instance.Score1 = PfEasyManager.instance.Score1 + 1;
            ComText.text = "������ 1�� ȹ���߾�!";

            gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Player") && PfEasyManager.instance.Score1 >= 10)
        {
            PfEasyManager.instance.Score1 = PfEasyManager.instance.Score1 - 10;
            PfEasyManager.instance.Score2 = PfEasyManager.instance.Score2 + 1;
            ComText.text = "������ 10�� ȹ���ؼ� ���θӽ��� 1���� ��ȯ�߾�!";
           gameObject.SetActive(false);
        }
    }
}
