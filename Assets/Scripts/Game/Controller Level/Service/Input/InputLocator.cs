using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputLocator
{
    private static IInputProvider nullService { get; } = new NullInputProvider();
    public static IInputProvider service { get; private set; } = nullService;


    public static void Provide(IInputProvider value)
    {
        service = value != null ? value : nullService;
    }
}
