using Microsoft.Win32;
using System.Drawing;

namespace lab5
{
    internal abstract class Shape
    {
        public int x { get; set; }
        public int y { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string serializationType { get; protected set; }
        public Shape(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            reInit();
        }

        public Shape() { }

        public abstract void draw(Graphics g, bool highlighted = false);

        public abstract void drawGhost(Graphics g, Point cursor);

        public abstract void beginDraw(Point cursorPos);

        public abstract Shape finishDraw(Point cursor);

        virtual public string serialize()
        {
            return serializationType + "|" + x + "|" + y + "|" + width 
                + "|" + height;
        }

        public abstract void reInit();

        virtual public void deserialize(string data)
        {
            string[] values = getDeserializeValues(data);
            if (values == null)
            {
                return;
            }
            x = int.Parse(values[1]);
            y = int.Parse(values[2]);
            width = int.Parse(values[3]);
            height = int.Parse(values[4]);
            reInit();
        }

        protected string[] getDeserializeValues(string data)
        {
            string[] values = data.Split('|');
            string type = values[0];
            if (type != serializationType)
            {
                return null;
            }
            return values;
        }

    }
}
