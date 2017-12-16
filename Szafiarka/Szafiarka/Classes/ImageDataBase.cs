using System.Drawing;

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
}
