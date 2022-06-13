using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerOperation
{
    void Run(IPlayerOperationInput input, IPlayerOperationOutput output, float deltaTime);
}
