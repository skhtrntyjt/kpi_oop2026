using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace lab5
{

    public partial class MainForm : Form
    {
        bool drawing = false;
        Point cursor = new Point(0, 0);
        Shape currentShape = new Dot();
        List<int> highlightedShapes = new List<int>();
        public MainForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            MyEditor editor = MyEditor.getInstance();
            for (int i = 0; i < editor.shapeList.Count; i++)
            {
                Shape shape = editor.shapeList[i];
                shape.draw(g, highlightedShapes.Contains(i));
            }
            if (drawing)
            {
                currentShape.drawGhost(g, cursor);
            }
        }

        public void redraw()
        {
            pictureBox1.Invalidate();
        }

        public void highlight(List<int> indexes)
        {
            highlightedShapes.Clear();
            highlightedShapes.AddRange(indexes);
            
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
            if (!drawing)
                return;
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

        private Shape getShape(string shapeName)
        {
            if (new CircleLine().serializationType == shapeName)
            {
                return new CircleLine();
            }
            if (new Line().serializationType == shapeName)
            {
                return new Line();
            }
            if (new Dot().serializationType == shapeName)
            {
                return new Dot();
            }
            if (new CubeFrame().serializationType == shapeName)
            {
                return new CubeFrame();
            }
            if (new Ellipse().serializationType == shapeName)
            {
                return new Ellipse();
            }
            if (new Rectangle().serializationType == shapeName)
            {
                return new Rectangle();
            }
            return null;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog.FileName;

                MyEditor.getInstance().shapeList.Clear();

                string serializationStr = File.ReadAllText(filename);
                BindingList<Shape> shapeList = MyEditor.getInstance().shapeList;
              



                foreach (string s in serializationStr.Split('\n'))
                {
                    string[] data = s.Trim().Split('|');
                    Shape sh = getShape(data[0]);
                    if (sh != null)
                    {
                        sh.deserialize(s);
                        shapeList.Add(sh);
                    }
                }
                pictureBox1.Invalidate();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFileDialog.FileName;
                string serializationStr = "";
                foreach (Shape s in MyEditor.getInstance().shapeList)
                {
                    serializationStr += s.serialize() + "\n";
                }
                File.WriteAllText(filename, serializationStr);
            }
        }

        private void openTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TableForm form = new TableForm();
            form.Show(this);
            
        }
    }
}
