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
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && 
                (Name == DGVMainDataNames.items.ToString()
                || Name == DGVMainDataNames.bin.ToString()
                || Name == DGVMainDataNames.lastItems.ToString()))
            {
                ContextMenu m = new ContextMenu();
                m.MenuItems.Add(new MenuItem("Cut"));
                m.MenuItems.Add(new MenuItem("Copy"));
                m.MenuItems.Add(new MenuItem("Paste"));

                int currentMouseOverRow = HitTest(e.X, e.Y).RowIndex;

                if (currentMouseOverRow >= 0)
                {
                    m.MenuItems.Add(new MenuItem(string.Format("Do something to row {0}", currentMouseOverRow.ToString())));
                }

                m.Show(this, new Point(e.X, e.Y));

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
            else if (Name == DGVMainDataNames.items.ToString()
                || Name == DGVMainDataNames.bin.ToString()
                || Name == DGVMainDataNames.lastItems.ToString())
            {
                cell.ToolTipText = queries.getItemDescriptionById(Int32.Parse(row.Cells[0].Value.ToString()));
            }
        }

        public void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (checkIfGridEnableToShowItemForm(Name) && !checkIfDoubleClicedRowsIsHeader(e.RowIndex))
            {
                var itemId = Int32.Parse(Rows[e.RowIndex].Cells[0].Value.ToString());
                var itemForm = new ItemForm(itemId);
                if (itemForm != null)
                {
                    itemForm.Show();
                }

            }
        }

        private bool checkIfGridEnableToShowItemForm(string gridName)
        {
            List<string> namesGridsEnableToShowItemForm = new List<string> {
                DGVMainDataNames.items.ToString(),
                DGVMainDataNames.lastItems.ToString(),
                DGVMainDataNames.bin.ToString()
            };

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
    }
}
