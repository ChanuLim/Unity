using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMini : MonoBehaviour
{
    Rigidbody2D myrig;
    RectTransform myrect;
    Animator myanim;
    [SerializeField] float speed = 5;
    Vector2 _vec = new Vector2(1, 0);
    void Start()
    {
        myrect = GetComponent<RectTransform>();
        myanim = GetComponent<Animator>();
        myrig = GetComponent<Rigidbody2D>();
        myanim.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (RunGameManager.instance.isStart && !RunGameManager.instance.isClearReady)
        {
            myanim.enabled = true;
            myrig.velocity = _vec * Time.deltaTime * speed;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Sign"))
        {
            RunGameManager.instance.isClearReady = true;
            myrig.velocity = Vector2.zero;
            myanim.enabled = false;
            myrect.position = new Vector2(1383f, 1028f);
        }
    }
}
