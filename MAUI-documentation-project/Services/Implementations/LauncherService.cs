using MAUI_documentation_project.Services.Interfaces;

namespace MAUI_documentation_project.Services.Implementations;

public class LauncherService : ILauncherService
{
    public async Task OpenAsync(string url)
    {
        if (string.IsNullOrEmpty(url))
        {
            return;
        }
        
        await Launcher.Default.OpenAsync(url);
    }
}