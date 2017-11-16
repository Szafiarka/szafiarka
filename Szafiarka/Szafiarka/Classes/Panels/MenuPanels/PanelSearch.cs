using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szafiarka.Classes
{
    class PanelSearch : Panels
    {

        public PanelSearch()
        {
            Name = "pSearch";
            BackColor = System.Drawing.Color.FromArgb(0, 50, 0);
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }
}
