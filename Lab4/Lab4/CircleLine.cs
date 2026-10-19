using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    internal class CircleLine : Line
    {
        private Ellipse beginC;
        private Ellipse endC;
        private static int circleD = 5; 

        public CircleLine(int x1, int y1, int x2, int y2)
        : base(x1, y1, x2, y2) {
            beginC = new Ellipse(x1 - circleD / 2, y1 - circleD / 2, circleD, circleD);
            endC = new Ellipse(x2 - circleD / 2, y2 - circleD / 2, circleD, circleD);
        }

        public CircleLine() : base() { }

        public override void beginDraw(Point cursorPos)
        {
            base.beginDraw(cursorPos);
            beginC = new Ellipse(cursorPos.X, cursorPos.Y, circleD, circleD);
            endC = new Ellipse(cursorPos.X, cursorPos.Y, circleD, circleD);

        }

        public override void draw(Graphics g)
        {
            base.draw(g);
            beginC.draw(g);
            endC.draw(g);
        }

        public override void drawGhost(Graphics g, Point cursor)
        {
            base.drawGhost(g, cursor);
            endC = new Ellipse(cursor.X, cursor.Y, circleD, circleD);
            beginC.drawGhost(g, new Point(beginC.x + circleD / 2, beginC.y + circleD / 2));
            endC.drawGhost(g, new Point(endC.x + circleD / 2, endC.y + circleD / 2));
            //new Point(endC.x + circleD / 2, endC.y + circleD / 2)

        }

        public override Shape finishDraw(Point cursor)
        {
            return new CircleLine(x, y, end.X, end.Y);
        }
    }
}
