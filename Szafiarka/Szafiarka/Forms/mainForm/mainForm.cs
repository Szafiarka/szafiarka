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

namespace Szafiarka
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            var assemblyData = new RetrievingAssemblyData();
            InitializeComponent();
            //InitializeComponent(assemblyData);
        }
    }
}
