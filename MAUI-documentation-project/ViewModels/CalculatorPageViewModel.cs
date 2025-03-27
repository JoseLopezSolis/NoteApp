using System.Globalization;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI_documentation_project.Enums;
using MAUI_documentation_project.Services;
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
    private Operations? _operation;
    private bool _isNewEntry = false;
    
    #endregion

    public CalculatorPageViewModel(INavigationService navigationService, ILiteDbService liteDbService) : base(navigationService, liteDbService)
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
        if (_isNewEntry)
        {
            CurrentInput = buttonText;
            _isNewEntry = false;
        }
        else
        {
            string newInput = (CurrentInput == "0" && buttonText != ".") ? buttonText : CurrentInput + buttonText;

            if (double.TryParse(newInput.Replace(",", ""), out double formattedNumber))
                CurrentInput = formattedNumber.ToString("N0", CultureInfo.InvariantCulture);
            else
                CurrentInput = newInput;
        }
    }

    private void setPreviousValue(Operations operation)
    {
        if (double.TryParse(CurrentInput, NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out var value))
        {
            _previousValue = value;
        }
        _operation = operation;
        _isNewEntry = true;
    }

    [RelayCommand]
    private void OnOperationSelected(Operations operation)
    {
        switch (operation)
        {
            case Operations.Sum:
                setPreviousValue(Operations.Sum);
                break;
            case Operations.Subtract:
                setPreviousValue(Operations.Subtract);
                break;
            case Operations.Multiply:
                setPreviousValue(Operations.Multiply);
                break;
            case Operations.Divide:
                setPreviousValue(Operations.Divide);
                break;
            case Operations.Equal:
                CalculateResult();
                break;
            default: 
                break;
        }
    }

    [RelayCommand]
    private void CalculateResult()
    {
        if ( _operation != null && double.TryParse(CurrentInput.Replace(",", ""), out var currentValue))
        {
            double result = _previousValue;

            switch (_operation)
            {
                case Operations.Sum:
                    result += currentValue;
                    break;
                case Operations.Subtract:
                    result -= currentValue;
                    break;
                case Operations.Multiply:
                    result *= currentValue;
                    break;
                case Operations.Divide:
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
            _operation = null;
            _isNewEntry = true;
        }
    }

    [RelayCommand]
    private void DeleteClicked()
    {
        CurrentInput = "0";
    }
    #endregion
}