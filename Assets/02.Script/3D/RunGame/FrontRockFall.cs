
using UnityEngine;


public class FrontRockFall : MonoBehaviour
{
    private Rigidbody myrigid;
    Transform myTr;

    void Start()
    {
        myrigid = GetComponent<Rigidbody>();
        myTr = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        RockForce();

    }
    void RockForce()
    {
        Vector3 Force = new Vector3(0f, 0f, -1f);
        myrigid.AddForce(Force * 1f, ForceMode.Impulse);
        if (Mathf.Abs(myrigid.velocity.z) < -6)
            myrigid.velocity = new Vector3(Mathf.Sign(myrigid.velocity.z) * -5, -5);
        Invoke("SetDestory", 15f);
    }
    void SetDestory() 
    {
        Destroy(gameObject);
    }


}
