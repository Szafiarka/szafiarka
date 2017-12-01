using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Szafiarka.Classes.MapDB;

namespace Szafiarka.Classes
{
    class PanelSearch : Panels
    {
        private FlatButton searchItemName;
        private TextBox textBoxItemName;
        private Queries queries = new Queries();
        private DataGridViewStartPanel DGVLastItems;
        private DataGridViewStartPanel DGVMainData;
        private static int DGVHeight = 600;
        private static int LocationHeightStart = 50;
        private static int DGVMainWidth = 720;
        


        public PanelSearch()
        {
            Name = "pSearch";
            BackColor = System.Drawing.Color.FromArgb(0, 50, 0);
            InitializeComponent();
        }

        private void AddColumnsToDGV(DataGridView gridView, string[,] columns)
        {
            for (int i = 0; i < columns.Length / 2; i++)
            {
                gridView.Columns.Add(columns[i, 0], columns[i, 1]);
            }
        }

        private static string[,] ITEMSCOLUMNS = {
            { "id", "ID" },
            { "name", "Nazwa" },
            { "category", "Kategoria" },
            { "date", "Data" }
        };

        private void DTVLastItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var itemId = Int32.Parse(DGVMainData.Rows[e.RowIndex].Cells[0].Value.ToString());
            var itemForm = new ItemForm(itemId);
            itemForm.Show();
        }

        private void getDescription_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = (DataGridView)sender;
            var row = grid.Rows[e.RowIndex];
            var cell = row.Cells[e.ColumnIndex];
            if (grid.Name == DGVMainDataNames.categories.ToString())
            {
                cell.ToolTipText = queries.getCategoryDescriptionById(Int32.Parse(row.Cells[0].Value.ToString()));
            }
            else if (grid.Name == DGVMainDataNames.items.ToString())
            {
                cell.ToolTipText = queries.getItemDescriptionById(Int32.Parse(row.Cells[0].Value.ToString()));
            }
        }

        private void InitializeComponent()
        {
            this.searchItemName = new Szafiarka.Classes.FlatButton();
            this.textBoxItemName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // searchItemName
            // 
            this.searchItemName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(168)))), ((int)(((byte)(204)))));
            this.searchItemName.FlatAppearance.BorderSize = 0;
            this.searchItemName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.searchItemName.Location = new System.Drawing.Point(0, 0);
            this.searchItemName.Name = "searchItemName";
            this.searchItemName.Size = new System.Drawing.Size(75, 23);
            this.searchItemName.TabIndex = 0;
            this.searchItemName.Text = "Szukaj";
            this.searchItemName.UseVisualStyleBackColor = false;
            this.searchItemName.Click += new System.EventHandler(this.searchItemName_Click);
            // 
            // textBoxItemName
            // 
            this.textBoxItemName.Location = new System.Drawing.Point(0, 0);
            this.textBoxItemName.Name = "textBoxItemName";
            this.textBoxItemName.Size = new System.Drawing.Size(100, 20);
            this.textBoxItemName.TabIndex = 0;
            this.ResumeLayout(false);

        }

        private void InitalizeDataGrids()
        {
            var sizeWidth = 300;
            DGVLastItems = new DataGridViewStartPanel();
            DGVLastItems.Location = new Point(Width - sizeWidth, LocationHeightStart);
            DGVLastItems.Name = "DTVLastItems";
            DGVLastItems.Size = new Size(sizeWidth, DGVHeight - (DGVHeight / 2));
            AddColumnsToDGV(DGVLastItems, ITEMSCOLUMNS);
            DTVLastItemsFillColumns(DGVLastItems);
            DGVLastItems.Columns[0].Visible = false;

            Controls.Add(DGVLastItems);

            DGVMainData = new DataGridViewStartPanel();
            DGVMainData.Location = new Point(0, LocationHeightStart);
            DGVMainData.Size = new Size(DGVMainWidth, DGVHeight);
            DGVMainData.CellDoubleClick += DTVLastItems_CellDoubleClick;
            DGVMainData.Visible = false;
            DGVMainData.CellFormatting += new DataGridViewCellFormattingEventHandler(getDescription_CellFormatting);

            Controls.Add(DGVMainData);
        }

        private void searchItemName_Click(object sender, EventArgs e)
        {
            string name = textBoxItemName.Text;
            queries.getGridViewItemByName(name);
            private void DTVLastItemsFillColumns(DataGridView gridView)
            {
                var query = queries.getGridViewLastItems();
                foreach (var item in query.OrderByDescending(X => X.modify_date))
                {
                    gridView.Rows.Add(item.id, item.name, item.category, item.modify_date);
                }
            }
        }
    }
}