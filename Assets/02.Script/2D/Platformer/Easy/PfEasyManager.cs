using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PfEasyManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI GrapeText;
    [SerializeField] TextMeshProUGUI ShineText;
    [SerializeField] TextMeshProUGUI TimerText;
    [SerializeField] TextMeshProUGUI ComText;
    [SerializeField] Image TimeupImg;
    [SerializeField] Image ClearImg;
    [SerializeField] Image TimeupReloadScene;
    [SerializeField] GameObject Player;

    public static PfEasyManager instance;


    public int Score1 = 0;
    public int Score2 = 0;

    public float Timer = 60.0f;

    public bool isStart = false;
    public bool isTimeover;
    public bool isClear;

    void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        Score();
        LiveTime();
        Clear();
    }
    void Score()
    {
        GrapeText.text = "X " + Score1;
        ShineText.text = "X " + Score2;
    }
    void LiveTime()
    {
        if (isStart)
        {
            Timer -= Time.deltaTime;


            if (Timer >= 0)
            {
                TimerText.text = "Time : " + Timer.ToString("F1");
            }
            if (Timer <= 0)
            {
                TimerText.text = "Time Over";
                TimeupImg.gameObject.SetActive(true);
                Invoke("TimeupImgSetf", 5);
                isTimeover = true;
                isStart = false;
                Player.SetActive(false);
            }
        }
    }
    void TimeupImgSetf()
    {
        TimeupImg.gameObject.SetActive(false);
        TimeupReloadScene.gameObject.SetActive(true);
    }
    void Clear()
    {
        if (isClear)
        {
            isStart = false;
            ComText.text = "스테이지 클리어!";
            TimerText.gameObject.SetActive(false);
            ClearImg.gameObject.SetActive(true);
        }
    }
}
