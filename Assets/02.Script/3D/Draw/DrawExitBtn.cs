using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawExitBtn : MonoBehaviour
{
    [SerializeField] GameObject Parent;
    [SerializeField] GameObject DrawObj;
    [SerializeField] GameObject DrawObj2;
    
    public void OnbuttonClick()
    {
        Draw.Instance.OneDraw = false;
        Draw.Instance.TenDraw = false;
        Draw.Instance.onedraw = 1;
        Draw.Instance.tendraw = 10;
        Parent.gameObject.SetActive(false);
        DrawObj.gameObject.SetActive(false);
        DrawObj2.gameObject.SetActive(false);
        Invoke("OnbuttonClick1", 0.1f);
        Invoke("OnbuttonClick2", 0.1f);
    }
    void OnbuttonClick1() 
    {
        gameObject.SetActive(false);
    }
    void OnbuttonClick2()
    {
        Transform[] childList = Parent.gameObject.GetComponentsInChildren<Transform>();
        if (childList != null)
        {
            for (int i = 1; i < childList.Length; i++)
            {
                if (childList[i] != transform)
                    Destroy(childList[i].gameObject);
            }
        }
    }
}
