public class Startup
{
    // ...existing code...

    public void ConfigureServices(IServiceCollection services)
    {
        // ...existing code...
        services.AddHttpClient();  // <-- Añadido
        services.AddLogging();  // <-- Añadido
        // ...existing code...
    }

    // ...existing code...
}
