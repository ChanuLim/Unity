
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReloadEasy : MonoBehaviour
{
    public void RestartOnClickBtn()
    {
        SceneManager.LoadScene("2D Platformer Easy");
    }
}
