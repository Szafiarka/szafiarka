using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szafiarka.Classes
{
    class PanelStart : Panels
    {
        private DataGridView DGVLastItems;
        private DataGridView DGVMainData;
        private static int DGVHeight = 600;
        private static int LocationHeightStart = 50;
        private static int DGVMainWidth = 720;

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
            InitializeComponent();
        }

        #region Events
        private void start_Click(object sender, EventArgs e)
        {
            var rooms = DBconnection.DBCONNECTION.Room.ToArray();
            var result = from room in rooms where room.id_room == 16 select room;
            MessageBox.Show(result.First().name);
        }
        #endregion

        private void InitializeComponent()
        {
            SuspendLayout();
            InitializeMainData();
            InitializeObjectsButtons();
            InitializeLastItems();
            ResumeLayout(false);
        }

        private void InitializeObjectsButtons()
        {
            var buttonLenght = 100;
            for (int i = 0; i < OBJECTSBUTTONS.Length / 2; i++)
            {
                var button = new FlatButton()
                {
                    Location = new Point((buttonLenght + 10) * i, 0),
                    Name = OBJECTSBUTTONS[i,0],
                    Size = new Size(buttonLenght, 30),
                    Text = OBJECTSBUTTONS[i, 1],

                };
                addEventToButton(button);
                Controls.Add(button);
            }
        }

        private void InitializeMainData()
        {
            DGVMainData = new DataGridView();
            DGVMainData.Location = new Point(0, LocationHeightStart);
            DGVMainData.Size = new Size(DGVMainWidth, DGVHeight);
            DGVMainData.Name = "aaa";
            DGVMainData.BackgroundColor = BackColor;

            DGVMainData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            DGVMainData.RowHeadersVisible = false;
            DGVMainData.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;
            DGVMainData.AllowUserToAddRows = false;
            DGVMainData.AllowUserToDeleteRows = false;
            DGVMainData.AllowUserToResizeRows = false;
            DGVMainData.ReadOnly = true;
            DGVMainData.RowHeadersWidthSizeMode =
                DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            DGVMainData.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            DGVMainData.CellDoubleClick += DTVLastItems_CellDoubleClick;

            DGVMainData.Visible = false;
            
            Controls.Add(DGVMainData);
        }

        private void InitializeLastItems()
        {
            var sizeWidth = 300;
            DGVLastItems = new DataGridView();
            DGVLastItems.Location = new Point(Width - sizeWidth, LocationHeightStart);
            DGVLastItems.BackgroundColor = BackColor;
            DGVLastItems.Name = "DTVLastItems";
            DGVLastItems.Size = new Size(sizeWidth, DGVHeight);
            DGVLastItems.Font = new Font(Font.Name, 12);

            DGVLastItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            DGVLastItems.RowHeadersVisible = false;
            DGVLastItems.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;
            DGVLastItems.AllowUserToAddRows = false;
            DGVLastItems.AllowUserToDeleteRows = false;
            DGVLastItems.AllowUserToResizeRows = false;
            DGVLastItems.ReadOnly = true;
            DGVLastItems.RowHeadersWidthSizeMode =
                DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            DGVLastItems.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            DGVLastItems.CellDoubleClick += DTVLastItems_CellDoubleClick;

            DTVLastItemsAddColumns(DGVLastItems);
            DTVLastItemsFillColumns(DGVLastItems);
            DGVLastItems.Columns[0].Visible = false;

            Controls.Add(DGVLastItems);
        }

        private void DTVLastItemsFillColumns(DataGridView gridView)
        {
            var query = from i in DBconnection.DBCONNECTION.Item
                        join c in DBconnection.DBCONNECTION.Category on i.id_category equals c.id_category
                        select new
                        {
                            id = i.id_item,
                            name = i.name,
                            category_name = c.name,
                            creation_date = i.creation_date
                        };

            foreach (var item in query.OrderByDescending(X => X.creation_date))
            {
                gridView.Rows.Add(item.id, item.name, item.category_name);
            }
        }

        private void DTVLastItemsAddColumns(DataGridView gridView)
        {
            for (int i = 0; i < LASTITEMSCOLUMNS.Length / 2; i++)
            {
                gridView.Columns.Add(LASTITEMSCOLUMNS[i, 0], LASTITEMSCOLUMNS[i, 1]);
            }
        }

        private void DTVLastItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var cos = DGVLastItems.Rows[e.RowIndex].Cells[0].Value;
            var name = from items in DBconnection.DBCONNECTION.Item
                       where items.id_item.ToString() == cos.ToString()
                       select new { Name = items.name} ;
            MessageBox.Show(name.ToList().First().Name);
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
        }

        private void DGVMainDataChangeVisable(object sender, EventArgs e)
        {
            DGVMainData.Visible = true;
        }

        private void DGVItemsView(object sender, EventArgs e)
        {
            DGVMainData.Rows.Clear();
            DGVMainData.Columns.Clear();
            string[,] Columns = {
                { "id", "ID" },
                { "name", "Nazwa" },
                { "category", "Kategoria" },
                { "status", "Status" },
                { "rooms", "Pokój" },
                { "wardrobe", "Szafa" },
                { "shelf", "Szuflada" },
            };
            for (int i = 0; i < Columns.Length / 2; i++)
            {
                DGVMainData.Columns.Add(Columns[i, 0], Columns[i, 1]);
            }

            var query = from item in DBconnection.DBCONNECTION.Item
                        join category in DBconnection.DBCONNECTION.Category on item.id_category equals category.id_category
                        join status in DBconnection.DBCONNECTION.Status on item.id_status equals status.id_status
                        join shelf in DBconnection.DBCONNECTION.Shelf on item.id_shelf equals shelf.id_shelf
                        join wardorobe in DBconnection.DBCONNECTION.Wardrobe on shelf.id_wardrobe equals wardorobe.id_wardrobe
                        join room in DBconnection.DBCONNECTION.Room on wardorobe.id_room equals room.id_room
                        select new
                        {
                            id = item.id_item,
                            name = item.name,
                            category_name = category.name,
                            status = status.name,
                            room = room.name,
                            wardorobe = wardorobe.name,
                            shelf = shelf.location
                        };
            foreach (var item in query)
            {
                DGVMainData.Rows.Add(item.id, item.name, item.category_name, item.status,
                    item.room, item.wardorobe, Int32.Parse(item.shelf)+1);
            }

            DGVMainData.Columns[0].Visible = false;
        }

        private void DGVRoomsView(object sender, EventArgs e)
        {
            DGVMainData.Rows.Clear();
            DGVMainData.Columns.Clear();
            string[,] Columns = {
                { "id", "ID" },
                { "name", "Nazwa" }
            };
            for (int i = 0; i < Columns.Length / 2; i++)
            {
                DGVMainData.Columns.Add(Columns[i, 0], Columns[i, 1]);
            }

            var query = from room in DBconnection.DBCONNECTION.Room
                        select new
                        {
                            id = room.id_room,
                            name = room.name,
                        };
            foreach (var item in query)
            {
                DGVMainData.Rows.Add(item.id, item.name);
            }

            DGVMainData.Columns[0].Visible = false;
        }

        private void DGVStatusView(object sender, EventArgs e)
        {
            DGVMainData.Rows.Clear();
            DGVMainData.Columns.Clear();
            string[,] Columns = {
                { "id", "ID" },
                { "name", "Nazwa" },
                { "itemsCount", "Ilość rzeczy" }
            };
            for (int i = 0; i < Columns.Length / 2; i++)
            {
                DGVMainData.Columns.Add(Columns[i, 0], Columns[i, 1]);
            }

            var query = from status in DBconnection.DBCONNECTION.Status
                        select new
                        {
                            id = status.id_status,
                            name = status.name,
                            itemsCount = DBconnection.DBCONNECTION.Item.Where(x => x.id_status == status.id_status).Count()
                        };
            foreach (var item in query)
            {
                DGVMainData.Rows.Add(item.id, item.name, item.itemsCount);
            }

            DGVMainData.Columns[0].Visible = false;
        }

        private void DGVCategoriesView(object sender, EventArgs e)
        {
            DGVMainData.Rows.Clear();
            DGVMainData.Columns.Clear();
            string[,] Columns = {
                { "id", "ID" },
                { "name", "Nazwa" },
                { "itemsCount", "Ilość rzeczy" }
            };
            for (int i = 0; i < Columns.Length / 2; i++)
            {
                DGVMainData.Columns.Add(Columns[i, 0], Columns[i, 1]);
            }

            var query = from category in DBconnection.DBCONNECTION.Category
                        select new
                        {
                            id = category.id_category,
                            name = category.name,
                            itemsCount = DBconnection.DBCONNECTION.Item.Where(x => x.id_category == category.id_category).Count()
                        };

            foreach (var item in query)
            {
                DGVMainData.Rows.Add(item.id, item.name, item.itemsCount);
            }

            DGVMainData.Columns[0].Visible = false;
        }

        private void DGVWardrobesView(object sender, EventArgs e)
        {
            DGVMainData.Rows.Clear();
            DGVMainData.Columns.Clear();
            string[,] Columns = {
                { "id", "ID" },
                { "name", "Nazwa" },
                { "room", "Pokój" },
                { "shelfCount", "Ilość półek" }
            };
            for (int i = 0; i < Columns.Length / 2; i++)
            {
                DGVMainData.Columns.Add(Columns[i, 0], Columns[i, 1]);
            }

            var query = from wardrobe in DBconnection.DBCONNECTION.Wardrobe
                        join room in DBconnection.DBCONNECTION.Room on wardrobe.id_room equals room.id_room
                        select new
                        {
                            id = wardrobe.id_wardrobe,
                            name = wardrobe.name,
                            room = room.name,
                            shelfCount = DBconnection.DBCONNECTION.Shelf.Where(x => x.id_wardrobe == wardrobe.id_wardrobe).Count()
                        };

            foreach (var item in query)
            {
                DGVMainData.Rows.Add(item.id, item.name, item.room, item.shelfCount);
            }

            DGVMainData.Columns[0].Visible = false;
        }
    }
}
