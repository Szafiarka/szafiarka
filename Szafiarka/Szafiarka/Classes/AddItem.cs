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
        private MapDB.Queries queries = new MapDB.Queries();
        public AddItem()
        {
            newItem = new MapDB.Item();
        }

        public AddItem(MapDB.Item item)
        {
            newItem = item;
            oldItem = (MapDB.Item)item.Clone();
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
            if (!itemsSame())
            {
                DBconnection.DBCONNECTION.SubmitChanges();
                Panels.refreshPanelStartGrid();
                Panels.refreshPanelBinGrid();
                MessageBox.Show(Utils.GetEnumDescription(Messages.ok.SAVE), "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var hisotry = new HistoryLogic();
                if (oldItem == null)
                    hisotry.addItem(newItem);
                else
                    hisotry.addItem(newItem, oldItem);
                hisotry.save();
            }

            return newItem;
        }

        public MapDB.Item revertHistory(int historyId)
        {
            var history = queries.getHistoryById(historyId);

            newItem.deleted = history.deleted;
            newItem.id_status = history.id_status;
            newItem.id_shelf = history.id_shelf;
            newItem.description = history.description;
            newItem.id_category = history.id_category;
            newItem.size = history.size;
            newItem.name = history.name;
            newItem.id_item = history.id_item;
            newItem.image = history.image;
            newItem.modify_date = DateTime.Now;

            DBconnection.DBCONNECTION.SubmitChanges();

            var his = new HistoryLogic();
            his.addItem(newItem);
            his.save("przywrócenie historii");

            return newItem;
        }

        private bool itemsSame()
        {
            if (newItem.name != oldItem.name)
                return false;
            if (newItem.description != oldItem.description)
                return false;
            if (newItem.image != oldItem.image)
                return false;
            if (newItem.id_category != oldItem.id_category)
                return false;
            if (newItem.id_shelf != oldItem.id_shelf)
                return false;
            if (newItem.id_status != oldItem.id_status)
                return false;
            if (newItem.id_category != oldItem.id_category)
                return false;
            if (newItem.deleted != oldItem.deleted)
                return false;
            if (newItem.size != oldItem.size)
                return false;

            return true;
        }
    }
}