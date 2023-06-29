using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearBgmQuit : MonoBehaviour
{
    public AudioSource bgAudio;
    private void Awake()
    {
        bgAudio.enabled = false;
    }
}
