using MAUI_documentation_project.Enums;

namespace MAUI_documentation_project.Exceptions;

public class DatabaseException(string reason, DatabaseStatusEnum statusCode) : Exception
{
    public string Reason => reason;

    public DatabaseStatusEnum StatusCode => statusCode;
}