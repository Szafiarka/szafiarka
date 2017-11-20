using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Szafiarka.Classes
{
    class Utils
    {
        public Utils()
        {

        }
        
        public string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public void changePanelsVisableToFalse(List<Panels> PanelsList)
        {
            try
            {
                foreach (var item in PanelsList)
                    item.changeVisableToFalse();
            }
            catch { }
        }

        public void changePanelVisableToTrue(List<Panels> PanelsList, Enum name)
        {
            try
            {
                var panel = PanelsList.Find(X => X.Name.ToUpper() == name.ToString("g"));
                panel.changeVisableToTrue();
            }
            catch { }
        }

        public bool mod2(int value)
        {
            return (value % 2 == 0);
        }

    }
}
