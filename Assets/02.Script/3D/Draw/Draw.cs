using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Draw : MonoBehaviour
{
    public static Draw Instance;
    [SerializeField] TextMeshProUGUI shineText;
    [SerializeField] GameObject DrawPanel;
    [SerializeField] GameObject OneDrawObj;
    [SerializeField] GameObject TenDrawObj;
    

    public bool OneDraw = false;
    public int onedraw = 1;
    public bool TenDraw = false;
    public int tendraw = 10;
    void Start()
    {
        Instance = this;
    }

    void Update()
    {
        DrawSystem();
    }
    void DrawSystem() 
    {
        shineText.text = "X " + GameManager.instance.playerShine;
        if (OneDraw) 
        {
            DrawPanel.SetActive(true);
            OneDrawObj.SetActive(true);
        }
        if (TenDraw) 
        {
            DrawPanel.SetActive(true);
            TenDrawObj.SetActive(true);
        }
    }


}
