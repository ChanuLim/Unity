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
    // �÷��̾� �̵�
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
        if (Input.GetKeyDown(KeyCode.Space)) //���� Ű�� ������ ��
        {
            if (isjumping == false) //���� ������ ���� ��
            {
                myRig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //�������� ���� �ش�.

                isjumping = true;
                playerAnimator.SetBool("isJump", true);
                JumpSound.Play();
                Invoke("DelayDownForce", 1.4f);
            }
            else return; //���� ���� ���� �������� �ʰ� �ٷ� return.
        }
    }
    void DelayDownForce()
    {
        myRig.AddForce(Vector3.down * jumpForce * 2f, ForceMode.Impulse);
    }
    private void CamChange() // �÷��̾� ī�޶� ��ȯ
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
            ComText.text = "���� ���� ����� �ϳ� �Ҿ���!";

        }
        if (other.gameObject.CompareTag("Rock"))
        {
            other.gameObject.GetComponent<MeshCollider>().SetEnable(false);
            RunGameManager.instance.isHit = true;
            HitSound.Play();
            ComText.text = "���� �¾� ����� �ϳ� �Ҿ���!";
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Grape") && RunGameManager.instance.Score1 < 10)
        {
            RunGameManager.instance.Score1 = RunGameManager.instance.Score1 + 1;
            ComText.text = "������ 1�� ȹ���߾�!";
            audioSource.Play();
            other.gameObject.SetActive(false);
            Invoke("comTextReturn", 1.2f);
        }
        if (other.gameObject.CompareTag("Grape") && RunGameManager.instance.Score1 >= 10)
        {
            RunGameManager.instance.Score1 = RunGameManager.instance.Score1 - 10;
            RunGameManager.instance.Score2 = RunGameManager.instance.Score2 + 1;
            ComText.text = "������ 10�� ȹ���ؼ� ���θӽ��� 1���� ��ȯ�߾�!";
            audioSource.Play();
            other.gameObject.SetActive(false);
            Invoke("comTextReturn", 1.2f);
        }
        if (other.gameObject.CompareTag("Shine"))
        {
            RunGameManager.instance.Score2 = RunGameManager.instance.Score2 + 1;
            ComText.text = "���θӽ��� 1���� ȹ���߾�!";
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
        ComText.text = "��ǥ�������� ��ֹ��� ���ϰ� ������ ȹ���ϸ� ������!";
    }
    void ReturnMain()
    {
        SceneManager.LoadScene("Main");
    }
}
