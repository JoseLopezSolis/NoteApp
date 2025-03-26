using System.Collections.ObjectModel;
using LiteDB;
using MAUI_documentation_project.Models;

namespace MAUI_documentation_project.Services.database;

public class LiteDbService : ILiteDbService
{
    private readonly string _dbPath;
    private readonly LiteDatabase _database;

    public LiteDbService()
    {
        _dbPath = Path.Combine(FileSystem.AppDataDirectory, "Notes.db");
        _database = new LiteDatabase(_dbPath);
    }

    public ILiteCollection<NoteDb> GetNotesCollection()
    {
        return _database.GetCollection<NoteDb>("Notes");
    }

    public void InsertNote(NoteDb note)
    {
        var collection = GetNotesCollection();
        var result = collection.Insert(note);
    }

    public List<NoteDb> GetAllNotes()
    {
        var collection = GetNotesCollection();
        return (collection.FindAll().ToList());
    }
    
}