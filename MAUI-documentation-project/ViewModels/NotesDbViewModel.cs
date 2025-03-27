using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI_documentation_project.Helpers;
using MAUI_documentation_project.Models;
using MAUI_documentation_project.Services;
using MAUI_documentation_project.Services.Interfaces;
using MAUI_documentation_project.ViewModels.Base;
using MAUI_documentation_project.Views;

namespace MAUI_documentation_project.ViewModels;

public partial class NotesDbViewModel: BaseViewModel
{
    #region Observables properties
    [ObservableProperty] 
    private ObservableCollection<NoteDb> _notes;

    [ObservableProperty] 
    private NoteDb _selectedNote;
    #endregion

    public NotesDbViewModel
        (INavigationService navigationService, ILiteDbService liteDbService): base(navigationService, liteDbService)
    {
    }

    #region Relay_Commands
    [RelayCommand]
    private async Task NoteTapped()
    {
        if (SelectedNote != null)
        {
            var parameters = new Dictionary<string, object>
            {
                { "Note", SelectedNote }
            };
            await Shell.Current.GoToAsync(nameof(NotePage), parameters);
        }
    }
    
    [RelayCommand]
    private void onSelectionChanged()
    {
        NavigationService.GoToAsync(RouteConstants.NotePageDbRoute, new Dictionary<string, object>
        {
            {
                "note", SelectedNote
            }
        });
    }
 
    [RelayCommand]
    private async Task AddNoteAsync()
    {
        await Shell.Current.GoToAsync(nameof(NotePageDb));
    }
    
    public override void OnAppearing()
    {
        var result = DbService.GetAllData<NoteDb>();
        if (result != null)
        { 
            Notes = new ObservableCollection<NoteDb>(result);
        }
        base.OnAppearing(); 
    }
    #endregion
}