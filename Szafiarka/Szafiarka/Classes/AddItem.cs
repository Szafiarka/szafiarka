using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szafiarka.Classes
{
    class AddItem
    {
        private MapDB.Item oldItem;
        private MapDB.Item newItem;
        public AddItem()
        {
            newItem = new MapDB.Item();
        }

        public AddItem(MapDB.Item item)
        {
            newItem = item;
            oldItem = item;
        }

        public void setName(string name)
        {
            newItem.name = name;
        }

        public void setCategory(MapDB.Category category)
        {
            newItem.id_category = category.id_category;
        }

        public void setStatus(MapDB.Status status)
        {
            newItem.id_status = status.id_status;
        }

        public void setActive(Boolean active)
        {
            newItem.deleted = active;
        }

        public void setSize(int size)
        {
            newItem.size = size;
        }

        public void setImage(Bitmap image)
        {
            if (image == null)
            {
                newItem.image = null;
            }
            else
            {
                Image im = (Image)image;
                var cos = ImageConverter.imageToByteArray(im);
                newItem.image = cos;
            }
        }

        public void setShelf(MapDB.Shelf shelf)
        {
            newItem.id_shelf = shelf.id_shelf;
        }

        public void setDescription(string description)
        {
            newItem.description = description;
        }

        public MapDB.Item save()
        {
            if (oldItem == null)

            {
                newItem.creation_date = DateTime.Now;
                DBconnection.DBCONNECTION.Item.InsertOnSubmit(newItem);
            }
            else
            {
                newItem.modify_date = DateTime.Now;
            }

            DBconnection.DBCONNECTION.SubmitChanges();
            Panels.refreshPanelStartGrid();
            Panels.refreshPanelBinGrid();
            MessageBox.Show(Utils.GetEnumDescription(Messages.addItem.saved));

            var hisotry = new HistoryLogic();
            hisotry.addItem(newItem);
            hisotry.save("dodanie rzeczy");

            return newItem;
        }
    }
}