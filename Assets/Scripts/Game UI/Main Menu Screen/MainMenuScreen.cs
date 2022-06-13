using System.Collections;
using System.Collections.Generic;
using Developed.ScriptableObjects.Variables;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScreen : MonoBehaviour
{
    [SerializeField] private FloatVariable loadingState;

    [SerializeField] private Canvas selectionCanvas;
    [SerializeField] private Canvas mainMenu;


    // Start is called before the first frame update
    void Start()
    {
        loadingState.SetValue(1);
    }


    public void StartGame()
    {
        mainMenu.enabled = false;
        selectionCanvas.enabled = true;
    }
    public void Quit() => Application.Quit();
}
