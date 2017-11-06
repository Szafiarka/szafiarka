using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szafiarka.Classes
{
    partial class MenuButton
    {
        private ContextMenuStrip contextMenuStripAdd = new ContextMenuStrip();
        private enum menuStripOptions
        {
            [Description("Dodaj status")]
            STATUS,
            [Description("Dodaj kategorię")]
            CATEGORY,
            [Description("Dodaj pokój")]
            ROOM,
            [Description("Dodaj szafę")]
            WARDROB,
            [Description("Dodaj rzecz")]
            ITEM,
        }

        private void add_Click(object sender, EventArgs e)
        {
            InitializeContextMenuStripAdd();
            contextMenuStripAdd.Show((sender as MenuButton), new Point(Width, 0));
        }

        private void InitializeContextMenuStripAdd()
        {
            contextMenuStripAdd.BackColor = this.BackColor;
            contextMenuStripAdd.Items.Clear();
            foreach (menuStripOptions item in Enum.GetValues(typeof(menuStripOptions)))
            {
                contextMenuStripAdd.Items.Add(GetEnumDescription(item));
            }
            contextMenuStripAdd.ItemClicked += new ToolStripItemClickedEventHandler(
                                                 contextMenuStrip_ItemClicked);
        }

        private void contextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Panels.changePanelsVisableToFalse();
            if (e.ClickedItem.Text == GetEnumDescription(menuStripOptions.STATUS))
            {
                Panels.changePanelVisableToTrue(Panels.PanelsName.PADDSTATUS);
            }
        }
    }
}

