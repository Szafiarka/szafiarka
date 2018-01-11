using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Szafiarka.Classes;

namespace Szafiarka.Forms.ItemForm
{
    partial class LabelsImproved
    {
        public static List<Label> labels;
        public enum names
        {
            [Description("Nazwa")]
            name,
            [Description("Opis")]
            description,
            [Description("Rozmiar")]
            size,
            [Description("Stan")]
            state,
            [Description("Pokój")]
            room,
            [Description("Szafa")]
            wardrobe,
            [Description("Półka")]
            shelf,
            [Description("Kategoria")]
            category,
            [Description("Status")]
            status,
            [Description("Historia")]
            histry,
        }

        private static object[] namesArray = {
            names.name,
            names.description,
            names.size,
            names.state,
            names.room,
            names.wardrobe,
            names.shelf,
            names.category,
            names.status,
            names.histry,
        };

        public LabelsImproved()
        {
            createList();
        }

        public static object[] getArray()
        {
            return namesArray;
        }

        private void createList()
        {
            if(labels != null)
            {
                labels.Clear();
            }

            labels = new List<Label> { };

            foreach (var item in namesArray)
            {
                var label = new Label
                {
                    Width = 200,
                    ForeColor = Color.White,
                    Name = item.ToString(),
                    Text = Utils.GetEnumDescription(item as Enum)
                };
                labels.Add(label);
            }
        }

        public static List<Label> getList()
        {
            return labels;
        }

        public static Label getLabelByName(Enum name)
        {
            return labels.Find(x => x.Name.ToUpper() == name.ToString().ToUpper());
        }
    }
}
