using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Reflection;

namespace Szafiarka.Classes
{
    class FlatButton : Button
    {
        public FlatButton() : base()
        {
            FlatStyle = FlatStyle.Flat;
            Font = new Font(this.Font.Name, 10);
            FlatAppearance.BorderSize = 0;
            BackColor = Color.FromArgb(1, 168, 204);
        }

        public void changeBackColor(Color color)
        {
            BackColor = color;
        }
    }
}
