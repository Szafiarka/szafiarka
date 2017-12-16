using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;

namespace Szafiarka.Classes
{
    partial class MenuButton : FlatButton
    {
        public enum buttonsNames
        {
            [Description("Start")]
            home,
            [Description("Wyszukaj")]
            search,
            [Description("Dodaj")]
            add,
            [Description("Edytuj")]
            edit,
            [Description("Usuń")]
            delete,
            [Description("Kosz")]
            bin,
            [Description("Wyjście")]
            exit
        }

        private static List<MenuButton> MenuButtonsList;
        private static string PATHTOSTART = "..\\..\\images\\menuButtons\\home.png";
        private static string PATHTOSEARCH = "..\\..\\images\\menuButtons\\search.png";
        private static string PATHTOADD = "..\\..\\images\\menuButtons\\add.png";
        private static string PATHTOEDIT = "..\\..\\images\\menuButtons\\edit.png";
        private static string PATHTODELETE = "..\\..\\images\\menuButtons\\delete.png";
        private static string PATHTOBIN = "..\\..\\images\\menuButtons\\bin.png";
        private static string PATHTOEXIT = "..\\..\\images\\menuButtons\\exit.png";

        private static object[,] MENUBUTTONSNAMES = {
            { buttonsNames.home, PATHTOSTART },
            { buttonsNames.search, PATHTOSEARCH},
            { buttonsNames.add, PATHTOADD},
            { buttonsNames.edit,  PATHTOEDIT},
            { buttonsNames.delete, PATHTODELETE},
            { buttonsNames.bin, PATHTOBIN},
            { buttonsNames.exit, PATHTOEXIT}
        };

        public MenuButton() : base()
        {
            UseVisualStyleBackColor = false;
            Size = new Size(100, 100);
            TextAlign = ContentAlignment.BottomCenter;
        }

        public static void addNewButtonToList(MenuButton button)
        {
            if (MenuButtonsList == null)
            {
                MenuButtonsList = new List<MenuButton> { };
            }
            MenuButtonsList.Add(button);
        }

        public static object[,] getButtonsArray()
        {
            return MENUBUTTONSNAMES;
        }

        public static void changeButtonsEnabled(bool value)
        {
            Enum[] buttons = { buttonsNames.edit, buttonsNames.delete };
            foreach (var name in buttons)
            {
                var button = getButtonByName(name);
                button.Enabled = value;
            }
        }

        public static  MenuButton getButtonByName(Enum name)
        {
            return MenuButtonsList.Find(x => x.Name.ToUpper() == name.ToString().ToUpper());
        }

        public bool compareEnumValueToButtonName(Enum @enum)
        {
            return Name.ToUpper() == @enum.ToString().ToUpper();
        }

        public void addImage()
        {
            var imagePath = selectImagePath();
            try
            {
                Image = Image.FromFile(@imagePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(
                    String.Format("Unable to add image to button name = {0}\n{1}", Name, e.Message)
                    );
            }
        }

        private string selectImagePath()
        {
            var lenght = MENUBUTTONSNAMES.Length / 2;
            for (int i = 0; i < lenght; i++)
            {
                Enum @enum = MENUBUTTONSNAMES[i, 0] as Enum;
                if (compareEnumValueToButtonName(@enum))
                {
                    return (string)MENUBUTTONSNAMES[i, 1];
                }
            }
            return "";
        }
    }
}
