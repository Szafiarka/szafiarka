using System;
using System.Windows.Forms;
using System.Drawing;

namespace Szafiarka.Classes
{
    partial class MenuButton : Button
    {
        private static string PATHTOSTART = "";
        private static string PATHTOSEARCH = "";
        private static string PATHTOADD = "";
        private static string PATHTOEDIT = "";
        private static string PATHTODELETE = "";
        private static string PATHTOEXIT = "..\\..\\images\\exit.png";
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
                addImageToButton(ref button, i);
                selectAndAddEvent(ref button);
                form.Controls.Add(button);
                pMenu.Controls.Add(button);
            }
        }

        private void addImageToButton(ref MenuButton button, int selectedButton)
        {
            try
            {
                button.Image = Image.FromFile(@MENUBUTTONSNAMES[selectedButton, 2]);
            }
            catch (Exception e)
            {
                Console.WriteLine(
                    String.Format("Unable to add image to button name = {0}\n{1}", button.Name, e.Message)
                    );
            }
        }

        private void selectAndAddEvent(ref MenuButton button)
        {
            if (button.Name is "exit")
            {
                button.Click += new EventHandler(exit_Click);
            }
            if (button.Name is "home")
            {
                button.Click += new EventHandler(start_Click);
            }
        }
    }
}
