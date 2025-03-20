using MAUI_documentation_project.Extensions;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;

namespace MAUI_documentation_project;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        }).RegisterShellRoutes().UseMauiCommunityToolkit();
#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}