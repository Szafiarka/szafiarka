using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Szafiarka.Classes
{
    class LabelRightPanelStartPanel : Label
    {
        public LabelRightPanelStartPanel()
        {
            Size = new Size(300, 30);
            ForeColor = Color.White;
            Font = Font = new Font("Arial", 16, FontStyle.Bold);
        }
    }
}
