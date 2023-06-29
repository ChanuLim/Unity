using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnPortal1 : MonoBehaviour
{
    GameObject jumpsound;
    private void Start()
    {
       jumpsound = GameObject.FindGameObjectWithTag("JumpSound");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.isFirst = true;
            Destroy(jumpsound);
            SceneManager.LoadScene("Main");
        }
    }
}
