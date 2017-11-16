using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szafiarka.Classes
{
    class PanelAddStatus : Panels
    {
        private System.Windows.Forms.TextBox textBox1;
        private FlatButton flatButton1;
        private System.Windows.Forms.Label label1;

        public PanelAddStatus()
        {
            Name = "pAddStatus";
            //BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.flatButton1 = new Szafiarka.Classes.FlatButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nazwa";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 50);
            this.textBox1.TabIndex = 0;
            // 
            // flatButton1
            // 
            this.flatButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(168)))), ((int)(((byte)(204)))));
            this.flatButton1.FlatAppearance.BorderSize = 0;
            this.flatButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.flatButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.flatButton1.Location = new System.Drawing.Point(200, 0);
            this.flatButton1.Name = "flatButton1";
            this.flatButton1.Size = new System.Drawing.Size(75, 23);
            this.flatButton1.TabIndex = 0;
            this.flatButton1.Text = "flatButton1";
            this.flatButton1.UseVisualStyleBackColor = false;
            // 
            // PanelAddStatus
            // 
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.flatButton1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
