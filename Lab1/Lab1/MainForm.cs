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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void form1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            if (form.ShowDialog() == DialogResult.OK)
            {
                label1.Text = "Число: " + form.getValue();
            }
            else
            {
                MessageBox.Show("Зміни скасовано");
            }
        }

        private void form2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Hide();
            Form2 form = new Form2();
            if (form.ShowDialog() == DialogResult.OK)
            {
                Form3 form1 = new Form3();
                DialogResult res1 = form1.ShowDialog();
                if (res1 == DialogResult.Retry)
                {
                    form2ToolStripMenuItem_Click(sender, e);
                    return;
                }

            }
            Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
