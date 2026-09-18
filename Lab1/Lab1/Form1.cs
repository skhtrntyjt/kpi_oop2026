using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        private int value;
        public Form1()
        {
            InitializeComponent();
            value = 1;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        public int getValue() { return value; }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            label1.Text = value.ToString();
        }

        private void hScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            value = hScrollBar1.Value;
            label1.Text = value.ToString();
        }
    }
}
