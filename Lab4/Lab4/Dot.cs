using System.Drawing;

namespace Lab4
{
    internal class Dot : Shape
    {
        private static int dotSize = 8;
        public Dot(int x, int y)
            : base(x, y, dotSize, dotSize) { }
        public Dot() : base() { }

        public override void draw(Graphics g)
        {
            MyEditor e = MyEditor.getInstance();
            g.FillEllipse(e.dotBrush, x - dotSize / 2, y - dotSize / 2, dotSize, dotSize);
        }

        public override void drawGhost(Graphics g, Point cursor)
        {
            x = cursor.X;
            y = cursor.Y;
            MyEditor e = MyEditor.getInstance();
            g.DrawEllipse(e.ghostOutline, x - dotSize / 2, y - dotSize / 2, dotSize, dotSize);
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
