using UnityEngine;

public class JumpSound : MonoBehaviour
{
    public AudioSource audioSource;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& PlayerMove2D.Instatnce.jumpCount != 0)
        {
            audioSource.Play();
        }
    }
}
