using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szafiarka.Classes
{
    class Panels : Panel
    {
        public enum PanelsName
        {
            PSTART, PSEARCH, PBIN
        };

        private static List<Panels> PanelsList;

        public Panels()
        {
            Location = new System.Drawing.Point(110, 70);
            Size = new System.Drawing.Size(1060, 680);
            Visible = false;
        }

        public void changeVisableToTrue()
        {
            Visible = true;
        }

        public void changeVisableToFalse()
        {
            Visible = false;
        }

        public static void addNewPanelToList(Panels panel)
        {
            if (PanelsList == null)
            {
                PanelsList = new List<Panels> { };
            }
            PanelsList.Add(panel);
        }

        public static List<Panels> getPanelsList()
        {
            return PanelsList;
        }

        public static Panels getPanelByName(Enum value)
        {
            return PanelsList.Find(x => x.Name.ToUpper() == value.ToString().ToUpper());
        }

        public static void changePanelsVisableToFalse()
        {
            try
            {
                foreach (var item in PanelsList)
                    item.changeVisableToFalse();
            }
            catch { }
        }

        public static void changePanelVisableToTrueByEnum(Enum value)
        {
            try
            {
                var panel = getPanelByName(value);
                panel.changeVisableToTrue();
            }
            catch { }
        }

        public static void refreshPanelBinGrid()
        {
            PanelBin panel = Panels.getPanelByName(Panels.PanelsName.PBIN) as PanelBin;
            panel.refreashGrid();
        }

        public static void refreshPanelStartGrid()
        {
            PanelStart panel = Panels.getPanelByName(Panels.PanelsName.PSTART) as PanelStart;
            panel.refreashGrid();
        }

    }
}
