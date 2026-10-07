using System;
using System.Drawing;

namespace Lab3
{
    internal class Rectangle : Shape
    {
        private Point center;
        public Rectangle(int x, int y, int width, int height)
            : base(x, y, width, height) { }
        public Rectangle() : base() { }
        public override void draw(Graphics g)
        {
            g.FillRectangle(DrawingUtil.shapeInfillRectangle, x, y, width, height);
            g.DrawRectangle(DrawingUtil.outline, x, y, width, height);
        }

        public override void drawGhost(Graphics g, Point cursor)
        {
            int x = Math.Min(center.X, cursor.X);
            int y = Math.Min(center.Y, cursor.Y);

            int width = Math.Abs(center.X - cursor.X);
            int height = Math.Abs(center.Y - cursor.Y);
            g.DrawRectangle(DrawingUtil.ghostOutline, x, y,
                width, height);
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
            return new Rectangle(x, y, width, height);
        }
    }
}
