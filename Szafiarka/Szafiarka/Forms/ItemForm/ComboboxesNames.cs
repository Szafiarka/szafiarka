using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Szafiarka.Classes;
using Szafiarka.Classes.MapDB;

namespace Szafiarka.Forms.ItemForm
{
    class ComboboxesNames : ComboBox
    {
        private static List<ComboboxesNames> comboboxes;

        public enum names {
            room,
            wardrobe,
            shelf,
            category,
            status
        }

        private static object[] namesArray = {
            names.room,
            names.wardrobe,
            names.shelf,
            names.category,
            names.status
        };

        public ComboboxesNames() : base()
        {

        }

        public static object[] getNamesArray()
        {
            return namesArray;
        }

        public static void addNewButtonToList(ComboboxesNames combobox)
        {
            if (comboboxes == null)
            {
                comboboxes = new List<ComboboxesNames> { };
            }
            comboboxes.Add(combobox);
        }

        public static ComboboxesNames getButtonByName(Enum name)
        {
            return comboboxes.Find(x => x.Name.ToUpper() == name.ToString().ToUpper());
        }

        public void addRange(Enum name)
        {
            if (name is names.category)
            {
                List<Category> category;
                category = new List<Category> { };

                category.AddRange(DBconnection.DBCONNECTION.Category.ToList());
                Items.AddRange(category.ToArray());
            }
            if (name is names.status)
            {
                List<Status> status;
                status = new List<Status> { };

                status.AddRange(DBconnection.DBCONNECTION.Status.ToList());
                Items.AddRange(status.ToArray());
            }
            if (name is names.room)
            {
                List<Room> room;
                room = new List<Room> { };

                room.AddRange(DBconnection.DBCONNECTION.Room.ToList());
                Items.AddRange(room.ToArray());
            }
        }
    }
}
