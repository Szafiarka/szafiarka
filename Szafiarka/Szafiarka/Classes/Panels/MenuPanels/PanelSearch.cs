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
    class PanelSearch : Panels
    {
        private FlatButton searchItemName;
        private TextBox textBoxItemName;
        private TextBox textBoxItemStatus;
        private Queries queries = new Queries();
        private DataGridViewNew DGVMainData;
        private static int DGVHeight = 600;
        private static int LocationHeightStart = 30;
        private Label labelSearchName;
        private Label labelSearchStatus;
        private Label labelSearchCategory;
        private Label labelSearchChangeDate;
        private TextBox textBoxItemCategory;
        private TextBox textBoxItemChangeDate;
        private static int DGVMainWidth = 900;
        


        public PanelSearch()
        {
            Name = "pSearch";
           // BackColor = System.Drawing.Color.FromArgb(0, 50, 0);
            InitializeComponent();
        }

        private void AddColumnsToDGV(DataGridView gridView, string[,] columns)
        {
            for (int i = 0; i < columns.Length / 2; i++)
            {
                gridView.Columns.Add(columns[i, 0], columns[i, 1]);
            }
        }

        private void InitializeComponent()
        {
            this.searchItemName = new Szafiarka.Classes.FlatButton();
            this.textBoxItemName = new System.Windows.Forms.TextBox();
            this.textBoxItemStatus = new System.Windows.Forms.TextBox();
            this.labelSearchName = new System.Windows.Forms.Label();
            this.labelSearchStatus = new System.Windows.Forms.Label();
            this.labelSearchCategory = new System.Windows.Forms.Label();
            this.labelSearchChangeDate = new System.Windows.Forms.Label();
            this.textBoxItemCategory = new System.Windows.Forms.TextBox();
            this.textBoxItemChangeDate = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // searchItemName
            // 
            this.searchItemName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(168)))), ((int)(((byte)(204)))));
            this.searchItemName.FlatAppearance.BorderSize = 0;
            this.searchItemName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.searchItemName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.searchItemName.Location = new System.Drawing.Point(800, 0);
            this.searchItemName.Name = "searchItemName";
            this.searchItemName.Size = new System.Drawing.Size(90, 35);
            this.searchItemName.TabIndex = 0;
            this.searchItemName.Text = "Szukaj";
            this.searchItemName.UseVisualStyleBackColor = false;
            this.searchItemName.Click += new System.EventHandler(this.searchItemName_Click);
            // 
            // textBoxItemName
            // 
            this.textBoxItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxItemName.Location = new System.Drawing.Point(80, 0);
            this.textBoxItemName.Name = "textBoxItemName";
            this.textBoxItemName.Size = new System.Drawing.Size(570, 32);
            this.textBoxItemName.TabIndex = 0;
            // 
            // textBoxItemStatus
            // 
            this.textBoxItemStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxItemStatus.Location = new System.Drawing.Point(80, 35);
            this.textBoxItemStatus.Name = "textBoxItemStatus";
            this.textBoxItemStatus.Size = new System.Drawing.Size(100, 21);
            this.textBoxItemStatus.TabIndex = 0;
            // 
            // labelSearchName
            // 
            this.labelSearchName.AutoSize = true;
            this.labelSearchName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSearchName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelSearchName.Location = new System.Drawing.Point(0, 0);
            this.labelSearchName.Name = "labelSearchName";
            this.labelSearchName.Size = new System.Drawing.Size(55, 18);
            this.labelSearchName.TabIndex = 0;
            this.labelSearchName.Text = "Nzwa:";
            // 
            // labelSearchStatus
            // 
            this.labelSearchStatus.AutoSize = true;
            this.labelSearchStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSearchStatus.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelSearchStatus.Location = new System.Drawing.Point(0, 35);
            this.labelSearchStatus.Name = "labelSearchStatus";
            this.labelSearchStatus.Size = new System.Drawing.Size(61, 18);
            this.labelSearchStatus.TabIndex = 0;
            this.labelSearchStatus.Text = "Status:";
            // 
            // labelSearchCategory
            // 
            this.labelSearchCategory.AutoSize = true;
            this.labelSearchCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSearchCategory.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelSearchCategory.Location = new System.Drawing.Point(190, 35);
            this.labelSearchCategory.Name = "labelSearchCategory";
            this.labelSearchCategory.Size = new System.Drawing.Size(75, 18);
            this.labelSearchCategory.TabIndex = 0;
            this.labelSearchCategory.Text = "Kategoria:";
            // 
            // labelSearchChangeDate
            // 
            this.labelSearchChangeDate.AutoSize = true;
            this.labelSearchChangeDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSearchChangeDate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelSearchChangeDate.Location = new System.Drawing.Point(385, 35);
            this.labelSearchChangeDate.Name = "labelSearchChangeDate";
            this.labelSearchChangeDate.Size = new System.Drawing.Size(153, 18);
            this.labelSearchChangeDate.TabIndex = 0;
            this.labelSearchChangeDate.Text = "Data ostatniej zmiany:";
            // 
            // textBoxItemCategory
            // 
            this.textBoxItemCategory.Location = new System.Drawing.Point(275, 35);
            this.textBoxItemCategory.Name = "textBoxItemCategory";
            this.textBoxItemCategory.Size = new System.Drawing.Size(100, 20);
            this.textBoxItemCategory.TabIndex = 0;
            // 
            // textBoxItemChangeDate
            // 
            this.textBoxItemChangeDate.Location = new System.Drawing.Point(550, 35);
            this.textBoxItemChangeDate.Name = "textBoxItemChangeDate";
            this.textBoxItemChangeDate.Size = new System.Drawing.Size(100, 20);
            this.textBoxItemChangeDate.TabIndex = 0;
            // 
            // PanelSearch
            // 
            this.Controls.Add(this.textBoxItemName);
            this.Controls.Add(this.textBoxItemStatus);
            this.Controls.Add(this.labelSearchName);
            this.Controls.Add(this.labelSearchStatus);
            this.Controls.Add(this.textBoxItemCategory);
            this.Controls.Add(this.textBoxItemChangeDate);
            this.Controls.Add(this.labelSearchCategory);
            this.Controls.Add(this.labelSearchChangeDate);
            this.Controls.Add(this.searchItemName);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void InitalizeDataGrids()
        {
            DGVMainData = new DataGridViewNew();
            DGVMainData.Location = new Point(0, LocationHeightStart);
            DGVMainData.Size = new Size(DGVMainWidth, DGVHeight);
            DGVMainData.Visible = true;

            Controls.Add(DGVMainData);
        }

        private void DGVItemsView()
        {
            DGVMainData.clearRowsAndColumns();
            DGVMainData.setName(DataGridViewNew.DGVMainDataNames.items.ToString());
            string[,] columns = {
                { "id", "ID" },
                { "name", "Nazwa" },
                { "category", "Kategoria" },
                { "status", "Status" },
                { "rooms", "Pokój" },
                { "wardrobe", "Szafa" },
                { "shelf", "Szuflada" },
            };
            DGVMainData.AddColumns(columns);
            string name = textBoxItemName.Text;
            string status = textBoxItemStatus.Text;
            string category = textBoxItemCategory.Text;
            string changeDate = textBoxItemChangeDate.Text;
            var query = queries.getGridViewItemByName(name);

            foreach (var item in query)
            {
                DGVMainData.Rows.Add(item.id, item.name, item.category, item.status,
                    item.room, item.wardorobe, Int32.Parse(item.shelf) + 1);
            }
            DGVMainData.changeIdColumnVisableToFalse();            
        }

        private void DTVLastItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var itemId = Int32.Parse(DGVMainData.Rows[e.RowIndex].Cells[0].Value.ToString());
            var itemForm = new ItemForm(itemId);
            itemForm.Show();
        }

        private void searchItemName_Click(object sender, EventArgs e)
        {
            DGVItemsView();            
        }
    }
}