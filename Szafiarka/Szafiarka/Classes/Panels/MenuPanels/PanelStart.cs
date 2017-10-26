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
        private static List<Panel> ObjectList;

        private enum buttonsNames
        {
            rooms, wardrobes, addStatus
        }

        private static string[,] OBJECTSBUTTONS =
        {
            { buttonsNames.rooms.ToString(), "Pokoje" },
            { buttonsNames.wardrobes.ToString(), "Szafy" },
            { buttonsNames.wardrobes.ToString(), "Szafy" },
            { buttonsNames.addStatus.ToString(), "Dodaj Status" },
            { buttonsNames.wardrobes.ToString(), "Szafy" },
            { buttonsNames.wardrobes.ToString(), "Szafy" },
        };

        public PanelStart()
        {
            Name = "pStart";
            Visible = true;
            InitializeComponent();
        }

        #region Events
        private void start_Click(object sender, EventArgs e)
        {
            var rooms = DBconnection.DBCONNECTION.Room.ToArray();
            var result = from room in rooms where room.id_room == 16 select room;
            MessageBox.Show(result.First().name);
        }
        #endregion

        private void InitializeComponent()
        {
            SuspendLayout();
            InitializePanels();
            InitializeObjectsButtons();
            ResumeLayout(false);

        }

        private void InitializeObjectsButtons()
        {
            var buttonLenght = 100;
            for (int i = 0; i < OBJECTSBUTTONS.Length / 2; i++)
            {
                var button = new FlatButton()
                {
                    Location = new System.Drawing.Point((buttonLenght + 10) * i, 0),
                    Name = OBJECTSBUTTONS[i,0],
                    Size = new System.Drawing.Size(buttonLenght, 30),
                    Text = OBJECTSBUTTONS[i, 1],

                };
                addEventToButton(button);
                Controls.Add(button);
            }
        }

        private void InitializePanels()
        {
            ObjectList = new List<Panel> {

            };

            foreach (var panel in ObjectList)
            {
                Controls.Add(panel);
            };
        }

        private void addEventToButton(Button button)
        {

        }

        new public static void changePanelsVisableToFalse()
        {
            foreach (var item in ObjectList)
                item.Visible = false;
        }

        new public static void changePanelVisableToTrue(PanelsName name)
        {
            var panel = ObjectList.Find(X => X.Name.ToUpper() == name.ToString("g"));
            panel.Visible = true;
        }
    }
}
