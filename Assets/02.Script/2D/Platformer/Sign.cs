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
                detail = "�� ��ȯ ��Ż";
            }
        }
        if (other.gameObject == BeSign& Input.GetKeyDown(KeyCode.Z))
        {
            isOpen = true;
            if (isOpen & isInter)
            {
                PanelOpen.gameObject.SetActive(true);
                detail = "2D �÷����� ������ ������ �е��� ���� \n�ʺ��� ���\n�� : �������" ;
            }
        }
        if (other.gameObject == AdSign& Input.GetKeyDown(KeyCode.Z))
        {
            isOpen = true;
            if (isOpen & isInter)
            {
                PanelOpen.gameObject.SetActive(true);
                detail = "2D �÷����� ������ �ͼ��Ͻ� �е��� ���� \n������ ���";
            }
        }
        if (other.gameObject == AdadSign& Input.GetKeyDown(KeyCode.Z))
        {
            isOpen = true;
            if (isOpen & isInter)
            {
                PanelOpen.gameObject.SetActive(true);
                detail = "�� : �������\n�� : ��ָ��";
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
