using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventQueueLocator
{
    public static IEventQueue service { get; } = new EventQueue();
}