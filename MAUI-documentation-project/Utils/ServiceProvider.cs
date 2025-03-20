public static class ServiceProvider
{
    public static TService? GetService<TService>()
        => Current != null
            ? Current.GetService<TService>()
            : default;
    
    public static object? GetService(Type serviceType)
        => Current != null
            ? Current.GetService(serviceType)
            : default;

    private static IServiceProvider? Current => IPlatformApplication.Current?.Services;
}