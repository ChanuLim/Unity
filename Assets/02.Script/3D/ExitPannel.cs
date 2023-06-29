using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPannel : MonoBehaviour
{
    [SerializeField] GameObject _ExitPannel;
    public void ExitBtn() 
    {
        _ExitPannel.SetActive(true);
    }
    public void YesBtn() 
    {
        SceneManager.LoadScene("Main");
    }
    public void NoBtn()
    {
        _ExitPannel.SetActive(false);
    }
}
