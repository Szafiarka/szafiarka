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

namespace Szafiarka.Forms.ItemForm
{
    public partial class ItemForm : Form
    {
        private static double maxX = 400;
        private static double maxY = 600;
        private Queries queries;
        private Bitmap oryginalImage;
        private Item item;

        public ItemForm()
        {
            InitializeComponent();
            queries = new Queries();
        }

        public ItemForm(int itemId)
        {
            InitializeComponent();
            queries = new Queries();
            getItem(itemId);
            fillForm();
        }

        private void flatButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files| *.jpg; *.jpeg; *.png";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                var image = new Bitmap(dialog.FileName);
                image = chnageImageSize(image);
                pictureBox1.Image = image;
                oryginalImage = image;
                pictureBox1.DoubleClick += new EventHandler(image_DoubleClick);
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

        private void image_DoubleClick(object sender, EventArgs e)
        {
            var image = sender as PictureBox;
            if (image.Image != null)
            {
                var form = new Form();
                form.ClientSize = oryginalImage.Size;
                form.BackgroundImage = oryginalImage;
                form.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                try
                {
                    form.Text = string.Format("{0} zdjęcie", item.name);
                }
                catch { }

                form.ShowDialog();
            }
        }

        private void getItem(int id)
        {
            var _item = queries.getItemById(id);
            item = _item;
        }

        private void fillForm()
        {
            this.textBox1.Text = item.name;
            this.checkBox1.Checked = item.deleted ? false : true;
        }
    }
}
