using CommunityToolkit.Mvvm.Input;
using MAUI_documentation_project.Services;
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
        ILauncherService launcherService, ILiteDbService liteDbService) : base(navigationService ,liteDbService)
    {
        _launcherService = launcherService;
    }

    #region Relay Commands

    // Command for handling the "Learn More" button click
    [RelayCommand]
    private async Task LearnMore()
    {
        // await _launcherService.OpenAsync(MoreInfoUrl);
        // await NavigationService
        //     .GoToAsync(
        //         RouteConstants.NotePageRoute, 
        //         new Dictionary<string, object>
        //         {
        //             { nameof(NotePage.ItemId), SelectedNote.Filename }
        //         });
        if (!string.IsNullOrWhiteSpace(MoreInfoUrl))
            await _launcherService.OpenAsync(MoreInfoUrl);
            // await _launcherService.OpenAsync(MoreInfoUrl);
    }

    #endregion
}