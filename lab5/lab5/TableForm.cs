using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace lab5
{
    public partial class TableForm : Form
    {
        public TableForm()
        {
            InitializeComponent();
        }

        private void TableForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = MyEditor.getInstance().shapeList;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            MainForm mainForm = (MainForm)Owner;
            mainForm.redraw();
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            MainForm mainForm = (MainForm)Owner;
            mainForm.redraw();
        }

        private void dataGridView1_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            if (e.StateChanged == DataGridViewElementStates.Selected)
            {
                MainForm mainForm = (MainForm)Owner;
                HashSet<int> selected = new HashSet<int>();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Selected)
                        {
                            selected.Add(row.Index);
                        }
                    }

                }
                if (selected.Count > 0)
                {
                    mainForm.highlight(new List<int>(selected));
                    mainForm.redraw();
                }
            }
        }

        private void TableForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm mainForm = (MainForm)Owner;
            mainForm.highlight(new List<int>());
            mainForm.redraw();
        }
    }
}
