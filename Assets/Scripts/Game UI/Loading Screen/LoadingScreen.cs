using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private Developed.ScriptableObjects.Variables.FloatVariable loadingState;
    [SerializeField] private Canvas loadingCanvas;


    void Awake()
    {
        loadingState.ValueChanged += OnValueChanged;
    }

    void OnDestroy()
    {
        loadingState.ValueChanged -= OnValueChanged;
    }



    private void OnValueChanged(float value)
    {
        loadingCanvas.enabled = value < 1;

        // if (value >= 1)
        //     return;
    }
}
