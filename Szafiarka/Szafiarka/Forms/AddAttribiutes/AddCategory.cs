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
    public partial class AddCategory : Szafiarka.Forms.AddAttribiutes.Common
    {
        private bool valid = false;
        public AddCategory(ComboBox combobox)
        {
            this.combobox = combobox;
            InitializeComponent();
        }

        private void textbox_ValueChanged(object sender, EventArgs e)
        {
            if (nameT.TextLength > 2)
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

        protected override void save_Click(object sender, EventArgs e)
        {
            if (valid)
            {
                var category = queries.addCategory(nameT.Text, descriptionT.Text);
                combobox.Items.Add(category);
                combobox.SelectedItem = category;

                Close();
            }
            else
                MessageBox.Show(Utils.GetEnumDescription(Messages.errors.SAVE), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
