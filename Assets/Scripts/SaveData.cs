using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveData : MonoBehaviour
{
    public static SaveData instance;
    public string playerName;
    public int highScore;
    private string currentPlayerName;
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
    }

    public void SetPlayerName(string playerName)
    {
        this.playerName = playerName;
    }

    public void SetCurrentPlayerName(string name)
    {
        currentPlayerName = name;   
    } 

    public void SetHighScore(int score)
    {
        if (score > highScore)
        {
            highScore = score;
            SaveHighScore();
        }
    }

    [System.Serializable]
    class Savedata
    {
        public string playerName;
        public int highScore;
    }
    public void SaveHighScore()
    {
        Savedata savedata = new Savedata();
        savedata.playerName = currentPlayerName;
        savedata.highScore = highScore;
        playerName = currentPlayerName;

        string json = JsonUtility.ToJson(savedata);
        File.WriteAllText(Application.persistentDataPath + "/savedata.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savedata.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Savedata savedata=JsonUtility.FromJson<Savedata>(json);

            highScore = savedata.highScore;
            playerName=savedata.playerName;
        }
    }

}
