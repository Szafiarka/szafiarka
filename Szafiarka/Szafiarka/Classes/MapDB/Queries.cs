using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szafiarka.Classes.MapDB
{
    public class Queries
    {
        private MapDBDataContext connection; 
        public Queries()
        {
            connection = DBconnection.DBCONNECTION;
        }
        #region GridViews
        public IEnumerable<ResultDataGridCategory> getGridViewCategory()
        {
            return from category in connection.Category
                   select new ResultDataGridCategory
                   {
                       id = category.id_category,
                       name = category.name,
                       itemsCount = connection.Item.Where(x => x.id_category == category.id_category && x.deleted == false).Count()
                   };
        }

        public IEnumerable<ResultDataGridWardrobe> getGridViewWardrobe()
        {
            return from wardrobe in connection.Wardrobe
                   join room in connection.Room on wardrobe.id_room equals room.id_room
                   select new ResultDataGridWardrobe
                   {
                       id = wardrobe.id_wardrobe,
                       name = wardrobe.name,
                       room = room.name,
                       shelfCount = connection.Shelf.Where(x => x.id_wardrobe == wardrobe.id_wardrobe).Count(),
                       mostCategory = getMostVategoryInWardrobeByWardrobeId(wardrobe.id_wardrobe)
                   };
        }

        public IEnumerable<ResultDataGridRoom> getGridViewRoom()
        {
            return from room in connection.Room                
                   select new ResultDataGridRoom
                   {
                       id = room.id_room,
                       name = room.name,
                       wardrobesCount = connection.Wardrobe.Where(x => x.id_room == room.id_room).Count()
                   };
        }

        public IEnumerable<ResultDataGridStatus> getGridViewStatus()
        {
            return from status in connection.Status
                   select new ResultDataGridStatus
                   {
                       id = status.id_status,
                       name = status.name,
                       itemsCount = connection.Item.Where(x => x.id_status == status.id_status && x.deleted == false).Count()
                   };
        }

        public IEnumerable<ResultDataGridItem> getGridViewItem(bool deleted = false)
        {
            return from item in connection.Item
                   where item.deleted == deleted
                   join category in connection.Category on item.id_category equals category.id_category
                   join status in connection.Status on item.id_status equals status.id_status
                   join shelf in connection.Shelf on item.id_shelf equals shelf.id_shelf
                   join wardorobe in connection.Wardrobe on shelf.id_wardrobe equals wardorobe.id_wardrobe
                   join room in connection.Room on wardorobe.id_room equals room.id_room
                   select new ResultDataGridItem
                   {
                       id = item.id_item,
                       name = item.name,
                       category = category.name,
                       status = status.name,
                       room = room.name,
                       wardorobe = wardorobe.name,
                       shelf = Utils.increaseValueByOne(shelf.location)
                   };
        }

        public IEnumerable<ResultDataGridItem> getGridViewItemByName(string name, string _category, string _status, string _wardrobe, string _room)
        {
            return from item in connection.Item
                   where item.deleted == false && item.name.Contains(name)
                   join category in connection.Category on item.id_category equals category.id_category where category.name.Contains(_category)
                   join status in connection.Status on item.id_status equals status.id_status where status.name.Contains(_status)
                   join shelf in connection.Shelf on item.id_shelf equals shelf.id_shelf
                   join wardorobe in connection.Wardrobe on shelf.id_wardrobe equals wardorobe.id_wardrobe where wardorobe.name.Contains(_wardrobe)
                   join room in connection.Room on wardorobe.id_room equals room.id_room where room.name.Contains(_room)
                   select new ResultDataGridItem
                   {
                       id = item.id_item,
                       name = item.name,
                       category = category.name,
                       status = status.name,
                       room = room.name,
                       wardorobe = wardorobe.name,
                       shelf = Utils.increaseValueByOne(shelf.location)
                   };
        }

        public IEnumerable<ResultDataGridLastItems> getGridViewLastItems()
        {
            return from i in connection.Item
                   join c in connection.Category on i.id_category equals c.id_category
                   select new ResultDataGridLastItems
                   {
                       id = i.id_item,
                       name = i.name,
                       category = c.name,
                       creation_date = i.creation_date,
                       modify_date = (i.modify_date != null) ? i.modify_date : i.creation_date
                   };
        }

        public IEnumerable<ResulWardrobesOccupancy> getWardrobesCapacity()
        {
            return from shelfs in connection.Shelf
                    group shelfs by shelfs.id_wardrobe into shelfsGB
                    select new ResulWardrobesOccupancy
                    {
                        wardrobe = shelfsGB.FirstOrDefault().Wardrobe,
                        capacity_wardrobe = shelfsGB.Sum(x => x.capacity),
                        capacity = getWardrobeOccupancyByWardrobeId(shelfsGB.FirstOrDefault().id_wardrobe)
                    };
        }
        #endregion
        public void changeItemDeletedById(int id, bool deleted)
        {
            var item = connection.Item.Where(x => x.id_item == id).FirstOrDefault();
            Item itemOld = (Item)item.Clone();

            item.deleted = deleted;
            item.modify_date = DateTime.Now;
            connection.SubmitChanges();

            var hisotry = new HistoryLogic();
            hisotry.addItem(item, itemOld);
            hisotry.save();
        }

        public double getWardrobeOccupancyByWardrobeId(int id)
        {
            try
            {
                return (from items in connection.Item
                        where items.Shelf.id_wardrobe == id && items.deleted == false
                        select items.size).Sum(x => x);
            }
            catch { return 0; }
        }

        public double getShelfOccupancyByShelfId(int id)
        {
            try
            {
                return (from items in connection.Item
                        where items.Shelf.id_shelf == id && items.deleted == false
                        select items.size).Sum(x => x);
            }
            catch { return 0; }
        }

        public string getMostVategoryInWardrobeByWardrobeId(int id)
        {
            var query = (from items in connection.Item
                         where items.Shelf.id_wardrobe == id
                         group items by items.Category into i
                         let g = i.Select(i2 => new { name = i2.Category.name, count = i.Count() }).OrderByDescending(c => c.count)
                         select g.FirstOrDefault());
            if (query.FirstOrDefault() != null)
            {
                return query.FirstOrDefault().name;
            }
            else
                return "brak kategorii";

        }

        public string getCategoryDescriptionById(int id)
        {
            return (from category in connection.Category
                    where category.id_category == id
                    select category.description).FirstOrDefault();
        }

        public string getItemDescriptionById( int id)
        {
            return (from item in connection.Item
                    where item.id_item == id
                    select item.description).FirstOrDefault();
        }

        public Item getItemById(int id)
        {
            var query = from items in connection.Item
                        where items.id_item == id
                        select items;
            try
            {
                return query.First();
            }
            catch
            {
                return null;
            }
        }

        public Category getCategoryById(int id)
        {
            var query = from items in connection.Category
                        where items.id_category == id
                        select items;
            try
            {
                return query.First();
            }
            catch
            {
                return null;
            }
        }

        public Room getRoomByShelfId(int id)
        {
            var query = from rooms in connection.Room
                        where rooms.id_room == getWardrobeByShelfId(id).id_room
                        select rooms;

            try
            {
                return query.First();
            }
            catch
            {
                return null;
            }
        }

        public Shelf getShelfById(int id)
        {
            var query = from shelfs in connection.Shelf
                        where shelfs.id_shelf == id
                        select shelfs;
            try
            {
                return query.First();
            }
            catch
            {
                return null;
            }
        }

        public Wardrobe getWardrobeByShelfId(int id)
        {
            var query = from wardrobes in connection.Wardrobe
                        where wardrobes.id_wardrobe == getShelfById(id).id_wardrobe
                        select wardrobes;
            try
            {
                return query.First();
            }
            catch
            {
                return null;
            }

        }

        public Status getStatusById(int id)
        {
            var query = from status in connection.Status
                        where status.id_status == id
                        select status;
            try
            {
                return query.First();
            }
            catch
            {
                return null;
            }

        }

        public IEnumerable<ResultItemHistory> getHistoryByItemId(int id)
        {
            return from history in connection.History
                   where history.id_item == id
                   select new ResultItemHistory
                   {
                       id = history.id_history,
                       name = history.name,
                       action = history.action,
                       creation_date = history.creation_date
                   };
        }

        public History getHistoryById(int id)
        {
            var query = from history in connection.History
                        where history.id_history == id
                        select history;
            try
            {
                return query.First();
            }
            catch
            {
                return null;
            }
        }

        public Room addRoom(string name)
        {
            Room room = new Room();
            room.name = name;
            DBconnection.DBCONNECTION.Room.InsertOnSubmit(room);
            DBconnection.DBCONNECTION.SubmitChanges();
            return room;
        }

        public Status addStatus(string name)
        {
            Status status = new Status();
            status.name = name;
            DBconnection.DBCONNECTION.Status.InsertOnSubmit(status);
            DBconnection.DBCONNECTION.SubmitChanges();
            return status;
        }

        public Category addCategory(string name, string description)
        {
            Category category = new Category();
            category.name = name;
            category.description = description;
            DBconnection.DBCONNECTION.Category.InsertOnSubmit(category);
            DBconnection.DBCONNECTION.SubmitChanges();
            return category;
        }

        public Wardrobe addWardrobe(string name, int room_id)
        {
            Wardrobe wardrobe = new Wardrobe();
            wardrobe.name = name;
            wardrobe.id_room = room_id;
            DBconnection.DBCONNECTION.Wardrobe.InsertOnSubmit(wardrobe);
            DBconnection.DBCONNECTION.SubmitChanges();
            return wardrobe;
        }

        public Shelf addShelf(int location, int capacity, int wardrobe_id)
        {
            Shelf shelf = new Shelf();
            shelf.location = location - 1;
            shelf.capacity = capacity;
            shelf.id_wardrobe = wardrobe_id;
            DBconnection.DBCONNECTION.Shelf.InsertOnSubmit(shelf);
            DBconnection.DBCONNECTION.SubmitChanges();
            return shelf;
        }
    }
}
