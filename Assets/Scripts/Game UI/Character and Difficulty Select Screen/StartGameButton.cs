using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameButton : MonoBehaviour
{
    [SerializeField] private Canvas selectionCanvas;
    [SerializeField] private Canvas mainMenu;


    public void StartGame() => SceneLoaderLocator.service.ToGame();

    public void Back()
    {
        selectionCanvas.enabled = false;
        mainMenu.enabled = true;
    }
}
