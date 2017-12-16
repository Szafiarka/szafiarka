using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szafiarka.Classes
{
    class FieldTitleLabel: Label
    {
        public FieldTitleLabel()
        {
            Size = new Size(140, 25);
            ForeColor = Color.White;
            Font = new Font("Arial", 12, FontStyle.Bold);
        }
    }
}
