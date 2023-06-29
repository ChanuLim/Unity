using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemSelect : MonoBehaviour
{
    public List<GetItem> deck = new List<GetItem>();  // 카드 덱
    public int total = 0;  // 카드들의 가중치 총 합

    void Start()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            // 스크립트가 활성화 되면 카드 덱의 모든 카드의 총 가중치를 구해줍니다.
            total += deck[i].weight;
        }
        // 
        ResultSelect();
    }

    public List<GetItem> result = new List<GetItem>();  // 랜덤하게 선택된 카드를 담을 리스트

    public Transform parent;
    public GameObject itemprefab;

    public void ResultSelect()
    {
        for (int i = 0; i < 10; i++)
        {
            // 가중치 랜덤을 돌리면서 결과 리스트에 넣어줍니다.
            result.Add(RandomItem());
            // 비어 있는 카드를 생성하고
            ItemUI itemUI = Instantiate(itemprefab, parent).GetComponent<ItemUI>();
            // 생성 된 카드에 결과 리스트의 정보를 넣어줍니다.
            itemUI.ItemUISet(result[i]);
            Debug.Log("44");
        }
    }
    // 가중치 랜덤의 설명은 영상을 참고.
    public GetItem RandomItem()
    {
        int weight = 0;
        int selectNum = 0;

        selectNum = Mathf.RoundToInt(total * Random.Range(0.0f, 1.0f));

        for (int i = 0; i < deck.Count; i++)
        {
            weight += deck[i].weight;
            if (selectNum <= weight)
            {
                GetItem temp = new GetItem(deck[i]);
                return temp;
            }
        }
        return null;
    }

   

}
