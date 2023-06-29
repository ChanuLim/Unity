using UnityEngine;

public class CreatePlatformAd : MonoBehaviour
{
    public GameObject Platform; //���� ������
        
    public int count = 15;//���� ����

    public float timeBetSpawnMin = 0.4f; // ���� ��ġ���� �ּڰ�
    public float timeBetSpawnMax = 1f; // ���� ��ġ���� �ִ�
    public float timeBetSpawn;

    
    public float xMin = 93f;// ��ġ�� ��ġ�� x �ּҰ�
    public float xMax = 125f;// ��ġ�� ��ġ�� x �ִ밪
    private float yPos = -5f;
    public GameObject[] Platforms; // �̸� ������ ���ǵ�
    public int currentindex = 0;// ����� ���� ������ ����



    private Vector2 poolPosition=new Vector2(0,-25); // �ʹݿ� ������ ���ǵ��� ���ܵ� ��
    public float lastSpawnTime; //������ ��ġ ����
    
    private void Update()
    {
        if (PfAdManager.instance.isTimeover)
        {
            return;
        }
        if (Time.time >= lastSpawnTime + timeBetSpawn) 
        {
            lastSpawnTime = Time.time;
            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);

            float xPos = Random.Range(xMin, xMax);

            Platforms[currentindex].SetActive(false);
            Platforms[currentindex].SetActive(true);


            Platforms[currentindex].transform.position = new Vector2(xPos, yPos);
            currentindex++;

            if (currentindex >= count)
            {
                currentindex = 0;
            }

        }
    }
    void CurrentF() 
    {
        Platforms[currentindex].SetActive(false);
    }
    void CurrentT() 
    {
        Platforms[currentindex].SetActive(true);
    }


}
