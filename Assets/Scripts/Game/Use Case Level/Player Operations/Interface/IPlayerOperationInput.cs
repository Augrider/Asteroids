using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerOperationInput
{
    InputData inputData { get; }

    ISpaceEntity player { get; }
    bool isPlayerAlive { get; }

    WeaponState primary { get; }
    WeaponState special { get; }
}
