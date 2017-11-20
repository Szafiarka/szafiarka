using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
        private Utils utils = new Utils();

        private FlatButton oldButton;

        private enum buttonsNames
        {
            rooms, wardrobes, items, status, categories
        }

        private enum DGVMainDataNames
        {
            categories, items, nameCleared
        }

        private enum rightLabelsNames
        {
            [Description("Ostatnio zmodyfikowane")]
            lastItems,
            [Description("Najbardziej zajęte")]
            mostOccupancy,
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
            { "category", "Kategoria" },
            { "date", "Data" }
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
            InitializeMainPanel();
            InitializeRightPanel();
            ResumeLayout(false);
        }

        private void InitializeRightPanel()
        {
            InitializeRightPanelLabels();
            IntializeProgressBars();
        }

        private void InitializeMainPanel()
        {
            InitalizeDataGrids();
            InitializeObjectsButtons();
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

        private void InitializeRightPanelLabels()
        {
            var label = new LabelRightPanelStartPanel
            {
                Location = new Point(Width - 300, 0),
                Text = utils.GetEnumDescription(rightLabelsNames.lastItems)
            };

            var label2 = new LabelRightPanelStartPanel
            {
                Location = new Point(Width - 300, 360),
                Text = utils.GetEnumDescription(rightLabelsNames.mostOccupancy)
            };

            Controls.Add(label);
            Controls.Add(label2);
        }

        private void InitalizeDataGrids()
        {
            var sizeWidth = 300;
            DGVLastItems = new DataGridViewStartPanel();
            DGVLastItems.Location = new Point(Width - sizeWidth, LocationHeightStart);
            DGVLastItems.Name = "DTVLastItems";
            DGVLastItems.Size = new Size(sizeWidth, DGVHeight-(DGVHeight/2));
            DTVLastItemsFillColumns(DGVLastItems);

            Controls.Add(DGVLastItems);

            DGVMainData = new DataGridViewStartPanel();
            DGVMainData.Location = new Point(0, LocationHeightStart);
            DGVMainData.Size = new Size(DGVMainWidth, DGVHeight);
            DGVMainData.CellDoubleClick += DTVLastItems_CellDoubleClick;
            DGVMainData.Visible = false;
            DGVMainData.CellFormatting += new DataGridViewCellFormattingEventHandler(getDescriptionCellFormatting);

            Controls.Add(DGVMainData);
        }

        private void DTVLastItemsFillColumns(DataGridViewStartPanel gridView)
        {
            gridView.clearRowsAndColumns();
            gridView.AddColumns(LASTITEMSCOLUMNS);
            var query = queries.getGridViewLastItems();

            foreach (var item in query.OrderByDescending(X => X.modify_date))
            {
                gridView.Rows.Add(item.id, item.name, item.category, item.modify_date);
            }
            DGVLastItems.changeIdColumnVisableToFalse();
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
        #region Add DGV Views
        private void DGVItemsView(object sender, EventArgs e)
        {
            DGVMainData.clearRowsAndColumns();
            DGVMainData.setName(DGVMainDataNames.items.ToString());
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

            var query = queries.getGridViewItem();

            foreach (var item in query)
            {

                DGVMainData.Rows.Add(item.id, item.name, item.category, item.status,
                    item.room, item.wardorobe, Int32.Parse(item.shelf)+1);
            }

            DGVMainData.changeIdColumnVisableToFalse();
        }

        private void DGVRoomsView(object sender, EventArgs e)
        {
            DGVMainData.clearRowsAndColumns();
            DGVMainData.setName(DGVMainDataNames.nameCleared.ToString());
            string[,] columns = {
                { "id", "ID" },
                { "name", "Nazwa" },
                { "wardrobesCount", "Ilość szaf" },
            };
            DGVMainData.AddColumns(columns);

            var query = queries.getGridViewRoom();
            foreach (var item in query)
            {
                DGVMainData.Rows.Add(item.id, item.name, item.wardrobesCount);
            }

            DGVMainData.changeIdColumnVisableToFalse();
        }

        private void DGVStatusView(object sender, EventArgs e)
        {
            DGVMainData.clearRowsAndColumns();
            DGVMainData.setName(DGVMainDataNames.nameCleared.ToString());
            string[,] columns = {
                { "id", "ID" },
                { "name", "Nazwa" },
                { "itemsCount", "Ilość rzeczy" }
            };
            DGVMainData.AddColumns(columns);

            var query = queries.getGridViewStatus();
            foreach (var item in query)
            {
                DGVMainData.Rows.Add(item.id, item.name, item.itemsCount);
            }

            DGVMainData.changeIdColumnVisableToFalse();
        }

        private void DGVCategoriesView(object sender, EventArgs e)
        {
            DGVMainData.clearRowsAndColumns();
            DGVMainData.setName(DGVMainDataNames.categories.ToString());
            string[,] columns = {
                { "id", "ID" },
                { "name", "Nazwa" },
                { "itemsCount", "Ilość rzeczy" }
            };
            DGVMainData.AddColumns(columns);

            var query = queries.getGridViewCategory();

            foreach (var item in query)
            {
                DGVMainData.Rows.Add(item.id, item.name, item.itemsCount);
            }
            DGVMainData.changeIdColumnVisableToFalse();
        }

        private void DGVWardrobesView(object sender, EventArgs e)
        {
            DGVMainData.clearRowsAndColumns();
            DGVMainData.setName(DGVMainDataNames.nameCleared.ToString());
            string[,] columns = {
                { "id", "ID" },
                { "name", "Nazwa" },
                { "room", "Pokój" },
                { "shelfCount", "Ilość półek" },
                { "mostCategory", "Najpopularniejsza kategoria" }
            };
            DGVMainData.AddColumns(columns);

            var query = queries.getGridViewWardrobe();

            foreach (var item in query)
            {
                DGVMainData.Rows.Add(item.id, item.name, item.room, item.shelfCount, item.mostCategory);
            }

            DGVMainData.changeIdColumnVisableToFalse();
        }
        #endregion
        private void IntializeProgressBars()
        {
            var query = queries.getWardrobesCapacity();
            var space = 0;
            foreach (var item in query.OrderByDescending(x => (x.capacity / x.capacity_wardrobe) * 100).Take(4))
            {
                addProgressBar(item, space);
                space++;
            }
        }

        private void addProgressBar(MapDB.ResulWardrobesOccupancy item, int space)
        {
            var label = new Label();;
            var progressBar = new ColoredProgressBar(new SolidBrush(Color.FromArgb(127, 195, 28)));

            label.Location = new Point(Width - 300, 400 + space * 60);
            label.Text = String.Format("{0} {1}",item.wardrobe.Room.name, item.wardrobe.name);
            label.ForeColor = Color.White;

            progressBar.Location = new Point(Width - 300, 425 + space * 60);
            progressBar.Size = new Size(300, 20);
            if (item.capacity > 0 )
                progressBar.Value = (int)((item.capacity / item.capacity_wardrobe) * 100);            
            else
                progressBar.Value = 0;

            Controls.Add(label);
            Controls.Add(progressBar);
        }

        private void getDescriptionCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
    }
}
