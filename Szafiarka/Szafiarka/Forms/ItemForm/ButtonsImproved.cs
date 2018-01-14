using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using Szafiarka.Classes;

namespace Szafiarka.Forms.ItemForm
{
    class ButtonsImproved
    {
        private static List<FlatButton> buttons;
        public enum names
        {
            [Description("Dodaj zdjęcie")]
            image,
            [Description("Usuń zdjęcie")]
            image_delete,
            [Description("Zapisz")]
            save,
            [Description("Resetuj")]
            revert,
            [Description("Anuluj")]
            cancel,
            [Description("Przywróć historię")]
            history
        }

        private object[] buttonsArray =
        {
            names.image_delete,
            names.image,
            names.history,
            names.revert,
            names.save,
            names.cancel
        };

        public ButtonsImproved()
        {
            createList();
        }

        private void createList()
        {
            if (buttons != null)
            {
                buttons.Clear();
            }

            buttons = new List<FlatButton> { };

            foreach (var item in buttonsArray)
            {
                var button = new FlatButton()
                {
                    Size = new Size(189, 30),
                    Text = Utils.GetEnumDescription(item as Enum),
                    Name = item.ToString(),
                    ForeColor = Color.White
                };

                buttons.Add(button);
            }
        }

        public static List<FlatButton> getList()
        {
            return buttons;
        }


    }
}
