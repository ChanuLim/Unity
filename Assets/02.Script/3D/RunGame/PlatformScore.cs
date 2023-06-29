using Autodesk.Fbx;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlatformScore : MonoBehaviour
{
    Transform myTr;
    float xPosition;
    float yPosition;
    float zPosition;
    float _xPosition;
    float _yPosition;
    float _zPosition;
    public GameObject Grape;
    public GameObject Shine;
    int RandomCountGrape;
    int RandomCountShine;

    bool isCreate = false;

    void Start()
    {
        myTr = GetComponent<Transform>();
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {


    }
    void Spawn() 
    {
        RandomCountGrape = UnityEngine.Random.Range(150, 300);
        RandomCountShine = UnityEngine.Random.Range(70, 150);
        
        
        if (!isCreate)
        {
            for (int i = 0; i < RandomCountGrape; i++)
            {
                float xPosition = UnityEngine.Random.Range(-3.5f, 5.5f);
                float yPosition = UnityEngine.Random.Range(0.7f, 2.2f);
                float zPosition = UnityEngine.Random.Range(16f, 865f);
                Vector3 RandomSpawn = new Vector3(xPosition, yPosition, zPosition);
                GameObject grape = Instantiate(Grape, RandomSpawn, Quaternion.identity);
                grape.transform.SetParent(this.transform);
            }
            for (int i = 0; i < RandomCountShine; i++)
            {
                float _xPosition = UnityEngine.Random.Range(-3.5f, 5.5f);
                float _yPosition = UnityEngine.Random.Range(0.7f, 2.2f);
                float _zPosition = UnityEngine.Random.Range(16f, 865f);
                Vector3 _RandomSpawn = new Vector3(_xPosition, _yPosition, _zPosition);
                GameObject shine = Instantiate(Shine, _RandomSpawn, Quaternion.identity);
                shine.transform.SetParent(this.transform);
            }
            isCreate = true;
        }
    }


}
