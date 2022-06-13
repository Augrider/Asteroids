using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntitySpawnProvider
{
    /// <summary>
    /// Instantiate object used in game
    /// </summary>
    (GameObject, ISpaceEntity) GetNewEntity(Transform parent, Vector3 position, Vector2 direction);
}