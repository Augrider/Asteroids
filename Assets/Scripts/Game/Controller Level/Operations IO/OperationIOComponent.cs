using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OperationIOComponent
{
    protected GameContext gameContext;
    protected SceneContext sceneContext;
    protected GameSessionState gameState;


    public OperationIOComponent(GameContext gameContext, SceneContext sceneContext, GameSessionState gameState)
    {
        this.gameContext = gameContext;
        this.sceneContext = sceneContext;
        this.gameState = gameState;
    }
}
