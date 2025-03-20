using MAUI_documentation_project.Models;
using MAUI_documentation_project.ViewModels;
using MAUI_documentation_project.Views.Base;

namespace MAUI_documentation_project.Views;

public partial class AboutPage
{
    public AboutPage()
    {
        InitializeComponent();
    }

    // private async void LearnMore_Clicked(object sender, EventArgs e)
    // {
    //     if (BindingContext is Models.About about)
    //     {
    //         // Navigate to the specified URL in the system browser.
    //         await Launcher.Default.OpenAsync(about.MoreInfoUrl);
    //     }
    // }
}