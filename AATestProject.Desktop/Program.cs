using AATestLibrary;
using Avalonia;
using Avalonia.Logging;
using Avalonia.ReactiveUI;
using Serilog;
using System;

namespace AATestProject.Desktop;

class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
        VersatileUtils();
    }
    //public static void Main(string[] args) => BuildAvaloniaApp()
    //    .StartWithClassicDesktopLifetime(args);



    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            // .LogToTrace(LogEventLevel.Verbose)
            .LogToTrace(LogEventLevel.Debug)
            .UseReactiveUI();

    public static void VersatileUtils()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Warning()
            .WriteTo.Console()
            .CreateLogger();
    }

    ClassT1 t1;
    // ThreadPool
    // https://www.linkedin.com/pulse/c-threading-tasks-async-code-synchronization-part-2-meikopoulos/



}
