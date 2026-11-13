using System.Drawing;
using System.Windows.Forms.VisualStyles;

namespace lab5
{
    internal class Dot : Shape
    {
        private static int dotSize = 8;
        public Dot(int x, int y)
            : base(x, y, dotSize, dotSize) {
            serializationType = "dot";
        }
        public Dot() : base() {
            serializationType = "dot";
        }

        public override void draw(Graphics g, bool highlighted = false)
        {
            MyEditor e = MyEditor.getInstance();
            Brush b = e.dotBrush;
            if (highlighted)
                b = e.dotHighlight;
            g.FillEllipse(b, x - dotSize / 2, y - dotSize / 2, dotSize, dotSize);
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

        public override void reInit()
        {
        }
    }
}
