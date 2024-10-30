using System.Numerics;

namespace KochSnowflake
{
    public partial class FormBase : Form
    {
        int deepMax = 1;
        public FormBase()
        {
            InitializeComponent();

            Panel drawingPanel = new Panel();
            drawingPanel.Location = new Point(90, 59);
            drawingPanel.Name = "drawingPanel";
            drawingPanel.Size = new Size(800, 600);
            drawingPanel.TabIndex = 0;
            drawingPanel.Paint += DrawingPanel_Paint;

            this.Controls.Add(drawingPanel);
        }

        private void DrawingPanel_Paint(object sender, PaintEventArgs e)
        {
            Point p1 = new Point(2, 10);
            Point p2 = new Point(500, 400);
            Point[] test = new Point[] { p1, p2 };

            Point[] list = Fractalize(0, test);

            using (Pen pen = new Pen(Color.Blue, 1))
            {
                foreach (var (first, second) in list.Zip(list.Skip(1), (first, second) => (first, second)))
                {
                    e.Graphics.DrawLine(pen, first, second);
                }
            }
        }

        private Point CalculThirdPoint(Point p1, Point p2)
        {
            double difX = p2.X - p1.X;
            double difY = p2.Y - p1.Y;
            double milX = (p1.X + p2.X) / 2;
            double milY = (p1.Y + p2.Y) / 2;

            double longeurCote = Math.Sqrt(Math.Pow(difX, 2) + Math.Pow(difY, 2));

            double hauteur = Math.Sqrt(3) / 2 * longeurCote;

            double x3 = milX - (difY * hauteur / longeurCote);
            double y3 = milY - (difX * hauteur / longeurCote);

            Point p3 = new Point((int)x3, (int)y3);
            return p3;
        }

        private Point[] Fractalize(int deep, Point[] points)
        {
            if (deep == deepMax) return points;
            return points
            .Zip(points.Skip(1), (first, second) =>
            {
                Point[] listpoint = Partionner(first, second);
                return Fractalize(deep + 1, listpoint);
            })
            .SelectMany(list => list) // Flattening the array of arrays into a single array
            .ToArray();
        }

        private Point[] Partionner(Point p1, Point p2)
        {
            // Calcul du premier point P (à un tiers de la distance entre A et B)
            float Px = p1.X + (1f / 3f) * (p2.X - p1.X);
            float Py = p1.Y + (1f / 3f) * (p2.Y - p1.Y);
            Point P = new Point((int)Px, (int)Py);

            // Calcul du second point Q (aux deux tiers de la distance entre A et B)
            float Qx = p1.X + (2f / 3f) * (p2.X - p1.X);
            float Qy = p1.Y + (2f / 3f) * (p2.Y - p1.Y);
            Point Q = new Point((int)Qx, (int)Qy);

            Point mid = CalculThirdPoint(P, Q);

            return new Point[] { p1, P, mid, Q, p2 };
        }
    }
}
