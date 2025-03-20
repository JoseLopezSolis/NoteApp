using MAUI_documentation_project.ViewModels;

namespace MAUI_documentation_project.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class NotePage
{
    private NotePageViewModel? ViewModel => BindingContext as NotePageViewModel;

    public string ItemId
    {
        set { ViewModel?.LoadNote(value); }
    }

    public NotePage()
    {
        InitializeComponent();

        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";

        ViewModel?.LoadNote(Path.Combine(appDataPath, randomFileName));
    }
}