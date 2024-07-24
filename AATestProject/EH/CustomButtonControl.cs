using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace AATestProject.EH
{
    public class CustomButtonControl : Control
    {
        public static readonly RoutedEvent<RoutedEventArgs> ValueChangedEvent =
            RoutedEvent.Register<CustomButtonControl, RoutedEventArgs>(nameof(ValueChanged), RoutingStrategies.Direct);

        public event EventHandler<RoutedEventArgs> ValueChanged
        {
            add => AddHandler(ValueChangedEvent, value);
            remove => RemoveHandler(ValueChangedEvent, value);
        }

        private double _value;
        public double Value
        {
            get => _value;
            set
            {
                if (_value != value)
                {
                    _value = value;
                    OnValueChanged();
                }
            }
        }

        protected virtual void OnValueChanged()
        {
            RoutedEventArgs args = new RoutedEventArgs(ValueChangedEvent);
            RaiseEvent(args);
        }
    }
}
