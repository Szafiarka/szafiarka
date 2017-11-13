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

namespace Szafiarka
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            Thread splashThread = new Thread(new ThreadStart(SplashscreenStart));
            splashThread.Start();
            Thread.Sleep(3000);
            var assemblyData = new RetrievingAssemblyData();
            InitializeComponent(assemblyData);
            splashThread.Abort();
        }

        public void SplashscreenStart()
        {
            Application.Run(new Splashscreen());
        }

        private void pMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
