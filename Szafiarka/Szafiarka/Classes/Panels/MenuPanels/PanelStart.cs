using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Szafiarka.Forms.ItemForm;

namespace Szafiarka.Classes
{
    class PanelStart : Panels
    {
        private DataGridViewStartPanel DGVLastItems;
        private DataGridViewStartPanel DGVMainData;
        private static int DGVHeight = 600;
        private static int LocationHeightStart = 50;
        private static int DGVMainWidth = 720;
        private MapDB.Queries queries;

        private FlatButton oldButton;

        private enum buttonsNames
        {
            rooms, wardrobes, items, status, categories
        }

        private static string[,] OBJECTSBUTTONS =
        {
            { buttonsNames.rooms.ToString(), "Pokoje" },
            { buttonsNames.wardrobes.ToString(), "Szafy" },
            { buttonsNames.items.ToString(), "Rzeczy" },
            { buttonsNames.status.ToString(), "Statusy" },
            { buttonsNames.categories.ToString(), "Kategorie" },
        };

        private static string[,] LASTITEMSCOLUMNS = {
            { "id", "ID" },
            { "name", "Nazwa" },
            { "category", "Kategoria" }
        };

        public PanelStart()
        {
            Name = "pStart";
            Visible = true;
            queries = new MapDB.Queries();
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            InitalizeDataGrids();
            InitializeObjectsButtons();
            InitializeLabelLastItems();
            IntializeProgressBars();
            ResumeLayout(false);
        }

        private void InitializeObjectsButtons()
        {
            var buttonCount = OBJECTSBUTTONS.Length / 2;
            var buttonLenght = (DGVMainWidth / buttonCount);
            for (int i = 0; i < buttonCount; i++)
            {
                var button = new FlatButton()
                {
                    Location = new Point((buttonLenght) * i, 0),
                    Name = OBJECTSBUTTONS[i,0],
                    Size = new Size(buttonLenght, 30),
                    Text = OBJECTSBUTTONS[i, 1],

                };
                addEventToButton(button);
                Controls.Add(button);
            }
        }

        private void InitializeLabelLastItems()
        {
            var label = new Label();
            label.Location = new Point(Width - 300, 0);
            label.Size = new Size(300, 30);
            label.Text = "Ostatnio zmodyfikowane";
            label.ForeColor = Color.White;
            label.BackColor = Color.Tomato;
            Controls.Add(label);

        }

        private void InitalizeDataGrids()
        {
            var sizeWidth = 300;
            DGVLastItems = new DataGridViewStartPanel();
            DGVLastItems.Location = new Point(Width - sizeWidth, LocationHeightStart);
            DGVLastItems.BackgroundColor = BackColor;
            DGVLastItems.Name = "DTVLastItems";
            DGVLastItems.Size = new Size(sizeWidth, DGVHeight-(DGVHeight/2));
            AddColumnsToDGV(DGVLastItems, LASTITEMSCOLUMNS);
            DTVLastItemsFillColumns(DGVLastItems);
            DGVLastItems.Columns[0].Visible = false;

            Controls.Add(DGVLastItems);

            DGVMainData = new DataGridViewStartPanel();
            DGVMainData.Location = new Point(0, LocationHeightStart);
            DGVMainData.Size = new Size(DGVMainWidth, DGVHeight);
            DGVMainData.Name = "aaa";
            DGVMainData.BackgroundColor = BackColor;
            DGVMainData.CellDoubleClick += DTVLastItems_CellDoubleClick;
            DGVMainData.Visible = false;

            Controls.Add(DGVMainData);
        }

        private void DTVLastItemsFillColumns(DataGridView gridView)
        {
            var query = queries.getGridViewLastItems();

            foreach (var item in query.OrderByDescending(X => X.creation_date))
            {
                gridView.Rows.Add(item.id, item.name, item.category);
            }
        }

        private void DTVLastItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var itemId = Int32.Parse(DGVMainData.Rows[e.RowIndex].Cells[0].Value.ToString());
            var itemForm = new ItemForm(itemId);
            itemForm.Show(); 
        }

        private void addEventToButton(Button button)
        {
            if (button.Name.ToUpper() ==  buttonsNames.items.ToString().ToUpper())
            {
                button.Click += new EventHandler(DGVItemsView);
            }
            if (button.Name.ToUpper() == buttonsNames.rooms.ToString().ToUpper())
            {
                button.Click += new EventHandler(DGVRoomsView);
            }
            if (button.Name.ToUpper() == buttonsNames.status.ToString().ToUpper())
            {
                button.Click += new EventHandler(DGVStatusView);
            }
            if (button.Name.ToUpper() == buttonsNames.categories.ToString().ToUpper())
            {
                button.Click += new EventHandler(DGVCategoriesView);
            }
            if (button.Name.ToUpper() == buttonsNames.wardrobes.ToString().ToUpper())
            {
                button.Click += new EventHandler(DGVWardrobesView);
            }
            button.Click += new EventHandler(DGVMainDataChangeVisable);
            button.Click += new EventHandler(ChangeButtonSelection);
        }

