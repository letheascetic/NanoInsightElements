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
        private int bankIndex;
        private Mat bank;

        /// <summary>
        /// 子图像数据
        /// </summary>
        public Mat Bank
        {
            get { return bank; }
            set { bank = value; }
        }

        /// <summary>
        /// 子图像在图像中的索引号
        /// </summary>
        public int BankIndex
        {
            get { return bankIndex; }
            set { bankIndex = value; }
        }

        public int RowIndex
        {
            get { return BankIndex * Bank.Rows; }
        }

        public ScanBank(int rows, int columns, DepthType type, int channels, IntPtr data, int step, int bankIndex)
        {
            Bank = new Mat(rows, columns, type, channels, data, step);
            BankIndex = bankIndex;
        }

        public ScanBank(int rows, int columns, DepthType type, int channels)
        {
            Bank = new Mat(rows, columns, type, channels);
            BankIndex = -1;
        }
    }



}
