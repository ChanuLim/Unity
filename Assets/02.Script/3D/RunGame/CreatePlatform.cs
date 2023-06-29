using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreatePlatform : MonoBehaviour
{
    [SerializeField] Transform myPos;
    RaycastHit hit;
    LayerMask mask;
    public GameObject[] Platforms;
    public GameObject GoalPlatform;
    private bool IsCreate = false;
    bool isPortalCreate = false;
    int i;

  
    void Update()
    {
        hitRay();
    }
    void hitRay() 
    {
        Vector3 myVec = new Vector3(0, 0, myPos.position.z);

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            IsCreate = false;
        }
        else
        {
            IsCreate = true;
            if (IsCreate&&!RunGameManager.instance.isClearReady)
            {
                i = Random.Range(0, 8);
                Instantiate(Platforms[i], myVec, Quaternion.identity);
                IsCreate = false;
            }
            if (IsCreate && RunGameManager.instance.isClearReady && !isPortalCreate)
            {
                Instantiate(GoalPlatform, myVec, Quaternion.identity);
                isPortalCreate = true;
                IsCreate = false;
            }
        }        
    }
}