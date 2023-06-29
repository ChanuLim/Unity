using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReturnMain : MonoBehaviour
{
    public void RestartOnClickBtn()
    {
        SceneManager.LoadScene("Main");
    }
}
