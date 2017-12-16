using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Szafiarka.Classes;
using System.Threading;
using Szafiarka.Forms.Splashscreen;
using Szafiarka.Forms.ItemForm;

namespace Szafiarka
{
    public partial class MainForm : Form
    {
        private Classes.MapDB.Queries queries;

        private enum Messages
        {
            [Description("Nie wybrałeś elementu do usunięcia")]
            DELETE,
            [Description("Nie wybrałeś elementu do edycji")]
            EDIT,
        }


        public MainForm()
        {
            Thread splashThread = new Thread(new ThreadStart(SplashscreenStart));
            splashThread.Start();
            Thread.Sleep(3000);
            var assemblyData = new RetrievingAssemblyData();
            queries = new Classes.MapDB.Queries();
            InitializeComponent(assemblyData);
            splashThread.Abort();
        }

        public void SplashscreenStart()
        {
            Application.Run(new Splashscreen());
        }

        #region Menu Buttons
        private void selectAndAddEvent(MenuButton button)
        {
            if (button.compareEnumValueToButtonName(MenuButton.buttonsNames.exit))
            {
                button.Click += new EventHandler(exit_Click);
            }
            if (button.compareEnumValueToButtonName(MenuButton.buttonsNames.home))
            {
                button.Click += new EventHandler(start_Click);
            }
            if (button.compareEnumValueToButtonName(MenuButton.buttonsNames.add))
            {
                button.Click += new EventHandler(add_Click);
            }
            if (button.compareEnumValueToButtonName(MenuButton.buttonsNames.search))
            {
                button.Click += new EventHandler(search_Click);
            }
            if (button.compareEnumValueToButtonName(MenuButton.buttonsNames.edit))
            {
                button.Click += new EventHandler(edit_Click);
            }
            if (button.compareEnumValueToButtonName(MenuButton.buttonsNames.delete))
            {
                button.Click += new EventHandler(delete_Click);
            }
            if (button.compareEnumValueToButtonName(MenuButton.buttonsNames.bin))
                button.Click += new EventHandler(bin_Click);
            button.Click += new EventHandler(global_Click);
        }

        private void add_Click(object sender, EventArgs e)
        {
            var form = new ItemForm();
            form.ShowDialog();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            PanelStart panel = Panels.getPanelByName(Panels.PanelsName.PSTART) as PanelStart;
            var row = panel.getGridViewItemRow();
            if (panel.Visible == true && panel.getGridViewName() == DataGridViewNew.DGVMainDataNames.items.ToString() &&
                 row != null)
            {
                string messageBoxText = String.Format("Czy na pewno chcesz usunąć {0}?",
                    row.Cells["name"].Value.ToString());
                string caption = "Usuwanie";
                MessageBoxButtons button = MessageBoxButtons.YesNo;
                DialogResult res = MessageBox.Show(messageBoxText, caption, button);
                if (res == DialogResult.Yes)
                {
                    var itemId = Int32.Parse(row.Cells[0].Value.ToString());
                    queries.changeItemDeletedById(itemId, true);
                    refreshPanelStartGrid();
                }
            }
            else
                MessageBox.Show(Utils.GetEnumDescription(Messages.DELETE), "Warrning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void edit_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Utils.GetEnumDescription(Messages.EDIT), "Warrning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void global_Click(object sender, EventArgs e)
        {
            PanelStart panelStart = Panels.getPanelByName(Panels.PanelsName.PSTART) as PanelStart;
            if (panelStart.Visible == false)
                MenuButton.changeButtonsEnabled(false);
            else
                MenuButton.changeButtonsEnabled(true);
        }

        private void search_Click(object sender, EventArgs e)
        {
            Panels.changePanelsVisableToFalse();
            Panels.changePanelVisableToTrueByEnum(Panels.PanelsName.PSEARCH);
        }

        private void start_Click(object sender, EventArgs e)
        {
            Panels.changePanelsVisableToFalse();
            refreshPanelStartGrid();
            Panels.changePanelVisableToTrueByEnum(Panels.PanelsName.PSTART);
        }

        private void bin_Click(object sender, EventArgs e)
        {
            Panels.changePanelsVisableToFalse();
            refreshPanelBinGrid();
            Panels.changePanelVisableToTrueByEnum(Panels.PanelsName.PBIN);
        }
        #endregion
        private static void refreshPanelBinGrid()
        {
            PanelBin panel = Panels.getPanelByName(Panels.PanelsName.PBIN) as PanelBin;
            panel.refreashGrid();
        }

        private void refreshPanelStartGrid()
        {
            PanelStart panel = Panels.getPanelByName(Panels.PanelsName.PSTART) as PanelStart;
            panel.refreashGrid();
        }
        
    }
}