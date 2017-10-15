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
    public partial class Form1 : Form
    {
        public Form1()
        {
            MapDBDataContext bazaDC = new MapDBDataContext(); //polaczenie do bazy
            InitializeComponent();
        }
    }
}
