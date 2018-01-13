using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Szafiarka.Forms.OptionsForm;

namespace Szafiarka.Classes
{
    class OptionsButton : FlatButton
    {
        public OptionsButton()
        {
            Location = new Point(1097, 21);
            Size = new Size(80, 25);
            UseVisualStyleBackColor = true;
            Text = "Opcje";
            Name = "bOptions";
            Click += new EventHandler(tools_Click);
        }

        private void tools_Click(object sender, EventArgs e)
        {
            var optionForm = new OptionsForm();
            optionForm.Show();
            optionForm.Text = "Opcje";
        }
    }
}