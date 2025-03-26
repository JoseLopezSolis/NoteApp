using LiteDB;
using MAUI_documentation_project.Models;

namespace MAUI_documentation_project.Services.database;

public interface ILiteDbService
{ 
    ILiteCollection<NoteDb> GetNotesCollection();
    void InsertNote(NoteDb note);
    List<NoteDb> GetAllNotes();
}