using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szafiarka.Classes
{
    class ComboboxesImproved 
    {
        private bool withAdd;
        private static List<ComboboxNew> comboboxes;
        public enum names
        {
            room,
            wardrobe,
            shelf,
            category,
            status
        }

        private object[] namesArray = {
            names.room,
            names.wardrobe,
            names.shelf,
            names.category,
            names.status
        };

        public ComboboxesImproved(bool withAdd = true)
        {
            this.withAdd = withAdd;
            createList();
            addRangeRoom();
            addRangeCategory();
            addRangeStatus();
        }

        private void createList()
        {
            if (comboboxes != null)
            {
                comboboxes.Clear();
            }

            comboboxes = new List<ComboboxNew> { };

            foreach (var item in namesArray)
            {
                var combobox = new ComboboxNew(withAdd);
                combobox.setName(item.ToString());

                if (item is names.room)
                {
                    combobox.SelectedIndexChanged += new EventHandler(Room_SelectedIndexChanged);
                }
                else if (item is names.wardrobe)
                {
                    combobox.SelectedIndexChanged += new EventHandler(Wardrobe_SelectedIndexChanged);
                }

                comboboxes.Add(combobox);
            }
        }

        private void addRangeRoom()
        {
            var combobox = comboboxes.Find(x => x.Name == names.room.ToString());
            combobox.AddRange(DBconnection.DBCONNECTION.Room
                .OrderBy(x => x.name).ToArray());
        }

        private void addRangeCategory()
        {
            var combobox = comboboxes.Find(x => x.Name == names.category.ToString());
            combobox.AddRange(DBconnection.DBCONNECTION.Category
                .OrderBy(x => x.name).ToArray());
        }

        private void addRangeStatus()
        {
            var combobox = comboboxes.Find(x => x.Name == names.status.ToString());
            combobox.AddRange(DBconnection.DBCONNECTION.Status
                .OrderBy(x => x.name).ToArray());
        }

        private void addRangeWardrobe()
        {
            var combobox = comboboxes.Find(x => x.Name == names.wardrobe.ToString());
            disposeCombobox(combobox);
            try
            {
                var comboboxRoom = comboboxes.Find(x => x.Name == names.room.ToString());
                var room_id = (comboboxRoom.SelectedItem as MapDB.Room).id_room;
                combobox.AddRange(DBconnection.DBCONNECTION.Wardrobe.Where(x => x.id_room == room_id)
                    .OrderBy(x => x.name).ToArray());
            }
            catch { }

        }

        private void addRangeShelf()
        {
            var combobox = comboboxes.Find(x => x.Name == names.shelf.ToString());
            disposeCombobox(combobox);
            try
            {
                var comboboxWardrobe = comboboxes.Find(x => x.Name == names.wardrobe.ToString());
                var wardrobe_id = (comboboxWardrobe.SelectedItem as MapDB.Wardrobe).id_wardrobe;
                combobox.AddRange(DBconnection.DBCONNECTION.Shelf.Where(x => x.id_wardrobe == wardrobe_id)
                    .OrderBy(x => x.location).ToArray());
            }
            catch { }

        }

        private static void disposeCombobox(ComboboxNew combobox)
        {
            combobox.SelectedItem = null;
            combobox.Items.Clear();
        }

        public List<ComboboxNew> getComboboxImprovedList()
        {
            return comboboxes;
        }

        private void Room_SelectedIndexChanged(object sender, EventArgs e)
        {
            addRangeWardrobe();
        }

        private void Wardrobe_SelectedIndexChanged(object sender, EventArgs e)
        {
            addRangeShelf();
        }

        public static ComboboxNew getComboboxByName(Enum name)
        {
            return comboboxes.Find(x => x.Name.ToUpper() == name.ToString().ToUpper());
        }

    }

    class ComboboxNew : ComboBox
    {
        private bool withAdd;
        private enum actions
        {
            [Description("<Dodaj>")]
            add
        }
        public ComboboxNew(bool withAdd)
        {
            this.withAdd = withAdd;
            AutoCompleteMode = AutoCompleteMode.Suggest;
            AutoCompleteSource = AutoCompleteSource.ListItems;
            Width = 200;

            SelectedIndexChanged += new EventHandler(Add_SelectedIndexChanged);
        }

        public void setName(string name)
        {
            Name = name;
        }

        public void AddRange(object[] items)
        {
            foreach (var item in items)
            {
                Items.Add(item);
            }
            if (withAdd)
                Items.Add(Utils.GetEnumDescription(actions.add));
        }

        private void Add_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedItem != null 
                && SelectedItem.ToString() == Utils.GetEnumDescription(actions.add))
            {
                MessageBox.Show("Dodaj cos");
            }
        }
    }
}
