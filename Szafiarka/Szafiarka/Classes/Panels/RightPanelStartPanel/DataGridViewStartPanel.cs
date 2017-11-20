using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szafiarka.Classes
{
    class DataGridViewStartPanel : DataGridView
    {
        Utils utils = new Utils();
        public DataGridViewStartPanel() : base()
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
            RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.Tomato;
        }

        private void rowAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            var grid = sender as DataGridView;
            {
                foreach (DataGridViewRow item in grid.Rows)
                {
                    if (!utils.mod2(item.Index))
                    {
                        item.DefaultCellStyle.BackColor = Color.LightGray;
                    }
                }
            }
        }

        public void AddColumns(string[,] columns)
        {
            try
            {
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
