using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sec7Destory : MonoBehaviour
{
    void Update()
    {
        Invoke("Sec7",7);
    }
    void Sec7() 
    {
        Destroy(gameObject);
    }
}
