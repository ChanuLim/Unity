using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Draw10Btn : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Comtext;
    [SerializeField] Button DrawExitBtn;
    public void onClickBtn1()
    {
        if (GameManager.instance.playerShine > 100)
        {
            GameManager.instance.playerShine = GameManager.instance.playerShine - 100;
            Draw.Instance.TenDraw = true;
            DrawExitBtn.gameObject.SetActive(true);
        }

        if (GameManager.instance.playerShine < 99)
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
