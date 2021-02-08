using Emgu.CV;
using Emgu.CV.CvEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Engine.Data
{
    /// <summary>
    /// 扫描子图像数据
    /// </summary>
    public class ScanBank
    {
        private int index;
        private Matrix<DepthType> bank;

        /// <summary>
        /// 子图像数据
        /// </summary>
        public Matrix<DepthType> Bank
        {
            get { return bank; }
            set { bank = value; }
        }

        /// <summary>
        /// 子图像在图像中的索引号
        /// </summary>
        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        public ScanBank(int rows, int columns, int channels, IntPtr data, int step, int index)
        {
            Bank = new Matrix<DepthType>(rows, columns, channels, data, step);
            Index = index;
        }

    }
}
