using System.Collections.Generic;
using System.Drawing;

namespace Lab4
{
    internal class MyEditor
    {
        private static MyEditor instance;
        private static bool initialized = false;

        private MyEditor() {
            ghostOutline.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
        }

        public static MyEditor getInstance()
        {
            if (!initialized)
            {
                initialized = true;
                instance = new MyEditor();
            }
            return instance;
        }

        public List<Shape> shapeList { get; } = new List<Shape>(121);
        public Pen ghostOutline { get; } = new Pen(Color.Red, 3);
        public Pen outline { get; } = new Pen(Color.Black, 3);
        public Brush shapeInfillRectangle { get; } = new SolidBrush(Color.Orange);
        public Brush shapeInfillEllipse { get; } = new SolidBrush(Color.White);
        public Brush dotBrush { get; } = new SolidBrush(Color.Black);
    }
}
