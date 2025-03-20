using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI_documentation_project.Models;
using MAUI_documentation_project.ViewModels.Base;

namespace MAUI_documentation_project.ViewModels;

public partial class AboutPageViewModel : BaseViewModel
{
    // Property for holding About information (this could be a Model)
    [ObservableProperty]
    private About _about = new About();

    // Command for handling the "Learn More" button click
    [RelayCommand]
    private async Task LearnMore()
    {
        if (!string.IsNullOrWhiteSpace(About.MoreInfoUrl))
            await Launcher.Default.OpenAsync(About.MoreInfoUrl);
    }
}