namespace AATestProject.ViewModels;

public class MainViewModel : ViewModelBase
{
    public string Greeting => "Welcome to Avalonia!";

    public ViewModelType01 VmType01 { get; } = new ViewModelType01();
    
    public ViewModelType02 VmType02 { get; }  = new ViewModelType02();   
}
