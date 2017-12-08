using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Reflection;


namespace Szafiarka.Classes
{
    partial class OptionsTabPages: TabPage
    {
       /* private enum tabsNames
        {
            backup, appearance, contact, about_program
        }

        private static string[,] TABPAGESNAMES = {
            { tabsNames.backup.ToString(), "Kopia zapasowa" },
            { tabsNames.appearance.ToString(), "Wygląd"},
            { tabsNames.contact.ToString(), "Kontakt"},
            { tabsNames.about_program.ToString(), "O programie"}
        };*/

        public OptionsTabPages()
        {
            BackColor = System.Drawing.Color.FromArgb(0, 0, 64);
            //Font fnt = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            //this.Font = fnt;
        }
    }
}
