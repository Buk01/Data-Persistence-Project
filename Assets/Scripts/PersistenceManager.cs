using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class PersistenceManager : MonoBehaviour
{
    public static PersistenceManager Instance;
    public string playerName;
    public int highScore;
    public string highScoreName;
    public TextMeshProUGUI HighScoreText;
    [System.Serializable]
    class PlayerData
    {
        public string name;
        public int score;
    }

    public void GetName()
    {
        playerName = GameObject.Find("Name Input").GetComponent<TMP_InputField>().text;
    }

    public void SetHighScore(int score)
    {
        highScore = score;
    }

    public void SaveData()
    {
        PlayerData data = new PlayerData();
        data.name = playerName;
        data.score = highScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        highScoreName = playerName;
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);
            highScoreName = data.name;
            highScore = data.score;
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // This object will not be destroyed when loading a new scene
            LoadData();
        }
        else
        {
            Destroy(gameObject); // Destroy the new object if there is already one
        }
    }
}
