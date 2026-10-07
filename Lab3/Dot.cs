using System.Drawing;

namespace Lab3
{
    internal class Dot : Shape
    {
        private static int dotSize = 8;
        public Dot(int x, int y)
            : base(x, y, dotSize, dotSize) { }
        public Dot() : base() { }

        public override void draw(Graphics g)
        {

            g.FillEllipse(DrawingUtil.dotBrush, x - dotSize / 2, y - dotSize / 2, dotSize, dotSize);
        }

        public override void drawGhost(Graphics g, Point cursor)
        {
            x = cursor.X;
            y = cursor.Y;
            g.DrawEllipse(DrawingUtil.ghostOutline, x - dotSize / 2, y - dotSize / 2, dotSize, dotSize);
        }

        public override void beginDraw(Point cursorPos)
        {

        }

        public override Shape finishDraw(Point cursor)
        {
            return new Dot(x, y);
        }
    }
}
