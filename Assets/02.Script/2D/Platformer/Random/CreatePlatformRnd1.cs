using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlatformRnd1 : MonoBehaviour
{
    public int count = 15;//���� ����

    public float timeBetSpawnMin = 0.4f; // ���� ��ġ���� �ּڰ�
    public float timeBetSpawnMax = 1f; // ���� ��ġ���� �ִ�
    public float timeBetSpawn;

    public float xMin = 93f;// ��ġ�� ��ġ�� x �ּҰ�
    public float xMax = 125f;// ��ġ�� ��ġ�� x �ִ밪
    private float yPos = -5f; // ���� y��
    public GameObject[] Platforms; // ���� ������
    public int crindex = 0; // ��������



    private Vector3 poolPosition; // ���ǻ�����ġ
    public float lastSpawnTime; //������ ��ġ ����


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

