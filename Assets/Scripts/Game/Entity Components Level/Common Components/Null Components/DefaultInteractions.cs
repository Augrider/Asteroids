using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultInteractions : IInteractionsProvider
{
    public void OnCollision(ISpaceEntity self, ISpaceEntity other)
    {
        Debug.Log("Ded");
        self.state.destroyed = true;
    }
}
