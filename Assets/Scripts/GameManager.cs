using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;


public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public string playerName;
    private BestPlayer _bestPlayer;
    public BestPlayer BestPlayer
    {
        get { return _bestPlayer; }
        set { _bestPlayer = value; SaveData(); }
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(Instance);
        LoadData();
    }


    public void LoadMainScene()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public void SaveData()
    {
        SaveData data = new SaveData();
        data.BestPlayer = BestPlayer;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/saveFile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/saveFile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            BestPlayer = data.BestPlayer;
        }
    }

}
[Serializable]
public class BestPlayer
{
    public int score;
    public string playerName;

    public BestPlayer(string playerName, int score)
    {
        this.playerName = playerName;
        this.score = score;
    }
}

[Serializable]
public class SaveData
{
    public BestPlayer BestPlayer;
}
