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
            Comtext.text = "���θӽ����� ������ �̱⸦ �� �� ����!";
            Invoke("AutoClose", 2f);
        }

    }
    void AutoClose()
    {
        Comtext.text = "���θӽ��� 10����  1ȸ �̱⸦ �� �� �־�!";
    }
}
