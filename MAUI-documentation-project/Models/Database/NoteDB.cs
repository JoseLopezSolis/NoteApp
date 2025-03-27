using MAUI_documentation_project.Models.Base;

namespace MAUI_documentation_project.Models;

public class NoteDb : BaseDatabaseModel
{
    public string BodyNote { get; set; }
    public DateTime Date { get; set; }
}