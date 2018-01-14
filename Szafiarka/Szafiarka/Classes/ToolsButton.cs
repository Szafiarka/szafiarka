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

        public ToolsButton()
        {
            Location = new Point(1097, 21);
            Size = new Size(80, 25);
            UseVisualStyleBackColor = true;
            Text = "Narzędzia";
            Name = "bTools";
            //InitializeContextMenuStrip1();
            Click += new EventHandler(tools_Click);
        }


        private void tools_Click(object sender, EventArgs e)
        {
            var optionForm = new OptionsForm();
            optionForm.Show();
            optionForm.Text = Utils.GetEnumDescription(ToolName.OPTIONS);
        }
       

    }
}