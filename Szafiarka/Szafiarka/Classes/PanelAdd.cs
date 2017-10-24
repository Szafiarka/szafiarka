using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szafiarka.Classes
{
    public partial class PanelAdd : Component
    {
        public PanelAdd()
        {
            InitializeComponent();
        }

        public PanelAdd(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
