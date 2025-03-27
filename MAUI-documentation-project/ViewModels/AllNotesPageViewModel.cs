using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI_documentation_project.Helpers;
using MAUI_documentation_project.Models;
using MAUI_documentation_project.Services.database;
using MAUI_documentation_project.Services.Interfaces;
using MAUI_documentation_project.ViewModels.Base;
using MAUI_documentation_project.Views;

namespace MAUI_documentation_project.ViewModels;

public partial class AllNotesPageViewModel : BaseViewModel
{
    #region Observable_properties
    
    [ObservableProperty]
    private ObservableCollection<Note> notes = new();

    [ObservableProperty] 
    private Note selectedNote;
    
    #endregion
   
    public AllNotesPageViewModel(INavigationService navigationService, ILiteDbService liteDbService) : base(navigationService, liteDbService)
    {
        
    }
    
    #region Override_methods
    public override void OnAppearing()
    {
        LoadNotes();
        base.OnAppearing();
    }
    #endregion
    
    #region Relay_commands
    [RelayCommand]
    private async Task AddNoteAsync()
    {
        await Shell.Current.GoToAsync(nameof(NotePage));
    }
    
    [RelayCommand]
    private async Task SelectNote()
    {
        if (SelectedNote != null)
        {
            await NavigationService
                .GoToAsync(
                    RouteConstants.NotePageDbRoute, 
                    new Dictionary<string, object>
                    {
                        { nameof(NotePage.ItemId), SelectedNote.Filename }
                    });
        }
        
        SelectedNote = null;
    }
    #endregion
    
    #region Public_methods
    public void LoadNotes()
    {
        string appDataPath = FileSystem.AppDataDirectory;

        var resultNotes = Directory
            .EnumerateFiles(appDataPath, "*.notes.txt")
            .Select(filename => new Note()
            {
                Filename = filename,
                Text = File.ReadAllText(filename),
                Date = File.GetLastWriteTime(filename)
            })
            .OrderBy(note => note.Date);

        Notes = new ObservableCollection<Note>(resultNotes);

    }
    #endregion
}