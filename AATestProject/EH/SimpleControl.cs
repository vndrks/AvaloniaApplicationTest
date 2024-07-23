using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AATestProject.EH
{
    public class SimpleControl : Control
    {
        public static readonly RoutedEvent<RoutedEventArgs> TapEvent =
            RoutedEvent.Register<SimpleControl, RoutedEventArgs>(nameof(Tap), RoutingStrategies.Bubble);
        
        public event EventHandler<RoutedEventArgs> Tap
        {
            add => AddHandler(TapEvent, value);
            remove => RemoveHandler(TapEvent, value);
        }
    }
}
