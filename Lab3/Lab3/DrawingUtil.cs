using System.Collections.Generic;
using System.Drawing;

namespace Lab3
{
    internal class DrawingUtil
    {
        public static Shape[] shapeList = new Shape[122];
        public static int shapeCount = 0;
        public static Pen ghostOutline = new Pen(Color.Blue, 3);
        public static Pen outline = new Pen(Color.Black, 3);
        public static Brush shapeInfillRectangle = new SolidBrush(Color.Orange);
        public static Brush shapeInfillEllipse = new SolidBrush(Color.White);
        public static Brush dotBrush = new SolidBrush(Color.Black);
    }
}
