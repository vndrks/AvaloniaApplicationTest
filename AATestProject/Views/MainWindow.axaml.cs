using Avalonia.Controls;
using Avalonia.Rendering;
using Avalonia.Threading;
using Avalonia.VisualTree;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AATestProject.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        // TCustomButton button = new TCustomButton();

        InitializeComponent();
        /*
                foreach (var type in assembly.GetTypes())
                {
                    if (type.FullName == "AvaloniaPlug.Window1")
                    {
                        //创建type实例
                        Window? instance = (Window)type.GetConstructor([])!.Invoke(null);

                        Dispatcher.UIThread.InvokeAsync(() =>
                        {
                            instance.Show();
                            instance.Close();

                        }).Wait();

                        instance = null;

                        //instance.Show();
                    }

                }
        */
    }


    protected override void OnClosed(EventArgs e)
    {
        base.OnClosed(e);
    }
    private int count = 100;
    protected override void OnOpened(EventArgs e)
    {
        base.OnOpened(e);

        var tokenSource = new CancellationTokenSource();
        var token = tokenSource.Token;

        var renderRoot = this.GetVisualRoot() as IRenderRoot;
        if (renderRoot is IRenderRoot root)
        {
            //            Logger.Sink.Log(LogEventLevel.Information, "Render", this, $"Current render backend: {root.Renderer.GetType().Name}");
        }

        _ = Task.Run(() =>
        {
            while (count-- >= 0)
            {
                OnSendMessage();
                Thread.Sleep(1000);
            }
        });
    }

    private void do_work() { }

    async void OnSendMessage()
    {
        Dispatcher.UIThread.Post(new Action(() =>
        {
            TextBlock? TB_DEFAULT = MainViewObject.FindControl<TextBlock>("DefaultButton");
            if (TB_DEFAULT != null)
                TB_DEFAULT.Text = "Text Block : " + count;
            // Thread.Sleep(10000);
        }));

        await Dispatcher.UIThread.InvokeAsync(new Action(() =>
        {
            Button? BTN_NORMAL = MainViewObject.FindControl<Button>("NormalButton");
            if (BTN_NORMAL != null)
                BTN_NORMAL.Content = "Enable : " + (100 - count);
            // Thread.Sleep(1000);
        }));

        var res = await Dispatcher.UIThread.InvokeAsync(GetNormalButton);
    }

    public string GetNormalButton()
    {
        return "NormalButton";
    }

}
