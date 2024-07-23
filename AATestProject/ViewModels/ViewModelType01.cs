using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AATestLibrary;

namespace AATestProject.ViewModels
{
    // internal class ViewModelType01
    public class ViewModelType01 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string? _PropQues;
        public string? PropQues
        {
            get => _PropQues;
            set
            {
                if (_PropQues != value)
                {
                    _PropQues = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(PropAnswer));
                }
            }
        }

        private string? _PropAnswer;
        public string? PropAnswer
        {
            set => _PropAnswer = value;
            get
            {
                if (string.IsNullOrEmpty(PropQues))
                {
                    return "Avalonia.Samples";
                }
                else
                {
                    return $"Avalonia.Samples - {PropQues}";
                }
            }
        }

        private string? _UName;
        private string? _UAddress;
        public string? UName
        {
            get => _UName;
            set => _UName = value;
        }

        public string? UAddress
        {
            get => _UAddress;
            set => _UAddress = value;
        }

        private void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
