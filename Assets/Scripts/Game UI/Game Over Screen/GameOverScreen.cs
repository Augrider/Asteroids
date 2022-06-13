using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreCount;
    [SerializeField] private TextMeshProUGUI waveCount;
    [SerializeField] private TextMeshProUGUI highScoreText;

    [SerializeField] private Canvas gameOverCanvas;


    public void UpdateDisplay(int gameScore, int gameWave, int highestPoints, int highestWave)
    {
        gameOverCanvas.enabled = true;

        scoreCount.SetText("Score " + gameScore.ToString("D6"));
        waveCount.SetText("Wave " + gameWave.ToString());

        highScoreText.SetText("Highscore " + highestPoints.ToString("D6") + " (" + highestWave.ToString() + ")");
    }


    public void Retry() => SceneLoaderLocator.service.ToGame();
    public void ToMenu() => SceneLoaderLocator.service.ToMainMenu();
}
