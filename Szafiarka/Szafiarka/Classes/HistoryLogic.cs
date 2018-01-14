using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szafiarka.Classes.MapDB;

namespace Szafiarka.Classes
{
    class HistoryLogic
    {
        private enum actions
        {
            [Description("dodanie rzeczy")]
            add,
            [Description("zmiana nazwy")]
            name,
            [Description("zmiana statusu")]
            status,
            [Description("zmiana zdjęcia")]
            image,
            [Description("usunięcie zdjęcia")]
            delete_image,
            [Description("dodanie zdjęcia")]
            add_image,
            [Description("zmiana opisu")]
            description,
            [Description("zmiana pokoju")]
            room,
            [Description("zmiana rozmiaru")]
            size,
            [Description("zmiana kategorii")]
            category,
            [Description("zmiana szafy")]
            wardrobe,
            [Description("zmiana stanu")]
            deleted,
            [Description("zmiana półki")]
            shelf,
        }
        private History history;
        private Item oldItem;
        private Queries queries = new Queries();
        public HistoryLogic()
        {
            history = new History();
        }

        public void addItem(Item item)
        {
            addHistory(item);
        }

        private void addHistory(Item item)
        {
            history.deleted = item.deleted;
            history.id_status = item.id_status;
            history.id_shelf = item.id_shelf;
            history.description = item.description;
            history.id_category = item.id_category;
            history.size = item.size;
            history.name = item.name;
            history.id_item = item.id_item;
            if (item.image != null)
            {
                history.image = item.image;
            }
        }

        public void addItem(Item item, Item oldItem)
        {
            this.oldItem = oldItem;

            addHistory(item);
        }

        public void save()
        {
            if (oldItem == null)
            {
                history.action = Utils.GetEnumDescription(actions.add);
            }
            else
            {
                history.action = getActions();
            }
            history.creation_date = DateTime.Now;
            DBconnection.DBCONNECTION.History.InsertOnSubmit(history);
            DBconnection.DBCONNECTION.SubmitChanges();
        }

        public void save(string action)
        {
            history.action = action;

            history.creation_date = DateTime.Now;
            DBconnection.DBCONNECTION.History.InsertOnSubmit(history);
            DBconnection.DBCONNECTION.SubmitChanges();
        }

        private string getActions()
        {
            string actionsS = "";

            if (history.name != oldItem.name)
                actionsS = string.Format("{0}{1}, ", actionsS, Utils.GetEnumDescription(actions.name));
            if (history.description != oldItem.description)
                actionsS = string.Format("{0}{1}, ", actionsS, Utils.GetEnumDescription(actions.description));
            if (history.id_status != oldItem.id_status)
                actionsS = string.Format("{0}{1}, ", actionsS, Utils.GetEnumDescription(actions.status));
            if (history.id_shelf != oldItem.id_shelf)
                actionsS = string.Format("{0}{1}, ", actionsS, Utils.GetEnumDescription(actions.shelf));
            if (queries.getRoomByShelfId(history.id_shelf).id_room != oldItem.Shelf.Wardrobe.Room.id_room)
                actionsS = string.Format("{0}{1}, ", actionsS, Utils.GetEnumDescription(actions.room));
            if (queries.getWardrobeByShelfId(history.id_shelf).id_wardrobe != oldItem.Shelf.Wardrobe.id_wardrobe)
                actionsS = string.Format("{0}{1}, ", actionsS, Utils.GetEnumDescription(actions.wardrobe));
            if (history.deleted != oldItem.deleted)
                actionsS = string.Format("{0}{1}, ", actionsS, Utils.GetEnumDescription(actions.deleted));
            if (history.size != oldItem.size)
                actionsS = string.Format("{0}{1}, ", actionsS, Utils.GetEnumDescription(actions.size));
            if (history.id_category != oldItem.id_category)
                actionsS = string.Format("{0}{1}, ", actionsS, Utils.GetEnumDescription(actions.category));

            if (history.image != oldItem.image)
            {
                if (history.image == null)
                    actionsS = string.Format("{0}{1}, ", actionsS, Utils.GetEnumDescription(actions.delete_image));
                else if (oldItem.image == null)
                    actionsS = string.Format("{0}{1}, ", actionsS, Utils.GetEnumDescription(actions.add_image));
                else
                    actionsS = string.Format("{0}{1}, ", actionsS, Utils.GetEnumDescription(actions.image));
            }

            return actionsS;
        }
    }
}
