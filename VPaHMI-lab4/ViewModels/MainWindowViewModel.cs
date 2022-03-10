using System;
using System.Collections.Generic;
using System.Text;
using System.Reactive;
using ReactiveUI;
using VPaHMI_lab4.Models;

namespace VPaHMI_lab4.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        string input = "";
        bool displayResult = false;
        public MainWindowViewModel()
        {
            ChangeInput = ReactiveCommand.Create((string element) => {
                if (displayResult)
                {
                    Input = "";
                }
                displayResult = false;
                return Input += element;
            }
            );
            Calculate = ReactiveCommand.Create(() => {
                try
                {
                    displayResult = true;
                    return Input = RomanNumberCalculator.Calculate(input).ToString();
                }
                catch (Exception)
                {
                    return Input = "ERROR";
                }
            });
        }
        public string Input
        {
            set
            {
                this.RaiseAndSetIfChanged(ref input, value);
            }
            get
            {
                return this.input;
            }
        }
        public ReactiveCommand<string, string> ChangeInput { get; }
        public ReactiveCommand<Unit, string> Calculate { get; }
    }
}
