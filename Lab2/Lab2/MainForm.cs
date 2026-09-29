using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab2
{
    public partial class MainForm : Form
    {
        bool drawing = false;
        Point cursor = new Point(0, 0);
        Shape currentShape = new Dot();
        public MainForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            foreach (Shape shape in DrawingUtil.shapeList)
            {
                shape.draw(g);
            }
            if (drawing)
            {
                currentShape.drawGhost(g, cursor);
            }
        }

        private void dotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentShape = new Dot();
            this.Text = "Drawing: Dot";
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentShape = new Line();
            this.Text = "Drawing: Line";
        }

        private void rectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentShape = new Rectangle();
            this.Text = "Drawing: Rectangle";
        }

        private void ellipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentShape = new Ellipse();
            this.Text = "Drawing: Ellipse";
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            drawing = true;
            cursor = new Point(e.Location.X, e.Location.Y);
            currentShape.beginDraw(cursor);
            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            drawing = false;
            DrawingUtil.shapeList.Add(currentShape.finishDraw(e.Location));
            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                pictureBox1.Invalidate();
                cursor = e.Location;
            }
        }
    }
}
