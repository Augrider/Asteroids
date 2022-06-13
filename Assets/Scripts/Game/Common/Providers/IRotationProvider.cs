using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDirectionProvider
{
    Vector2 forward { get; }

    void SetDirection(Vector2 value);
}