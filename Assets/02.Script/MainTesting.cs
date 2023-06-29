using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainTesting : MonoBehaviour
{
    public void onClickBtn()
    {
        SceneManager.LoadScene("2D Platformer Main");
    }
    public void onClickBtn1()
    {
        SceneManager.LoadScene("3D Maze Map1");
    }
    public void onClickBtn2()
    {
        SceneManager.LoadScene("3D");
    }   
    public void onClickBtn3()
    {
        SceneManager.LoadScene("3D RunGame");
    }
}
