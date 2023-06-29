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
            ComText.text = "포도를 1개 획득했어!";
            gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Player") && PfAdManager.instance.Score1 >= 10)
        {
            PfAdManager.instance.Score1 = PfAdManager.instance.Score1 - 10;
            PfAdManager.instance.Score2 = PfAdManager.instance.Score2 + 1;
            ComText.text = "포도를 10개 획득해서 샤인머스켓 1개로 교환했어!";
            gameObject.SetActive(false);
        }
    }
}
