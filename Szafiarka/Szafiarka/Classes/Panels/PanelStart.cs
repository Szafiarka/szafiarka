using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szafiarka.Classes
{
    class PanelStart : Panels
    {
        private System.Windows.Forms.Button button1;

        public PanelStart()
        {
            Name = "pStart";
            //BackColor = System.Drawing.Color.FromArgb(255, 168, 255);
            Visible = true;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            button1 = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(0, 0);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // PanelStart
            // 
            Controls.Add(button1);
            ResumeLayout(false);

        }
    }
}
