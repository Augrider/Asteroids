using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class HighScoreToJSON
{
    private string fileName;


    public HighScoreToJSON(string name)
    {
        this.fileName = name + "HighScore.json";
    }


    public int Load(out int highestWave)
    {
        var dataString = "";

        if (System.IO.File.Exists(GetFilePath(fileName)))
            dataString = System.IO.File.ReadAllText(GetFilePath(fileName));

        if (string.IsNullOrEmpty(dataString))
        {
            highestWave = 0;
            return 0;
        }

        var highScoreData = JsonUtility.FromJson<HighScoreData>(dataString);

        highestWave = highScoreData.highestWave;
        return highScoreData.highScore;
    }

    public void Save(int highScore, int highestWave)
    {
        var dataString = JsonUtility.ToJson(new HighScoreData(highScore, highestWave));
        System.IO.File.WriteAllText(GetFilePath(fileName), dataString);
    }



    private string GetFilePath(string fileName)
    {
        return System.IO.Path.Combine(Application.persistentDataPath, fileName);
    }


    [Serializable]
    private struct HighScoreData
    {
        public int highScore;
        public int highestWave;


        public HighScoreData(int highScore, int highestWave)
        {
            this.highScore = highScore;
            this.highestWave = highestWave;
        }
    }
}