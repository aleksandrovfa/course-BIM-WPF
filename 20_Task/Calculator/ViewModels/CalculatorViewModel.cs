﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Calculator.Commands;
using Calculator.Models;

namespace Calculator.ViewModels
{
    class CalculatorViewModel : ViewModelBase
    {

        #region Private members

        private Models.CalculationModel calculation;

        private DelegateCommand<string> digitButtonPressCommand;
        private DelegateCommand<string> operationButtonPressCommand;
        private DelegateCommand<string> singularOperationButtonPressCommand;

        private string lastOperation;
        private bool newDisplayRequired = false;
        private string display;

        #endregion

        #region Constructor

        public CalculatorViewModel()
        {
            this.calculation = new CalculationModel();
            this.display = "0";
            this.FirstOperand = string.Empty;
            this.SecondOperand = string.Empty;
            this.Operation = string.Empty;
            this.lastOperation = string.Empty;
        }

        #endregion


        #region Public Properties

        public string FirstOperand
        {
            get { return calculation.FirstOperand; }
            set { calculation.FirstOperand = value; }
        }

        public string SecondOperand
        {
            get { return calculation.SecondOperand; }
            set { calculation.SecondOperand = value; }
        }

        public string Operation
        {
            get { return calculation.Operation; }
            set { calculation.Operation = value; }
        }

        public string LastOperation
        {
            get { return lastOperation; }
            set { lastOperation = value; }
        }

        public string Result
        {
            get { return calculation.Result; }
        }

        public string Display
        {
            get { return display; }
            set
            {
                display = value;
                OnPropertyChanged("Display");
            }
        }


        #endregion


        #region Commands

        public ICommand OperationButtonPressCommand
        {
            get
            {
                if (operationButtonPressCommand == null)
                {
                    operationButtonPressCommand = new DelegateCommand<string>(
                        OperationButtonPress, CanOperationButtonPress);
                }
                return operationButtonPressCommand;
            }
        }

        private static bool CanOperationButtonPress(string number)
        {
            return true;
        }


        public ICommand SingularOperationButtonPressCommand
        {
            get
            {
                if (singularOperationButtonPressCommand == null)
                {
                    singularOperationButtonPressCommand = new DelegateCommand<string>(
                         SingularOperationButtonPress, CanSingularOperationButtonPress);
                }
                return singularOperationButtonPressCommand;
            }
        }

        private static bool CanSingularOperationButtonPress(string number)
        {
            return true;
        }


        public ICommand DigitButtonPressCommand
        {
            get
            {
                if (digitButtonPressCommand == null)
                {
                    digitButtonPressCommand = new DelegateCommand<string>(
                        DigitButtonPress, CanDigitButtonPress);
                }
                return digitButtonPressCommand;
            }
        }

        private static bool CanDigitButtonPress(string button)
        {
            return true;
        }
        #endregion

        //deals with button inputs and sorts out the display accordingly
        public void DigitButtonPress(string button)
        {
            switch (button)
            {
                case "C":
                    Display = "0";
                    FirstOperand = string.Empty;
                    SecondOperand = string.Empty;
                    Operation = string.Empty;
                    LastOperation = string.Empty;
                    break;
                case "Del":
                    if (display.Length > 1)
                        Display = display.Substring(0, display.Length - 1);
                    else Display = "0";
                    break;
                case "CE":
                    Display = "0";
                    break;
                case "+/-":
                    if (display.Contains("-") || display == "0")
                    {
                        Display = display.Remove(display.IndexOf("-"), 1);
                    }
                    else Display = "-" + display;
                    break;
                case ".":
                    if (newDisplayRequired)
                    {
                        Display = "0.";
                    }
                    else
                    {
                        if (!display.Contains("."))
                        {
                            Display = display + ".";
                        }
                    }
                    break;
                default:
                    if (display == "0" || newDisplayRequired)
                        Display = button;
                    else
                        Display = display + button;
                    break;
            }
            newDisplayRequired = false;
        }

        //for operations with 2 operands
        public void OperationButtonPress(string operation)
        {
            try
            {
                if (FirstOperand == string.Empty || LastOperation == "=")
                {
                    FirstOperand = display;
                    LastOperation = operation;
                }
                else if (operation == "%")
                {
                    SecondOperand = (Convert.ToDouble(FirstOperand) * Convert.ToDouble(display)/100).ToString();
                    Operation = lastOperation;
                    calculation.CalculateResult();
                    LastOperation = "=";
                    Display = Result;
                    FirstOperand = display;
                }
                else
                {
                    SecondOperand = display;
                    Operation = lastOperation;
                    calculation.CalculateResult();
                    LastOperation = operation;
                    Display = Result;
                    FirstOperand = display;
                }
                newDisplayRequired = true;
            }
            catch (Exception ex)
            {
                Display = Result == string.Empty ? "Error - see event log" : Result;
            }
        }

        //for sin,cos,tan
        public void SingularOperationButtonPress(string operation)
        {
            try
            {
                FirstOperand = Display;
                Operation = operation;
                calculation.CalculateResult();
                LastOperation = "=";
                Display = Result;
                FirstOperand = display;
                newDisplayRequired = true;
            }
            catch (Exception ex)
            {
                Display = Result == string.Empty ? "Error - see event log" : Result;
            }
        }



    }

}