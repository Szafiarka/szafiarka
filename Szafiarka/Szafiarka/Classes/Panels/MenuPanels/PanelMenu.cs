using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Szafiarka.Classes
{
    class PanelMenu : Panel
    {
        public static Color defaultColor { get; private set; }

        public PanelMenu()
        {
            defaultColor = Color.FromArgb(1, 168, 204);
            BackColor = defaultColor;
            Location = new Point(0, 0);
            Size = new Size(100, 766);
            Name = "pMenu";
        }
    }
}
