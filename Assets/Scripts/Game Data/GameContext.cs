using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameContext : ScriptableObject
{
    public GameDifficulty gameDifficulty;
    public PlayerData playerData;


    public void UpdateHighScore(int currentScore, int currentWave)
    {
        var highScore = GetHighScore(out var highestWave);

        if (currentScore > highScore)
            highScore = currentScore;

        if (currentWave > highestWave)
            highestWave = currentWave;

        var highScoreSaver = new HighScoreToJSON(gameDifficulty.name);
        highScoreSaver.Save(highScore, highestWave);
    }

    public int GetHighScore(out int highestWave)
    {
        var highScoreSaver = new HighScoreToJSON(gameDifficulty.name);

        return highScoreSaver.Load(out highestWave);
    }
}