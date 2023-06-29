using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReloadAd : MonoBehaviour
{
    public void RestartOnClickBtn()
    {
        SceneManager.LoadScene("2D Platformer Advanced");
    }
}
