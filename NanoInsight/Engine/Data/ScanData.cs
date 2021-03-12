using Emgu.CV;
using Emgu.CV.CvEnum;
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
        public int ActivatedChannelNum { get; }

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
        /// 三通道灰度图像[只用作临时数据]
        /// </summary>
        // public ScanBank[][] Gray3Banks { get; set; }
        /// <summary>
        /// BGR彩色图像
        /// </summary>
        public ScanImage[][] BGRImages { get; set; }
        /// <summary>
        /// 多通道合成后的图像
        /// </summary>
        public ScanImage[] MergeImages { get; set; }

        public ScanData(int rows, int columns, int numOfBank, int numOfChannels, int numOfSlices, bool[] statusOfChannels)
        {
            OriginDataSet = new ScanImage[numOfChannels][];
            OriginImages = new ScanImage[numOfChannels][];
            GrayImages = new ScanImage[numOfChannels][];
            BGRImages = new ScanImage[numOfChannels][];
            // Gray3Banks = new ScanBank[numOfChannels][];

            ActivatedChannelNum = statusOfChannels.Where(p => p == true).Count();
            MergeImages = ActivatedChannelNum > 1 ? new ScanImage[numOfSlices] : null;
            if (MergeImages != null)
            {
                for (int i = 0; i < numOfSlices; i++)
                {
                    MergeImages[i] = new ScanImage(rows, columns, Emgu.CV.CvEnum.DepthType.Cv8U, 3, numOfBank, i);
                }
            }

            for (int i = 0; i < numOfChannels; i++)
            {
                if (statusOfChannels[i])
                {
                    OriginDataSet[i] = new ScanImage[numOfSlices];
                    OriginImages[i] = new ScanImage[numOfSlices];
                    GrayImages[i] = new ScanImage[numOfSlices];
                    BGRImages[i] = new ScanImage[numOfSlices];
                    // Gray3Banks[i] = new ScanBank[numOfSlices];
                    for (int j = 0; j < numOfSlices; j++)
                    {
                        OriginDataSet[i][j] = new ScanImage(rows, columns, Emgu.CV.CvEnum.DepthType.Cv32S, 1, numOfBank, j);
                        OriginImages[i][j] = new ScanImage(rows, columns, Emgu.CV.CvEnum.DepthType.Cv8U, 1, numOfBank, j);
                        GrayImages[i][j] = new ScanImage(rows, columns, Emgu.CV.CvEnum.DepthType.Cv8U, 1, numOfBank, j);
                        BGRImages[i][j] = new ScanImage(rows, columns, Emgu.CV.CvEnum.DepthType.Cv8U, 3, numOfBank, j);
                        // Gray3Banks[i][j] = new ScanBank(rows / numOfBank, columns, Emgu.CV.CvEnum.DepthType.Cv8U, 3);
                    }
                }
                else
                {
                    OriginDataSet[i] = null;
                    OriginImages[i] = null;
                    GrayImages[i] = null;
                    BGRImages[i] = null;
                    // Gray3Banks[i] = null;
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

        /// <summary>
        /// 将OriginImages中指定的bank转换成GrayIamges中对应的bank
        /// </summary>
        /// <param name="brightness"></param>
        /// <param name="contrast"></param>
        /// <param name="channelIndex"></param>
        /// <param name="sliceIndex"></param>
        /// <param name="bankIndex"></param>
        public void ToGrayImages(int brightness, int contrast, int channelIndex, int sliceIndex, int bankIndex)
        {
            double alpha = Math.Pow(10, contrast / 10.0);
            Mat originImageBank = OriginImages[channelIndex][sliceIndex].Banks[bankIndex].Bank;
            Mat grayImageBank = GrayImages[channelIndex][sliceIndex].Banks[bankIndex].Bank;
            MatrixUtil.ToGrayImage(originImageBank, ref grayImageBank, alpha, brightness);
        }

        /// <summary>
        /// 将OriginImages中指定的Image转换成GrayIamges中对应的Image
        /// </summary>
        /// <param name="brightness"></param>
        /// <param name="contrast"></param>
        /// <param name="channelIndex"></param>
        /// <param name="sliceIndex"></param>
        public void ToGrayImages(int brightness, int contrast, int channelIndex, int sliceIndex)
        {
            double alpha = Math.Pow(10, contrast / 10.0);
            Mat originImage = OriginImages[channelIndex][sliceIndex].Image;
            Mat grayImage = GrayImages[channelIndex][sliceIndex].Image;
            MatrixUtil.ToGrayImage(originImage, ref grayImage, alpha, brightness);
        }

        /// <summary>
        /// 将OriginImages中指定的Image转换成GrayIamges中对应的Image
        /// </summary>
        /// <param name="brightness"></param>
        /// <param name="contrast"></param>
        /// <param name="channelIndex"></param>
        public void ToGrayImages(int brightness, int contrast, int channelIndex)
        {
            for (int i = 0; i < OriginImages[channelIndex].Length; i++)
            {
                ToGrayImages(brightness, contrast, channelIndex, i);
            }
        }

        public void ToGrayImages(Mat lookupTable, int channelIndex, int sliceIndex, int bankIndex)
        {
            Mat originImageBank = OriginImages[channelIndex][sliceIndex].Banks[bankIndex].Bank;
            Mat grayImageBank = GrayImages[channelIndex][sliceIndex].Banks[bankIndex].Bank;
            MatrixUtil.LUT(originImageBank, ref grayImageBank, lookupTable);
        }

        public void ToGrayImages(Mat lookupTable, int channelIndex, int sliceIndex)
        {
            Mat originImage = OriginImages[channelIndex][sliceIndex].Image;
            Mat grayImage = GrayImages[channelIndex][sliceIndex].Image;
            MatrixUtil.LUT(originImage, ref grayImage, lookupTable);
        }

        public void ToGrayImages(Mat lookupTable, int channelIndex)
        {
            for (int i = 0; i < OriginImages[channelIndex].Length; i++)
            {
                ToGrayImages(lookupTable, channelIndex, i);
            }
        }

        public void ToBGRImages(Mat lookupTable, int channelIndex, int sliceIndex, int bankIndex)
        {
            Mat grayImageBank = GrayImages[channelIndex][sliceIndex].Banks[bankIndex].Bank;
            Mat gray3ImageBank = new Mat();
            Mat bgrImageBank = BGRImages[channelIndex][sliceIndex].Banks[bankIndex].Bank;
            CvInvoke.CvtColor(grayImageBank, gray3ImageBank, ColorConversion.Gray2Bgr);
            CvInvoke.LUT(gray3ImageBank, lookupTable, bgrImageBank);
        }

        public void ToBGRImages(Mat lookupTable, int channelIndex, int sliceIndex)
        {
            Mat grayImage = GrayImages[channelIndex][sliceIndex].Image;
            Mat gray3Image = new Mat();
            Mat bgrImage = BGRImages[channelIndex][sliceIndex].Image;
            CvInvoke.CvtColor(grayImage, gray3Image, ColorConversion.Gray2Bgr);
            CvInvoke.LUT(gray3Image, lookupTable, bgrImage);
        }

        public void ToBGRImages(Mat lookupTable, int channelIndex)
        {
            Mat gray3Image = new Mat();
            for (int i = 0; i < GrayImages[channelIndex].Length; i++)
            {
                Mat grayImage = GrayImages[channelIndex][i].Image;
                CvInvoke.CvtColor(grayImage, gray3Image, ColorConversion.Gray2Bgr);
                Mat bgrImage = BGRImages[channelIndex][i].Image;
                CvInvoke.LUT(gray3Image, lookupTable, bgrImage);
            }
        }

        public void ToMergeImages(int sliceIndex, int bankIndex)
        {
            int activatedChannelCount = 0;
            Mat mergeImage = null;
            for (int i = 0; i < BGRImages.Length; i++)
            {
                if (BGRImages[i] != null)
                {
                    if (activatedChannelCount == 0)
                    {
                        mergeImage = BGRImages[i][sliceIndex].Banks[bankIndex].Bank.Clone();
                    }
                    else
                    {
                        mergeImage += BGRImages[i][sliceIndex].Banks[bankIndex].Bank;
                    }
                    activatedChannelCount++;
                }
            }
            mergeImage.ConvertTo(MergeImages[sliceIndex].Banks[bankIndex].Bank, mergeImage.Depth);
        }

        public void ToMergeImages(int sliceIndex)
        {
            int activatedChannelCount = 0;
            Mat mergeImage = null;
            for (int i = 0; i < BGRImages.Length; i++)
            {
                if (BGRImages[i] != null)
                {
                    if (activatedChannelCount == 0)
                    {
                        mergeImage = BGRImages[i][sliceIndex].Image.Clone();
                    }
                    else
                    {
                        mergeImage += BGRImages[i][sliceIndex].Image;
                    }
                    activatedChannelCount++;
                }
            }
            mergeImage.ConvertTo(MergeImages[sliceIndex].Image, mergeImage.Depth);
        }

        public void ToMergeImages()
        {
            for (int i = 0; i < MergeImages.Length; i++)
            {
                ToMergeImages(i);
            }
        }
    }
}
