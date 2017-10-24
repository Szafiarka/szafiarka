using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szafiarka.Classes
{
    class Panels : Panel
    {
        public Panels()
        {
            Location = new System.Drawing.Point(107, 68);
            Size = new System.Drawing.Size(1065, 686);
            Visible = false;
        }

        public void initializePanels(Form form)
        {
            var pAdd = new PanelAdd();
            form.Controls.Add(pAdd);
        }
    }
}
