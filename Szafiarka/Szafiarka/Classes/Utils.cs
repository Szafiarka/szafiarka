using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Szafiarka.Classes
{
    public static class Utils
    {
        public static string CAPITALIZEENUM = "g";
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

        public static bool mod2(int value)
        {
            return (value % 2 == 0);
        }

        public static int increaseValueByOne(int value)
        {
            return value+1;
        }

    }
}
