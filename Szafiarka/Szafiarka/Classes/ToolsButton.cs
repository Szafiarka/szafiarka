using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Szafiarka.Forms.OptionsForm;
using Szafiarka.Forms.HelpForm;

namespace Szafiarka.Classes
{
    class ToolsButton : FlatButton
    {
        private ContextMenuStrip contextMenuStrip1 = new ContextMenuStrip();
        private bool contextMenuStrip1Clicked = false;

        private enum ToolName
        {
            [Description("Pomoc")]
            HELP,
            [Description("Opcje")]
            OPTIONS,
        }

        private Utils utils = new Utils();
        public ToolsButton()
        {
            Location = new Point(1097, 21);
            Size = new Size(80, 25);
            UseVisualStyleBackColor = true;
            Text = "Narzędzia";
            Name = "bTools";
            InitializeContextMenuStrip1();
            Click += new EventHandler(tools_Click);
        }

        private void InitializeContextMenuStrip1()
        {
            contextMenuStrip1.Items.Clear();
            foreach (ToolName item in Enum.GetValues(typeof(ToolName)))
            {
                contextMenuStrip1.Items.Add(utils.GetEnumDescription(item));
            }
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

            if (e.ClickedItem.Text == utils.GetEnumDescription(ToolName.HELP))
            {
                var helpForm = new HelpForm();
                helpForm.Show();
                helpForm.Text = utils.GetEnumDescription(ToolName.HELP);
            }
            if (e.ClickedItem.Text == utils.GetEnumDescription(ToolName.OPTIONS))
            {
                var optionForm = new OptionsForm();
                optionForm.Show();
                optionForm.Text = utils.GetEnumDescription(ToolName.OPTIONS);
            }
        }

    }
}