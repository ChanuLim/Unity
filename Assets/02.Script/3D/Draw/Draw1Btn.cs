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
            Comtext.text = "���θӽ����� ������ �̱⸦ �� �� ����!";
            Invoke("AutoClose", 2f);
        }

    }
    void AutoClose()
    {
        Comtext.text = "���θӽ��� 10����  1ȸ �̱⸦ �� �� �־�!";
    }
}
