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
using Szafiarka.Classes.MapDB;

namespace Szafiarka.Forms.ItemForm
{
    public partial class ItemForm : Form
    {
        private static double maxX = 400;
        private static double maxY = 600;
        private Queries queries;
        public ItemForm()
        {
            InitializeComponent();
            queries = new Queries();
        }

        public ItemForm(int itemID)
        {
            queries = new Queries();
            InitializeComponent(itemID);
        }

        private void flatButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                var image = new Bitmap(dialog.FileName);
                image = chnageImageSize(image);
                pictureBox1.Image = image;
            }
        }

        private Bitmap chnageImageSize(Bitmap image)
        {
            double x = image.Size.Width;
            double y = image.Size.Height;
            double newX = 0;
            double newY = 0;
            if (x > maxX)
            {
                double xPro = maxX / x;
                newX = maxX;
                newY = y * xPro;
            }
            if (y > maxY)
            {
                double yPro = maxY / y;
                newY = maxY;
                newX = x * yPro;
            }
            var size = new Size((int)newX, (int)newY);

            return new Bitmap(image as Image, size);
        }
    }
}
