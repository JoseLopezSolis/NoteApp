using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI_documentation_project.Services.Interfaces;
using MAUI_documentation_project.ViewModels.Base;

namespace MAUI_documentation_project.ViewModels;

public partial class NotePageViewModel : BaseViewModel
{
    #region Observable_properties
    [ObservableProperty]
    private string filename;

    [ObservableProperty]
    private string text;

    [ObservableProperty]
    private DateTime date;

    #endregion
    
    public NotePageViewModel(INavigationService navigationService) : base(navigationService)
    {
    }
    
    #region Public_methods
    public void LoadNote(string fileName)
    {
        Filename = fileName;

        if (File.Exists(fileName))
        {
            Date = File.GetCreationTime(fileName);
            Text = File.ReadAllText(fileName);
        }
    }
    #endregion
    
    #region Relay_commands
    [RelayCommand]
    private async Task SaveNote()
    {
        if (!string.IsNullOrWhiteSpace(Filename))
        {
            File.WriteAllText(Filename, Text);
            await NavigationService.GoBackAsync();
        }
    }
    
    [RelayCommand]
    private async Task DeleteNote()
    {
        if (!string.IsNullOrWhiteSpace(Filename) && File.Exists(Filename))
        {
            File.Delete(Filename);
            await NavigationService.GoBackAsync();
        }
    }
    #endregion
}