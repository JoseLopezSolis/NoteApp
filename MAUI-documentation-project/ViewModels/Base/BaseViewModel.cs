using CommunityToolkit.Mvvm.ComponentModel;
using MAUI_documentation_project.Services.Interfaces;
using MAUI_documentation_project.ViewModels.Interfaces;

namespace MAUI_documentation_project.ViewModels.Base;

public class BaseViewModel : ObservableObject, IViewModel, IQueryAttributable
{
    #region Private Properties

    protected readonly INavigationService NavigationService;

    #endregion
    
    public BaseViewModel(INavigationService navigationService)
    {
        NavigationService = navigationService;
    }

    #region Virtual Methods

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

    #endregion
}