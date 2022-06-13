using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EntityStorageLocator
{
    private static IEntityStorage nullService { get; } = new NullEntityStorage();
    public static IEntityStorage service { get; private set; } = nullService;


    public static void Provide(IEntityStorage value)
    {
        Debug.Log($"Provided with {value}");
        service = value != null ? value : nullService;
    }
}