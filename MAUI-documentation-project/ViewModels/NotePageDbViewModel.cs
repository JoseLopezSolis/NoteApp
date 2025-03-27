using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI_documentation_project.Models;
using MAUI_documentation_project.Services;
using MAUI_documentation_project.Services.Interfaces;
using MAUI_documentation_project.ViewModels.Base;
namespace MAUI_documentation_project.ViewModels;

public partial class NotePageDbViewModel : BaseViewModel
{
    #region Observable_properties
    [ObservableProperty]
    private string _text;

    [ObservableProperty]
    private DateTime _date;
    
    [ObservableProperty] 
    private NoteDb _noteDbInformation;

    private int? _currentNoteId;

    #endregion
    
    #region ObtainingParameters
    public override void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("note"))
        {
            var note = (NoteDb)query["note"];
            NoteDbInformation = note;
            Text = note.BodyNote;
            _currentNoteId = note.Id;
        }
        base.ApplyQueryAttributes(query);
    }
    #endregion
    
    public NotePageDbViewModel(INavigationService navigationService,
        ILiteDbService liteDbService) : base(navigationService, liteDbService)
    {
    }

   
    
    #region Relay_commands
    [RelayCommand]
    private async Task SaveCurrentNote()
    {
        if (!string.IsNullOrWhiteSpace(Text))
        {
            if (_currentNoteId != null) 
            {
                var note = DbService.FindById<NoteDb>(_currentNoteId.Value);
                if (note != null)
                {
                    note.BodyNote = Text; 
                    bool success = DbService.Update(note);
                    Console.WriteLine(success ? "Updated successfully" : "Update failed");
                }
            }
            else
            {
                DbService.Insert(new NoteDb { BodyNote = Text, Date = DateTime.Now });
            }
            await NavigationService.GoBackAsync();
        }
    }
    #endregion
    
    
    #region Relay_commands
    [RelayCommand]
    private async Task RemoveCurrentNote()
    {
        if (_currentNoteId != null)
        {
            var success = DbService.Delete<NoteDb>(_currentNoteId.Value);
            Console.WriteLine(success ? "Deleted successfully" : "No document found with that ID");
            await NavigationService.GoBackAsync();
        }
    }
    #endregion
 

}