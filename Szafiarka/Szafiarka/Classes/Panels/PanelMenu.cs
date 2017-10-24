using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szafiarka.Classes
{
    class PanelMenu : Panel
    {
        public PanelMenu()
        {
            BackColor = System.Drawing.Color.FromArgb(1, 168, 204);
            Location = new System.Drawing.Point(0, 0);
            Size = new System.Drawing.Size(100, 766);
            Name = "pMenu";
        }
    }
}
