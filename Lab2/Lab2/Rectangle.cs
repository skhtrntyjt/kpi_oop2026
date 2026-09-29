using System.Drawing;

namespace Lab2
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
            int width = (center.X - cursor.X) * 2;
            int height = (center.Y - cursor.Y) * 2;
            g.DrawRectangle(DrawingUtil.ghostOutline, cursor.X, cursor.Y,
                width, height);
        }

        public override void beginDraw(Point cursorPos)
        {
            center = cursorPos;
        }

        public override Shape finishDraw(Point cursor)
        {
            int width = (center.X - cursor.X) * 2;
            int height = (center.Y - cursor.Y) * 2;
            return new Rectangle(cursor.X, cursor.Y, width, height);
        }
    }
}
