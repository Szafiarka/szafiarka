using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szafiarka.Classes
{
    public class ColoredProgressBar : ProgressBar
    {
        public enum ProgressBarDisplayText
        {
            Percentage,
            CustomText
        }

        Brush colorBar;
        bool text;
        //Property to set to decide whether to print a % or Text
        public ProgressBarDisplayText DisplayStyle { get; set; }

        //Property to hold the custom text
        public String CustomText { get; set; }
        public ColoredProgressBar(Brush color, bool textB = true)
        {
            text = textB;
            colorBar = color;
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rec = e.ClipRectangle;

            rec.Width = (int)(rec.Width * ((double)Value / Maximum));
            if (ProgressBarRenderer.IsSupported)
                ProgressBarRenderer.DrawHorizontalBar(e.Graphics, e.ClipRectangle);
            rec.Height = rec.Height;
            e.Graphics.FillRectangle(colorBar, 0, 0, rec.Width, rec.Height);

            if (text)
            {
                string text = DisplayStyle == ProgressBarDisplayText.Percentage ? Value.ToString() + '%' : CustomText;


                using (Font f = new Font(FontFamily.GenericSerif, 10))
                {

                    SizeF len = e.Graphics.MeasureString(text, f);
                    // Calculate the location of the text (the middle of progress bar)
                    // Point location = new Point(Convert.ToInt32((rect.Width / 2) - (len.Width / 2)), Convert.ToInt32((rect.Height / 2) - (len.Height / 2)));
                    Point location = new Point(Convert.ToInt32((Width / 2) - len.Width / 2), Convert.ToInt32((Height / 2) - len.Height / 2));
                    // The commented-out code will centre the text into the highlighted area only. This will centre the text regardless of the highlighted area.
                    // Draw the custom text
                    e.Graphics.DrawString(text, f, Brushes.Black, location);
                }
            }
        }
    }
}
