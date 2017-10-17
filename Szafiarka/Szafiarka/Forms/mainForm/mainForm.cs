using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Szafiarka.Classes;
using Szafiarka.Classes.MapDB;

namespace Szafiarka
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = DBconnection.DbConnection)
            {
                var room = new Room();
                room.name = "jadalnia";
                db.Room.InsertOnSubmit(room);
                db.SubmitChanges();
                var rooms = db.Room.ToArray();
                MessageBox.Show(rooms.ElementAt(1).name);
                
            }
        }
    }
}
