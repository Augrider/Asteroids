using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Data/Player Data")]
public class PlayerData : ScriptableObject
{
    public WeaponData primary;
    public WeaponData special;

    public float maxAcceleration;
    public float maxRotationSpeed;

    public IEntitySpawnProvider playerSpawnProvider => playerObjectData;
    [SerializeField] private SpaceEntityData playerObjectData;
}
