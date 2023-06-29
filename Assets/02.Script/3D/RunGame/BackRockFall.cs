using UnityEngine;
public class BackRockFall : MonoBehaviour
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
        Vector3 Force = new Vector3(0, 0, 1f);
        myrigid.AddForce(Force * 2f, ForceMode.Impulse);
        if (Mathf.Abs(myrigid.velocity.z) < -6)
            myrigid.velocity = new Vector3(Mathf.Sign(myrigid.velocity.z) * -5,-5);
        Invoke("SetDestory", 15f);
    }
    void SetDestory()
    {
        Destroy(gameObject);
    }


}
