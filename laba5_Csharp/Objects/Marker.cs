﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace laba5_Csharp.Objects
{
    class Marker : BaseObject
    {
        public Marker(float x, float y, float angle) : base(x, y, angle)
        {
        }

        public override void Render (Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Red), -3, -3, 6, 6);
            g.DrawEllipse(new Pen(Color.Red, 2), -6, -6, 12, 12);
            g.DrawEllipse(new Pen(Color.Red,2), -10, -10, 20, 20);
        }
    }
}
