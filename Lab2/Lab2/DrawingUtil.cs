using System.Collections.Generic;
using System.Drawing;

namespace Lab2
{
    internal class DrawingUtil
    {
        public static List<Shape> shapeList = new List<Shape>(121);

        public static Pen ghostOutline = new Pen(Color.Red, 3);
        public static Pen outline = new Pen(Color.Black, 3);
        public static Brush shapeInfillRectangle = new SolidBrush(Color.Pink);
        public static Brush shapeInfillEllipse = new SolidBrush(Color.White);
        public static Brush dotBrush = new SolidBrush(Color.Black);
    }
}
