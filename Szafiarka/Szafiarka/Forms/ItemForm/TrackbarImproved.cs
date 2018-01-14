using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Szafiarka.Classes;

namespace Szafiarka.Forms.ItemForm
{
    class TrackbarImproved
    {
        private static TrackbarNew trackbar;
        public TrackbarImproved()
        {
            createTrackbar();
        }

        private void createTrackbar()
        {
            if (trackbar != null)
                trackbar = null;
            trackbar = new TrackbarNew()
            {
                Maximum = 6,
                Name = "size"
            };
        }

        public static TrackbarNew getTrackbar()
        {
            return trackbar;
        }
    }

    class TrackbarNew : TrackBar
    {
        private enum description
        {
            [Description("skarpetki, majtki, drobiazgi")]
            var1,
            [Description("koszulka, książka, obrazek")]
            var2,
            [Description("buty, proszek do prania")]
            var3,
            [Description("garnek, bluza, poduszka")]
            var4,
            [Description("odkurzacz, laptop, kurtka")]
            var5,
            [Description("walizka, kołdra")]
            var6,
            [Description("Skarpetki, majtki, drobiazgi")]
            var7,
            [Description("Skarpetki, majtki, drobiazgi")]
            var8,
            [Description("Skarpetki, majtki, drobiazgi")]
            var9,
            [Description("Skarpetki, majtki, drobiazgi")]
            var10
        }

        private object[] names = {
            description.var1,
            description.var2,
            description.var3,
            description.var4,
            description.var5,
            description.var6,
            description.var7,
            description.var8,
            description.var9,
            description.var10,

        };

        public TrackbarNew()
        {
            Width = 200;
            ValueChanged += new EventHandler(TrackBar1_ValueChanged);
        }

        private void TrackBar1_ValueChanged(object sender, System.EventArgs e)
        {
            Console.WriteLine(getEnum(Value));
            var textbox = LabelsImproved.getLabelByName(LabelsImproved.names.size);
            textbox.Text = string.Format("{0}: {1} {2}",
                Utils.GetEnumDescription(LabelsImproved.names.size),
                Value,
                getEnum(Value));
        }

        private string getEnum(int value)
        {
            string result = "";
            var name = string.Format("var{0}", value);
            foreach (var item in names)
            {
                if (item.ToString() == name)
                {
                    result = Utils.GetEnumDescription(item as Enum);
                }
            }
            return result;
        }
    }
}
