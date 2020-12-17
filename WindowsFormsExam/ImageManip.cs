using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsExam
{
    public static class ImageManip
    {
        public static Image ResizeImage(Image img, Size size)
        {
            return new Bitmap(img, size);
        }

        public static byte[] ImageToByteArray(Image img)
        {
            ImageConverter converter = new ImageConverter();
            byte[] arr = (byte[])converter.ConvertTo(img, typeof(byte[]));

            return arr;
        }

        public static Image ByteArrayToImage(byte[] arr)
        {
            MemoryStream ms = new MemoryStream(arr);
            Image img = Image.FromStream(ms);
            return img;
        }
    }
}
