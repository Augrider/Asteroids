using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameRule
{
    bool Check(GameSessionState gameState, GameContext gameContext, SceneContext sceneContext);
}
