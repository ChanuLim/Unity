using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public List<int> ItemID = new List<int>();
    public List<string> ItemName = new List<string>();
    public List<string> ItemDis = new List<string>();

    public int grape;
    public int shine;
    public Vector3 LastPlayerSave;
}

public class DataManager : MonoBehaviour
{
    string path;
    private void Awake()
    {
        var obj = FindObjectsOfType<DataManager>();
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        path = Path.Combine(Application.dataPath, "database.json");
        JsonLoad();

    }

    public void JsonLoad()
    {
        SaveData saveData = new SaveData();

        if (!File.Exists(path))
        {
            GameManager.instance.playerGrape = 0;
            GameManager.instance.playerShine = 0;
            JsonSave();
        }
        else
        {
            string loadJson = File.ReadAllText(path);
            saveData = JsonUtility.FromJson<SaveData>(loadJson);

            if (saveData != null)
            {
                for (int i = 0; i < saveData.ItemID.Count; i++)
                {
                    GameManager.instance.ItemID.Add(saveData.ItemID[i]);
                }
                for (int i = 0; i < saveData.ItemName.Count; i++)
                {
                    GameManager.instance.ItemName.Add(saveData.ItemName[i]);
                }
                for (int i = 0; i < saveData.ItemDis.Count; i++)
                {
                    GameManager.instance.ItemDis.Add(saveData.ItemDis[i]);
                }
                GameManager.instance.playerGrape = saveData.grape;
                GameManager.instance.playerShine = saveData.shine;
                GameManager.LastPlayerSave = saveData.LastPlayerSave;
            }
        }
    }

    public void JsonSave()
    {
        SaveData saveData = new SaveData();


        for (int i = 0; i < 10; i++)
        {
            saveData.ItemID.Add(i);
        }
        for (int i = 0; i < 10; i++)
        {
            saveData.ItemName.Add("아이템 이름 : " + i);
        }  
        for (int i = 0; i < 10; i++)
        {
            saveData.ItemDis.Add("아이템 설명 :  " + i);
        }

        saveData.grape = GameManager.instance.playerGrape;
        saveData.shine = GameManager.instance.playerShine;
        saveData.LastPlayerSave = GameManager.LastPlayerSave;
        string json = JsonUtility.ToJson(saveData, true);

        File.WriteAllText(path, json);
    }
}