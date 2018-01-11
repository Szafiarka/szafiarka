using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Szafiarka.Forms.ItemForm;

namespace Szafiarka.Classes
{
    class PanelBin : Panels, IPanels
    {
        private MapDB.Queries queries;
        private DataGridViewNew grid;
        public PanelBin()
        {
            queries = new MapDB.Queries();
            Name = Panels.PanelsName.PBIN.ToString();
            InitializeComponent();
        }

        private void InitializeComponent()
        {
           initializeGrid();

            var button = new FlatButton()
            {
                Location = new Point(0, 0),
                Text = "Przywróć rzecz",
                
            };
            button.Click += click_button;
            Controls.Add(button);
        }

        private void initializeGrid()
        {
            grid = new DataGridViewNew()
            {
                Location = new Point(0, 50),
                Size = new Size(Size.Width, Size.Height - 100),
            };
            grid.setName(DataGridViewNew.DGVMainDataNames.bin.ToString());

            Controls.Add(grid);
        }

        public void refreashGrid()
        {
            string[,] columns = {
                { "id", "ID" },
                { "name", "Nazwa" },
                { "category", "Kategoria" },
                { "status", "Status" },
                { "room", "Pokój" },
                { "wardrobe", "Szafa" },
                { "shelf", "Półka" },
            };

            grid.AddColumns(columns);
            addItemsToGrid(grid);
        }

        private void addItemsToGrid(DataGridViewNew grid)
        {
            var deleted = true;
            var query = queries.getGridViewItem(deleted);

            foreach (var item in query)
            {

                grid.Rows.Add(item.id, item.name, item.category, item.status,
                    item.room, item.wardorobe, item.shelf);
            }

            grid.changeIdColumnVisableToFalse();
        }

        private void click_button(object sender, EventArgs e)
        {
            string messageBoxText = "Czy na pewno chcesz przywrócić tę rzecz?";
            string caption = "Przywracanie";
            MessageBoxButtons button = MessageBoxButtons.YesNo;
            DialogResult res = MessageBox.Show(messageBoxText, caption, button);
            if (res == DialogResult.Yes && grid.CurrentRow != null)
            {
                var itemId = Int32.Parse(grid.CurrentRow.Cells[0].Value.ToString());
                queries.changeItemDeletedById(itemId, false);
                Panels.refreshPanelBinGrid();
            }
        }
    }
}
