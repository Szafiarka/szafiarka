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
            [Description("Skarpetki, majtki, drobiazgi")]
            var1
        }

        private object[] names = {
            description.var1,

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
