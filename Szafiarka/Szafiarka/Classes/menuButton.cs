using System;
using System.Windows.Forms;
using System.Drawing;

namespace Szafiarka.Classes
{
    class menuButton : Button 
    {
        public menuButton() : base()
        {
            UseVisualStyleBackColor = false;
            Size = new Size(80, 80);
            //BackColor = Color.FromArgb(200, 150, 75);
        }
    }
}
