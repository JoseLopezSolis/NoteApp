using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI_documentation_project.Models;
using MAUI_documentation_project.Services.database;
using MAUI_documentation_project.Services.Interfaces;
using MAUI_documentation_project.ViewModels.Base;
using MAUI_documentation_project.Views;

namespace MAUI_documentation_project.ViewModels;

public partial class NotesDbViewModel: BaseViewModel
{
    [ObservableProperty] 
    private ObservableCollection<NoteDb> _notes;
    
    public NotesDbViewModel
        (INavigationService navigationService, ILiteDbService liteDbService): base(navigationService, liteDbService)
    {
    }

    public override void OnAppearing()
    {
        Notes = new ObservableCollection<NoteDb>(DbService.GetAllNotes());
        base.OnAppearing(); 
    }

    [RelayCommand]
    private async Task AddNoteAsync()
    {
        await Shell.Current.GoToAsync(nameof(NotePageDb));
    }
}