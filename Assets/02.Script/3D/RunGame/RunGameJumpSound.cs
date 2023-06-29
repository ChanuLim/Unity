using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunGameJumpSound : MonoBehaviour
{
    public AudioSource audioSource;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.Play();
        }
    }
}
