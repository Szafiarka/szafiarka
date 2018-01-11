using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Szafiarka.Classes;
using Szafiarka.Classes.MapDB;

namespace Szafiarka.Forms.ItemForm
{
    partial class ItemForm
    {
        private void addImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files| *.jpg; *.jpeg; *.png";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var image = new Bitmap(dialog.FileName);
                image = ImageDataBase.chnageImageSize(image);
                pictureBox1.Image = image;
                oryginalImage = image;
                var button = ButtonsImproved.getList().Find(x => x.Name == ButtonsImproved.names.image_delete.ToString());
                button.Enabled = true;
            }
        }

        private void image_DoubleClick(object sender, EventArgs e)
        {
            var image = sender as PictureBox;
            if (image.Image != null)
            {
                var form = new Form();
                form.ClientSize = oryginalImage.Size;
                form.BackgroundImage = oryginalImage;
                form.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                try
                {
                    form.Text = string.Format("{0} zdjęcie", item.name);
                }
                catch { }

                form.ShowDialog();
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void revert_Click(object sender, EventArgs e)
        {
            fillForm();
        }

        private void revertHistory_Click(object sender, EventArgs e)
        {
            Console.WriteLine("a");
            var row = historyDataGridView.CurrentRow;
            if (row != null)
            {
                var addItem = new AddItem(item);
                var id = Int32.Parse(row.Cells[0].Value.ToString());
                addItem.revertHistory(id);
            }
            fillForm();
        }

        private void deleteImage_Click(object sender, EventArgs e)
        {
            oryginalImage = null;
            pictureBox1.Image = null;
        }

        private void save_Click(object sender, EventArgs e)
        {
            AddItem addItem;
            if (item != null)
            {
                addItem = new AddItem(item);
            }
            else
            {
                addItem = new AddItem();
            }

            if (checkIfSave())
            {
                addItem.setActive(false);
                addItem.setName(TextboxesNames.getTextBoxByName(TextboxesNames.names.name).Text);
                addItem.setStatus(ComboboxesImproved.getComboboxByName(ComboboxesImproved.names.status).SelectedItem as Status);
                addItem.setShelf(ComboboxesImproved.getComboboxByName(ComboboxesImproved.names.shelf).SelectedItem as Shelf);
                addItem.setCategory(ComboboxesImproved.getComboboxByName(ComboboxesImproved.names.category).SelectedItem as Category);
                addItem.setSize(TrackbarImproved.getTrackbar().Value);
                addItem.setImage(oryginalImage);

                var desc = TextboxesNames.getTextBoxByName(TextboxesNames.names.description).Text;
                if (desc != null)
                    addItem.setDescription(desc);
                item = addItem.save();
                fillForm();
            }
            else
            {
                MessageBox.Show(Utils.GetEnumDescription(Messages.errors.SAVE), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private bool nameValidation()
        {
            bool check = false;
            var text = TextboxesNames.getTextBoxByName(TextboxesNames.names.name).Text;
            if (text.Length >= 3)
                check = true;

            return check;
        }

        private void textBoxOut_TextChanged(object sender, EventArgs e)
        {
            TextBox something = (TextBox)sender;
            setTextboxesErrors(something);
        }

        private void setTextboxesErrors(TextBox something)
        {
            switch (something.Name)
            {
                case "name":
                    if (something.TextLength < 3)
                    {
                        errorProviders[0].Icon = Properties.Resources.ERR;
                        errorProviders[0].SetError(TextboxesNames.getTextBoxByName(TextboxesNames.names.name), "Podpis musi mieć więcej niż 3 znaki!");
                        errors[0] = false;
                    }
                    else
                    {
                        errorProviders[0].Icon = Properties.Resources.OK;
                        errorProviders[0].SetError(TextboxesNames.getTextBoxByName(TextboxesNames.names.name), "OK");
                        errors[0] = true;
                    }
                    break;
            }
        }

        private void trackbar_ValueChanged(object sender, EventArgs e)
        {
            TrackBar something = (TrackBar)sender;
            setTrackbarErrors(something);
        }

        private void setTrackbarErrors(TrackBar something)
        {
            switch (something.Name)
            {
                case "size":
                    if (something.Value < 1)
                    {
                        errorProviders[6].Icon = Properties.Resources.ERR;
                        errorProviders[6].SetError(TrackbarImproved.getTrackbar(), "Nie wybrałeś warości");
                        errors[6] = false;
                    }
                    else
                    {
                        errorProviders[6].Icon = Properties.Resources.OK;
                        errorProviders[6].SetError(TrackbarImproved.getTrackbar(), "OK");
                        errors[6] = true;
                    }
                    break;
            }
        }

        private void comboBoxSelectionChangeCommitted(object sender, EventArgs e)
        {

            ComboBox senderComboBox = (ComboBox)sender;
            setComboboxesErrors(senderComboBox);
        }

            private void combobox_Leave(object sender, EventArgs e)
        {
            ComboBox something = (ComboBox)sender;
            setComboboxesErrors(something);
        }

        private void setComboboxesErrors(ComboBox something)
        {
            switch (something.Name)
            {
                case "room":
                    if (something.SelectedItem == null)
                    {
                        errorProviders[1].Icon = Properties.Resources.ERR;
                        errorProviders[1].SetError(ComboboxesImproved.getComboboxByName(ComboboxesImproved.names.room), "Nie wybrałeś pokoju");
                        errors[1] = false;
                    }
                    else
                    {
                        errorProviders[1].Icon = Properties.Resources.OK;
                        errorProviders[1].SetError(ComboboxesImproved.getComboboxByName(ComboboxesImproved.names.room), "OK");
                        errors[1] = true;
                    }
                    break;
                case "wardrobe":
                    if (something.SelectedItem == null)
                    {
                        errorProviders[2].Icon = Properties.Resources.ERR;
                        errorProviders[2].SetError(ComboboxesImproved.getComboboxByName(ComboboxesImproved.names.wardrobe), "Nie wybrałeś pokoju");
                        errors[2] = false;
                    }
                    else
                    {
                        errorProviders[2].Icon = Properties.Resources.OK;
                        errorProviders[2].SetError(ComboboxesImproved.getComboboxByName(ComboboxesImproved.names.wardrobe), "OK");
                        errors[2] = true;
                    }
                    break;
                case "shelf":
                    if (something.SelectedItem == null)
                    {
                        errorProviders[3].Icon = Properties.Resources.ERR;
                        errorProviders[3].SetError(ComboboxesImproved.getComboboxByName(ComboboxesImproved.names.shelf), "Nie wybrałeś pokoju");
                        errors[3] = false;
                    }
                    else
                    {
                        errorProviders[3].Icon = Properties.Resources.OK;
                        errorProviders[3].SetError(ComboboxesImproved.getComboboxByName(ComboboxesImproved.names.shelf), "OK");
                        errors[3] = true;
                    }
                    break;
                case "status":
                    if (something.SelectedItem == null)
                    {
                        errorProviders[4].Icon = Properties.Resources.ERR;
                        errorProviders[4].SetError(ComboboxesImproved.getComboboxByName(ComboboxesImproved.names.status), "Nie wybrałeś pokoju");
                        errors[4] = false;
                    }
                    else
                    {
                        errorProviders[4].Icon = Properties.Resources.OK;
                        errorProviders[4].SetError(ComboboxesImproved.getComboboxByName(ComboboxesImproved.names.status), "OK");
                        errors[4] = true;
                    }
                    break;
                case "category":
                    if (something.SelectedItem == null)
                    {
                        errorProviders[5].Icon = Properties.Resources.ERR;
                        errorProviders[5].SetError(ComboboxesImproved.getComboboxByName(ComboboxesImproved.names.category), "Nie wybrałeś pokoju");
                        errors[5] = false;
                    }
                    else
                    {
                        errorProviders[5].Icon = Properties.Resources.OK;
                        errorProviders[5].SetError(ComboboxesImproved.getComboboxByName(ComboboxesImproved.names.category), "OK");
                        errors[5] = true;
                    }
                    break;
            }
        }

        private bool checkIfSave()
        {
            foreach (var item in errors)
            {
                if (!item)
                    return false;
            }
            return true;
        }
    }
}
