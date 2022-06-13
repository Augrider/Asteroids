using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameOverOnPlayerRemoved : IGameRule
{
    public bool Check(GameSessionState gameState, GameContext gameContext, SceneContext sceneContext)
    {
        if (gameState.isPlayerAlive)
            return false;

        SetGameOver(gameState, gameContext);
        return true;
    }



    private void SetGameOver(GameSessionState gameState, GameContext gameContext)
    {
        gameContext.UpdateHighScore(gameState.currentScore, gameState.currentWave);
        var highestScore = gameContext.GetHighScore(out var highestWave);

        UIPresenterLocator.service.SetGameOver(gameState.currentScore, gameState.currentWave, highestScore, highestWave);
    }
}
