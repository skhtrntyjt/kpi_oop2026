using System;
using System.Drawing;

namespace Lab3
{
    internal class Ellipse : Shape
    {
        private Point center;
        public Ellipse(int x, int y, int width, int height)
            : base(x, y, width, height) { }
        public Ellipse() : base() { }

        public override void draw(Graphics g)
        {
            g.DrawEllipse(DrawingUtil.outline, x, y, width, height);
        }

        public override void drawGhost(Graphics g, Point cursor)
        {
            int width = (center.X - cursor.X) * 2;
            int height = (center.Y - cursor.Y) * 2;
            g.DrawEllipse(DrawingUtil.ghostOutline, cursor.X, cursor.Y, width, height);
        }

        public override void beginDraw(Point cursorPos)
        {
            center = cursorPos;
        }

        public override Shape finishDraw(Point cursor)
        {
            int width = (center.X - cursor.X) * 2;
            int height = (center.Y - cursor.Y) * 2;
            return new Ellipse(cursor.X, cursor.Y, width, height);
        }
    }
}
