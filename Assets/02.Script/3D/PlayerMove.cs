using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEditor;
using TMPro;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float Speed = 5f;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private float mouseSensitivity = 100f;

    private float currentCamRotX;
    private bool isjumping = false;
    private bool isRunning = false;



    [SerializeField] private float camRotLim;
    [SerializeField] private Camera myCam;
    [SerializeField] private Camera myCam3;
    [SerializeField] private Camera myCamFront;
    [SerializeField] private LayerMask Ground;


    private Rigidbody myRig;
    Transform myTr;
    private Animator playerAnimator;

    [SerializeField] private Image runGauge;
    [SerializeField] GameObject DrawPannel;
    [SerializeField] TextMeshProUGUI Comtext;
    Vector3 moveVac;
    public Vector3 respawnPosition = Vector3.zero;
    public bool isOpenPannel;
   public bool MouseOpen = false;



    void Start()
    {
        myTr = transform;
        Cursor.lockState = CursorLockMode.Locked;
        myRig = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        PlayerLoad();
    }

    void Update()
    {
        if (!GameManager.instance.isPannelOpen)
        {
            Move();
            CameraRotation();
            CharacterRotation();
            CamChange();
            Jump();
        }
        PlayerSave();
        if (Input.GetKeyDown(KeyCode.Escape)&& !MouseOpen)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && MouseOpen)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    // 플레이어 이동
    private void Move()
    {
        float _moveDirX = Input.GetAxisRaw("Horizontal");
        float _moveDirZ = Input.GetAxisRaw("Vertical");
        Vector3 _moveHorizontal = transform.right * _moveDirX;
        Vector3 _moveVertical = transform.forward * _moveDirZ;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * Speed;
        moveVac = new Vector3(_moveDirX, 0, _moveDirZ).normalized;

        myRig.MovePosition(transform.position + _velocity * Time.deltaTime);

        playerAnimator.SetBool("isWalk", moveVac != Vector3.zero);


        if (Input.GetKeyDown(KeyCode.LeftShift) && playerAnimator.GetBool("isWalk") == true)
        {
            isRunning = true;
            Speed = 50;
            playerAnimator.SetBool("isRun", moveVac != Vector3.zero);
        }

        if ((Input.GetKeyUp(KeyCode.LeftShift) && playerAnimator.GetBool("isRun") == true) || runGauge.fillAmount <= 0)
        {
            isRunning = false;
            Speed = 30;
            playerAnimator.SetBool("isRun", moveVac == Vector3.zero);
        }
        if (isRunning == false)
        {
            Speed = 30;
            playerAnimator.SetBool("isRun", false);
        }
    }
    private void CharacterRotation()  // 좌우 캐릭터 회전
    {
        float _yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 _characterRotationY = new Vector3(0f, _yRotation, 0f) * mouseSensitivity;
        myRig.MoveRotation(myRig.rotation * Quaternion.Euler(_characterRotationY));
    }

    void Jump()
    {
        float _moveDirY = Input.GetAxis("Jump");
        Vector3 _Jump = transform.up * _moveDirY;
        if (Input.GetKeyDown(KeyCode.Space)) //점프 키가 눌렸을 때
        {
            if (isjumping == false) //점프 중이지 않을 때
            {
                myRig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //위쪽으로 힘을 준다.

                isjumping = true;
                playerAnimator.SetBool("isJump", true);
                Invoke("DelayDownForce", 1.4f);
            }
            else return; //점프 중일 때는 실행하지 않고 바로 return.
        }
    }
    void DelayDownForce()
    {
        myRig.AddForce(Vector3.down * jumpForce * 2f, ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            isjumping = false;
            playerAnimator.SetBool("isJump", false);
        }
    }
    private void CameraRotation() // 카메라 회전
    {
        float _xRotation = Input.GetAxisRaw("Mouse Y");
        float _cameraRotationX = _xRotation * mouseSensitivity;

        currentCamRotX -= _cameraRotationX;
        currentCamRotX = Mathf.Clamp(currentCamRotX, -camRotLim, camRotLim);

        myCam.transform.localEulerAngles = new Vector3(currentCamRotX, 0f, 0f);
        myCam3.transform.localEulerAngles = new Vector3(currentCamRotX, 0f, 0f);
        myCamFront.transform.localEulerAngles = new Vector3(180, 0f, 180);
    }
    private void CamChange() // 플레이어 카메라 전환
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            myCam.enabled = true;
            myCam3.enabled = false;
            myCamFront.enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.F2))
        {
            myCam.enabled = false;
            myCam3.enabled = true;
            myCamFront.enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.F3))
        {
            myCam.enabled = false;
            myCam3.enabled = false;
            myCamFront.enabled = true;
        }
    }
    public void Respawn()
    {
        myRig.velocity = Vector3.zero;
        transform.position = respawnPosition + Vector3.up * 10;
        Vector3 myRot = new Vector3(0, 0, 0);
        transform.rotation = Quaternion.Euler(myRot);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SlotMachine"))
        {
            Comtext.text = "근처에서 Z키를 눌러 아이템 뽑기창을 열어봐!";
        }
        if (other.CompareTag("SlotMachine") && Input.GetKeyDown(KeyCode.Z))
        {
            Comtext.text = "근처에서 Z키를 눌러 아이템 뽑기창을 열어봐!";
            Cursor.lockState = CursorLockMode.None;
            DrawPannel.SetActive(true);
            GameManager.instance.isPannelOpen = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("SlotMachine"))
        {
            Comtext.text = "근처에서 Z키를 눌러 아이템 뽑기창을 열어봐!";
        }
        if (other.CompareTag("SlotMachine") && Input.GetKeyDown(KeyCode.Z))
        {
            Comtext.text = "근처에서 Z키를 눌러 아이템 뽑기창을 열어봐!";
            Cursor.lockState = CursorLockMode.None;
            DrawPannel.SetActive(true);
            GameManager.instance.isPannelOpen = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SlotMachine"))
        {
            Comtext.text = "숨겨진 포탈을 찾아 미니게임을 플레이해봐!";
        }
    }
    void PlayerSave()
    {
        GameManager.LastPlayerSave = new Vector3(myTr.position.x, myTr.position.y+3, myTr.position.z);
    }
    void PlayerLoad()
    {
        myTr.position = GameManager.LastPlayerSave;
    }
}
