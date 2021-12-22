using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEditor;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //public int[] Scores = new int[10];
    //public string[] PlayerNames = new string[10];
    public KeepData scoreData { get; set; }
    public string playerName;
    public int score;

    public GameManager()
    {
        scoreData = new KeepData();
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadData();
    }

    [System.Serializable]
    public class KeepData
    {
        public int[] Scores = new int[10];
        public string[] PlayerNames = new string[10];
        public ArrayList abc;
    }
    
    public void SaveData()
    { 
        string path = Application.persistentDataPath + "/savefile.json";
        File.WriteAllText(path, JsonUtility.ToJson(scoreData));
        Debug.Log($"file path: {path}");

    }

    //Load saved data at startup
    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            scoreData = JsonUtility.FromJson<KeepData>(json);
           
        }
    }
    //Place player's score and name into scoreboard if it's in the top 10
    public void HighScoreSorter(int score, string playerName)
    {
        int scoreBeatenAtIndex = Array.FindIndex(scoreData.Scores, el => el < score);
        Debug.Log(scoreBeatenAtIndex);
        List<int> tempScores = new List<int>(scoreData.Scores);
        List<string> tempNames = new List<string>(scoreData.PlayerNames);
        
        if (scoreBeatenAtIndex > -1)
        {
            tempScores.Insert(scoreBeatenAtIndex, score);
            tempScores.RemoveRange(10, tempScores.Count - 10);
            tempNames.Insert(scoreBeatenAtIndex, playerName);
            tempNames.RemoveRange(10, tempNames.Count - 10);

            scoreData.Scores = tempScores.ToArray();
            scoreData.PlayerNames = tempNames.ToArray();

        } else
        {
            Debug.Log($"Not in Top 10");
        }

    }

    public void UpdateScore(int latestScore)
    {
        score = latestScore;
        HighScoreSorter(score, playerName);
        SaveData();
    }

    public void Exit()
    {
        SaveData();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }





}
