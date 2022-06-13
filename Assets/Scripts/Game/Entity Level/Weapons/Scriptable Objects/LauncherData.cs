using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Data/Weapons/Launchers/Default Launcher")]
public class LauncherData : ScriptableObject
{
    [SerializeField] private Vector2 originOffset;
    [SerializeField] private Vector2 originDirection;


    public virtual EntitySpawnData[] Fire(IEntitySpawnProvider projectile, Vector3 position, Vector2 direction)
    {
        return new EntitySpawnData[] { new EntitySpawnData(projectile, GetOriginPoint(position, direction), GetOriginDirection(direction)) };
    }


    protected Vector2 GetOriginPoint(Vector2 objectPosition, Vector2 objectDirection)
    {
        var resultLinear = objectDirection * originOffset.y;
        var resultPerpendicular = -Vector2.Perpendicular(objectDirection) * originOffset.x;

        var result = resultLinear + resultPerpendicular;

        return objectPosition + result;
    }

    protected Vector2 GetOriginDirection(Vector2 objectDirection)
    {
        if (originDirection == Vector2.zero)
            return objectDirection;

        var originNormal = originDirection.normalized;

        var resultLinear = objectDirection * originNormal.y;
        var resultPerpendicular = -Vector2.Perpendicular(objectDirection) * originNormal.x;

        return resultLinear + resultPerpendicular;
    }
}
