using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Reflection;

namespace Szafiarka.Classes
{
    partial class OptionsTabPages: TabPage
    {
        private enum tabsNames
        {
            backup, appearance, contact, about_program
        }

        private static string[,] TABPAGESNAMES = {
            { tabsNames.backup.ToString(), "Kopia zapasowa" },
            { tabsNames.appearance.ToString(), "Wygląd"},
            { tabsNames.contact.ToString(), "Kontakt"},
            { tabsNames.about_program.ToString(), "O programie"}
        };

        static public void InitializeOptionsTabPages(OptionsTabControl tabControl)
        {
            for (int i = 0; i < TABPAGESNAMES.Length / 2; i++)
            {
                var tab = new OptionsTabPages()
                {
                    Name = TABPAGESNAMES[i, 0],
                    Text = TABPAGESNAMES[i, 1]
                };
                tabControl.Controls.Add(tab);
            }
        }

        public OptionsTabPages()
        {
            //kolory
        }
    }
}
