using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEditor;

public class PlayerMoveMaze : MonoBehaviour
{
    [SerializeField] private float Speed = 10f;
    [SerializeField] private float mouseSensitivity = 1f;

    private float currentCamRotX;
    private bool isRunning = false;



    [SerializeField] private float camRotLim;
    [SerializeField] private Camera myCam;
    [SerializeField] private Camera myCam3;
    [SerializeField] private LayerMask Ground;
    private Rigidbody myRig;
    Transform myTr;
    private Animator playerAnimator;

    [SerializeField] private Image runGauge;

    Vector3 moveVac;



    void Start()
    {
        myTr= transform;
        Cursor.lockState = CursorLockMode.Locked;
        myRig = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        myCam.enabled = false;
        myCam3.enabled = true;
    }

    void Update()
    {
        if (MazeGameManager.instance.isStart)
        {
            Move();
            CameraRotation();
            CharacterRotation();
            CamChange();
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
            Speed = 12;
            playerAnimator.SetBool("isRun", moveVac != Vector3.zero);
        }

        if ((Input.GetKeyUp(KeyCode.LeftShift) && playerAnimator.GetBool("isRun") == true)|| runGauge.fillAmount <= 0)
        {
            isRunning = false;
            Speed = 12;
            playerAnimator.SetBool("isRun", moveVac == Vector3.zero);
        }
        if (isRunning==false)
        {
            Speed = 7;
            playerAnimator.SetBool("isRun", false);
        }
    }
    private void CharacterRotation()  // 좌우 캐릭터 회전
    {
        float _yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 _characterRotationY = new Vector3(0f, _yRotation, 0f) * mouseSensitivity;
        myRig.MoveRotation(myRig.rotation * Quaternion.Euler(_characterRotationY));
    }
    private void CameraRotation() // 카메라 회전
    {
        float _xRotation = Input.GetAxisRaw("Mouse Y");
        float _cameraRotationX = _xRotation * mouseSensitivity;

        currentCamRotX -= _cameraRotationX;
        currentCamRotX = Mathf.Clamp(currentCamRotX, -camRotLim, camRotLim);

        myCam.transform.localEulerAngles = new Vector3(currentCamRotX, 0f, 0f);
        myCam3.transform.localEulerAngles = new Vector3(currentCamRotX, 0f, 0f);
    }
    private void CamChange() // 플레이어 카메라 전환
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            myCam.enabled = true;
            myCam3.enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.F2))
        {
            myCam.enabled = false;
            myCam3.enabled = true;
        }
    }
}
