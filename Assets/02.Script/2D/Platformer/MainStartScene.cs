using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;


public class MainStartScene : MonoBehaviour
{
    [SerializeField] Camera Maincam;
    [SerializeField] GameObject Player;
    [SerializeField] Camera StartCam;


    private void Start()
    {
        StartCoroutine(Startscene());
        Maincam.gameObject.SetActive(false);
        Player.SetActive(false);
    }

    private void Update()
    {
        Camera.main.orthographicSize -= Time.deltaTime / 2;
    }
    IEnumerator Startscene()
    {
        yield return new WaitForSeconds(3.0f);
        StartCam.gameObject.SetActive(false);
        Maincam.gameObject.SetActive(true);
        Player.SetActive(true);
        Destroy(gameObject);
    }
}
