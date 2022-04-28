using CalculatorRPN.Model;
using CalculatorRPN.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CalculatorRPN.ViewModel
{
    public class ViewModel:INotifyPropertyChanged
    {
        CalculatorReversePolishNotation RNP = new CalculatorReversePolishNotation();

        string inputText = string.Empty;

        public event PropertyChangedEventHandler PropertyChanged;

        public string InputText
        {
            get => inputText;
            set => inputText=value;
        }

        double? result = null;
        public double? Result
        {
            get => result;
            set => result = value;
        }

        string RNPstring = string.Empty;
        public string RNPString
        {
            get => RNPstring;
            set => RNPstring = value;
        }

        #region Добавление символа на кнопку в строку
        public AddInputCommand AddToInputCommand { get; private set; }

        public void AddToInputText(object parametr)
        {
            InputText += parametr.ToString();
            PropertyChanged(this, new PropertyChangedEventArgs("InputText"));
        }
        #endregion

        #region Очистка поля для ввода выражения
        public ClearInputCommand ClearCommand { get; private set; }
        public void Clear()
        {
            InputText = string.Empty;
            RNPString = string.Empty;
            Result = null;
            PropertyChanged(this, new PropertyChangedEventArgs("InputText"));
            PropertyChanged(this, new PropertyChangedEventArgs("Result"));
            PropertyChanged(this, new PropertyChangedEventArgs("RNPString"));
        }
        #endregion

        #region Получение результата подсчёта
        public ResultCalculationCommand ResultCommand { get; private set; }
        private void ResultCalculation(object parametr)
        {
            Result = RNP.Calculate(parametr.ToString());
            RNPString = RNP.RNP;
            PropertyChanged(this, new PropertyChangedEventArgs("Result"));
            PropertyChanged(this, new PropertyChangedEventArgs("RNPString"));
        }
        #endregion
        public ViewModel()
        {
            AddToInputCommand = new AddInputCommand(AddToInputText);
            ClearCommand = new ClearInputCommand(Clear);
            ResultCommand = new ResultCalculationCommand(ResultCalculation);
        }

    }
}
