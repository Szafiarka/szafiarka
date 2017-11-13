using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Reflection;

namespace Szafiarka.Classes
{
    class FlatButton : Button
    {
        public FlatButton() : base()
        {
            FlatStyle = FlatStyle.Flat;
            Font = new Font(this.Font.Name, 10);
            FlatAppearance.BorderSize = 0;
            BackColor = Color.FromArgb(1, 168, 204);
        }

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}
