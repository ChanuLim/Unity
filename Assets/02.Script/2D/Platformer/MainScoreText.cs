using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainScoreText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ShineText;
    [SerializeField] TextMeshProUGUI GrapeText;
    int mainShine;
    int mainGrape;

    private void Update()
    {
        mainShine = GameManager.instance.playerShine;
        mainGrape = GameManager.instance.playerGrape;

        GrapeText.text = "X " + mainGrape;
        ShineText.text = "X " + mainShine;
    }
}
