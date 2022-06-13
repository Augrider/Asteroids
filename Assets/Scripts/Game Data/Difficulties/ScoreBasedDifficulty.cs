using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Data/Difficulty/Spawn Score Based")]
public class ScoreBasedDifficulty : GameDifficulty
{
    [SerializeField] private SpaceEntityData mainSpawn;
    [SerializeField] private SpawnRecord[] secondarySpawns;

    [SerializeField] protected int startingPoints;
    [SerializeField] protected int wavePoints;


    public override EntitySpawnData[] GetWaveEntities(int currentWave, Bounds bounds)
    {
        var totalPoints = startingPoints + wavePoints * (currentWave - 1);
        var entityList = new List<EntitySpawnData>();
        var edgesSpawn = new EdgesSpawnHandler(bounds);

        foreach (var spawn in secondarySpawns)
        {
            if (spawn.minimalWave > currentWave)
                continue;

            var amount = GetEntitiesAmount(totalPoints, spawn.spawnCost, spawn.maxAmount);

            for (int j = 0; j < amount; j++)
                entityList.Add(GetSpawnData(spawn.entitySpawnData, edgesSpawn));

            totalPoints -= spawn.spawnCost * amount;
        }

        for (int j = 0; j < totalPoints; j++)
            entityList.Add(GetSpawnData(mainSpawn, edgesSpawn));

        return entityList.ToArray();
    }



    private EntitySpawnData GetSpawnData(IEntitySpawnProvider entitySpawn, ISpawnPlacementProvider spawnPlacement)
    {
        (var position, var direction) = spawnPlacement.GetPositionAndDirection();

        return new EntitySpawnData(entitySpawn, position, direction);
    }


    private int GetEntitiesAmount(int totalPoints, int spawnCost, int maxAmount)
    {
        var amount = totalPoints / spawnCost;

        if (maxAmount <= 0)
            amount = Mathf.Min(totalPoints / spawnCost, maxAmount);

        return Random.Range(0, amount);
    }



    [System.Serializable]
    private struct SpawnRecord
    {
        public SpaceEntityData entitySpawnData;

        public int spawnCost;
        public int minimalWave;
        public int maxAmount;
    }
}
