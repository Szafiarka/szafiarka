using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szafiarka.Classes
{
    class PanelStart : Panels
    {
        private static string[,] OBJECTSBUTTONS =
        {
            { "rooms", "Pokoje" },
            { "wardrobes", "Szafy" },
            { "wardrobes", "Szafy" },
            { "addStatus", "Dodaj Status" },
            { "wardrobes", "Szafy" },
            { "wardrobes", "Szafy" },
        };

        public PanelStart()
        {
            Name = "pStart";
            Visible = true;
            InitializeComponent();
        }

        private void start_Click(object sender, EventArgs e)
        {
            var rooms = DBconnection.DBCONNECTION.Room.ToArray();
            var result = from room in rooms where room.id_room == 16 select room;
            MessageBox.Show(result.First().name);
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            InitializeObjectsButtons();
            ResumeLayout(false);

        }

        private void InitializeObjectsButtons()
        {
            var buttonLenght = 100;
            for (int i = 0; i < OBJECTSBUTTONS.Length / 2; i++)
            {
                var button = new FlattButton()
                {
                    Location = new System.Drawing.Point((buttonLenght + 10) * i, 0),
                    Name = OBJECTSBUTTONS[i,0],
                    Size = new System.Drawing.Size(buttonLenght, 30),
                    Text = OBJECTSBUTTONS[i, 1],

                };
                button.Click += new EventHandler(start_Click);
                Controls.Add(button);
            }
        }
    }
}
