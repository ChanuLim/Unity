using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.UI;

public class RunGameManager : MonoBehaviour
{
    public static RunGameManager instance;
    [SerializeField] TextMeshProUGUI GrapeText;
    [SerializeField] TextMeshProUGUI ShineText;
    [SerializeField] TextMeshProUGUI HeartText;
    [SerializeField] TextMeshProUGUI ComText;
    [SerializeField] Image GameoverImg;
    [SerializeField] Image ClearImg;
    [SerializeField] Image GameoverReloadScene;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject PlayerMin;
    [SerializeField] GameObject BackGround;



    public int Score1 = 0;
    public int Score2 = 0;
    public int Life = 3;


    public bool isStart = false;
    public bool isHit;
    public bool isRock;
    public bool isTimeover;
    public bool isClear;
    public bool isClearReady=false;
    

    void Awake()
    {
        
        instance = this;
    }
    private void Update()
    {
        Score();
        Clear();
        LifeOver();

    }
    void Score()
    {
        GrapeText.text = "X " + Score1;
        ShineText.text = "X " + Score2;
        HeartText.text = "X " + Life;
        if (isStart) 
        {
            BackGround.SetActive(true);
        }
        if (!isStart)
        {
            BackGround.SetActive(false);
        }
    }
    void LifeOver()
    {
        if (isHit)
        {
            isHit = false;
            Life = Life - 1;
            Player.GetComponent<Animator>().SetBool("isHit", true);
            Invoke("HitReturn",1.5f);
        }
        if (Life == 0)
        {
            GameoverImg.gameObject.SetActive(true);
            Player.GetComponent<PlayerMoveRunGame>().enabled=false;
            PlayerMin.GetComponent<PlayerMini>().enabled = false;
            BackGround.SetActive(false);
            Invoke("ReloadPanel", 4f);
        }
    }
    void HitReturn()
    {
        Player.GetComponent<Animator>().SetBool("isHit", false);
    }
    void Clear()
    {
        if (isClear)
        {
            isRock = false;
            isStart = false;
            ComText.text = "스테이지 클리어!";
            ClearImg.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }
    void ReloadPanel() 
    {
        Cursor.lockState = CursorLockMode.None;
        GameoverReloadScene.gameObject.SetActive(true);
    }
}
