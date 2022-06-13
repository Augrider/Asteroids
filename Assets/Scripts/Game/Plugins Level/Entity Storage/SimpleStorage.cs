using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SimpleStorage : MonoBehaviour, IEntityStorage
{
    private Dictionary<ISpaceEntity, GameObject> entities = new Dictionary<ISpaceEntity, GameObject>();


    void Awake()
    {
        EntityStorageLocator.Provide(this);
    }

    void OnDestroy()
    {
        EntityStorageLocator.Provide(null);
    }


    public ISpaceEntity CreateEntity(IEntitySpawnProvider entitySpawn, Vector3 position, Vector2 direction)
    {
        (var entityObject, var entity) = entitySpawn.GetNewEntity(transform, position, direction);
        entities.Add(entity, entityObject);

        return entity;
    }

    public ISpaceEntity[] GetSpaceEntities()
    {
        return entities.Keys.ToArray();
    }

    public void RemoveEntity(ISpaceEntity entity)
    {
        MonoBehaviour.Destroy(entities[entity]);

        entities.Remove(entity);
    }
}
