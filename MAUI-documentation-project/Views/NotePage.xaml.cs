using MAUI_documentation_project.ViewModels;

namespace MAUI_documentation_project.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class NotePage
{
    #region Private_fields
    private NotePageViewModel? ViewModel => BindingContext as NotePageViewModel;
    
    #endregion

    #region Public_methods
    public string ItemId
    {
        set { ViewModel?.LoadNote(value); }
    }
    
    #endregion

    public NotePage()
    {
        InitializeComponent();

        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";

        ViewModel?.LoadNote(Path.Combine(appDataPath, randomFileName));
    }
}