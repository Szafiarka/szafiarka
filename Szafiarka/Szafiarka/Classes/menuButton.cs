using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Reflection;

namespace Szafiarka.Classes
{
    partial class MenuButton : FlatButton
    {
        private static string PATHTOSTART = "..\\..\\images\\menuButtons\\home.png";
        private static string PATHTOSEARCH = "..\\..\\images\\menuButtons\\search.png";
        private static string PATHTOADD = "..\\..\\images\\menuButtons\\add.png";
        private static string PATHTOEDIT = "..\\..\\images\\menuButtons\\edit.png";
        private static string PATHTODELETE = "..\\..\\images\\menuButtons\\delete.png";
        private static string PATHTOEXIT = "..\\..\\images\\menuButtons\\exit.png";
        private enum buttonsNames
        {
            home, search, add, edit, delete, exit
        }
        private static string[,] MENUBUTTONSNAMES = {
            { buttonsNames.home.ToString(), "Start", PATHTOSTART },
            { buttonsNames.search.ToString(), "Wyszukaj", PATHTOSEARCH},
            { buttonsNames.add.ToString(), "Dodaj", PATHTOADD},
            { buttonsNames.edit.ToString(), "Edytuj",  PATHTOEDIT},
            { buttonsNames.delete.ToString(), "Usuń", PATHTODELETE},
            { buttonsNames.exit.ToString(), "Wyjście", PATHTOEXIT}
        };
        private enum Messages {
            [Description("Nie wybrałeś elementu do usunięcia")]
            DELETE,
            [Description("Nie wybrałeś elementu do edycji")]
            EDIT,
        }

        public MenuButton() : base()
        {
            UseVisualStyleBackColor = false;
            BackColor = PanelMenu.defaultColor;
            Size = new Size(100, 100);
            TextAlign = ContentAlignment.BottomCenter;
        }

        public void InitializeMenuButtons(Form form, PanelMenu pMenu)
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
            if (button.Name == buttonsNames.exit.ToString())
            {
                button.Click += new EventHandler(exit_Click);
            }
            if (button.Name == buttonsNames.home.ToString())
            {
                button.Click += new EventHandler(start_Click);
            }
            if (button.Name == buttonsNames.add.ToString())
            {
                button.Click += new EventHandler(add_Click);
            }
            if (button.Name == buttonsNames.search.ToString())
            {
                button.Click += new EventHandler(search_Click);
            }
            if (button.Name == buttonsNames.edit.ToString())
            {
                button.Click += new EventHandler(edit_Click);
            }
            if (button.Name == buttonsNames.delete.ToString())
            {
                button.Click += new EventHandler(delete_Click);
            }
        }
    }
}
