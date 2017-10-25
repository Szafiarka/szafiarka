using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szafiarka.Classes
{
    class PanelStart : Panels
    {
        private FlattButton button1;

        public PanelStart()
        {
            Name = "pStart";
            Visible = true;
            InitializeComponent();
        }

        private void start_Click(object sender, EventArgs e)
        {
            var rooms = DBconnection.DBCONNECTION.Room.ToArray();
            var result = from room in rooms where room.id_room == 16 select room;
            MessageBox.Show(result.First().name);
        }

            private void InitializeComponent()
        {
            button1 = new FlattButton();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(0, 0);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(75, 25);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += new EventHandler(start_Click);
            // 
            // PanelStart
            // 
            Controls.Add(button1);
            ResumeLayout(false);

        }
    }
}
