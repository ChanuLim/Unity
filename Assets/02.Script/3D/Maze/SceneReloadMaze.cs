using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReloadMaze : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(gameObject.scene.name);
    }
    public void ReturnMain() 
    {
        SceneManager.LoadScene("Main");
    }
}
