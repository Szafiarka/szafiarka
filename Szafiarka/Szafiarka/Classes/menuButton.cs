using System;
using System.Windows.Forms;
using System.Drawing;

namespace Szafiarka.Classes
{
    class MenuButton : Button
    {
        public MenuButton() : base()
        {
            UseVisualStyleBackColor = false;
            Size = new Size(80, 80);
            BackColor = Color.FromArgb(200, 150, 75);
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            TextAlign = ContentAlignment.BottomCenter;
        }
    }
}
