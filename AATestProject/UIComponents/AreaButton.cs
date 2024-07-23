﻿using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AATestProject.UIComponents
{
    [PseudoClasses(":left", ":right", ":middle")]
    public class AreaButton : Button
    {
        protected override void OnPointerMoved(PointerEventArgs e)
        {
            base.OnPointerMoved(e);
            var pos = e.GetPosition(this);
            
            if (pos.X < Bounds.Width * 0.25)
                SetAreaPseudoclasses(true, false, false);
            else if (pos.X > Bounds.Width * 0.75)
                SetAreaPseudoclasses(false, true, false);
            else
                SetAreaPseudoclasses(false, false, true);
        }

        protected override void OnPointerExited(PointerEventArgs e)
        {
            base.OnPointerExited(e);
            SetAreaPseudoclasses(false, false, false);
        }

        private void SetAreaPseudoclasses(bool left, bool right, bool middle)
        {
            PseudoClasses.Set(":left", left);
            PseudoClasses.Set(":right", right);
            PseudoClasses.Set(":middle", middle);
        }
    }
}
