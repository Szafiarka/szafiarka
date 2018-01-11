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
    class PanelStart : Panels, IPanels
    {
        private DataGridViewNew DGVLastItems;
        private DataGridViewNew DGVMainData;
        private static int DGVHeight = 600;
        private static int LocationHeightStart = 50;
        private static int DGVMainWidth = 720;
        private MapDB.Queries queries;

        private FlatButton oldButton;

        private enum buttonsNames
        {
            rooms, wardrobes, items, status, categories
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
                Text = Utils.GetEnumDescription(rightLabelsNames.lastItems)
            };

            var label2 = new LabelRightPanelStartPanel
            {
                Location = new Point(Width - 300, 360),
                Text = Utils.GetEnumDescription(rightLabelsNames.mostOccupancy)
            };

            Controls.Add(label);
            Controls.Add(label2);
        }

        private void InitalizeDataGrids()
        {
            var sizeWidth = 300;
            DGVLastItems = new DataGridViewNew();
            DGVLastItems.Location = new Point(Width - sizeWidth, LocationHeightStart);
            DGVLastItems.setName(DataGridViewNew.DGVMainDataNames.lastItems.ToString());
            DGVLastItems.Size = new Size(sizeWidth, DGVHeight-(DGVHeight/2));
            DTVLastItemsFillColumns();

            Controls.Add(DGVLastItems);

            DGVMainData = new DataGridViewNew();
            DGVMainData.Location = new Point(0, LocationHeightStart);
            DGVMainData.Size = new Size(DGVMainWidth, DGVHeight);
            DGVMainData.Visible = false;

            Controls.Add(DGVMainData);
        }

        private void DTVLastItemsFillColumns()
        {
            string [,] columns = {
                { "id", "ID" },
                { "name", "Nazwa" },
                { "category", "Kategoria" },
                { "date", "Dni temu" }
            };
            DGVLastItems.AddColumns(columns);
            var query = queries.getGridViewLastItems();

            foreach (var item in query.OrderByDescending(X => X.modify_date).Take(7))
            {
                var calculatedDays = Utils.compareDateToNowAndGetDaysCount((DateTime)item.modify_date);
                DGVLastItems.Rows.Add(item.id, item.name, item.category, calculatedDays);
            }
            DGVLastItems.changeIdColumnVisableToFalse();
        }
        
        private void addEventToButton(Button button)
        {

            button.Click += new EventHandler(selectFillDGVMainData);
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

        private void selectFillDGVMainData(object sender, EventArgs e)
        {
            var button = sender as FlatButton;
            if (button.Name.ToUpper() == buttonsNames.items.ToString().ToUpper())
            {
                DGVItemsView();
            }
            if (button.Name.ToUpper() == buttonsNames.rooms.ToString().ToUpper())
            {
                DGVRoomsView();
            }
            if (button.Name.ToUpper() == buttonsNames.status.ToString().ToUpper())
            {
                DGVStatusView();
            }
            if (button.Name.ToUpper() == buttonsNames.categories.ToString().ToUpper())
            {
                DGVCategoriesView();
            }
            if (button.Name.ToUpper() == buttonsNames.wardrobes.ToString().ToUpper())
            {
                DGVWardrobesView();
            }
        }

        #region Add DGV Views
        private void DGVItemsView()
        {
            DGVMainData.setName(DataGridViewNew.DGVMainDataNames.items.ToString());
            string[,] columns = {
                { "id", "ID" },
                { "name", "Nazwa" },
                { "category", "Kategoria" },
                { "status", "Status" },
                { "room", "Pokój" },
                { "wardrobe", "Szafa" },
                { "shelf", "Półka" },
            };
            DGVMainData.AddColumns(columns);

            var query = queries.getGridViewItem();

            foreach (var item in query)
            {

                DGVMainData.Rows.Add(item.id, item.name, item.category, item.status,
                    item.room, item.wardorobe, item.shelf);
            }

            DGVMainData.changeIdColumnVisableToFalse();
        }

        private void DGVRoomsView()
        {
            DGVMainData.setName(DataGridViewNew.DGVMainDataNames.nameCleared.ToString());
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

        private void DGVStatusView()
        {
            DGVMainData.setName(DataGridViewNew.DGVMainDataNames.nameCleared.ToString());
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

        private void DGVCategoriesView()
        {
            DGVMainData.setName(DataGridViewNew.DGVMainDataNames.categories.ToString());
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

        private void DGVWardrobesView()
        {
            DGVMainData.setName(DataGridViewNew.DGVMainDataNames.nameCleared.ToString());
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

        public void refreashGrid()
        {
            DTVLastItemsFillColumns();
            if (DGVMainData.Name == DataGridViewNew.DGVMainDataNames.items.ToString())
            {
                DGVItemsView();
            }
        }

        public string getGridViewName()
        {
            return DGVMainData.Name;
        }

        public DataGridViewRow getGridViewItemRow()
        {
            return DGVMainData.CurrentRow;
        }
    }
}
