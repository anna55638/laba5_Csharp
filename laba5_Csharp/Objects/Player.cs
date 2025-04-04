﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba5_Csharp.Objects
{
    class Player : BaseObject // наследуем BaseObject
    {
        public Player(float x, float y, float angle) : base(x, y, angle)
        {

        }

        public override void Render(Graphics g)
        {
            g.FillEllipse(
                new SolidBrush(Color.DeepSkyBlue),
                    -15, -15,
                    30, 30
            );

            g.DrawEllipse(
                new Pen(Color.Black, 2),
                -15, -15,
                30, 30
            );

            g.DrawLine(new Pen(Color.Black, 2), 0, 0, 25, 0);
        }
    }
}
