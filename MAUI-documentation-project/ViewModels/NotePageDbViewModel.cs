using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI_documentation_project.Models;
using MAUI_documentation_project.Services.database;
using MAUI_documentation_project.Services.Interfaces;
using MAUI_documentation_project.ViewModels.Base;
namespace MAUI_documentation_project.ViewModels;

public partial class NotePageDbViewModel : BaseViewModel
{
    #region Observable_properties
    [ObservableProperty]
    private string text;

    [ObservableProperty]
    private DateTime date;

    #endregion
    
    public NotePageDbViewModel(INavigationService navigationService, ILiteDbService liteDbService) : base(navigationService, liteDbService)
    {
    }
    #region Relay_commands
    [RelayCommand]
    private async Task SaveCurrentNote()
    {
        if (!string.IsNullOrWhiteSpace(Text))
        {
            DbService.InsertNote(new NoteDb() { BodyNote = Text, Date = DateTime.Now });
            // var notas = DbService.GetAllNotes();
            await NavigationService.GoBackAsync();
        }
    }
    #endregion
}