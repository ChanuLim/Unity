using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookatPlayer : MonoBehaviour
{
    [SerializeField] Transform PlayerTr;
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(PlayerTr);
    }
}
