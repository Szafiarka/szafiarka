using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }

    public class ResultDataGridRoom : ResultDataGrid
    {

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
        public virtual string shelf { get; set; }
    }

    public class ResultDataGridLastItems : ResultDataGrid
    {
        public virtual string category { get; set; }
        public virtual DateTime creation_date { get; set; }
    }

    public class ResulWardrobesOccupancy
    {
        public virtual double capacity { get; set; }
        public virtual Wardrobe wardrobe { get; set; }
        public virtual double capacity_wardrobe { get; set; }
    }
}
