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
        public ScanImage[][] Gray3Images { get; set; }
        /// <summary>
        /// BGR彩色图像
        /// </summary>
        public ScanImage[][] BGRImages { get; set; }

        public ScanData(int rows, int columns, int numOfBank, int numOfChannels, int numOfSlices, bool[] statusOfChannels)
        {
            OriginImages = new ScanImage[numOfChannels][];
            GrayImages = new ScanImage[numOfChannels][];
            Gray3Images = new ScanImage[numOfChannels][];
            BGRImages = new ScanImage[numOfChannels][];
            for (int i = 0; i < numOfChannels; i++)
            {
                if (statusOfChannels[i])
                {
                    OriginImages[i] = new ScanImage[numOfSlices];
                    GrayImages[i] = new ScanImage[numOfSlices];
                    Gray3Images[i] = new ScanImage[numOfSlices];
                    BGRImages[i] = new ScanImage[numOfSlices];
                    for (int j = 0; j < numOfSlices; j++)
                    {
                        OriginImages[i][j] = new ScanImage(rows, columns, Emgu.CV.CvEnum.DepthType.Cv32S, 1, numOfBank, j);
                        GrayImages[i][j] = new ScanImage(rows, columns, Emgu.CV.CvEnum.DepthType.Cv8U, 1, numOfBank, j);
                        Gray3Images[i][j] = new ScanImage(rows, columns, Emgu.CV.CvEnum.DepthType.Cv8U, 3, numOfBank, j);
                        BGRImages[i][j] = new ScanImage(rows, columns, Emgu.CV.CvEnum.DepthType.Cv8U, 3, numOfBank, j);
                    }
                }
                else
                {
                    OriginImages[i] = null;
                    GrayImages[i] = null;
                    Gray3Images[i] = null;
                    BGRImages[i] = null;
                }
            }
        }
    }
}
