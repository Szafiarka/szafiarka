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
        private Dictionary<TabPage, Color> TabColors = new Dictionary<TabPage, Color>();
        public OptionsTabControl()
        {
            this.Size = new Size(1000, 647);//(900, 582);
            this.Location = new Point(0,0);//(50, 32);     //testowy rozmiar i lokalizacja
            this.Name = "OptionsTabControl";
            this.SizeMode = TabSizeMode.Fixed;
            this.ItemSize = new Size((1000/3)-1, 35);
            InitializeTabControls();
            this.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.DrawItem += new DrawItemEventHandler(this.OptionsTabControl_DrawItem);
        }

        private void OptionsTabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            Font headerFontStyle = new Font("Arial", 14, FontStyle.Bold);
            var headerFontColor = new SolidBrush(Color.FromArgb(255, 0, 0, 64));

            using (Brush br = new SolidBrush(TabColors[this.TabPages[e.Index]]))
            {
                e.Graphics.FillRectangle(br, e.Bounds);
                SizeF sz = e.Graphics.MeasureString(this.TabPages[e.Index].Text, headerFontStyle);
                e.Graphics.DrawString(this.TabPages[e.Index].Text, headerFontStyle, headerFontColor, e.Bounds.Left + (e.Bounds.Width - sz.Width) / 2, e.Bounds.Top + (e.Bounds.Height - sz.Height) / 2 + 1);

                Rectangle rect = e.Bounds;
                rect.Offset(0, 1);
                rect.Inflate(0, -1);
                e.Graphics.DrawRectangle(Pens.DarkGray, rect);
                e.DrawFocusRectangle();
            }
        }

        private void InitializeTabControls()
        {
             tabPagesList = new List<OptionsTabPages> {
                new AboutProgramTabPage(),
                new AppearanceTabPage(),
                new ContactTabPage()
            };

            foreach (var tabPage in tabPagesList)
            {
                SetTabHeader(tabPage, Color.FromArgb(1, 168, 204));
                Controls.Add(tabPage);
            };
        }

        private void SetTabHeader(TabPage page, Color color)
        {
            TabColors[page] = color;
            this.Invalidate();
        }
    }
}
