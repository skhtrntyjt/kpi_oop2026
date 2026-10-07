using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab3
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

            for (int i = 0; i < DrawingUtil.shapeCount; i++)
            {
                DrawingUtil.shapeList[i].draw(g);
            }

            if (drawing)
            {
                currentShape.drawGhost(g, cursor);
            }
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
            if (DrawingUtil.shapeCount < DrawingUtil.shapeList.Length)
            {
                DrawingUtil.shapeList[DrawingUtil.shapeCount] = currentShape.finishDraw(e.Location);
                DrawingUtil.shapeCount++;
            }

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
        private void switchDot(object sender, EventArgs e)
        {
            currentShape = new Dot();
            toolStripTextBox1.Text = "Точка";
        }

        private void switchLine(object sender, EventArgs e)
        {
            currentShape = new Line();
            toolStripTextBox1.Text = "Лінія";
        }

        private void switchRectangle(object sender, EventArgs e)
        {
            currentShape = new Rectangle();
            toolStripTextBox1.Text = "Прямокутник";
        }

        private void switchEllipse(object sender, EventArgs e)
        {
            currentShape = new Ellipse();
            toolStripTextBox1.Text = "Еліпс";
        }
        
    }
}
