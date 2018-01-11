using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szafiarka.Classes
{
    class HistoryLogic
    {
        private MapDB.History history;
        public HistoryLogic()
        {
            history = new MapDB.History();
        }

        public void addItem(MapDB.Item item)
        {
            history.deleted = item.deleted;
            history.id_status = item.id_status;
            history.id_shelf = item.id_shelf;
            history.description = item.description;
            history.id_category = item.id_category;
            history.size = item.size;
            history.name = item.name;
            history.id_item = item.id_item;
        }

        public void save(string action)
        {
            history.action = action;
            history.creation_date = DateTime.Now;
            DBconnection.DBCONNECTION.History.InsertOnSubmit(history);
            DBconnection.DBCONNECTION.SubmitChanges();
        }
    }
}
