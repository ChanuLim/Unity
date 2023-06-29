using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    [SerializeField] GameObject InterText;
    [SerializeField] GameObject AdSign;
    [SerializeField] GameObject BeSign;
    [SerializeField] GameObject AdadSign;
    [SerializeField] GameObject FirstSign;
    [SerializeField] GameObject PanelOpen;

    [SerializeField] TextMeshProUGUI MainText;
    public bool isInter;
    public bool isOpen;
    string detail;
    private void Awake()
    {
        
    }
    private void Update()
    {
       MainText.text = detail; 
       MainText.color = Color.black;


       keyInput();
    }
    void keyInput()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isOpen = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Sign"))
        {
            InterText.gameObject.SetActive(true);
            isInter = true;
            
        }
 
    }
    private void OnTriggerStay2D(Collider2D other)
    {
            if (other.gameObject == FirstSign& Input.GetKeyDown(KeyCode.Z))
            {
            isOpen = true;
            if (isOpen & isInter)
            {
                PanelOpen.gameObject.SetActive(true);
                detail = "← 귀환 포탈";
            }
        }
        if (other.gameObject == BeSign& Input.GetKeyDown(KeyCode.Z))
        {
            isOpen = true;
            if (isOpen & isInter)
            {
                PanelOpen.gameObject.SetActive(true);
                detail = "2D 플랫포머 게임이 어려우신 분들을 위한 \n초보자 모드\n→ : 이지모드" ;
            }
        }
        if (other.gameObject == AdSign& Input.GetKeyDown(KeyCode.Z))
        {
            isOpen = true;
            if (isOpen & isInter)
            {
                PanelOpen.gameObject.SetActive(true);
                detail = "2D 플랫포머 게임이 익숙하신 분들을 위한 \n숙련자 모드";
            }
        }
        if (other.gameObject == AdadSign& Input.GetKeyDown(KeyCode.Z))
        {
            isOpen = true;
            if (isOpen & isInter)
            {
                PanelOpen.gameObject.SetActive(true);
                detail = "↗ : 랜덤모드\n→ : 노멀모드";
            }
        }
     
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Sign"))
        {
            InterText.gameObject.SetActive(false);
            isInter = false;

        }
    }
}
