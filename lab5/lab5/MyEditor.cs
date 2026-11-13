using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace lab5
{
    internal class MyEditor
    {
      private static readonly MyEditor instance = new MyEditor();

 private MyEditor()
 {
     ghostOutline.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
 }

 public static MyEditor getInstance()
 {
     return instance;
 }

        public BindingList<Shape> shapeList { get; } = new BindingList<Shape>(
            new List<Shape>(121));
        public Pen ghostOutline { get; } = new Pen(Color.Red, 3);
        public Pen outline { get; } = new Pen(Color.Black, 3);
        public Pen highlight { get; } = new Pen(Color.LimeGreen, 4);
        public Brush shapeInfillRectangle { get; } = new SolidBrush(Color.Orange);
        public Brush shapeInfillEllipse { get; } = new SolidBrush(Color.White);
        public Brush dotBrush { get; } = new SolidBrush(Color.Black);
        public Brush dotHighlight { get; } = new SolidBrush(Color.LimeGreen);
    }
}
