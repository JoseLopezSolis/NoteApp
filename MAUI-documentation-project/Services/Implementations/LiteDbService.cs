using LiteDB;
using MAUI_documentation_project.Models.Base;

namespace MAUI_documentation_project.Services;

public class LiteDbService : ILiteDbService
{
    private readonly string _dbPath;
    private readonly LiteDatabase _database;

    public LiteDbService()
    {
        _dbPath = Path.Combine(FileSystem.AppDataDirectory, "Notes.db");
        _database = new LiteDatabase(_dbPath);
    }

    #region Public Methods

    public int Insert<TDatabaseTable>(TDatabaseTable item) where TDatabaseTable : BaseDatabaseModel
    {
        try
        {
            var collection = GetCollection<TDatabaseTable>();

            if (item is BaseDatabaseModel baseModel)
            {
                baseModel.CreatedAt = DateTime.Now;
            }
            
            return collection.Insert(item);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        return -1;
    }

    public List<TDatabaseTable>? GetAllData<TDatabaseTable>() where TDatabaseTable : BaseDatabaseModel
    {
        try
        {
            var collection = GetCollection<TDatabaseTable>();
            return (collection.FindAll().ToList());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return null;
    }

    public TDatabaseTable? FindById<TDatabaseTable>(int id) where TDatabaseTable : BaseDatabaseModel
    {
        try
        {
            var collection = GetCollection<TDatabaseTable>();
            return collection.FindById(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return default;
    }

    public bool Delete<TDatabaseTable>(int id) where TDatabaseTable : BaseDatabaseModel
    {
        try
        {
            var collection = GetCollection<TDatabaseTable>();
            return collection.Delete(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        return false;
    }

    public bool Update<TDatabaseTable>(TDatabaseTable item) where TDatabaseTable : BaseDatabaseModel
    {
        try
        { 
            var collection = GetCollection<TDatabaseTable>();

            if (item is BaseDatabaseModel baseModel)
            {
                baseModel.UpdatedAt = DateTime.Now;
            }
            
            return collection.Update(item);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        return false;
    }

    #endregion

    #region Private Methods

    private ILiteCollection<TDatabaseTable> GetCollection<TDatabaseTable>()
    {
        return _database.GetCollection<TDatabaseTable>(typeof(TDatabaseTable).Name);
    }

    #endregion
}