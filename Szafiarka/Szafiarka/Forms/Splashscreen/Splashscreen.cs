using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szafiarka.Forms.Splashscreen
{
    public partial class Splashscreen : Form
    {
        public Splashscreen()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SplashscreenPrograssBar.Increment(5);
            if (SplashscreenPrograssBar.Value == 100)
            {
                splashTimer.Stop();
            }
        }
    }
}
