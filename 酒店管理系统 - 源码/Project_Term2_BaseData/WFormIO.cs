using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Term2_BaseData
{
    /// <summary>
    /// 该类中主要包含了关于WinForm相关的操作，所需的方法或对象
    /// </summary>
    public class WFormIO
    {
        /// <summary>
        /// 用于选择图片文件的基本方法，它会返回一个完整的文件路径（如：在为主窗口设置背景时使用）
        /// </summary>
        /// <returns></returns>
        public static string SelectImage()
        {
            OpenFileDialog OF = new OpenFileDialog(); OF.Filter = "图片文件|*.jpg;*.png;*.bmp;*.gif;*.jpeg";
            if (OF.ShowDialog() == DialogResult.OK)
                return OF.FileName;
            else return null;
        }

    }
}
