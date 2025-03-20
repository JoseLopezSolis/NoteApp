using MAUI_documentation_project.Extensions;
using MAUI_documentation_project.ViewModels.Base;

namespace MAUI_documentation_project.Views.Base;

public partial class BasePage : ContentPage

{
    public BasePage()
    {
        InitializeComponent();
        BindingContext = this.GetViewModel();
    }

    protected override void OnAppearing()
    {
        if (BindingContext is IViewModel viewModel)
        {
            viewModel.OnAppearing();
        }
    }
    
    protected override void OnDisappearing()
    {
        if (BindingContext is IViewModel viewModel)
        {
            viewModel.OnDisappearing();
        }
    }
}