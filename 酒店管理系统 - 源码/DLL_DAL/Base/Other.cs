using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TModel;
using System.Windows.Media.Imaging;
using System.IO;
using System.Data;

namespace DLL_DAL
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

        /// <summary>
        /// 将图片地址转换成可以保存到数据库的二进制流，参数1：文件路径，参数2：参数名（不带@符号）
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static SqlParameter ImageToSqlParameter(string uri, string name)
        {
            FileStream mystream;
            if (uri != null)
                mystream = new FileStream(uri, FileMode.Open, FileAccess.Read);
            else mystream = new FileStream("Default.jpg", FileMode.Open, FileAccess.Read);
            long len = mystream.Length;
            SqlParameter s = new SqlParameter("@"+name, SqlDbType.Image, (int)len);
            s.Direction = System.Data.ParameterDirection.Input;
            byte[] box = new byte[len];
            mystream.Read(box, 0, (int)len);

            //mycmd.Parameters["@a"].Value = box;
            s.Value = box;
            return s;
        }
    }
}
