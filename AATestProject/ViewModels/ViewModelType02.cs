using ReactiveUI;
using System;
using System.Runtime.InteropServices;

namespace AATestProject.ViewModels
{
    public class ViewModelType02 : ReactiveObject
    {
        [DllImport("ATestLib.dll")]
        public static extern string GetTestLibInfo();

        [DllImport("User32.dll")]
        public static extern int SetForegroundWindow(IntPtr point);

        public void ActivateTargetApplication()
        {
            //Process p = Process.Start("notepad.exe");
            //p.WaitForInputIdle();
            //IntPtr h = p.MainWindowHandle;
            //SetForegroundWindow(h);

            //IntPtr processFoundWindow = p.MainWindowHandle;
        }

        public ViewModelType02()
        {
            //ActivateTargetApplication();
            //string res = GetTestLibInfo();
            // Debug.WriteLine(res);
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
