using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShineScoreEasy : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ComText;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PfEasyManager.instance.Score2 = PfEasyManager.instance.Score2 + 1;
            ComText.text = "»þÀÎ¸Ó½ºÄÏ 1°³¸¦ È¹µæÇß¾î!";
            gameObject.SetActive(false);
        }
    }
}
