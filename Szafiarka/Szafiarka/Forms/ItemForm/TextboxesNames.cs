using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szafiarka.Forms.ItemForm
{
    class TextboxesNames : TextBox
    {
        private static List<TextBox> textboxes = new List<TextBox>{ };
        public enum names
        {
            name,
            description
        }

        private static object[,] namesArray =
        {
            { names.name, false },
            { names.description, true }
        };

        public TextboxesNames()
        {
            createList();
        }

        public static object[,] getArray()
        {
            return namesArray;
        }

        private void createList()
        {
            if (textboxes != null)
            {
                textboxes.Clear();
            }

            for (int i = 0; i < namesArray.Length / 2; i++)
            {
                var textbox = new TextBox()
                {
                    CausesValidation = true,
                    Name = namesArray[i , 0].ToString(),
                    Multiline = (Boolean)namesArray[i, 1]
                };
                textboxes.Add(textbox);
            }
        }

        public List<TextBox> getList()
        {
            return textboxes;
        }

        public static TextBox getTextBoxByName(Enum name)
        {
            return textboxes.Find(x => x.Name.ToUpper() == name.ToString().ToUpper());
        }
    }
}
