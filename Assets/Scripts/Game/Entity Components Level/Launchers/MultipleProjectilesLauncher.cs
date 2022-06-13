using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Data/Weapons/Launchers/Multiple Projectiles Launcher")]
public class MultipleProjectilesLauncher : LauncherData
{
    public int projectileAmount;
    public float angleSpread;


    public override EntitySpawnData[] Fire(IEntitySpawnProvider projectile, Vector3 position, Vector2 direction)
    {
        var originPoint = GetOriginPoint(position, direction);
        var originDirection = GetOriginDirection(direction);
        var result = new EntitySpawnData[projectileAmount];

        var spreadCone = angleSpread * (projectileAmount - 1);

        for (int i = 0; i < projectileAmount; i++)
        {
            var projectileDirection = GetDirection(originDirection, i * angleSpread - spreadCone / 2);

            result[i] = new EntitySpawnData(projectile, originPoint, projectileDirection);
        }

        return result;
    }



    private Vector2 GetDirection(Vector2 direction, float deviation)
    {
        return Rotate(direction, deviation);
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
