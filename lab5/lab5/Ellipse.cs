using System;
using System.Drawing;

namespace lab5
{
    internal class Ellipse : Shape
    {
        private Point center;
        public Ellipse(int x, int y, int width, int height)
            : base(x, y, width, height) {
            reInit();
            serializationType = "ellipse";
        }
        public Ellipse() : base() {
            serializationType = "ellipse";
        }

        public override void draw(Graphics g, bool highlighted = false)
        {
            //g.FillEllipse(DrawingUtil.shapeInfillEllipse, x, y, width, height);
            MyEditor e = MyEditor.getInstance();
            Pen pen = e.outline;
            if (highlighted)
                pen = e.highlight;
            g.DrawEllipse(pen, x, y, width, height);
        }

        public override void drawGhost(Graphics g, Point cursor)
        {
            int width = (center.X - cursor.X) * 2;
            int height = (center.Y - cursor.Y) * 2;
            MyEditor e = MyEditor.getInstance();
            g.DrawEllipse(e.ghostOutline, cursor.X, cursor.Y, width, height);
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

        public override void reInit()
        {
            center = new Point(x, y);
        }
    }
}
