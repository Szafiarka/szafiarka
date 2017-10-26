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
        private static string PATHTOIMAGE = "..\\..\\images\\settings.png";

        public OptionsButton()
        {
            Location = new Point(1097, 21);
            Size = new Size(75, 25);
            UseVisualStyleBackColor = true;
            Name = "bSettings";

            Text = "Opcje";
            TextAlign = ContentAlignment.MiddleRight;

            Image = Image.FromFile(@PATHTOIMAGE);
            ImageAlign = ContentAlignment.MiddleLeft;

            InitializecontextMenuStrip1();
            Click += new EventHandler(button1_Click);
        }

        private void InitializecontextMenuStrip1()
        {
            contextMenuStrip1.Items.Clear();
            contextMenuStrip1.Items.Add("pomoc");
            contextMenuStrip1.Items.Add("o programie");
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
