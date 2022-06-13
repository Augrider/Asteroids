using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Data/Weapons/Weapon Data")]
public class WeaponData : ScriptableObject
{
    public int maxCharges = 2;
    public float oneChargeCooldown = 0.5f;
    public float fireCooldown = 1;

    public SpaceEntityData projectileData;
    public LauncherData[] launchers;
}