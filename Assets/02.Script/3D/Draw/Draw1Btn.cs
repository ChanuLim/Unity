using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Draw1Btn : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Comtext;
    [SerializeField] Button DrawExitBtn;
    public void onClickBtn1()
    {
        if (GameManager.instance.playerShine > 10)
        {
            GameManager.instance.playerShine = GameManager.instance.playerShine - 10;
            Draw.Instance.OneDraw = true;
            DrawExitBtn.gameObject.SetActive(true);
        }

        if (GameManager.instance.playerShine < 9)
        {
            Comtext.text = "샤인머스켓이 부족해 뽑기를 할 수 없어!";
            Invoke("AutoClose", 2f);
        }

    }
    void AutoClose()
    {
        Comtext.text = "샤인머스켓 10개로  1회 뽑기를 할 수 있어!";
    }
}
