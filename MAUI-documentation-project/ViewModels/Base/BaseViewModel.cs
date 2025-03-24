using CommunityToolkit.Mvvm.ComponentModel;
using MAUI_documentation_project.ViewModels.Interfaces;

namespace MAUI_documentation_project.ViewModels.Base;

public class BaseViewModel : ObservableObject, IViewModel, IQueryAttributable
{
    public BaseViewModel()
    {
        
    }
    public virtual void OnAppearing()
    {
    }

    public virtual void OnDisappearing()
    {
    }

    public virtual void ApplyQueryAttributes(IDictionary<string, object> query)
    {
    }

    protected virtual void InitProperties()
    {
    }
}