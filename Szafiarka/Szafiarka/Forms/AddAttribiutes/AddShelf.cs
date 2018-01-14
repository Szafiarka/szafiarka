using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Szafiarka.Classes;
using Szafiarka.Classes.MapDB;

namespace Szafiarka.Forms.AddAttribiutes
{
    public partial class AddShelf : Szafiarka.Forms.AddAttribiutes.Common
    {
        private bool[] valid = { false, false };
        public AddShelf(ComboBox combobox)
        {
            this.combobox = combobox;
            InitializeComponent();
        }

        private void textbox_ValueChanged(object sender, EventArgs e)
        {
            if (locationT.TextLength > 0)
            {
                errorProvider1.Icon = Properties.Resources.OK;
                valid[0] = true;
            }
            else
            {
                errorProvider1.Icon = Properties.Resources.ERR;
                errorProvider1.SetError(locationT, "Nazwa musi być dłuższa niż 0");
                valid[0] = false;
            }

            if (capacityT.TextLength > 0)
            {
                errorProvider2.Icon = Properties.Resources.OK;
                valid[1] = true;
            }
            else
            {
                errorProvider2.Icon = Properties.Resources.ERR;
                errorProvider2.SetError(capacityT, "Nazwa musi być dłuższa niż 0");
                valid[1] = false;
            }
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        protected override void save_Click(object sender, EventArgs e)
        {
            if (valid[0] && valid[1])
            {
                var wardrobe = ComboboxesImproved.getComboboxByName(ComboboxesImproved.names.wardrobe).SelectedItem as Wardrobe;
                var shelf = queries.addShelf(Int32.Parse(locationT.Text), Int32.Parse(capacityT.Text), wardrobe.id_wardrobe);
                combobox.Items.Add(shelf);
                combobox.SelectedItem = shelf;

                Close();
            }
            else
                MessageBox.Show(Utils.GetEnumDescription(Messages.errors.SAVE), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
