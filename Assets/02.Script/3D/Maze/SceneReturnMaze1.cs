using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReturnMaze : MonoBehaviour
{
    public void RestartOnClickBtn()
    {
        SceneManager.LoadScene("Main");
    }
}
