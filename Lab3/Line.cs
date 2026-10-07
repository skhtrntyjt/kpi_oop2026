using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class Line : Shape
    {
        private Point end;
        public Line(int x1, int y1, int x2, int y2)
            : base(x1, y1, 0, 0) {
            end = new Point(x2, y2);
            x = x1;
            y = y1;
        }
        public Line() : base() { }
        public override void draw(Graphics g)
        {
            g.DrawLine(DrawingUtil.outline, x, y, end.X, end.Y);
        }

        public override void drawGhost(Graphics g, Point cursor)
        {
            end.X = cursor.X;
            end.Y = cursor.Y;
            g.DrawLine(DrawingUtil.ghostOutline, x, y, end.X, end.Y);
        }

        public override void beginDraw(Point cursorPos)
        {
            x = cursorPos.X;
            y = cursorPos.Y;
        }

        public override Shape finishDraw(Point cursor)
        {
            return new Line(x, y, end.X, end.Y);
        }
    }
}
