using Emgu.CV;
using Emgu.CV.CvEnum;
using NanoInsight.Engine.Common;
using NanoInsight.Engine.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Engine.Attribute
{
    /// <summary>
    /// 通道伪彩色更新事件
    /// </summary>
    /// <param name="imageProperty"></param>
    /// <returns></returns>
    public delegate int ImagePseudoColorChangedEventHandler(ImageProperty imageProperty);

    /// <summary>
    /// 通道偏置更新事件委托
    /// </summary>
    /// <param name="channel"></param>
    /// <returns></returns>
    public delegate int ImageOffsetChangedEventHandler(ImageProperty imageProperty);

    public delegate int ImageBrightnessChangedEventHandler(ImageProperty imageProperty);

    public delegate int ImageContrastChangedEventHandler(ImageProperty imageProperty);

    public delegate int ImageGammaChangedEventHandler(ImageProperty imageProperty);

    public delegate int ImageGammaMinChangedEventHandler(ImageProperty imageProperty);

    public delegate int ImageGammaMaxChangedEventHandler(ImageProperty imageProperty);

    /// <summary>
    /// 图像校正属性
    /// </summary>
    public class ImageProperty
    {
        ///////////////////////////////////////////////////////////////////////////////////////////

        private Mat mGammaLUT;
        private Mat mPseudoColorLUT;
        private Color mPseudoColor;
        private int mOffset;
        private int mBrightness;
        private int mContrast;
        private int mGamma;
        private int mGammaMin;
        private int mGammaMax;

        /// <summary>
        /// 伽马校正LUT
        /// </summary>
        public Mat GammaLUT
        {
            get { return mGammaLUT; }
        }
        
        /// <summary>
        /// 伪彩色LUT
        /// </summary>
        public Mat PseudoColorLUT
        {
            get { return mPseudoColorLUT; }
        }

        public int ID { get; }

        /// <summary>
        /// 伪彩色
        /// </summary>
        public Color PseudoColor { get { return mPseudoColor; } }
        /// <summary>
        /// 偏置
        /// </summary>
        public int Offset { get { return mOffset; } }
        /// <summary>
        /// 亮度
        /// </summary>
        public int Brightness { get { return mBrightness; } }
        /// <summary>
        /// 对比度
        /// </summary>
        public int Contrast { get { return mContrast; } }
        /// <summary>
        /// 伽马
        /// </summary>
        public int Gamma { get { return mGamma; } }
        /// <summary>
        /// 伽马校正最小值[小于该值的灰度值不变]
        /// </summary>
        public int GammaMin { get { return mGammaMin; } }
        /// <summary>
        /// 伽马校正最大值[大于该值的灰度值不变]
        /// </summary>
        public int GammaMax { get { return mGammaMax; } }

        public ImageProperty(int id)
        {
            switch (id)
            {
                case ScanChannel.Channel405:
                    ID = ScanChannel.Channel405;
                    mOffset = Settings.Default.ScanChannel405Offset;
                    mGamma = Settings.Default.ScanChannel405Gamma;
                    mPseudoColor = Settings.Default.ScanChannel405PseudoColor;
                    mBrightness = Settings.Default.ScanChannel405Brightness;
                    mContrast = Settings.Default.ScanChannel405Contrast;
                    break;
                case ScanChannel.Channel488:
                    ID = ScanChannel.Channel488;
                    mOffset = Settings.Default.ScanChannel488Offset;
                    mGamma = Settings.Default.ScanChannel488Gamma;
                    mPseudoColor = Settings.Default.ScanChannel488PseudoColor;
                    mBrightness = Settings.Default.ScanChannel488Brightness;
                    mContrast = Settings.Default.ScanChannel488Contrast;
                    break;
                case ScanChannel.Channel561:
                    ID = ScanChannel.Channel561;
                    mOffset = Settings.Default.ScanChannel561Offset;
                    mGamma = Settings.Default.ScanChannel561Gamma;
                    mPseudoColor = Settings.Default.ScanChannel561PseudoColor;
                    mBrightness = Settings.Default.ScanChannel561Brightness;
                    mContrast = Settings.Default.ScanChannel561Contrast;
                    break;
                case ScanChannel.Channel640:
                    ID = ScanChannel.Channel640;
                    mOffset = Settings.Default.ScanChannel640Offset;
                    mGamma = Settings.Default.ScanChannel640Gamma;
                    mPseudoColor = Settings.Default.ScanChannel640PseudoColor;
                    mBrightness = Settings.Default.ScanChannel640Brightness;
                    mContrast = Settings.Default.ScanChannel640Contrast;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("ID Exception");
            }
            mGammaMin = 0;
            mGammaMax = 255;
            mGammaLUT = new Mat(1, 256, DepthType.Cv8U, 1);
            mPseudoColorLUT = new Mat(1, 256, DepthType.Cv8U, 3);
            ImageUtil.GenerateGammaMapping(Gamma, mGammaMin, mGammaMax, ref mGammaLUT);
            ImageUtil.GenerateColorMapping(PseudoColor, ref mPseudoColorLUT);
        }

        public ImageProperty(ImageProperty imageProperty)
        {
            ID = imageProperty.ID;
            mOffset = imageProperty.Offset;
            mGamma = imageProperty.Gamma;
            mPseudoColor = imageProperty.PseudoColor;
            mBrightness = imageProperty.Brightness;
            mContrast = imageProperty.Contrast;
            mGammaMin = imageProperty.GammaMin;
            mGammaMax = imageProperty.GammaMax;
            mGammaLUT = new Mat(1, 256, DepthType.Cv8U, 1);
            mPseudoColorLUT = new Mat(1, 256, DepthType.Cv8U, 3);
            ImageUtil.GenerateGammaMapping(Gamma, mGammaMin, mGammaMax, ref mGammaLUT);
            ImageUtil.GenerateColorMapping(PseudoColor, ref mPseudoColorLUT);
        }
        
        /// <summary>
        /// 设置伪彩色[同时更新伪彩色LUT]
        /// </summary>
        /// <param name="mColor"></param>
        public void SetPseudoColor(Color mColor)
        {
            mPseudoColor = mColor;
            ImageUtil.GenerateColorMapping(PseudoColor, ref mPseudoColorLUT);
        }

        /// <summary>
        /// 设置偏置
        /// </summary>
        /// <param name="offset"></param>
        public void SetOffset(int offset)
        {
            mOffset = offset;
        }

        /// <summary>
        /// 设置亮度
        /// </summary>
        /// <param name="brightness"></param>
        public void SetBrightness(int brightness)
        {
            mBrightness = brightness;
        }

        /// <summary>
        /// 设置对比度
        /// </summary>
        /// <param name="contrast"></param>
        public void SetContrast(int contrast)
        {
            mContrast = contrast;
        }

        /// <summary>
        /// 设置伽马值
        /// </summary>
        /// <param name="gamma"></param>
        public void SetGamma(int gamma)
        {
            mGamma = gamma;
            ImageUtil.GenerateGammaMapping(Gamma, mGammaMin, mGammaMax, ref mGammaLUT);
        }

        /// <summary>
        /// 设置伽马校正范围最小值
        /// </summary>
        /// <param name="gammaMin"></param>
        public void SetGammaMin(int gammaMin)
        {
            if (gammaMin < 0 || gammaMin > 128)
            {
                throw new ArgumentOutOfRangeException(string.Format("Invalid Gamma Min Value: [{0}].", gammaMin));
            }
            mGammaMin = gammaMin;
            ImageUtil.GenerateGammaMapping(Gamma, mGammaMin, mGammaMax, ref mGammaLUT);
        }

        /// <summary>
        /// 设置伽马校正范围最大值
        /// </summary>
        /// <param name="gammaMax"></param>
        public void SetGammaMax(int gammaMax)
        {
            if (gammaMax < 128 || gammaMax > 255)
            {
                throw new ArgumentOutOfRangeException(string.Format("Invalid Gamma Max Value: [{0}].", gammaMax));
            }
            mGammaMax = gammaMax;
            ImageUtil.GenerateGammaMapping(Gamma, mGammaMin, mGammaMax, ref mGammaLUT);
        }

    }
}
