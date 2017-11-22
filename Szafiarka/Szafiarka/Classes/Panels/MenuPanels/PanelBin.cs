using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szafiarka.Classes
{
    class PanelBin : Panels, IPanels
    {
        private MapDB.Queries queries;
        private Utils utils = new Utils();
        private DataGridViewNew grid;
        private Action refreashGridStart;
        private Action refreashGridBin;
        public PanelBin(Action refreshStart, Action refreashBin)
        {
            queries = new MapDB.Queries();
            refreashGridStart = refreshStart;
            refreashGridBin = refreashBin;
            Name = "pBin";
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
            grid = new DataGridViewNew();
            grid.Location = new Point(0, 50);
            grid.Size = new Size(Size.Width, Size.Height - 100);
            grid.setName(DataGridViewNew.DGVMainDataNames.bin.ToString());

            Controls.Add(grid);
        }

        public void refreashGrid()
        {
            grid.clearRowsAndColumns();
            string[,] columns = {
                { "id", "ID" },
                { "name", "Nazwa" },
                { "category", "Kategoria" },
                { "status", "Status" },
                { "rooms", "Pokój" },
                { "wardrobe", "Szafa" },
                { "shelf", "Szuflada" },
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
                    item.room, item.wardorobe, Int32.Parse(item.shelf) + 1);
            }

            grid.changeIdColumnVisableToFalse();
        }

        private void click_button(object sender, EventArgs e)
        {
            string messageBoxText = "Czy na pewno chcesz przywrócić tę rzecz?";
            string caption = "Przywracanie";
            MessageBoxButtons button = MessageBoxButtons.YesNo;
            DialogResult res = MessageBox.Show(messageBoxText, caption, button);
            if (res == DialogResult.Yes)
            {
                var itemId = Int32.Parse(grid.CurrentRow.Cells[0].Value.ToString());
                queries.changeItemDeletedById(itemId, false);
                refreashGridStart();
                refreashGridBin();
            }
        }
    }
}
