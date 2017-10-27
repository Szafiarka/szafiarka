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
            InitializeComponent();
            Thread splashThread = new Thread(new ThreadStart(SplashscreenStart));
            splashThread.Start();
            Thread.Sleep(3000);
            var assemblyData = new RetrievingAssemblyData();
            splashThread.Abort();
            //InitializeComponent(assemblyData);
        }

        private void SplashscreenStart()
        {
            var splashForm = new Splashscreen();
            splashForm.BackColor = BackColor;
            Application.Run(splashForm);
        }

        private void pMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
