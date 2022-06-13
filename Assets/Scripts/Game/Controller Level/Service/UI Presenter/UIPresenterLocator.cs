using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UIPresenterLocator
{
    private static IUIPresenter nullService { get; } = new NullUIPresenter();
    public static IUIPresenter service { get; private set; } = nullService;


    public static void Provide(IUIPresenter value)
    {
        service = value != null ? value : nullService;
    }
}
