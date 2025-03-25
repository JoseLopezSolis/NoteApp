using System.Globalization;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI_documentation_project.Services.Interfaces;
using MAUI_documentation_project.ViewModels.Base;

namespace MAUI_documentation_project.ViewModels;

public partial class CalculatorPageViewModel : BaseViewModel
{
    
    #region Observable_properties
    [ObservableProperty] 
    private string _currentInput = string.Empty;
    
    [ObservableProperty] 
    private double _resultOperation = 0;
    #endregion
    
    #region Private_properties
    
    private double _previousValue = 0;
    private string _operation = string.Empty;
    private bool _isNewEntry = false;
    
    #endregion

    public CalculatorPageViewModel(INavigationService navigationService) : base(navigationService)
    {
        _currentInput = "0";
    }
    
    
    #region Relay_commands
    /// <summary>
    /// This button display the number selected in the bar that display the numbers
    /// </summary>
    /// <param name="buttonText"></param>
    /// 
    [RelayCommand]
    private void OnButtonClicked(string buttonText)
    {
        if (buttonText == "+" || buttonText == "-" || buttonText == "*" || buttonText == "/")
        {
            if (double.TryParse(CurrentInput, NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out var value))
            {
                _previousValue = value;
            }
            _operation = buttonText;
            _isNewEntry = true;
        }
        else if (buttonText == "=")
        {
            CalculateResult();
        }
        else
        {
            if (_isNewEntry)
            {
                CurrentInput = buttonText;
                _isNewEntry = false;
            }
            else
            {
                string newInput = (CurrentInput == "0" && buttonText != ".") ? buttonText : CurrentInput + buttonText;

                if (double.TryParse(newInput.Replace(",", ""), out double formattedNumber))
                {
                    CurrentInput = formattedNumber.ToString("N0", CultureInfo.InvariantCulture);
                }
                else
                {
                    CurrentInput = newInput;
                }
            }
        }
    }
    
    [RelayCommand]
    private void CalculateResult()
    {
        if (!string.IsNullOrEmpty(_operation) && double.TryParse(CurrentInput.Replace(",", ""), out var currentValue))
        {
            double result = _previousValue;

            switch (_operation)
            {
                case "+":
                    result += currentValue;
                    break;
                case "-":
                    result -= currentValue;
                    break;
                case "*":
                    result *= currentValue;
                    break;
                case "/":
                    if (currentValue != 0)
                        result /= currentValue;
                    else
                    {
                        CurrentInput = "Error";
                        return;
                    }
                    break;
            }

            _previousValue = result;
            CurrentInput = result.ToString("N0", CultureInfo.InvariantCulture);
            _operation = string.Empty;
            _isNewEntry = true;
        }
    }
    #endregion
    
}