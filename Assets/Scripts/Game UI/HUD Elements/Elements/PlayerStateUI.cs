using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStateUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI positionText;
    [SerializeField] private TextMeshProUGUI orientationText;
    [SerializeField] private TextMeshProUGUI speedText;


    public void UpdateDisplay(Vector3 position, float angle, float speed)
    {
        positionText.SetText(position.ToString("F0"));
        orientationText.SetText(angle.ToString("F1"));
        speedText.SetText(speed.ToString("F1"));
    }
}
