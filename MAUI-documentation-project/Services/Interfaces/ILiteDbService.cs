using MAUI_documentation_project.Models.Base;

namespace MAUI_documentation_project.Services;

public interface ILiteDbService
{
    int Insert<TDatabaseTable>(TDatabaseTable item) where TDatabaseTable : BaseDatabaseModel;
    List<TDatabaseTable>? GetAllData<TDatabaseTable>() where TDatabaseTable : BaseDatabaseModel;
    TDatabaseTable? FindById<TDatabaseTable>(int id) where TDatabaseTable : BaseDatabaseModel;
    bool Delete<TDatabaseTable>(int id) where TDatabaseTable : BaseDatabaseModel;
    bool Update<TDatabaseTable>(TDatabaseTable item) where TDatabaseTable : BaseDatabaseModel;
}