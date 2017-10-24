using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szafiarka.Classes
{
    partial class MenuButton
    {
        private void add_Click(object sender, EventArgs e)
        {
            var panel = (sender as MenuButton).FindForm().Controls.Find("pAdd", false);
            panel[0].Visible = true;
        }
    }
}

