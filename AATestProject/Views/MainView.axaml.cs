using Avalonia.Controls;
using Avalonia.Threading;
using System;
using System.Threading.Tasks;
using System.Timers;
using System.Threading;
using AATestLibrary;
using System.ComponentModel.DataAnnotations;
using Avalonia.Interactivity;
using AATestProject.EH;
using AATestProject.UIComponents;
using System.Diagnostics;

namespace AATestProject.Views;

public partial class MainView : UserControl
{
    private TextBlock? _TB_TITLE;
    private void SetText(string text) => _TB_TITLE.Text = text;
    private string GetText() => _TB_TITLE?.Text ?? "";

    private string GetText2()
    {
        Thread.Sleep(5000);
        return "GetText2";
    }

    private int _m_count = 0;

    private System.Timers.Timer _m_timer;

    private Thread _m_t1;
    public MainView()
    {
        InitializeComponent();

        var tabControl = this.FindControl<TabControl>("TEST_TAB_CTRL_01");

        if (tabControl != null)
        {
            Console.WriteLine($"Number of tabs : {tabControl.Items.Count}");
            tabControl.SelectedIndex = 0;
        }

        StackPanel? SP_01 = this.FindControl<StackPanel>("SP_PANEL_01");
        CheckBox? CB_01 = this.FindControl<CheckBox>("NULL TEST 01");
        CheckBox CB_02 = this.FindControl<CheckBox>("CB_TEST_02");
        CheckBox CB_03 = this.FindControl<CheckBox>("NULL TEST 02");

        _TB_TITLE = this.FindControl<TextBlock>("TB_TITLE");

        _ = Task.Run(() => OnTextFromAnotherThread("Entry Thread"));

        _m_timer = new System.Timers.Timer();
        _m_timer.Interval = 1000;
        _m_timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_elapsed);

        _m_timer.Start();


        _m_t1 = new Thread(do_work);
        _m_t1.Start();

        //TCustomButton btn = this.Get<TCustomButton>("AAA");
        //btn.Click += (s, e) =>
        //{
        //    Debug.WriteLine("##### Clicked 155");
        //};
        
        // t1.Join();
    }

    private void CustomButtonControl_NameChanged(object sender, RoutedEventArgs e)
    {
        // Handle the event here
        var slider = sender as CustomButtonControl;
        Console.WriteLine($"Slider value changed to: {slider?.Value}");
    }

    private async void OnTextFromAnotherThread(string text)
    {
        try
        {
            Dispatcher.UIThread.Post(() => SetText(text));

            var result = await Dispatcher.UIThread.InvokeAsync(() => {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                Debug.WriteLine("### Entry Async");
                // Thread.Sleep(5000);
                stopWatch.Stop();
                Debug.WriteLine($"### Finish : {stopWatch.ElapsedMilliseconds}ms");

                string elapsed_t = stopWatch.ElapsedMilliseconds.ToString();
                return stopWatch.ElapsedTicks;
            });
        }
        catch (Exception)
        {
            System.Diagnostics.Debug.WriteLine("Exception - do throw");
            throw;
        }
    }

    void timer_elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        Dispatcher.UIThread.Post(() => SetText("UIThread.Post " + _m_count++));

        if (_m_count >= 10)
        {
            _m_timer.Stop();
            _m_t1.Join();
        }
    }

    int _m_work_cnt = 100;
    void do_work()
    {
        while (_m_work_cnt > 0)
        {
            // Thread.Sleep(1000);
            // Dispatcher.UIThread.Post(() => SetText("UIThread.Post " + _m_work_cnt--));
            System.Diagnostics.Debug.WriteLine("Working from thread 1");
            _m_work_cnt--;
        }   
    }

    [Required]
    [EmailAddress]
    public string? EMail
    {
        get; set;
    }

}
