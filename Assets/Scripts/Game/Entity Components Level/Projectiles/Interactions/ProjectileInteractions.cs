using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileInteractions : IInteractionsProvider
{
    protected bool pierce = false;


    public ProjectileInteractions(bool pierce)
    {
        this.pierce = pierce;
    }


    public virtual void OnCollision(ISpaceEntity self, ISpaceEntity other)
    {
        if (!pierce)
            self.state.destroyed = true;

        other.interactions.OnCollision(other, self);
    }
}
