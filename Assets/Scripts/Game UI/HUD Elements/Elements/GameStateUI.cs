using UnityEngine;
using TMPro;
using Developed.ScriptableObjects.Variables;

public class GameStateUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI waveCount;
    [SerializeField] private TextMeshProUGUI scoreCount;

    [SerializeField] private IntVariable currentWave;
    [SerializeField] private IntVariable currentScore;


    void OnEnable()
    {
        currentWave.ValueChanged += UpdateWaveCount;
        currentScore.ValueChanged += UpdateScore;
    }

    void OnDisable()
    {
        currentWave.ValueChanged -= UpdateWaveCount;
        currentScore.ValueChanged -= UpdateScore;
    }



    private void UpdateWaveCount(int newValue) => waveCount.SetText(newValue.ToString());
    private void UpdateScore(int newValue) => scoreCount.SetText(newValue.ToString("D6"));
}