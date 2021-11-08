using Justec.Alcohol.Pulse.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justec.Alcohol.Pulse.Classes
{
    public class FrmHelper
    {
        /// <summary>
        /// 十六进制字符串转换为图片
        /// </summary>
        /// <param name="imageStr">十六进制字符串</param>
        /// <returns>图片</returns>
        public static Image GetImage(string imageStr)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(imageStr))
                {
                    byte[] buffer = JustecPort.ToHexBytes(imageStr);
                    MemoryStream stream = new MemoryStream(buffer);
                    Image image;
                    image = Image.FromStream(stream, true);
                    return image;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteErrorLog("图片转换GetImage()方法错误: " + ex.Message + "\r\n 转换字符串：" + imageStr);
                return null;
            }
        }
    }
}
