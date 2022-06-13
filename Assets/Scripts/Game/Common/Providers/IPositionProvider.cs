using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPositionProvider
{
    Vector2 value { get; }

    void SetPosition(Vector2 value);
}