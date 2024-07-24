using AATestProject.ViewModels;
using AATestProject.Views;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Logging;
using Avalonia.Markup.Xaml;
using System;

namespace AATestProject;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        Logger.TryGet(LogEventLevel.Fatal, LogArea.Control)?.Log(this, "Avalonia Infrastructure");
        System.Diagnostics.Debug.WriteLine("System Diagnostics Debug");


        var os = Environment.OSVersion;
        System.Diagnostics.Debug.WriteLine("### Current OS Information ### \n");
        System.Diagnostics.Debug.WriteLine("Platform: {0:G}", os.Platform);
        System.Diagnostics.Debug.WriteLine("Version String: {0}", os.VersionString);
        System.Diagnostics.Debug.WriteLine("Version Information :");
        System.Diagnostics.Debug.WriteLine("Major : {0}", os.Version.Major);
        System.Diagnostics.Debug.WriteLine("Minor : {0}", os.Version.Minor);
        System.Diagnostics.Debug.WriteLine("Service Pack : {0}", os.ServicePack);


        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainViewModel()
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = new MainViewModel()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}
