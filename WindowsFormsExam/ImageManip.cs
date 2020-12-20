using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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

            ms.Close();
            return img;
        }

        public static byte[] PhotoSliderToByteArray(byte[][] sliderArr)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(ms, sliderArr);

            ms.Close();
            return ms.ToArray();
        }

        public static byte[][] ByteArrToPhotoSlider(byte[] arr)
        {
            MemoryStream ms = new MemoryStream(arr);
            BinaryFormatter formatter = new BinaryFormatter();
            byte[][] slider = (byte[][])formatter.Deserialize(ms);

            ms.Close();
            return slider;
        }
    }
}
