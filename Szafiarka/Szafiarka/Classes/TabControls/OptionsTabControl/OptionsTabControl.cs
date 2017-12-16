using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Szafiarka.Classes
{
    class OptionsTabControl: TabControl
    {
        List<OptionsTabPages> tabPagesList;
        public OptionsTabControl()
        {
            this.Size = new Size(1000, 647);//(900, 582);
            this.Location = new Point(0,0);//(50, 32);     //testowy rozmiar i lokalizacja
            this.Name = "OptionsTabControl";
            this.SizeMode = TabSizeMode.Fixed;
            this.ItemSize = new Size((1000/4)-1, 20);

            InitializeTabControls();


        }

        private void InitializeTabControls()
        {
             tabPagesList = new List<OptionsTabPages> {
                new AboutProgramTabPage(),
                new AppearanceTabPage(),
                new BackupTabPage(),
                new ContactTabPage()
            };

            foreach (var tabPage in tabPagesList)
            {
                Controls.Add(tabPage);
            };
        }
    }
}
