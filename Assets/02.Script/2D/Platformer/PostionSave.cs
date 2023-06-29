using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PostionSave : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ComText;
    public Transform mytr;
    
    private void Start()
    {
        mytr = transform;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ComText.text = "현재 위치를 저장했어!";
            PlayerMove2D.Instatnce.saveDir = mytr.transform.position;
            gameObject.SetActive(false);
        }
    }
}
