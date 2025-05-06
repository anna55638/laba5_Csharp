using laba5_Csharp.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace laba5_Csharp
{
    public partial class Form1 : Form
    {
        List<BaseObject> objects = new();
        Player player;
        Marker marker;
        GreenCircle circle1;
        GreenCircle circle2;
        Random rnd = new Random();
        int point = 0;

        public Form1()
        {
            InitializeComponent();

            circle1 = new GreenCircle(pbMain.Width / 3, pbMain.Height / 3, 0);
            circle2 = new GreenCircle(pbMain.Width / 4, pbMain.Height / 4, 0);
            player = new Player(pbMain.Width / 2, pbMain.Height / 2, 0);

            player.OnOverlap += (p, obj) =>
            {
                txtLog.Text = $"[{DateTime.Now:HH:mm:ss:ff}] Игрок пересекся с {obj}\n" + txtLog.Text;
            };

            player.OnCircleOverlap += (m) =>
            {
                txtBoxPoint.Clear();
                objects.Remove(m);
                point++;
                string str = "Очки: " + point;
                txtBoxPoint.Text = str;
                GreenCircle newCircle = new GreenCircle(rnd.Next(40, pbMain.Width - 41), rnd.Next(40, pbMain.Height - 41), 0);
                if (m == circle1)
                {
                    circle1 = newCircle;
                }
                else
                {
                    circle2 = newCircle;
                }
                objects.Add(newCircle);
            };

            player.OnMarkerOverlap += (m) =>
            {
                objects.Remove(m);
                marker = null;
            };

            marker = new Marker(pbMain.Width / 2 + 50, pbMain.Height / 2 + 50, 0);

            objects.Add(circle1);
            objects.Add(circle2);
            objects.Add(marker);
            objects.Add(player);
        }

        private void pbMain_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(Color.White);
            updatePlayer();

            foreach (var obj in objects.ToList())
            {
                if (obj != player && player.Overlaps(obj, g))
                {
                    player.Overlap(obj);
                }
            }

            foreach (var obj in objects.ToList())
            {
                g.Transform = obj.GetTransform();
                obj.Render(g);
                if (obj is GreenCircle && (circle1.RemoveCircle() == true))
                {
                    objects.Remove(circle1);
                    circle1 = new GreenCircle(rnd.Next(40, pbMain.Width - 41), rnd.Next(40, pbMain.Height - 41), 0);
                    objects.Add(circle1);
                }
                else if (obj is GreenCircle && (circle2.RemoveCircle() == true))
                {
                    objects.Remove(circle2);
                    circle2 = new GreenCircle(rnd.Next(40, pbMain.Width - 41), rnd.Next(40, pbMain.Height - 41), 0);
                    objects.Add(circle2);
                }
            }
        }

        private void updatePlayer()
        {
            if (marker != null)
            {
                float dx = marker.X - player.X;
                float dy = marker.Y - player.Y;
                float length = MathF.Sqrt(dx * dx + dy * dy);
                dx /= length;
                dy /= length;

                player.vX += dx * 0.5f;
                player.vY += dy * 0.5f;
                player.Angle = 90 - MathF.Atan2(player.vX, player.vY) * 180 / MathF.PI;
            }

            player.vX += -player.vX * 0.1f;
            player.vY += -player.vY * 0.1f;
            player.X += player.vX;
            player.Y += player.vY;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pbMain.Invalidate();
        }

        private void pbMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (marker == null)
            {
                marker = new Marker(0, 0, 0);
                objects.Add(marker);
            }
            marker.X = e.X;
            marker.Y = e.Y;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}