using System.Drawing;
using System.IO;

namespace Szafiarka.Classes
{
    public static class ImageDataBase
    {
        private static double maxX = 400;
        private static double maxY = 600;
        public static Bitmap chnageImageSize(Bitmap image)
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


    public static class ImageConverter
    {

        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public static Image dbImgaeToImage(System.Data.Linq.Binary image)
        {
            byte[] b = image.ToArray();
            MemoryStream ms = new MemoryStream(b);
            Image img = Image.FromStream(ms);

            return img;
        }
    }
}
