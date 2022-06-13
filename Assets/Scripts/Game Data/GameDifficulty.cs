using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Data/Difficulty Data")]
public abstract class GameDifficulty : ScriptableObject
{
    public abstract EntitySpawnData[] GetWaveEntities(int currentWave, Bounds bounds);
}