using UnityEngine;

public class CreatePlatformAd : MonoBehaviour
{
    public GameObject Platform; //원본 프리팹
        
    public int count = 15;//발판 개수

    public float timeBetSpawnMin = 0.4f; // 다음 배치까지 최솟값
    public float timeBetSpawnMax = 1f; // 다음 배치까지 최댓값
    public float timeBetSpawn;

    
    public float xMin = 93f;// 배치할 위치의 x 최소값
    public float xMax = 125f;// 배치할 위치의 x 최대값
    private float yPos = -5f;
    public GameObject[] Platforms; // 미리 생성한 발판들
    public int currentindex = 0;// 사용할 현재 순서의 발판



    private Vector2 poolPosition=new Vector2(0,-25); // 초반에 생성된 발판들을 숨겨둘 곳
    public float lastSpawnTime; //마지막 배치 시점
    
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
