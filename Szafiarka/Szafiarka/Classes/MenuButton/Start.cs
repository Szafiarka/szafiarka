using System;
using System.Linq;
using System.Windows.Forms;

namespace Szafiarka.Classes
{
    partial class MenuButton
    {
        private void start_Click(object sender, EventArgs e)
        {
            Panels.changePanelsVisableToFalse();
            Panels.changePanelVisableToTrue(Panels.PanelsName.PSTART);
            PanelStart.changePanelsVisableToFalse();
        }
    }
}