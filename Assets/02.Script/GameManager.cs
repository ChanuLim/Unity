using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<int> ItemID = new List<int>();
    public List<string> ItemName = new List<string>();
    public List<string> ItemDis = new List<string>();

    public int playerShine;
    public int playerGrape;

    public int MazeCount=1;
    public bool isFirst=true;
    public bool isPannelOpen=false;

    public static Vector3 LastPlayerSave = new Vector3(524, 65, 365f);

    private void Update()
    {
        if (playerGrape > 9)
        {
            playerGrape = playerGrape - 10;
            playerShine = playerShine + 1;
        }
    }
    void Awake()
    {

        var obj = FindObjectsOfType<GameManager>();
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        instance = this;
    }

}