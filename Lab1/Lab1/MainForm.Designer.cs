namespace Lab1
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            menuStrip1 = new MenuStrip();
            form1ToolStripMenuItem = new ToolStripMenuItem();
            form2ToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 25F, FontStyle.Bold);
            label1.Location = new Point(321, 274);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(389, 57);
            label1.TabIndex = 1;
            label1.Text = "Число не вибрано";
            label1.Click += label1_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { form1ToolStripMenuItem, form2ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1067, 28);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // form1ToolStripMenuItem
            // 
            form1ToolStripMenuItem.Name = "form1ToolStripMenuItem";
            form1ToolStripMenuItem.Size = new Size(65, 24);
            form1ToolStripMenuItem.Text = "Form1";
            form1ToolStripMenuItem.Click += form1ToolStripMenuItem_Click;
            // 
            // form2ToolStripMenuItem
            // 
            form2ToolStripMenuItem.Name = "form2ToolStripMenuItem";
            form2ToolStripMenuItem.Size = new Size(65, 24);
            form2ToolStripMenuItem.Text = "Form2";
            form2ToolStripMenuItem.Click += form2ToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1067, 692);
            Controls.Add(menuStrip1);
            Controls.Add(label1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 5, 4, 5);
            Name = "MainForm";
            Text = "MainForm";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem form1ToolStripMenuItem;
        private ToolStripMenuItem form2ToolStripMenuItem;
    }
}