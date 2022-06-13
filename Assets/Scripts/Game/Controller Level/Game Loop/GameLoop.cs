using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    //Save some game state data in structure
    //Use Scene Context to keep references to scene objects
    //Use Game Context to save settings and player data
    //Game state should be in Game Context

    //Game rules should be entities
    //Unlike loop, they can have straight references to all data and context
    //That means that they should be in controller/plugin level
    //Two methods for init/deinit can handle subscription
    //Rules should be controlled from one class, which can also handle their lifecycle

    //Separate all details into their own plugins. They can be not just services, but abstract SO as well
    //Also details can just be normal classes, injected by initialization

    public IEntityOperation[] entityOperations { get; set; }
    public IPlayerOperation[] playerOperations { get; set; }

    public IEntityOperationInput entityOperationInput { get; set; }
    public IEntityOperationOutput entityOperationOutput { get; set; }

    public IPlayerOperationInput playerOperationInput { get; set; }
    public IPlayerOperationOutput playerOperationOutput { get; set; }


    // Update is called once per frame
    void Update()
    {
        if (playerOperationInput.isPlayerAlive)
        {
            UpdatePlayer(Time.deltaTime);
            UpdateUI();
        }

        UpdateEntities(Time.deltaTime);
    }



    private void UpdatePlayer(float deltaTime)
    {
        foreach (IPlayerOperation operation in playerOperations)
            operation.Run(playerOperationInput, playerOperationOutput, deltaTime);
    }

    private void UpdateEntities(float deltaTime)
    {
        foreach (IEntityOperation operation in entityOperations)
            operation.Run(entityOperationInput, entityOperationOutput, deltaTime);
    }


    private void UpdateUI()
    {
        UIPresenterLocator.service.UpdatePlayerState(entityOperationInput.playerState);
        UIPresenterLocator.service.UpdateWeaponDisplay(playerOperationInput.special);
    }
}
