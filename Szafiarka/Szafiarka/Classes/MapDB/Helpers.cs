using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szafiarka.Classes.MapDB
{
    public partial class Category
    {
        public override string ToString()
        {
            return string.Format("{0}", name);
        }
    }

    public partial class Status
    {
        public override string ToString()
        {
            return string.Format("{0}", name);
        }
    }

    public partial class Room
    {
        public override string ToString()
        {
            return string.Format("{0}", name);
        }
    }

    public partial class Wardrobe
    {
        public override string ToString()
        {
            return string.Format("{0}", name);
        }
    }

    public partial class Shelf
    {
        public override string ToString()
        {
            return string.Format("{0}", Utils.increaseValueByOne(location));
        }
    }

    public class ResultDataGrid
    {
        public virtual int id { get; set; }
        public virtual string name { get; set; }
    }

    public class ResultDataGridCategory : ResultDataGrid
    {
        public virtual int itemsCount { get; set; }
    }

    public class ResultDataGridWardrobe : ResultDataGrid
    {
        public virtual string room { get; set; }
        public virtual int shelfCount { get; set; }
        public virtual string mostCategory { get; set; }
    }

    public class ResultDataGridRoom : ResultDataGrid
    {
        public virtual int wardrobesCount { get; set; }
    }

    public class ResultDataGridStatus : ResultDataGrid
    {
        public virtual int itemsCount { get; set; }
    }

    public class ResultDataGridItem : ResultDataGrid
    {
        public virtual string category { get; set; }
        public virtual string room { get; set; }
        public virtual string status { get; set; }
        public virtual string wardorobe { get; set; }
        public virtual int shelf { get; set; }
    }

    public class ResultDataGridLastItems : ResultDataGrid
    {
        public virtual string category { get; set; }
        public virtual DateTime creation_date { get; set; }
        public virtual DateTime? modify_date { get; set; }
    }

    public class ResulWardrobesOccupancy
    {
        public virtual Wardrobe wardrobe { get; set; }
        public virtual double capacity_wardrobe { get; set; }
        public virtual double capacity { get; set; }
    }

    public class ResultItemHistory : ResultDataGrid
    {
        public virtual string action { get; set; }
        public virtual DateTime creation_date { get; set; }
    }
}
