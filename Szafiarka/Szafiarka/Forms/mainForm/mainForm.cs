using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Szafiarka.Classes;
using System.Threading;
using Szafiarka.Forms.Splashscreen;
using Szafiarka.Forms.ItemForm;

namespace Szafiarka
{
    public partial class MainForm : Form
    {
        Utils utils;

        #region Menu Button Properties
        private static string PATHTOSTART = "..\\..\\images\\menuButtons\\home.png";
        private static string PATHTOSEARCH = "..\\..\\images\\menuButtons\\search.png";
        private static string PATHTOADD = "..\\..\\images\\menuButtons\\add.png";
        private static string PATHTOEDIT = "..\\..\\images\\menuButtons\\edit.png";
        private static string PATHTODELETE = "..\\..\\images\\menuButtons\\delete.png";
        private static string PATHTOBIN = "..\\..\\images\\menuButtons\\bin.png";
        private static string PATHTOEXIT = "..\\..\\images\\menuButtons\\exit.png";

        private enum buttonsNames
        {
            [Description("Start")]
            home,
            [Description("Wyszukaj")]
            search,
            [Description("Dodaj")]
            add,
            [Description("Edytuj")]
            edit,
            [Description("Usuń")]
            delete,
            [Description("Kosz")]
            bin,
            [Description("Wyjście")]
            exit
        }

        private static object[,] MENUBUTTONSNAMES = {
            { buttonsNames.home, PATHTOSTART },
            { buttonsNames.search, PATHTOSEARCH},
            { buttonsNames.add, PATHTOADD},
            { buttonsNames.edit,  PATHTOEDIT},
            { buttonsNames.delete, PATHTODELETE},
            { buttonsNames.bin, PATHTOBIN},
            { buttonsNames.exit, PATHTOEXIT}
        };

        private enum Messages
        {
            [Description("Nie wybrałeś elementu do usunięcia")]
            DELETE,
            [Description("Nie wybrałeś elementu do edycji")]
            EDIT,
        }
        #endregion
        #region Menu Panels Properties
        private static List<Panels> PanelsList;
        private enum PanelsName
        {
            PSTART, PSEARCH
        };
        #endregion


        public MainForm()
        {
            Thread splashThread = new Thread(new ThreadStart(SplashscreenStart));
            splashThread.Start();
            Thread.Sleep(3000);
            var assemblyData = new RetrievingAssemblyData();
            utils = new Utils();
            InitializeComponent(assemblyData);
            splashThread.Abort();
        }

        public void SplashscreenStart()
        {
            Application.Run(new Splashscreen());
        }

        #region Menu Buttons
        private void selectAndAddEvent(ref MenuButton button)
        {
            if (button.Name == buttonsNames.exit.ToString())
            {
                button.Click += new EventHandler(exit_Click);
            }
            if (button.Name == buttonsNames.home.ToString())
            {
                button.Click += new EventHandler(start_Click);
            }
            if (button.Name == buttonsNames.add.ToString())
            {
                button.Click += new EventHandler(add_Click);
            }
            if (button.Name == buttonsNames.search.ToString())
            {
                button.Click += new EventHandler(search_Click);
            }
            if (button.Name == buttonsNames.edit.ToString())
            {
                button.Click += new EventHandler(edit_Click);
            }
            if (button.Name == buttonsNames.delete.ToString())
            {
                button.Click += new EventHandler(delete_Click);
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            var form = new ItemForm();
            form.ShowDialog();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            MessageBox.Show(utils.GetEnumDescription(Messages.DELETE), "Warrning");
        }

        private void edit_Click(object sender, EventArgs e)
        {
            MessageBox.Show(utils.GetEnumDescription(Messages.EDIT), "Warrning");
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void search_Click(object sender, EventArgs e)
        {
            utils.changePanelsVisableToFalse(PanelsList);
            utils.changePanelVisableToTrue(PanelsList, PanelsName.PSEARCH);
        }

        private void start_Click(object sender, EventArgs e)
        {
            utils.changePanelsVisableToFalse(PanelsList);
            utils.changePanelVisableToTrue(PanelsList, PanelsName.PSTART);
        }
        #endregion
    }
}