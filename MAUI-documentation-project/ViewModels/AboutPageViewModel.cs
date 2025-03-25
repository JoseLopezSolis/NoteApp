using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI_documentation_project.Models;
using MAUI_documentation_project.Services.Interfaces;
using MAUI_documentation_project.ViewModels.Base;

namespace MAUI_documentation_project.ViewModels;

public partial class AboutPageViewModel : BaseViewModel
{
    #region Private Properties
    private readonly ILauncherService _launcherService;
    #endregion

    #region Bindable Properties
    public string Title =>"My App";
    public string Version => "1.0.0";
    public string Message => "Welcome to my application";
    private string MoreInfoUrl  => "https://learn.microsoft.com/es-es/dotnet/maui/?view=net-maui-9.0";
    #endregion

    public AboutPageViewModel(
        INavigationService navigationService,
        ILauncherService launcherService) : base(navigationService)
    {
        _launcherService = launcherService;
    }

    #region Relay Commands

    // Command for handling the "Learn More" button click
    [RelayCommand]
    private async Task LearnMore()
    {
        if (!string.IsNullOrWhiteSpace(MoreInfoUrl))
            await _launcherService.OpenAsync(MoreInfoUrl);
    }

    #endregion
}