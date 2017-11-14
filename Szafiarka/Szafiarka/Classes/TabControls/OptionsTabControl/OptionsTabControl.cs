using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Szafiarka.Classes
{
    class OptionsTabControl: TabControl
    {
        public OptionsTabControl()
        {
            this.Size = new Size(1000, 647);//(900, 582);
            this.Location = new Point(0,0);//(50, 32);     //testowy rozmiar i lokalizacja
            this.Name = "OptionsTabControl";
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }
    }
}
