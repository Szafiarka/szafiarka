using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szafiarka.Classes
{
    class HeaderLabel1: Label
    {
       public  HeaderLabel1()
        {
            Size = new Size(900, 30);
            ForeColor = Color.White;
            Font = new Font("Arial", 16, FontStyle.Bold);
        }
    }
}
