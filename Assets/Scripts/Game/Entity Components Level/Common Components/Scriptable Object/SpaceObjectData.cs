using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Entity Data/Base Object")]
public class SpaceObjectData : SpaceEntityData
{
    [SerializeField] protected SpaceEntityType entityType;
    [SerializeField] protected int scoreValue;

    [SerializeField] protected float startSpeed;
    [SerializeField] protected float startRotationSpeed;

    [SerializeField] protected PhysicsData physicsData;

    [SerializeField] protected BaseEntityBehavior[] behaviors;
    [SerializeField] protected BaseOnDeathBehavior[] onDeath;


    protected sealed override void BuildEntityComponents(SpaceEntityBuilder builder, Vector3 position, Vector2 direction)
    {
        var movement = new MovementComponent(physicsData);

        movement.speed = startSpeed * direction;
        movement.rotationSpeed = startRotationSpeed;

        builder.SetEntityType(entityType);
        builder.SetScoreValue(scoreValue);

        builder.SetMovement(movement);
        builder.SetStateComponent(new StateComponent());

        builder.ProvideBehavior(GetBehaviorComponents());
        builder.ProvideInteractions(GetInteractionsComponent());
        builder.ProvideOnDeathBehavior(onDeath);
    }



    protected virtual IInteractionsProvider GetInteractionsComponent() => new DefaultInteractions();
    protected virtual IEntityBehavior[] GetBehaviorComponents()
    {
        var result = new IEntityBehavior[behaviors.Length];
        var index = 0;

        foreach (var control in behaviors)
        {
            result[index] = Instantiate(control);
            index++;
        }

        return result;
    }
}