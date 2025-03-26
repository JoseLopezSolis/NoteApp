using System.Runtime.InteropServices.JavaScript;

namespace MAUI_documentation_project.Models;

public class NoteDb
{
    public int Id { get; set; } // Se autoincrementa automáticamente
    public string BodyNote { get; set; }
    public DateTime Date { get; set; }
}