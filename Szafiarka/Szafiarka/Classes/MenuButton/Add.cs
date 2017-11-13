using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Szafiarka.Forms.ItemForm;

namespace Szafiarka.Classes
{
    partial class MenuButton
    {
        private void add_Click(object sender, EventArgs e)
        {
            var form = new ItemForm();
            form.ShowDialog();
        }
    }
}

