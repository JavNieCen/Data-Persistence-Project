using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{
    public static DataPersistenceManager Instance;

    public string highScoreText;
    public int highScore;
    public int bestScore;
    public string playerName;
    public string bestPlayer;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);        
    }

    [Serializable]
    class SaveData
    {
        public string playerName = "";
        public int highScore = 0;
    }

    public void SaveHighScore(int score)
    {
        bestScore = score;
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.highScore = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            bestPlayer = data.playerName;
        }
    }
}
