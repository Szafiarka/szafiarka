using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Szafiarka.Classes.MapDB;

namespace Szafiarka.Forms.AddAttribiutes
{
    public partial class Common : Form
    {
        protected Queries queries = new Queries();
        protected ComboBox combobox;
        public Common()
        {
            InitializeComponent();
        }

        protected virtual void save_Click(object sender, EventArgs e)
        {

        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
