using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlatformRnd : MonoBehaviour
{
    public int count = 15;//발판 개수

    public float timeBetSpawnMin = 0.4f; // 다음 배치까지 최솟값
    public float timeBetSpawnMax = 1f; // 다음 배치까지 최댓값
    public float timeBetSpawn;

    public float xMin = 93f;// 배치할 위치의 x 최소값
    public float xMax = 125f;// 배치할 위치의 x 최대값
    private float yPos = -5f; // 스폰 y값
    public GameObject[] Platforms; // 발판 프리팹
    public int crindex = 0; // 스폰순서



    private Vector3 poolPosition; // 발판생성위치
    public float lastSpawnTime; //마지막 배치 시점

    [SerializeField] GameObject frontCreate1;
    [SerializeField] GameObject frontCreate2;

    private void Start()
    {
          frontCreate1.gameObject.SetActive(false);
          frontCreate2.gameObject.SetActive(false);
    }

    private void Update()
    {

        if (PfRndManager.instance.isTimeover)
        {
            return;
        }
        if (Time.time >= lastSpawnTime + timeBetSpawn)
        {
            lastSpawnTime = Time.time;
            timeBetSpawn = UnityEngine.Random.Range(timeBetSpawnMin, timeBetSpawnMax);

            float xPos = UnityEngine.Random.Range(xMin, xMax);
            
            int crindex = UnityEngine.Random.Range(0, Platforms.Length);
            Vector3 poolPosition = new Vector3(xPos,yPos,0);
            Instantiate(Platforms[crindex], poolPosition, Platforms[crindex].transform.rotation);

        }
    }
} 

