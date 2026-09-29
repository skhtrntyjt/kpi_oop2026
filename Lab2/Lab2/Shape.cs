using System.Drawing;

namespace Lab2
{
    internal abstract class Shape
    {
        public int x { get; set; }
        public int y { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public Shape(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public Shape() { }

        public abstract void draw(Graphics g);

        public abstract void drawGhost(Graphics g, Point cursor);

        public abstract void beginDraw(Point cursorPos);

        public abstract Shape finishDraw(Point cursor);
    }
}
