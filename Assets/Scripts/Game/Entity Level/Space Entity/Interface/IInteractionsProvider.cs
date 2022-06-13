using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractionsProvider
{
    void OnCollision(ISpaceEntity self, ISpaceEntity other);
}