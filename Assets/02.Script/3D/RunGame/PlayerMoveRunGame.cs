using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.Animations.Rigging;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMoveRunGame : MonoBehaviour
{
    public static PlayerMoveRunGame Instance;
    [SerializeField] private float Speed = 25f;
    [SerializeField] private float jumpForce = 7f;



    public bool isjumping = false;



    [SerializeField] private float camRotLim;
    [SerializeField] private Camera myCam;
    [SerializeField] private Camera myCamBack;
    [SerializeField] private LayerMask Ground;

    [SerializeField] TextMeshProUGUI ComText;
    private Rigidbody myRig;
    Transform myTr;
    public Animator playerAnimator;
    public AudioSource audioSource;
    [SerializeField] AudioSource HitSound;
    [SerializeField] AudioSource JumpSound;

    public Vector3 respawnPosition = Vector3.zero;
    public Vector3 myVec = new Vector3(1, 0, 0);


    void Start()
    {
        myCamBack.enabled = false;
        myTr = transform;
        Cursor.lockState = CursorLockMode.Locked;
        myRig = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        playerAnimator = GetComponent<Animator>();
        playerAnimator.enabled = false;
    }

    void Update()
    {
        if (RunGameManager.instance.isStart && !RunGameManager.instance.isClear)
        {
            playerAnimator.enabled = true;

            Move();
            Jump();
            CamChange();
        }
        if (RunGameManager.instance.isClear) playerAnimator.enabled = false;

    }
    // 플레이어 이동
    private void Move()
    {
        float _moveDirX = Input.GetAxisRaw("Horizontal");
        Vector3 _myVec = transform.forward * Time.deltaTime / 2.5f;
        Vector3 _moveHorizontal = _moveDirX * transform.right * Time.deltaTime;
        Vector3 _velocity = (_moveHorizontal + _myVec).normalized * Speed;
        myRig.MovePosition(myRig.position + _velocity * Time.deltaTime);

    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //점프 키가 눌렸을 때
        {
            if (isjumping == false) //점프 중이지 않을 때
            {
                myRig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //위쪽으로 힘을 준다.

                isjumping = true;
                playerAnimator.SetBool("isJump", true);
                JumpSound.Play();
                Invoke("DelayDownForce", 1.4f);
            }
            else return; //점프 중일 때는 실행하지 않고 바로 return.
        }
    }
    void DelayDownForce()
    {
        myRig.AddForce(Vector3.down * jumpForce * 2f, ForceMode.Impulse);
    }
    private void CamChange() // 플레이어 카메라 전환
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            myCam.enabled = true;
            myCamBack.enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.F2))
        {
            myCam.enabled = false;
            myCamBack.enabled = true;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            isjumping = false;
            playerAnimator.SetBool("isJump", false);
        }
        if (other.gameObject.CompareTag("Water"))
        {

            RunGameManager.instance.isHit = true;
            HitSound.Play();
            ComText.text = "물에 젖어 목숨을 하나 잃었어!";

        }
        if (other.gameObject.CompareTag("Rock"))
        {
            other.gameObject.GetComponent<MeshCollider>().SetEnable(false);
            RunGameManager.instance.isHit = true;
            HitSound.Play();
            ComText.text = "돌에 맞아 목숨을 하나 잃었어!";
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Grape") && RunGameManager.instance.Score1 < 10)
        {
            RunGameManager.instance.Score1 = RunGameManager.instance.Score1 + 1;
            ComText.text = "포도를 1개 획득했어!";
            audioSource.Play();
            other.gameObject.SetActive(false);
            Invoke("comTextReturn", 1.2f);
        }
        if (other.gameObject.CompareTag("Grape") && RunGameManager.instance.Score1 >= 10)
        {
            RunGameManager.instance.Score1 = RunGameManager.instance.Score1 - 10;
            RunGameManager.instance.Score2 = RunGameManager.instance.Score2 + 1;
            ComText.text = "포도를 10개 획득해서 샤인머스켓 1개로 교환했어!";
            audioSource.Play();
            other.gameObject.SetActive(false);
            Invoke("comTextReturn", 1.2f);
        }
        if (other.gameObject.CompareTag("Shine"))
        {
            RunGameManager.instance.Score2 = RunGameManager.instance.Score2 + 1;
            ComText.text = "샤인머스켓 1개를 획득했어!";
            audioSource.Play();
            other.gameObject.SetActive(false);
            Invoke("comTextReturn", 1.2f);
        }
        if (other.transform.CompareTag("Portal"))
        {
            RunGameManager.instance.isClear = true;
            GameManager.instance.playerGrape = GameManager.instance.playerGrape + RunGameManager.instance.Score1;
            GameManager.instance.playerShine = GameManager.instance.playerShine + RunGameManager.instance.Score2;
            Invoke("ReturnMain", 3);
        }
    }
    void comTextReturn()
    {
        ComText.text = "목표지점까지 장애물을 피하고 포도를 획득하며 완주해!";
    }
    void ReturnMain()
    {
        SceneManager.LoadScene("Main");
    }
}
