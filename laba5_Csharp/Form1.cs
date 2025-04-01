using laba5_Csharp.Objects;

namespace laba5_Csharp
{
    public partial class Form1 : Form
    {
        // MyRectangle myRect; // создадим поле под наш прямоугольник
        List<BaseObject> objects = new();
        Player player;
        Marker marker;

        public Form1()
        {
            InitializeComponent();

            player = new Player(pbMain.Width / 2, pbMain.Height / 2, 0);

            marker = new Marker(pbMain.Width / 2 + 50, pbMain.Height / 2 + 50, 0);

            objects.Add(marker);

            objects.Add(player);

            objects.Add(new MyRectangle(50, 50, 0));
            objects.Add(new MyRectangle(100, 100, 45));

            //myRect = new MyRectangle(100, 100, 45); // создать экземпляр класса
        }

        private void pbMain_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            g.Clear(Color.White);

            foreach (var obj in objects)
            {
                g.Transform = obj.GetTransform();
                obj.Render(g);
            }

            // g.Transform = myRect.GetTransform(); // устанавливаем новую матрицу
            // myRect.Render(g); // рендерим как обычно
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            // расчитываем вектор между игроком и маркером
            float dx = marker.X - player.X;
            float dy = marker.Y - player.Y;
            // находим его длину
            float length = MathF.Sqrt(dx * dx + dy * dy);
            dx /= length; // нормализуем координаты
            dy /= length;

            player.X += dx * 2; // пересчитываем координаты игрока 
            player.Y += dy * 2;

            // запрашиваем обновление pMain
            pbMain.Invalidate();    // это вызовет метод pbMain_Paint по новой 
        }

        private void pbMain_MouseClick(object sender, MouseEventArgs e)
        {
            marker.X = e.X;
            marker.Y = e.Y;
        }
    }
}
