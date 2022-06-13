using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class BaseOnDeathBehavior : ScriptableObject, IOnDeathBehavior
{
    public abstract void Invoke(ISpaceEntity self);
}
