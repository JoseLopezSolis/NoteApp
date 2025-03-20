using CommunityToolkit.Maui;
using MAUI_documentation_project.Helpers;
using MAUI_documentation_project.ViewModels;
using MAUI_documentation_project.Views;

namespace MAUI_documentation_project.Extensions;

public static class MauiProgramExtension
{
    /// <summary>
    /// Register all viewmodels
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
    {
        // builder.Services.AddTransient<AllNotesPage, AllNotesPageViewModel>();
        builder.Services.AddTransient<AboutPage, AboutPageViewModel>();
        
        return builder;
    }
    
    /// <summary>
    /// Register all shell routes
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static MauiAppBuilder RegisterShellRoutes(this MauiAppBuilder builder)
    {
        builder.Services.AddTransientWithShellRoute<NotePage, NotePageViewModel>(RouteConstants.NotePageRoute);
        
        return builder;
    }
    
    /// <summary>
    /// Register all services
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static MauiAppBuilder RegisteServices(this MauiAppBuilder builder)
    {
                
        return builder;
    }
}