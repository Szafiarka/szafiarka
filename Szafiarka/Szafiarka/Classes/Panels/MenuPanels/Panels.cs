using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szafiarka.Classes
{
    class Panels : Panel
    {        
        public Panels()
        {
            Location = new System.Drawing.Point(110, 70);
            Size = new System.Drawing.Size(1060, 680);
            Visible = false;
        }

        public void changeVisableToTrue()
        {
            Visible = true;
        }

        public void changeVisableToFalse()
        {
            Visible = false;
        }
    }
}
