using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShineScoreAd : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ComText;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PfAdManager.instance.Score2 = PfAdManager.instance.Score2 + 1;
            ComText.text = "���θӽ��� 1���� ȹ���߾�!";
            gameObject.SetActive(false);
        }
    }
}
