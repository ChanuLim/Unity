using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestAi : MonoBehaviour
{
    [SerializeField]Transform PlayerTr;
    [SerializeField]GameObject Player;
    NavMeshAgent nav;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(PlayerTr);
        nav.SetDestination(Player.transform.position);
    }
}
