using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerMove2D : MonoBehaviour
{
    public float speed = 5f;
    public float JumpSpeed = 10f;
    public float jumpForce;
    public int jumpCount = 2;
    private bool IsJump = false;
    public bool isGrounded = false;

    Animator myAnim;
    Transform myTr;
    Rigidbody2D myRig;

    Vector2 moveDir;
    public Vector3 saveDir = new Vector3(-5f, 0, 0);

    [SerializeField] GameObject Res;
    [SerializeField] TextMeshProUGUI ComText;

    public static PlayerMove2D Instatnce;
    public AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        Instatnce = this;
    }
    void Start()
    {
        myAnim = GetComponent<Animator>();
        myRig = GetComponent<Rigidbody2D>();
        myTr = GetComponent<Transform>();
    }

    void Update()
    {
        JumpCtrl();
        Move();
        RespawnDir();
    }
    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            moveVelocity = Vector3.left;
            GetComponent<SpriteRenderer>().flipX = true;
            myAnim.SetBool("isRun", true);
        }

        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVelocity = Vector3.right;
            GetComponent<SpriteRenderer>().flipX = false;
            myAnim.SetBool("isRun", true);
        }
        else myAnim.SetBool("isRun", false);
        transform.position += moveVelocity * speed * Time.deltaTime;
    }

    void JumpCtrl()
    {
        myAnim.SetFloat("Velocity", JumpSpeed);
        if (IsJump)
        {
            JumpSpeed -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
            myAnim.SetBool("isJump", true);
        }
        if (Input.GetButtonUp("Jump"))
        {
            myAnim.SetBool("isJump", false);
        }
    }
    void Jump()
    {
        if (jumpCount != 0)
        {
            JumpSpeed = 1f;
            IsJump = true;
            myAnim.SetFloat("Velocity", JumpSpeed);
            myRig.velocity = Vector2.zero;
            myRig.velocity = moveDir;
            Vector2 jumpVelocity = new Vector2(0, jumpForce);
            myRig.AddForce(jumpVelocity, ForceMode2D.Impulse);
            myAnim.SetBool("isGrounded", false);

            jumpCount--;

        }
    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            IsJump = false;
            JumpSpeed = 1f;
            myAnim.SetBool("isJump", false);
            myAnim.SetBool("isGrounded", true);
            isGrounded = true;
            jumpCount = 2;
        }

    }
    void RespawnDir() 
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = saveDir;
            ComText.text = "R키를 눌러 저장지점으로 돌아왔어!";
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == Res)
        {
            transform.position = saveDir;
            ComText.text = "떨어져서 저장지점으로 돌아왔어!";
        }
        if (other.gameObject.CompareTag("Score"))
        {
            audioSource.Play();
        }
    }
}

