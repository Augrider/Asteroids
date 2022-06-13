using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityEventsHandler : MonoBehaviour
{
    [SerializeField] private SpaceEntity ownEntity;
    [SerializeField] private LayerMask collisionLayers;


    private void OnBecameInvisible()
    {
        ownEntity.state.outOfBounds = true;
    }

    private void OnBecameVisible()
    {
        ownEntity.state.outOfBounds = false;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.TryGetComponent<SpaceEntity>(out var entity))
            return;

        if (ownEntity == entity)
            return;

        if (entity.state.destroyed)
            return;

        if ((collisionLayers.value & 1 << entity.gameObject.layer) > 0)
            ownEntity.interactions.OnCollision(ownEntity, entity);
    }
}
