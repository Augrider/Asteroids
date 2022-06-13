using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Components/Projectiles/Limited Lifetime")]
public class LimitedLifetimeBehavior : BaseEntityBehavior
{
    [SerializeField] private float lifetime;
    private float currentLifetime = 0;


    public override void OnUpdate(ISpaceEntity self, PlayerState playerData, ISpaceEntity[] enemies, float deltaTime)
    {
        currentLifetime += deltaTime;

        if (currentLifetime > lifetime)
            self.state.destroyed = true;
    }
}
