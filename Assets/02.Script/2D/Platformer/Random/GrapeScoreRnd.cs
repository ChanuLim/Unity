using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GrapeScoreRnd : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ComText;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && PfRndManager.instance.Score1 < 10)
        {
            PfRndManager.instance.Score1 = PfRndManager.instance.Score1 + 1;
            PfRndManager.instance.grapeGet = true;
            gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Player") && PfRndManager.instance.Score1 >= 10)
        {
            PfRndManager.instance.Score1 = PfRndManager.instance.Score1 - 10;
            PfRndManager.instance.Score2 = PfRndManager.instance.Score2 + 1;
            PfRndManager.instance.grapeTr = true;
            gameObject.SetActive(false);
        }
    }
}
