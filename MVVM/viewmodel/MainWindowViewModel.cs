using Calc.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calc.viewmodel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public ICommand ButtonCommand { get; set; }

        /**
         * Napis wyświetlany jako wyjście kalkulatora.
         */
        private String calculatorDisplay = "0";
        public String CalculatorDisplay
        {
            get
            {
                return calculatorDisplay;
            }
            set
            {
                if (value != calculatorDisplay)
                {
                    calculatorDisplay = value;
                    OnPropertyChanged("CalculatorDisplay");
                }
            }
        }

        private bool isEnabled = true;
        public bool IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                if (value != isEnabled)
                {
                    isEnabled = value;
                    OnPropertyChanged("IsEnabled");
                }
            }
        }

        /**
         * Stan kalkulatora
         */
        private CalculatorBean calculatorBean = new CalculatorBean();

        /**
         * Lista operacji udostępnianych przez kalkulator.
         */
        private List<Calculation> calculations = new List<Calculation> { 
            new DefaultCalculation(), new ClearCalculation(), new ChangeSingCalculation(), 
            new EnterCalculation(), new PercentageCalulcation(),
            new SquareRootCalculation(), new SimpleMathematicalCalculation()
        };

        public MainWindowViewModel()
        {
            ButtonCommand = new RelayCommand(pars => buttonClicked(pars));
        }

        public event PropertyChangedEventHandler PropertyChanged = null;
        virtual protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        /**
         * Funkcja wywoływana w przypadku wciśnięcia klawisza.
         */
        private void buttonClicked(object pars)
        {
            calculations.ForEach(action => 
            {
                try
                {
                    String calculationResult = ((Calculation) action).calculate(calculatorBean, pars.ToString());
                    if (calculationResult != null)
                    {
                        CalculatorDisplay = calculationResult;
                    }
                } catch (CalculationException ex) {
                    calculatorBean.IsBlocked = true;
                }
            });

            // jeśli wynik operacji jest błędny to blokujemy kalkulator
            if (calculatorBean.IsBlocked == true)
            {
                CalculatorDisplay = "ERR";
                IsEnabled = false;
            } else {
                IsEnabled = true;
            }
        }

    }
}
