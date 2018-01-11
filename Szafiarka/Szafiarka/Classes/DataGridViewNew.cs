using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Szafiarka.Classes.MapDB;
using Szafiarka.Forms.ItemForm;

namespace Szafiarka.Classes
{
    class DataGridViewNew : DataGridView
    {
        private int menuClickedRow;
        private ContextMenuStrip menu = new ContextMenuStrip();
        private List<string> namesGridsEnableToShowItemForm = new List<string> {
                DGVMainDataNames.items.ToString(),
                DGVMainDataNames.lastItems.ToString(),
                DGVMainDataNames.bin.ToString()
            };
        public enum DGVMainDataNames
        {
            categories, items, nameCleared, bin, lastItems
        }

        Queries queries = new Queries();
        public DataGridViewNew() : base()
        {
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            MultiSelect = false;
            RowHeadersVisible = false;
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            AllowUserToResizeRows = false;
            ReadOnly = true;
            RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            BackgroundColor = Color.FromArgb(0, 0, 64);
            BorderStyle = BorderStyle.None;
            CellBorderStyle = DataGridViewCellBorderStyle.None;
            RowsAdded += new DataGridViewRowsAddedEventHandler(rowAdded);
            CellFormatting += new DataGridViewCellFormattingEventHandler(getDescriptionCellFormatting);
            CellDoubleClick += DataGridView_CellDoubleClick;
            RowsDefaultCellStyle.SelectionBackColor = Color.Tomato;
            Sorted += new EventHandler(columnsSortChanged);
            RowTemplate.Height = 35;
            ColumnHeadersHeight = 35;
            MouseClick += dataGridView1_MouseClick;
            menu.Items.Add("Podgląd");
            menu.Items.Add("Usuń");
            menu.ItemClicked += new ToolStripItemClickedEventHandler(menu_Clicked);
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right &&
                namesGridsEnableToShowItemForm.Contains(Name))
            {
                menuClickedRow = HitTest(e.X, e.Y).RowIndex;
                menu.Show(this, new Point(e.X, e.Y));
            }
        }

        private void rowAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            colorsCells();
        }

        private void columnsSortChanged(object sender, EventArgs e)
        {
            colorsCells();
        }

        private void colorsCells()
        {
            foreach (DataGridViewRow item in Rows)
            {
                if (!Utils.mod2(item.Index))
                {
                    item.DefaultCellStyle.BackColor = Color.LightGray;
                }
                else
                {
                    item.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void getDescriptionCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var row = Rows[e.RowIndex];
            var cell = row.Cells[e.ColumnIndex];
            if (Name == DGVMainDataNames.categories.ToString())
            {
                cell.ToolTipText = queries.getCategoryDescriptionById(Int32.Parse(row.Cells[0].Value.ToString()));
            }
            else if (namesGridsEnableToShowItemForm.Contains(Name))
            {
                cell.ToolTipText = queries.getItemDescriptionById(Int32.Parse(row.Cells[0].Value.ToString()));
            }
        }

        public void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (checkIfGridEnableToShowItemForm(Name) && !checkIfDoubleClicedRowsIsHeader(e.RowIndex))
            {
                int itemId = getItemIdFromRow(e.RowIndex);
                var itemForm = new ItemForm(itemId);
                if (itemForm != null)
                {
                    itemForm.Show();
                }

            }
        }

        private int getItemIdFromRow(int id)
        {
            return Int32.Parse(Rows[id].Cells[0].Value.ToString());
        }

        private bool checkIfGridEnableToShowItemForm(string gridName)
        {
            return namesGridsEnableToShowItemForm.Contains(gridName);
        }

        private bool checkIfDoubleClicedRowsIsHeader(int rowIndex)
        {
            const int indexHeaderRow = -1;
            return rowIndex == indexHeaderRow;
        }

        public void AddColumns(string[,] columns)
        {
            try
            {
                clearRowsAndColumns();
                var lenght = columns[0, 0].Length;
                for (int i = 0; i < columns.Length / 2; i++)
                {
                    Columns.Add(columns[i, 0], columns[i, 1]);
                }
            }
            catch { }
        }

        public void changeIdColumnVisableToFalse()
        {
            try
            {
                Columns["id"].Visible = false;
            }
            catch { }
            
        }
        public void clearRowsAndColumns()
        {
            Rows.Clear();
            Columns.Clear();
        }

        public void setName(string newName)
        {
            Name = newName;
        }

        private void menu_Clicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var clicked = e.ClickedItem.Text;
            if (clicked == "Podgląd")
            {
                var itemId = getItemIdFromRow(menuClickedRow);
                var itemForm = new ItemForm(itemId);
                if (itemForm != null)
                {
                    itemForm.Show();
                }
            }
        }
    }
}
