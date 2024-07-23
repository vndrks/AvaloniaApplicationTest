using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AATestProject.ViewModels
{
    public class ViewModelType02 : ReactiveObject
    {
        public ViewModelType02()
        {
        }

        private string? _name = string.Empty;

        public string? Name
        {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);

            /*
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    this.RaiseAndSetIfChanged(ref _name, value);
                    _name = value;
                }
            }
            */
        }
    }
}
