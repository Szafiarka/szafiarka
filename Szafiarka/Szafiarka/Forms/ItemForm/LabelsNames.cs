using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szafiarka.Forms.ItemForm
{
    partial class LabelsNames : Label
    {
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
            names.status
        };

        public LabelsNames() : base()
        {

        }

        public static object[] getLabelsArray()
        {
            return namesArray;
        }
    }
}
