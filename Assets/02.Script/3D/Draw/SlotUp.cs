using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotUp : MonoBehaviour
{
    Rigidbody2D rigid;
    Vector2 myVec = new Vector2(0, 600);

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        rigid.AddForce(myVec, ForceMode2D.Impulse);
        if (Mathf.Abs(rigid.velocity.y) > 600) 
            rigid.velocity = new Vector2(Mathf.Sign(rigid.velocity.y) * 600, 600);
    }
}
