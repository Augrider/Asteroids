using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateComponent : IStateProvider
{
    public bool outOfBounds { get; set; }
    public bool destroyed { get; set; }
}