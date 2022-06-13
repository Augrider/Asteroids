using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Developed.SceneManagement;
using System;
using Developed.ScriptableObjects.Variables;

public class GameSceneLoader : SceneLoader, ISceneLoader
{
    private enum SceneState { MainMenu, Game }

    private SceneState state;

    [SerializeField] private FloatVariable loadingState;

    [SerializeField] private ScenePackage mainMenu;
    [SerializeField] private ScenePackage gameScenes;


    protected override void Awake()
    {
        base.Awake();

        SceneLoaderLocator.Provide(this);

        this.state = SceneState.Game;
        ToMainMenu();
    }

    void OnDestroy()
    {
        SceneLoaderLocator.Provide(null);
    }


    public void ToMainMenu()
    {
        if (state == SceneState.MainMenu)
            return;

        state = SceneState.MainMenu;

        ShowLoadingScreen();
        UnloadAll();

        LoadFromScenePackage(mainMenu);
    }

    public void ToGame()
    {
        // if (state == SceneState.Game)
        //     return;

        state = SceneState.Game;

        ShowLoadingScreen();
        UnloadAll();

        LoadFromScenePackage(gameScenes);
    }



    private void ShowLoadingScreen()
    {
        loadingState.SetValue(0);
    }
}
