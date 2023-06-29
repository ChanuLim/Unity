using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MazeGameManager : MonoBehaviour
{
    public static MazeGameManager instance;
    [SerializeField] TextMeshProUGUI GrapeText;
    [SerializeField] TextMeshProUGUI ShineText;
    [SerializeField] TextMeshProUGUI TimerText;
    [SerializeField] TextMeshProUGUI ComText;
    [SerializeField] TextMeshProUGUI StageText;
    [SerializeField] Image TimeupImg;
    [SerializeField] Image ClearImg;
    [SerializeField] Image TimeupReloadScene;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject BGMParent;

    public int Score1 = 0;
    public int Score2 = 0;

    public float Timer = 90.0f;

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
        StageTxt();
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
                BGMParent.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
    void TimeupImgSetf()
    {
        TimeupImg.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
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
    void StageTxt() 
    {
        StageText.text = "제 " + GameManager.instance.MazeCount + " 스테이지";
    }
}