        private void DGVMainDataChangeVisable(object sender, EventArgs e)
        {
            DGVMainData.Visible = true;
        }

        private void ChangeButtonSelection(object sender, EventArgs e)
        {
            var button = sender as FlatButton;
            if (oldButton != null)
            {
                oldButton.BackColor = PanelMenu.defaultColor;
            }
            if(oldButton == button)
            {
                button.BackColor = PanelMenu.defaultColor;
                oldButton = null;
                DGVMainData.Visible = false;
            }
            else
            {
                oldButton = button;
                button.BackColor = Color.White;
            }
        }

        private void DGVItemsView(object sender, EventArgs e)
        {
            GridViewClearRowsAndColumns(DGVMainData);
            string[,] columns = {
                { "id", "ID" },
                { "name", "Nazwa" },
                { "category", "Kategoria" },
                { "status", "Status" },
                { "rooms", "Pokój" },
                { "wardrobe", "Szafa" },
                { "shelf", "Szuflada" },
            };
            AddColumnsToDGV(DGVMainData, columns);

            var query = queries.getGridViewItem();

            foreach (var item in query)
            {
                DGVMainData.Rows.Add(item.id, item.name, item.category, item.status,
                    item.room, item.wardorobe, Int32.Parse(item.shelf)+1);
            }

            DGVMainData.Columns[0].Visible = false;

        }

        private void DGVRoomsView(object sender, EventArgs e)
        {
            GridViewClearRowsAndColumns(DGVMainData);
            string[,] columns = {
                { "id", "ID" },
                { "name", "Nazwa" }
            };
            AddColumnsToDGV(DGVMainData, columns);

            var query = queries.getGridViewRoom();
            foreach (var item in query)
            {
                DGVMainData.Rows.Add(item.id, item.name);
            }

            DGVMainData.Columns[0].Visible = false;
        }

        private void DGVStatusView(object sender, EventArgs e)
        {
            GridViewClearRowsAndColumns(DGVMainData);
            string[,] columns = {
                { "id", "ID" },
                { "name", "Nazwa" },
                { "itemsCount", "Ilość rzeczy" }
            };
            AddColumnsToDGV(DGVMainData, columns);

            var query = queries.getGridViewStatus();
            foreach (var item in query)
            {
                DGVMainData.Rows.Add(item.id, item.name, item.itemsCount);
            }

            DGVMainData.Columns[0].Visible = false;
        }

        private void DGVCategoriesView(object sender, EventArgs e)
        {
            GridViewClearRowsAndColumns(DGVMainData);
            string[,] columns = {
                { "id", "ID" },
                { "name", "Nazwa" },
                { "itemsCount", "Ilość rzeczy" }
            };
            AddColumnsToDGV(DGVMainData, columns);

            var query = queries.getGridViewCategory();

            foreach (var item in query)
            {
                DGVMainData.Rows.Add(item.id, item.name, item.itemsCount);
            }

            DGVMainData.Columns[0].Visible = false;
        }

        private void DGVWardrobesView(object sender, EventArgs e)
        {
            GridViewClearRowsAndColumns(DGVMainData);
            string[,] columns = {
                { "id", "ID" },
                { "name", "Nazwa" },
                { "room", "Pokój" },
                { "shelfCount", "Ilość półek" }
            };
            AddColumnsToDGV(DGVMainData, columns);

            var query = queries.getGridViewWardrobe();

            foreach (var item in query)
            {
                DGVMainData.Rows.Add(item.id, item.name, item.room, item.shelfCount);
            }

            DGVMainData.Columns[0].Visible = false;
        }

        private void GridViewClearRowsAndColumns(DataGridView gridView)
        {
            gridView.Rows.Clear();
            gridView.Columns.Clear();
        }

        private void AddColumnsToDGV(DataGridView gridView, string[,] columns)
        {
            for (int i = 0; i < columns.Length / 2; i++)
            {
                gridView.Columns.Add(columns[i, 0], columns[i, 1]);
            }
        }

        private void IntializeProgressBars()
        {
            var query = queries.getWardrobesOccupancy();
            var k = 0;
            foreach (var item in query.OrderByDescending(x => x.capacity))
            {
                addProgressBar(item, k);
                Console.WriteLine(String.Format("{0} {1}",item.capacity, item.wardrobe.name));
                k++;
            }
        }

        private void addProgressBar(MapDB.ResulWardrobesOccupancy item, int k)
        {
            var label = new Label();
            var progressBar = new ProgressBar();

            label.Location = new Point(Width - 300, 380 + k * 60);
            label.Text = String.Format("{0} {1}",item.wardrobe.Room.name, item.wardrobe.name);
            label.ForeColor = Color.White;

            progressBar.Location = new Point(Width - 300, 405 + k * 60);
            progressBar.Size = new Size(300, 20);
            if (item.capacity >= 0 )
                progressBar.Value = (int)((item.capacity / item.capacity_wardrobe) * 100);
            else
                progressBar.Value = 0;
            progressBar.ForeColor = Color.Azure;

            Controls.Add(label);
            Controls.Add(progressBar);
        }
    }
}
