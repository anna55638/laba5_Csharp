using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba5_Csharp.Objects
{
    class GreenCircle : BaseObject
    {
        private Random random = new Random();
        private int areaWidth;
        private int areaHeight;

        public GreenCircle(float x, float y, int areaWidth, int areaHeight)
            : base(x, y, 0) // угол не используем для круга
        {
            this.areaWidth = areaWidth;
            this.areaHeight = areaHeight;
        }

        public override void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Green), -10, -10, 20, 20);
            g.DrawEllipse(new Pen(Color.DarkGreen, 2), -10, -10, 20, 20);
        }

        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(-10, -10, 20, 20);
            return path;
        }

        public override void Overlap(BaseObject obj)
        {
            base.Overlap(obj);

            // Если пересеклись с игроком - перемещаемся в случайное место
            if (obj is Player)
            {
                MoveToRandomPosition();
            }
        }

        private void MoveToRandomPosition()
        {
            X = random.Next(20, areaWidth - 20);
            Y = random.Next(20, areaHeight - 20);
        }
    }
}
