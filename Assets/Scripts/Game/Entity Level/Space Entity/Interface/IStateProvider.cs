using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateProvider
{
    bool destroyed { get; set; }
    bool outOfBounds { get; set; }
}