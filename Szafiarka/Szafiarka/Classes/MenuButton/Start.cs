using System;
using System.Linq;
using System.Windows.Forms;

namespace Szafiarka.Classes
{
    partial class MenuButton
    {
        private void start_Click(object sender, EventArgs e)
        {
            Panels.changePanelsVisableToFalse();
            Panels.changePanelVisableToTrue(Panels.PanelsName.PSTART);
            //var rooms = DBconnection.DBCONNECTION.Room.ToArray();
            //var result = from room in rooms where room.id_room == 16 select room;
            //MessageBox.Show(result.First().name);
        }
    }
}