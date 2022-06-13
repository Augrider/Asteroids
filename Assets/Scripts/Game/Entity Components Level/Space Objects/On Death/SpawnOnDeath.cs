using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Components/On Death/Spawn Entities")]
public class SpawnOnDeath : BaseOnDeathBehavior
{
    [SerializeField] private SpaceEntityData entityData;
    [SerializeField] private int amount = 4;

    [SerializeField] private bool ignoreDirection;


    public override void Invoke(ISpaceEntity self)
    {
        if (!entityData) throw new System.Exception();

        var entitySpawnData = new EntitySpawnData(entityData, self.position.value, GetDirection(self.direction.forward, 0));

        for (int i = 0; i < amount; i++)
        {
            entitySpawnData.direction = GetDirection(self.direction.forward, i * 360f / amount);

            EventQueueLocator.service.EnqueueEntitySpawn(entitySpawnData);
        }
    }



    private Vector2 GetDirection(Vector2 entityDirection, float deviation)
    {
        if (ignoreDirection)
            return Vector2.up;

        return Rotate(entityDirection, deviation);
    }


    /// <summary>
    /// Rotate vector on specified angle
    /// </summary>
    /// <param name="value">Vector to rotate</param>
    /// <param name="degrees">Angle in degrees</param>
    /// <returns>Rotated vector</returns>
    private Vector2 Rotate(Vector2 value, float degrees)
    {
        var result = value;

        float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
        float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

        result.x = (cos * value.x) - (sin * value.y);
        result.y = (sin * value.x) + (cos * value.y);

        return result;
    }
}