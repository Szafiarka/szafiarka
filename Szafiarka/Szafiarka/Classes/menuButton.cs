using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Reflection;

namespace Szafiarka.Classes
{
    partial class MenuButton : FlatButton
    {
        public MenuButton() : base()
        {
            UseVisualStyleBackColor = false;
            BackColor = PanelMenu.defaultColor;
            Size = new Size(100, 100);
            TextAlign = ContentAlignment.BottomCenter;
        }
    }
}
