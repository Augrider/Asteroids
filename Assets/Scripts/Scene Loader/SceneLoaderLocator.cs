public static class SceneLoaderLocator
{
    public static ISceneLoader service { get; private set; }


    public static void Provide(ISceneLoader value)
    {
        service = value;
        // service = value != null ? value : nullService;
    }
}