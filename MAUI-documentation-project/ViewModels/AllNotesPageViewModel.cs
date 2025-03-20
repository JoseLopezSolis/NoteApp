using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI_documentation_project.Helpers;
using MAUI_documentation_project.Models;
using MAUI_documentation_project.ViewModels.Base;
using MAUI_documentation_project.Views;

namespace MAUI_documentation_project.ViewModels;

public partial class AllNotesPageViewModel : BaseViewModel
{
    [ObservableProperty]
    private ObservableCollection<Note> notes = new();

    [ObservableProperty] private Note selectedNote;

    public AllNotesPageViewModel()
    {
    }

    public override void OnAppearing()
    {
        LoadNotes();
        base.OnAppearing();
    }

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
            await Shell.Current.GoToAsync($"{RouteConstants.NotePageRoute}?{nameof(NotePage.ItemId)}={SelectedNote.Filename}");
        }

        SelectedNote = null;
    }

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
}