﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace laba5_Csharp.Objects
{
    class Player : BaseObject
    {
        public Action<Marker> OnMarkerOverlap;
        public Action<GreenCircle> OnCircleOverlap;
        public float vX, vY;

        public Player(float x, float y, float angle) : base(x, y, angle) { }

        public override void Render(Graphics g)
        {
            g.FillEllipse(
                new SolidBrush(Color.DeepSkyBlue),
                -15, -15, 30, 30
            );

            g.DrawEllipse(
                new Pen(Color.Black, 2),
                -15, -15, 30, 30
            );

            g.DrawLine(new Pen(Color.Black, 2), 0, 0, 25, 0);
        }

        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(-15, -15, 30, 30);
            return path;
        }

        public override void Overlap(BaseObject obj)
        {
            base.Overlap(obj);

            if (obj is GreenCircle)
            {
                OnCircleOverlap(obj as GreenCircle);
            }
            else if (obj is Marker)
            {
                OnMarkerOverlap(obj as Marker);
            }
        }
    }
}