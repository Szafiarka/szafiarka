using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szafiarka.Classes
{
    partial class MenuButton
    {
        private void delete_Click(object sender, EventArgs e)
        {
            MessageBox.Show(GetEnumDescription(Messages.DELETE), "Warrning");
        }
    }
}