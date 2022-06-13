using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for handling weapon state
/// </summary>
public class WeaponState
{
    private IEntitySpawnProvider projectileSpawn;
    private LauncherData[] launchers;

    public float chargeState { get; private set; }

    public float chargeCooldown { get; private set; }
    public float fireCooldown { get; private set; }

    public int maxCharges { get; private set; }


    public WeaponState(WeaponData weaponData)
    {
        this.projectileSpawn = weaponData.projectileData;
        this.launchers = weaponData.launchers;

        this.chargeCooldown = weaponData.oneChargeCooldown;
        this.fireCooldown = weaponData.fireCooldown;

        this.maxCharges = weaponData.maxCharges;
    }


    public void SetCurrentCharges(float value)
    {
        chargeState = Mathf.Clamp(value, 0, maxCharges);
    }

    public EntitySpawnData[] GetProjectileSpawns(Vector3 position, Vector2 direction)
    {
        var result = new List<EntitySpawnData>();

        foreach (var launcher in launchers)
            result.AddRange(launcher.Fire(projectileSpawn, position, direction));

        return result.ToArray();
    }
}