using Emgu.CV;
using NanoInsight.Engine.Common;
using NumSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Engine.Data
{
    public class ScanData
    {
        /// <summary>
        /// 原始数据
        /// </summary>
        public ScanImage[][] OriginDataSet { get; set; }
        /// <summary>
        /// 原始图像
        /// </summary>
        public ScanImage[][] OriginImages { get; set; }
        /// <summary>
        /// 灰度图像
        /// </summary>
        public ScanImage[][] GrayImages { get; set; }
        /// <summary>
        /// 三通道灰度图像
        /// </summary>
        // public ScanImage[][] Gray3Images { get; set; }
        /// <summary>
        /// BGR彩色图像
        /// </summary>
        public ScanImage[][] BGRImages { get; set; }

        public ScanData(int rows, int columns, int numOfBank, int numOfChannels, int numOfSlices, bool[] statusOfChannels)
        {
            OriginDataSet = new ScanImage[numOfChannels][];
            OriginImages = new ScanImage[numOfChannels][];
            GrayImages = new ScanImage[numOfChannels][];
            // Gray3Images = new ScanImage[numOfChannels][];
            BGRImages = new ScanImage[numOfChannels][];
            for (int i = 0; i < numOfChannels; i++)
            {
                if (statusOfChannels[i])
                {
                    OriginDataSet[i] = new ScanImage[numOfSlices];
                    OriginImages[i] = new ScanImage[numOfSlices];
                    GrayImages[i] = new ScanImage[numOfSlices];
                    // Gray3Images[i] = new ScanImage[numOfSlices];
                    BGRImages[i] = new ScanImage[numOfSlices];
                    for (int j = 0; j < numOfSlices; j++)
                    {
                        OriginDataSet[i][j] = new ScanImage(rows, columns, Emgu.CV.CvEnum.DepthType.Cv32S, 1, numOfBank, j);
                        OriginImages[i][j] = new ScanImage(rows, columns, Emgu.CV.CvEnum.DepthType.Cv8U, 1, numOfBank, j);
                        GrayImages[i][j] = new ScanImage(rows, columns, Emgu.CV.CvEnum.DepthType.Cv8U, 1, numOfBank, j);
                        // Gray3Images[i][j] = new ScanImage(rows, columns, Emgu.CV.CvEnum.DepthType.Cv8U, 3, numOfBank, j);
                        BGRImages[i][j] = new ScanImage(rows, columns, Emgu.CV.CvEnum.DepthType.Cv8U, 3, numOfBank, j);
                    }
                }
                else
                {
                    OriginDataSet[i] = null;
                    OriginImages[i] = null;
                    GrayImages[i] = null;
                    // Gray3Images[i] = null;
                    BGRImages[i] = null;
                }
            }
        }

        /// <summary>
        /// 将Matrix数据矩阵更新到DataSet对应的bank
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="channelIndex"></param>
        /// <param name="sliceIndex"></param>
        /// <param name="bankIndex"></param>
        public void ToDataSet(NDArray matrix, int channelIndex, int sliceIndex, int bankIndex)
        {
            Mat datasetBank = OriginDataSet[channelIndex][sliceIndex].Banks[bankIndex].Bank;
            MatrixUtil.ToBankImage(matrix, ref datasetBank);
        }

        /// <summary>
        /// 将DataSet中指定的Bank转换成对应的OriginImage中的Bank
        /// </summary>
        /// <param name="scaleCoff"></param>
        /// <param name="channelIndex"></param>
        /// <param name="sliceIndex"></param>
        /// <param name="bankIndex"></param>
        /// <param name="offset"></param>
        public void ToOriginImages(int scaleCoff, int channelIndex, int sliceIndex, int bankIndex, int offset)
        {
            double scale = 1.0 / Math.Pow(2, scaleCoff);
            Mat originImageBank = OriginImages[channelIndex][sliceIndex].Banks[bankIndex].Bank;
            Mat datsetBank = OriginDataSet[channelIndex][sliceIndex].Banks[bankIndex].Bank;
            MatrixUtil.ToOriginImage(datsetBank, ref originImageBank, scale, offset);
        }

        /// <summary>
        /// 将DataSet中指定的图像数据集转换成OriginImages中对应的Image
        /// </summary>
        /// <param name="scaleCoff"></param>
        /// <param name="channelIndex"></param>
        /// <param name="sliceIndex"></param>
        /// <param name="offset"></param>
        public void ToOriginImages(int scaleCoff, int channelIndex, int sliceIndex, int offset)
        {
            double scale = 1.0 / Math.Pow(2, scaleCoff);
            Mat originImage = OriginImages[channelIndex][sliceIndex].Image;
            Mat dataset = OriginDataSet[channelIndex][sliceIndex].Image;
            MatrixUtil.ToOriginImage(dataset, ref originImage, scale, offset);
        }

        /// <summary>
        /// 将DataSet中指定通道的图像数据转换成OriginImages中对应的Image
        /// </summary>
        /// <param name="scaleCoff"></param>
        /// <param name="channelIndex"></param>
        /// <param name="offset"></param>
        public void ToOriginImages(int scaleCoff, int channelIndex, int offset)
        {
            for (int i = 0; i < OriginDataSet[channelIndex].Length; i++)
            {
                ToOriginImages(scaleCoff, channelIndex, i, offset);
            }
        }






    }
}
