using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Szafiarka.Forms.ToolsForm;

namespace Szafiarka.Classes
{
    class ToolsButton : FlatButton
    {
        ContextMenuStrip contextMenuStrip1 = new ContextMenuStrip();
        private bool contextMenuStrip1Clicked = false;

        private enum ToolName
        {
            [Description("Pomoc")]
            HELP,
            [Description("Opcje")]
            OPTIONS,
        }

        public ToolsButton()
        {
            Location = new Point(1097, 21);
            Size = new Size(80, 25);
            UseVisualStyleBackColor = true;
            Text = "Narzędzia";
            Name = "bTools";
            InitializecontextMenuStrip1();
            Click += new EventHandler(tools_Click);
        }

        private void InitializecontextMenuStrip1()
        {
            contextMenuStrip1.Items.Clear();
            contextMenuStrip1.Items.Add(GetEnumDescription(ToolName.HELP));
            contextMenuStrip1.Items.Add(GetEnumDescription(ToolName.OPTIONS));
            contextMenuStrip1.ItemClicked += new ToolStripItemClickedEventHandler(
                                                 contextMenuStrip1_ItemClicked);
        }

        private void tools_Click(object sender, EventArgs e)
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

            if (e.ClickedItem.Text == GetEnumDescription(ToolName.HELP))
            {
                Form helpForm = new ToolsForm();
                helpForm.Show();
                helpForm.Text = "Pomoc";
            }
            if (e.ClickedItem.Text == GetEnumDescription(ToolName.OPTIONS))
            {
                Form optionForm = new ToolsForm();
                optionForm.Show();
                optionForm.Text = "Opcje";
            }
        }

    }
}