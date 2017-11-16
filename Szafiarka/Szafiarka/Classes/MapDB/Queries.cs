using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szafiarka.Classes.MapDB
{
    class Queries
    {
        private MapDBDataContext connection;
        public Queries()
        {
            connection = DBconnection.DBCONNECTION; 
        }

        public IEnumerable<ResultDataGridCategory> getGridViewCategory()
        {
            return from category in DBconnection.DBCONNECTION.Category
                   select new ResultDataGridCategory
                   {
                       id = category.id_category,
                       name = category.name,
                       itemsCount = DBconnection.DBCONNECTION.Item.Where(x => x.id_category == category.id_category).Count()
                   };
        }

        public IEnumerable<ResultDataGridWardrobe> getGridViewWardrobe()
        {
            return from wardrobe in DBconnection.DBCONNECTION.Wardrobe
                   join room in DBconnection.DBCONNECTION.Room on wardrobe.id_room equals room.id_room
                   select new ResultDataGridWardrobe
                   {
                       id = wardrobe.id_wardrobe,
                       name = wardrobe.name,
                       room = room.name,
                       shelfCount = DBconnection.DBCONNECTION.Shelf.Where(x => x.id_wardrobe == wardrobe.id_wardrobe).Count()
                   };
        }

        public IEnumerable<ResultDataGridRoom> getGridViewRoom()
        {
            return from room in DBconnection.DBCONNECTION.Room
                   select new ResultDataGridRoom
                   {
                       id = room.id_room,
                       name = room.name,
                   };
        }

        public IEnumerable<ResultDataGridStatus> getGridViewStatus()
        {
            return from status in DBconnection.DBCONNECTION.Status
                   select new ResultDataGridStatus
                   {
                       id = status.id_status,
                       name = status.name,
                       itemsCount = DBconnection.DBCONNECTION.Item.Where(x => x.id_status == status.id_status).Count()
                   };
        }

        public IEnumerable<ResultDataGridItem> getGridViewItem()
        {
            return from item in DBconnection.DBCONNECTION.Item
                   join category in DBconnection.DBCONNECTION.Category on item.id_category equals category.id_category
                   join status in DBconnection.DBCONNECTION.Status on item.id_status equals status.id_status
                   join shelf in DBconnection.DBCONNECTION.Shelf on item.id_shelf equals shelf.id_shelf
                   join wardorobe in DBconnection.DBCONNECTION.Wardrobe on shelf.id_wardrobe equals wardorobe.id_wardrobe
                   join room in DBconnection.DBCONNECTION.Room on wardorobe.id_room equals room.id_room
                   select new ResultDataGridItem
                   {
                       id = item.id_item,
                       name = item.name,
                       category = category.name,
                       status = status.name,
                       room = room.name,
                       wardorobe = wardorobe.name,
                       shelf = shelf.location
                   };
        }

        public IEnumerable<ResultDataGridLastItems> getGridViewLastItems()
        {
            return from i in DBconnection.DBCONNECTION.Item
                   join c in DBconnection.DBCONNECTION.Category on i.id_category equals c.id_category
                   select new ResultDataGridLastItems
                   { 
                       id = i.id_item,
                       name = i.name,
                       category = c.name,
                       creation_date = i.creation_date
                   };
        }

        public Item getItemById(int id)
        {
            var query = from items in DBconnection.DBCONNECTION.Item
                   where items.id_item == id
                   select items;
            return query.First();
        }

    }
}
