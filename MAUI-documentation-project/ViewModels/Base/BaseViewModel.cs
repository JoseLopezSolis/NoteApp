using CommunityToolkit.Mvvm.ComponentModel;

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

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
    }

    public void InitProperties()
    {
        throw new NotImplementedException();
    }

}