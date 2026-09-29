using System;
using System.Drawing;

namespace Lab2
{
    internal class Ellipse : Shape
    {
        private Point center;
        public Ellipse(int x, int y, int width, int height)
            : base(x, y, width, height) { }
        public Ellipse() : base() { }

        public override void draw(Graphics g)
        {
            g.FillEllipse(DrawingUtil.shapeInfillEllipse, x, y, width, height);
            g.DrawEllipse(DrawingUtil.outline, x, y, width, height);
        }

        public override void drawGhost(Graphics g, Point cursor)
        {
            int x = Math.Min(center.X, cursor.X);
            int y = Math.Min(center.Y, cursor.Y);

            int width = Math.Abs(center.X - cursor.X);
            int height = Math.Abs(center.Y - cursor.Y);
            g.DrawEllipse(DrawingUtil.ghostOutline, x, y, width, height);
        }

        public override void beginDraw(Point cursorPos)
        {
            center = cursorPos;
        }

        public override Shape finishDraw(Point cursor)
        {
            int x = Math.Min(center.X, cursor.X);
            int y = Math.Min(center.Y, cursor.Y);

            int width = Math.Abs(center.X - cursor.X);
            int height = Math.Abs(center.Y - cursor.Y);
            return new Ellipse(x, y, width, height);
        }
    }
}
