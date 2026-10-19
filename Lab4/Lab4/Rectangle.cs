using System;
using System.Drawing;

namespace Lab4
{
    internal class Rectangle : Shape
    {
        private Point center;
        public Rectangle(int x, int y, int width, int height)
            : base(x, y, width, height) {
            center = new Point(x + width / 2, y + height / 2);
        }
        public Rectangle() : base() { }
        public override void draw(Graphics g)
        {
            MyEditor e = MyEditor.getInstance();
            //g.FillRectangle(e.shapeInfillRectangle, x, y, width, height);
            g.DrawRectangle(e.outline, x, y, width, height);
        }

        public override void drawGhost(Graphics g, Point cursor)
        {
            x = Math.Min(center.X, cursor.X);
            y = Math.Min(center.Y, cursor.Y);

            width = Math.Abs(center.X - cursor.X);
            height = Math.Abs(center.Y - cursor.Y);
            MyEditor e = MyEditor.getInstance();
            g.DrawRectangle(e.ghostOutline, x, y,
                width, height);
        }

        public override void beginDraw(Point cursorPos)
        {
            center = cursorPos;
        }

        public override Shape finishDraw(Point cursor)
        {
            x = Math.Min(center.X, cursor.X);
            y = Math.Min(center.Y, cursor.Y);

            width = Math.Abs(center.X - cursor.X);
            height = Math.Abs(center.Y - cursor.Y);
            return new Rectangle(x, y, width, height);
        }
    }
}
