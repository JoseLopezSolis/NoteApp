namespace MAUI_documentation_project.Services.Interfaces;

public interface INavigationService
{
    Page? CurrentPage { get; }
    
    Task GoToAsync(string route, IDictionary<string, object>? parameters = null);
    
    Task GoBackAsync();
}