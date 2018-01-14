using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Szafiarka.Classes;
using Szafiarka.Classes.MapDB;

namespace Szafiarka.Forms.ItemForm
{
    public partial class ItemForm : Form
    {
        private Queries queries;
        private Bitmap oryginalImage;
        private Item item;
        private List<ErrorProvider> errorProviders;
        private bool[] errors;

        public ItemForm()
        {
            InitializeComponent();
            queries = new Queries();
        }

        public ItemForm(int itemId)
        {
            queries = new Queries();
            getItem(itemId);
            InitializeComponent();
            fillForm();
        }

        private void getItem(int id)
        {
            var _item = queries.getItemById(id);
            item = _item;
        }

        private void fillForm()
        {
            var textbox = TextboxesNames.getTextBoxByName(TextboxesNames.names.name);
            textbox.Text = (item != null) ? item.name : null;
            setTextboxesErrors(textbox);

            textbox = TextboxesNames.getTextBoxByName(TextboxesNames.names.description);
            textbox.Text = (item != null) ? item.description : null;

            var combo = ComboboxesImproved.getComboboxByName(ComboboxesImproved.names.category);
            combo.SelectedItem = (item != null) ? queries.getCategoryById(item.id_category) : null;
            setComboboxesErrors(combo);

            combo = ComboboxesImproved.getComboboxByName(ComboboxesImproved.names.room);
            combo.SelectedItem = (item != null) ? queries.getRoomByShelfId(item.id_shelf) : null;
            setComboboxesErrors(combo);

            combo = ComboboxesImproved.getComboboxByName(ComboboxesImproved.names.wardrobe);
            combo.SelectedItem = (item != null) ? queries.getWardrobeByShelfId(item.id_shelf) : null;
            setComboboxesErrors(combo);

            combo = ComboboxesImproved.getComboboxByName(ComboboxesImproved.names.shelf);
            combo.SelectedItem = (item != null) ? queries.getShelfById(item.id_shelf) : null;
            setComboboxesErrors(combo);

            combo = ComboboxesImproved.getComboboxByName(ComboboxesImproved.names.status);
            combo.SelectedItem = (item != null) ? queries.getStatusById(item.id_status) : null;
            setComboboxesErrors(combo);

            var trackbar = TrackbarImproved.getTrackbar();
            trackbar.Value = (item != null) ? item.size : 0;
            setTrackbarErrors(trackbar);

            if (item != null && item.image != null)
            {
                pictureBox1.Image = Classes.ImageConverter.dbImgaeToImage(item.image);
                oryginalImage = (Bitmap)pictureBox1.Image;
                var button = ButtonsImproved.getList().Find(x => x.Name == ButtonsImproved.names.image_delete.ToString());
                button.Enabled = true;
            }
            else
            {
                var button = ButtonsImproved.getList().Find(x => x.Name == ButtonsImproved.names.image_delete.ToString());
                button.Enabled = false;
                pictureBox1.Image = null;
                oryginalImage = null;
            }
            fillHistoryGrid(historyDataGridView);
            //this.checkBox1.Checked = item.deleted ? false : true;
        }

        private void selectAndAddEvent(FlatButton button)
        {
            if (button.Name == ButtonsImproved.names.cancel.ToString())
            {
                button.Click += new EventHandler(exit_Click);
            }

            if (button.Name == ButtonsImproved.names.revert.ToString())
            {
                button.Click += new EventHandler(revert_Click);
            }

            if (button.Name == ButtonsImproved.names.save.ToString())
            {
                button.Click += new EventHandler(save_Click);
            }

            if (button.Name == ButtonsImproved.names.history.ToString())
            {
                button.Click += new EventHandler(revertHistory_Click);
            }

            if (button.Name == ButtonsImproved.names.image.ToString())
            {
                button.Click += new EventHandler(addImage_Click);
            }

            if (button.Name == ButtonsImproved.names.image_delete.ToString())
            {
                button.Click += new EventHandler(deleteImage_Click);
            }
            
        }
    }
}
