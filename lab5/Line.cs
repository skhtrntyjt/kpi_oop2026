using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    internal class Line : Shape
    {
        protected Point end;
        public Line(int x1, int y1, int x2, int y2)
            : base(x1, y1, 0, 0) {
            end = new Point(x2, y2);
            x = x1;
            y = y1;
            serializationType = "line";
        }
        public Line() : base() {
            serializationType = "line";
        }
        public override void draw(Graphics g, bool highlighted = false)
        {
            MyEditor e = MyEditor.getInstance();
            Pen pen = e.outline;
            if (highlighted)
                pen = e.highlight;
            g.DrawLine(pen, x, y, end.X, end.Y);
        }

        public override void drawGhost(Graphics g, Point cursor)
        {
            end.X = cursor.X;
            end.Y = cursor.Y;
            MyEditor e = MyEditor.getInstance();
            g.DrawLine(e.ghostOutline, x, y, end.X, end.Y);
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

        public override string serialize()
        {
            return base.serialize() + "|" + end.X + "|" + end.Y;
        }

        public override void deserialize(string data)
        {
            base.deserialize(data);
            string[] values = getDeserializeValues(data);
            if (values == null)
            {
                return;
            }
            int x2 = int.Parse(values[5]);
            int y2 = int.Parse(values[6]);
            end = new Point(x2, y2);
            reInit();
        }

        public override void reInit()
        {
        }
    }
}
