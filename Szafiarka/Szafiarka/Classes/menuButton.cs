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
        private static string PATHTOEDIT= "";
        private static string PATHTODELETE = "";
        private static string PATHTOEXIT = "";
        private static string[,] MENUBUTTONSNAMES = { { "home", "Start", PATHTOSTART }, { "search", "Wyszukaj", PATHTOSEARCH}, 
            { "add", "Dodaj", PATHTOADD}, {"edit", "Edytuj",  PATHTOEDIT}, { "delete", "Usun", PATHTODELETE}, { "exit", "Wyjście", PATHTOEXIT} };

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
