using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab4
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
            MyEditor editor = MyEditor.getInstance();
            foreach (Shape shape in editor.shapeList)
            {
                shape.draw(g);
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
            MyEditor editor = MyEditor.getInstance();
            editor.shapeList.Add(currentShape.finishDraw(e.Location));
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

        private void switchSquare(object sender, EventArgs e)
        {
            currentShape = new Rectangle();
            toolStripTextBox1.Text = "Прямокутник";
        }

        private void switchEllipse(object sender, EventArgs e)
        {
            currentShape = new Ellipse();
            toolStripTextBox1.Text = "Еліпс";
        }

        private void switchCircleLine(object sender, EventArgs e)
        {
            currentShape = new CircleLine();
            toolStripTextBox1.Text = "Лінія з кружечками";
        }

        private void switchCube(object sender, EventArgs e)
        {
            currentShape = new CubeFrame();
            toolStripTextBox1.Text = "Куб";
        }
    }
}
