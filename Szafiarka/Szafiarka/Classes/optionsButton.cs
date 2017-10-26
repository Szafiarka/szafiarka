using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szafiarka.Classes
{
    class OptionsButton : FlattButton
    {
        ContextMenuStrip contextMenuStrip1 = new ContextMenuStrip();
        private bool contextMenuStrip1Clicked = false;
        private static string PATHTOIMAGE = "";

        public OptionsButton()
        {
            Location = new Point(1097, 21);
            Size = new Size(75, 25);
            UseVisualStyleBackColor = true;
            Text = "Opcje";
            Name = "bSettings";
            InitializecontextMenuStrip1();
            Click += new EventHandler(button1_Click);
        }

        private void InitializecontextMenuStrip1()
        {
            contextMenuStrip1.Items.Clear();
            contextMenuStrip1.Items.Add("item1");
            contextMenuStrip1.Items.Add("item2");
            contextMenuStrip1.ItemClicked += new ToolStripItemClickedEventHandler(
                                                 contextMenuStrip1_ItemClicked);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!contextMenuStrip1Clicked)
            {
                contextMenuStrip1Clicked = true;
                contextMenuStrip1.Show(this, new Point(0, this.Height));
            }
            else
                contextMenuStrip1Clicked = false;
        }
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip1Clicked = false;
        }

    }
}
