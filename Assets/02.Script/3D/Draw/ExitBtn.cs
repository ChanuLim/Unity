using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBtn : MonoBehaviour
{
    [SerializeField] GameObject Parent;
    public void OnbuttonClick() 
    {
        GameManager.instance.isPannelOpen = false;
        Cursor.lockState = CursorLockMode.Locked;
        Parent.gameObject.SetActive(false);
    }
}
