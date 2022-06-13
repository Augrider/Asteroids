using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOnDeathBehavior
{
    void Invoke(ISpaceEntity self);
}