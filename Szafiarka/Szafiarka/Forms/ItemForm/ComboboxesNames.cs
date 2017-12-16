using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szafiarka.Forms.ItemForm
{
    class ComboboxesNames : ComboBox
    {
        private static List<ComboboxesNames> comboboxes;

        public ComboboxesNames() : base()
        {

        }

        public static void addNewButtonToList(ComboboxesNames combobox)
        {
            if (comboboxes == null)
            {
                comboboxes = new List<ComboboxesNames> { };
            }
            comboboxes.Add(combobox);
        }

        public static ComboboxesNames getButtonByName(Enum name)
        {
            return comboboxes.Find(x => x.Name.ToUpper() == name.ToString().ToUpper());
        }
    }
}
