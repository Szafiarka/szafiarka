using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szafiarka.Classes
{
    class HelpButton : FlattButton
    {
        private static string PATHTOIMAGE = "";

        public HelpButton()
        {
            Location = new Point(1017, 21);
            Size = new Size(75, 25);
            UseVisualStyleBackColor = true;
            Text = "Pomoc";
            Name = "bHelp";;
            Click += new EventHandler(help_Click);
        }

        private void help_Click(object sender, EventArgs e)
        {
            Panels.changePanelsVisableToFalse();
            Panels.changePanelVisableToTrue(Panels.PanelsName.PHELP);
        }
    }
}
