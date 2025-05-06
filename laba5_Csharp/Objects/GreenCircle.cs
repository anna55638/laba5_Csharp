using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace laba5_Csharp.Objects
{
    class GreenCircle : BaseObject
    {
        private float size = 0;

        public GreenCircle(float x, float y, float angle) : base(x, y, angle)
        {
            size = 80;
        }

        public bool RemoveCircle()
        {
            if (size <= 0)
            {
                return true;
            }
            else return false;
        }

        public override void Render(Graphics g)
        {
            if (size > 0)
            {
                g.FillEllipse(
                    new SolidBrush(Color.LightGreen),
                    -size / 2, -size / 2, size, size
                );
                size -= 0.5f;
            }
        }

        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(-size / 2, -size / 2, size, size);
            return path;
        }
    }
}