using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShineScoreRnd : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ComText;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PfRndManager.instance.Score2 = PfRndManager.instance.Score2 + 1;
            PfRndManager.instance.shineGet = true;
            gameObject.SetActive(false);
        }
    }
}
