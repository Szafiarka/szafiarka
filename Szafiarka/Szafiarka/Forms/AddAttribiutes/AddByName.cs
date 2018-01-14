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

namespace Szafiarka.Forms.AddAttribiutes
{
    public partial class AddByName : Common
    {
        private bool valid = false;
        public AddByName(ComboBox combobox)
        {
            this.combobox = combobox;
            InitializeComponent();
        }

        protected override void save_Click(object sender, EventArgs e)
        {
            if (valid)
            {
                if (combobox.Name == ComboboxesImproved.names.room.ToString())
                {
                    var room = queries.addRoom(nameT.Text);
                    combobox.Items.Add(room);
                    combobox.SelectedItem = room;
                }
                else if (combobox.Name == ComboboxesImproved.names.wardrobe.ToString())
                {
                    var room = ComboboxesImproved.getComboboxByName(ComboboxesImproved.names.room).SelectedItem as Room;
                    var wardrobe = queries.addWardrobe(nameT.Text, room.id_room);
                    combobox.Items.Add(wardrobe);
                    combobox.SelectedItem = wardrobe;
                }
                else if (combobox.Name == ComboboxesImproved.names.status.ToString())
                {
                    var status = queries.addStatus(nameT.Text);
                    combobox.Items.Add(status);
                    combobox.SelectedItem = status;
                }

                Close();
            }
            else
                MessageBox.Show(Utils.GetEnumDescription(Messages.errors.SAVE), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void textbox_ValueChanged(object sender, EventArgs e)
        {
            if (nameT.TextLength >=3 )
            {
                errorProvider1.Icon = Properties.Resources.OK;
                valid = true;
            }
            else
            {
                errorProvider1.Icon = Properties.Resources.ERR;
                errorProvider1.SetError(nameT, "Nazwa musi być dłuższa niż 3");
                valid = false;
            }
        }
    }
}
