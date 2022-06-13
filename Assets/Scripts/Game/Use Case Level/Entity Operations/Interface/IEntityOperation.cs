using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntityOperation
{
    void Run(IEntityOperationInput input, IEntityOperationOutput output, float deltaTime);
}
