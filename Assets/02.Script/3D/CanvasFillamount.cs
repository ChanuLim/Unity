using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CanvasFillamount : MonoBehaviour
{
    [SerializeField] public float runGauge;
    [SerializeField] public float runGaugeMax = 1f;
    [SerializeField] public Image runGaugeUI;

    [SerializeField] public float hp = 10;

    private Animator playerAnimator;

    public float delta;
    public float duration;
    public float _duration;

    void Start()
    {
        playerAnimator = GameObject.Find("3DPlayer").GetComponent<Animator>();
        runGauge = runGaugeMax;
    }
   
    
    void Update()
    {
        delta = Time.deltaTime;
        if (playerAnimator.GetBool("isRun"))
        {
            runGaugeUI.fillAmount -= delta * duration;
        }
        else runGaugeUI.fillAmount += delta * _duration;
    }
}
