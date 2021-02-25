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

        public Mat GammaLUT
        {
            get { return mGammaLUT; }
        }
        public Mat PseudoColorLUT
        {
            get { return mPseudoColorLUT; }
        }

        public int ID { get; set; }

        public Color PseudoColor { get; set; }

        public int Offset { get; set; }

        public int Brightness { get; set; }

        public int Contrast { get; set; }

        public int Gamma { get; set; }

        public int ThresholdMin { get; set; }

        public int ThresholdMax { get; set; }

        public ImageProperty(int id)
        {
            switch (id)
            {
                case ScanChannel.Channel405:
                    ID = ScanChannel.Channel405;
                    Offset = Settings.Default.ScanChannel405Offset;
                    Gamma = Settings.Default.ScanChannel405Gamma;
                    PseudoColor = Settings.Default.ScanChannel405PseudoColor;
                    Brightness = Settings.Default.ScanChannel405Brightness;
                    Contrast = Settings.Default.ScanChannel405Contrast;
                    break;
                case ScanChannel.Channel488:
                    ID = ScanChannel.Channel488;
                    Offset = Settings.Default.ScanChannel488Offset;
                    Gamma = Settings.Default.ScanChannel488Gamma;
                    PseudoColor = Settings.Default.ScanChannel488PseudoColor;
                    Brightness = Settings.Default.ScanChannel488Brightness;
                    Contrast = Settings.Default.ScanChannel488Contrast;
                    break;
                case ScanChannel.Channel561:
                    ID = ScanChannel.Channel561;
                    Offset = Settings.Default.ScanChannel561Offset;
                    Gamma = Settings.Default.ScanChannel561Gamma;
                    PseudoColor = Settings.Default.ScanChannel561PseudoColor;
                    Brightness = Settings.Default.ScanChannel561Brightness;
                    Contrast = Settings.Default.ScanChannel561Contrast;
                    break;
                case ScanChannel.Channel640:
                    ID = ScanChannel.Channel640;
                    Offset = Settings.Default.ScanChannel640Offset;
                    Gamma = Settings.Default.ScanChannel640Gamma;
                    PseudoColor = Settings.Default.ScanChannel640PseudoColor;
                    Brightness = Settings.Default.ScanChannel640Brightness;
                    Contrast = Settings.Default.ScanChannel640Contrast;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("ID Exception");
            }
            ThresholdMin = 0;
            ThresholdMax = 255;
            mGammaLUT = new Mat(1, 256, DepthType.Cv8U, 1);
            mPseudoColorLUT = new Mat(1, 256, DepthType.Cv8U, 3);
            ImageUtil.GenerateGammaMapping(Gamma, ref mGammaLUT);
            ImageUtil.GenerateColorMapping(PseudoColor, ref mPseudoColorLUT);
        }
    }
}
