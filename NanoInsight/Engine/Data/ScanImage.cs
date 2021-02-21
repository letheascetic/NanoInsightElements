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
    /// 扫描图像数据
    /// </summary>
    public class ScanImage
    {
        private int sliceIndex;
        private int numOfBank;
        private Mat matImage;
        private ScanBank[] banks;

        /// <summary>
        /// 切片索引
        /// </summary>
        public int SliceIndex
        {
            get { return sliceIndex; }
            set { sliceIndex = value; }
        }

        /// <summary>
        /// 扫描图像
        /// </summary>
        public Mat Image
        {
            get { return matImage; }
            set { matImage = value; }
        }
        /// <summary>
        /// 扫描图像块
        /// </summary>
        public ScanBank[] Banks
        {
            get { return banks; }
            set { banks = value; }
        }
        /// <summary>
        /// 扫描图像块的数量
        /// </summary>
        public int NumOfBank
        {
            get { return numOfBank; }
            set { numOfBank = value; }
        }

        public ScanImage(int rows, int columns, DepthType type, int channels, int numOfBank, int sliceIndex)
        {
            if (rows % numOfBank != 0)
            {
                throw new ArgumentException(string.Format("Rows[{0}] % NumOfBank[{1}] != 0", rows, numOfBank));
            }

            SliceIndex = sliceIndex;
            NumOfBank = numOfBank;
            Image = new Mat(rows, columns, type, channels);

            int rowIndex;
            int rowsOfBank = rows / NumOfBank;
            Banks = new ScanBank[NumOfBank];
            for (int i = 0; i < NumOfBank; i++)
            {
                rowIndex = i * rowsOfBank;
                Banks[i] = new ScanBank(rowsOfBank, columns, type, channels, Image.Row(rowIndex).DataPointer, Image.Step, i);
            }
        }

        public void Dispose()
        {
            Image.Dispose();
        }

    }
}
