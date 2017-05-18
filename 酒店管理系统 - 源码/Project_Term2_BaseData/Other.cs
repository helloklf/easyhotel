using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Project_Term2_BaseData
{
    public class Other
    {
        public static BitmapImage GetImage(byte[] img)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream(img);//img是从数据库中读取出来的字节数组
            ms.Seek(0, System.IO.SeekOrigin.Begin);
            BitmapImage newBitmapImage = new BitmapImage();
            newBitmapImage.BeginInit();
            newBitmapImage.StreamSource = ms;
            newBitmapImage.EndInit();
            return newBitmapImage;
        }
    }
}
