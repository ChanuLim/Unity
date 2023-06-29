using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformUp : MonoBehaviour
{
    Rigidbody2D rigid;
    Vector2 myVec = new Vector2(0, 1);

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        rigid.AddForce(myVec, ForceMode2D.Impulse);
        if (Mathf.Abs(rigid.velocity.y) > 6) // 가속도가 6 이상이라면
            rigid.velocity = new Vector2(Mathf.Sign(rigid.velocity.y) * 5, 5);
    }
}
