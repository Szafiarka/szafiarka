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
        private Queries queries = new Queries();
        private DataGridViewNew DGVMainData;
        private static int LocationHeightStart = 100;
        private Label labelSearchName;


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
            InitializeComboboxes();
            InitializeLabels();
            this.searchItemName = new Szafiarka.Classes.FlatButton();
            this.textBoxItemName = new System.Windows.Forms.TextBox();
            this.labelSearchName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // searchItemName
            // 
            this.searchItemName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(168)))), ((int)(((byte)(204)))));
            this.searchItemName.FlatAppearance.BorderSize = 0;
            this.searchItemName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.searchItemName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.searchItemName.Location = new System.Drawing.Point(740, 0);
            this.searchItemName.Name = "searchItemName";
            this.searchItemName.Size = new System.Drawing.Size(90, 32);
            this.searchItemName.TabIndex = 0;
            this.searchItemName.Text = "Szukaj";
            this.searchItemName.UseVisualStyleBackColor = false;
            this.searchItemName.Click += new System.EventHandler(this.searchItemName_Click);
            // 
            // textBoxItemName
            // 
            this.textBoxItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxItemName.Location = new System.Drawing.Point(70, 0);
            this.textBoxItemName.Name = "textBoxItemName";
            this.textBoxItemName.Size = new System.Drawing.Size(650, 32);
            this.textBoxItemName.TabIndex = 0;
            // 
            // labelSearchName
            // 
            this.labelSearchName.AutoSize = true;
            this.labelSearchName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSearchName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelSearchName.Location = new System.Drawing.Point(0, 5);
            this.labelSearchName.Name = "labelSearchName";
            this.labelSearchName.Size = new System.Drawing.Size(64, 18);
            this.labelSearchName.TabIndex = 0;
            this.labelSearchName.Text = "Nazwa:";
            
            // 
            // PanelSearch
            // 
            this.Controls.Add(this.textBoxItemName);
            this.Controls.Add(this.labelSearchName);
            this.Controls.Add(this.searchItemName);
            this.ResumeLayout(false);
            this.PerformLayout();
            this.InitalizeDataGrids();

        }

        private void InitializeComboboxes()
        {
            var k = 0;
            var comboboxes = new ComboboxesImproved(false);
            foreach (var item in comboboxes.getComboboxImprovedList())
            {
                item.Size = new System.Drawing.Size(100, 21);
                item.Location = new Point(70 + 200 * k, 50);
                Controls.Add(item);
                k++;
            }
        }

        private void InitializeLabels()
        {
            string[] labels = {
                "Pokój",
                "Szafa",
                "Półka",
                "Kategoria",
                "Status"
            };

            var k = 0;
            foreach (var item in labels)
            {
                var label = new Label()
                {
                    Text = item,
                    Location = new Point(0 + 200 * k, 50),
                    ForeColor = System.Drawing.SystemColors.ControlLightLight,
                    Size = new System.Drawing.Size(75, 18),
                    Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238))),

            };
                k++;
                Controls.Add(label);
            }
        }

        private void InitalizeDataGrids()
        {
            DGVMainData = new DataGridViewNew();
            DGVMainData.Location = new Point(0, LocationHeightStart);
            DGVMainData.Size = new Size(Size.Width, Size.Height - LocationHeightStart);
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
            string status = "";
            string category = "";
            string room = "";
            string wardrobe = "";
            try
            {
                status = ComboboxesImproved.getComboboxByName(ComboboxesImproved.names.status).SelectedItem.ToString();
            }
            catch { }
            try
            {
                category = ComboboxesImproved.getComboboxByName(ComboboxesImproved.names.category).SelectedItem.ToString();
            }
            catch { }
            try
            {
                room = ComboboxesImproved.getComboboxByName(ComboboxesImproved.names.room).SelectedItem.ToString();
            }
            catch { }
            try
            {
                wardrobe = ComboboxesImproved.getComboboxByName(ComboboxesImproved.names.wardrobe).SelectedItem.ToString();
            }
            catch { }
            var query = queries.getGridViewItemByName(name, category, status, wardrobe, room);

            foreach (var item in query)
            {
                DGVMainData.Rows.Add(item.id, item.name, item.category, item.status,
                    item.room, item.wardorobe, item.shelf);
            }
            DGVMainData.changeIdColumnVisableToFalse();
        }

        private void searchItemName_Click(object sender, EventArgs e)
        {
            DGVItemsView();
        }
    }
}