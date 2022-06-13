using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputProvider
{
    InputData GetInputData(float maxAcceleration, float maxRotationSpeed, PlayerState playerState);
}
