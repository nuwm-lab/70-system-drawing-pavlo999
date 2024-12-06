using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab7
{
    public partial class Form1 : Form
    {
        // Конструктор форми
        public Form1()
        {
            InitializeComponent();
            this.Text = "Графік функції z(t)";
            this.Size = new Size(800, 600);
            this.Resize += new EventHandler(OnResize);
        }

        // Крок для t
        private double step = 0.4;

        // Діапазон t
        private double tMin = 2.4;
        private double tMax = 6.9;

        // Метод, що відповідає за малювання графіка
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.Clear(Color.White);

            Pen axisPen = new Pen(Color.Black, 2);
            Pen graphPen = new Pen(Color.Blue, 2);

            // Знаходимо центр форми
            int centerX = this.ClientSize.Width / 2;
            int centerY = this.ClientSize.Height / 2;

            // Малюємо осі
            g.DrawLine(axisPen, 0, centerY, this.ClientSize.Width, centerY); // Ось X
            g.DrawLine(axisPen, centerX, 0, centerX, this.ClientSize.Height); // Ось Y

            // Масштаб
            double scaleX = this.ClientSize.Width / (tMax - tMin);
            double scaleY = this.ClientSize.Height / 10.0; // Задаємо приблизний масштаб для Y

            // Обчислення і малювання графіка функції
            for (double t = tMin; t <= tMax; t += step)
            {
                // Обчислюємо z
                double z1 = (t + Math.Sin(2 * t)) / (t * t - 3);
                double z2 = ((t + step) + Math.Sin(2 * (t + step))) / ((t + step) * (t + step) - 3);

                // Масштабування координат
                int x1 = centerX + (int)((t - tMin) * scaleX);
                int y1 = centerY - (int)(z1 * scaleY);

                int x2 = centerX + (int)(((t + step) - tMin) * scaleX);
                int y2 = centerY - (int)(z2 * scaleY);

                // Малюємо лінії графіка
                g.DrawLine(graphPen, x1, y1, x2, y2);
            }

            // Звільняємо ресурси
            axisPen.Dispose();
            graphPen.Dispose();
        }

        // Метод для перерисовки при зміні розміру вікна
        private void OnResize(object sender, EventArgs e)
        {
            this.Invalidate(); // Перемальовуємо вміст форми
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Місце для коду, що виконується під час завантаження форми
        }
    }
}
