using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JumpCountText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI JmpText;
   
    private void Update()
    {
        JmpText.text = "남은 점프 횟수 : " + PlayerMove2D.Instatnce.jumpCount;
    }
}
