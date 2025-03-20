using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI_documentation_project.ViewModels.Base;

namespace MAUI_documentation_project.ViewModels;

public partial class NotePageViewModel : BaseViewModel
{
    [ObservableProperty]
    private string filename;

    [ObservableProperty]
    private string text;

    [ObservableProperty]
    private DateTime date;

    public void LoadNote(string fileName)
    {
        Filename = fileName;

        if (File.Exists(fileName))
        {
            Date = File.GetCreationTime(fileName);
            Text = File.ReadAllText(fileName);
        }
    }

    [RelayCommand]
    private async Task SaveNote()
    {
        if (!string.IsNullOrWhiteSpace(Filename))
        {
            File.WriteAllText(Filename, Text);
            await Shell.Current.GoToAsync($"..");

        }
    }

    [RelayCommand]
    private async Task DeleteNote()
    {
        if (!string.IsNullOrWhiteSpace(Filename) && File.Exists(Filename))
        {
            File.Delete(Filename);
            await Shell.Current.GoToAsync($"..");

        }
    }
}