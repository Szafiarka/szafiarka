using System;
using System.Windows.Forms;
using System.Drawing;

namespace Szafiarka.Classes
{
    class MenuButton : Button
    {
        private static string PATHTOSTART = "";
        private static string PATHTOSEARCH = "";
        private static string PATHTOADD = "";
        private static string PATHTOEDIT = "";
        private static string PATHTODELETE = "";
        private static string PATHTOEXIT = "";
        private static string[,] MENUBUTTONSNAMES = {
            { "home", "Start", PATHTOSTART },
            { "search", "Wyszukaj", PATHTOSEARCH},
            { "add", "Dodaj", PATHTOADD},
            { "edit", "Edytuj",  PATHTOEDIT},
            { "delete", "Usuń", PATHTODELETE},
            { "exit", "Wyjście", PATHTOEXIT}
        };

        public MenuButton() : base()
        {
            UseVisualStyleBackColor = false;
            Size = new Size(100, 100);
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            TextAlign = ContentAlignment.BottomCenter;
            Font = new Font(this.Font.Name, 10);
        }

        public void InitializeMenuButtons(Form form, Panel pMenu)
        {
            for (int i = 0; i < MENUBUTTONSNAMES.Length / 3; i++)
            {
                var button = new MenuButton()
                {
                    Location = new Point(0, 100 * i),
                    BackColor = pMenu.BackColor,
                    Name = MENUBUTTONSNAMES[i, 0],
                    Text = MENUBUTTONSNAMES[i, 1]
                };

                form.Controls.Add(button);
                pMenu.Controls.Add(button);
            }
        }
    }
}
