using System;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace DrawingProgram
{
    public class Drawer
    {
        static float x, y;
        static Graphics graphics;

        public static void Initializate(Graphics newGraphics)
        {
            graphics = newGraphics;
            graphics.SmoothingMode = SmoothingMode.None;
            graphics.Clear(Color.Black);
        }

        public static void SetPosition(float x0, float y0)
        {
            x = x0;
            y = y0;
        }

        public static void DrawLine(Pen pen, double length, double angle)
        {
            //Делает шаг длиной length в направлении angle и рисует пройденную траекторию
            var x1 = (float)(x + length * Math.Cos(angle));
            var y1 = (float)(y + length * Math.Sin(angle));
            graphics.DrawLine(pen, x, y, x1, y1);
            x = x1;
            y = y1;
        }

        public static void Change(double length, double angle)
        {
            x = (float)(x + length * Math.Cos(angle));
            y = (float)(y + length * Math.Sin(angle));
        }
    }

    public class ImpossibleSquare
    {
        public static void Draw(int width, int height, Graphics graphics)
        {

            Drawer.Initializate(graphics);

            var minSide = Math.Min(width, height);

            var diagonalLength = Math.Sqrt(2) * (minSide * 0.375f + minSide * 0.04f) / 2;
            var x0 = (float)(diagonalLength * Math.Cos(Math.PI / 4 + Math.PI)) + width / 2f;
            var y0 = (float)(diagonalLength * Math.Sin(Math.PI / 4 + Math.PI)) + height / 2f;

            Drawer.SetPosition(x0, y0);

            //Рисуем 1-ую сторону
            DrawSide(Pens.Yellow, minSide, 0);

            //Рисуем 2-ую сторону

            DrawSide(Pens.Yellow, minSide, -Math.PI / 2);

            //Рисуем 3-ю сторону
            DrawSide(Pens.Yellow, minSide, Math.PI);

            //Рисуем 4-ую сторону
            DrawSide(Pens.Yellow, minSide, Math.PI / 2);
        }

        private static void DrawSide(Pen pen, int minSide, double angle)
        {
            Drawer.DrawLine(pen, minSide * 0.375f, angle + 0);
            Drawer.DrawLine(pen, minSide * 0.04f * Math.Sqrt(2), angle + Math.PI / 4);
            Drawer.DrawLine(pen, minSide * 0.375f, angle + Math.PI);
            Drawer.DrawLine(pen, minSide * 0.375f - minSide * 0.04f, angle + Math.PI / 2);

            Drawer.Change(minSide * 0.04f, angle - Math.PI);
            Drawer.Change(minSide * 0.04f * Math.Sqrt(2), angle + 3 * Math.PI / 4);
        }
    }
}