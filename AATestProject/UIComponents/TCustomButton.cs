using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Diagnostics;

namespace AATestProject.UIComponents;
public class TCustomButton : Button
{
    public static readonly StyledProperty<int> RepeatCountProperty =
        AvaloniaProperty.Register<TCustomButton, int>(nameof(RepeatCount), defaultValue: 1);

    public int RepeatCount
    {
        get => GetValue(RepeatCountProperty);
        set => SetValue(RepeatCountProperty, value);
    }

    public TCustomButton()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        // AvaloniaXamlLoader.Load(this);

        Click += (s, e) =>
        {
            if (s is Button button)
            {
                Debug.WriteLine($"### Clicked Sender Name :  {button.Name}");
                Debug.WriteLine($"### Clicked Sender Content :  {button.Content}");
                Debug.WriteLine($"### Clicked Sender RepeatCount :  {RepeatCount}");
            }
            if (s != null)
                ButtonClicked(s, e);
        };
    }

    public void ButtonClicked(object sender, RoutedEventArgs e)
    {
        Debug.WriteLine("### Clicked ###");
    }
}

