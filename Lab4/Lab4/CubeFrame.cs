using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    internal class CubeFrame : Shape
    {
        private Rectangle front = new Rectangle();
        private Rectangle back = new Rectangle();
        public CubeFrame(int x, int y, int width, int height)
            : base(x, y, width, height)
        {
            back = new Rectangle(x, y, width, height);
            Point f = new Point(
                (int)(back.x - width * 0.5),
                (int)(back.y + height * 0.5));
            front = new Rectangle(f.X, f.Y, width, height);
        }
        public CubeFrame() : base() { }
        public override void beginDraw(Point cursorPos)
        {
            back.beginDraw(cursorPos);
        }

        public override void draw(Graphics g)
        {
            back.draw(g);
            front.draw(g);
            int w = back.width;
            int h = back.height;
            MyEditor e = MyEditor.getInstance();
            g.DrawLine(e.outline, front.x, front.y, back.x, back.y);
            g.DrawLine(e.outline, front.x + w, front.y, back.x + w, back.y);
            g.DrawLine(e.outline, front.x, front.y + h, back.x, back.y + h);
            g.DrawLine(e.outline, front.x + w, front.y + h, back.x + w, back.y + h);
        }

        public override void drawGhost(Graphics g, Point cursor)
        {
            back.drawGhost(g, cursor);
            int w = back.width;
            int h = back.height;
            Point f = new Point(
                (int)(back.x - w * 0.5),
                (int)(back.y + h * 0.5));
            Point fc = new Point(
                (int)(cursor.X + w * 0.5),
                (int)(cursor.Y + h * 0.5));

            front = new Rectangle(f.X, f.Y, w, h);
            //front.beginDraw(f);
            //front.drawGhost(g, fc);
            MyEditor e = MyEditor.getInstance();
            g.DrawRectangle(e.ghostOutline, front.x, front.y, front.width, front.height);
            g.DrawLine(e.ghostOutline, front.x, front.y, back.x, back.y);
            g.DrawLine(e.ghostOutline, front.x + w, front.y, back.x + w, back.y);
            g.DrawLine(e.ghostOutline, front.x, front.y + h, back.x, back.y + h);
            g.DrawLine(e.ghostOutline, front.x + w, front.y + h, back.x + w, back.y + h);
        }

        public override Shape finishDraw(Point cursor)
        {
            return new CubeFrame(back.x, back.y, back.width, back.height);
        }
    }
}
