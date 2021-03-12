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
    /// 扫描区域变化事件
    /// </summary>
    /// <param name="scanArea"></param>
    /// <returns></returns>
    public delegate int ScanAreaChangedEventHandler(ScanArea scanArea);

    /// <summary>
    /// 扫描区域
    /// </summary>
    public class ScanArea
    {
        ///////////////////////////////////////////////////////////////////////////////////////////
        private const int EXTEND_LINE_TIME_DEFAULT = 100;
        private const int EXTEND_ROW_COUNT_DEFAULT = 0;
        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 行[X方向]扩展时间[单位：us]
        /// </summary>
        public static int ExtendLineTime { get; set; }
        /// <summary>
        /// [Y方向]扩展的行数
        /// </summary>
        public static int ExtendRowCount { get; set; }
        /// <summary>
        /// 行偏置时间[单位：us]
        /// </summary>
        public static int ExtendLineOffset { get; set; }
        /// <summary>
        /// [Y方向]的偏置
        /// </summary>
        public static int ExtendRowOffset { get; set; }
        /// <summary>
        /// 双向扫描中奇数偶数行错位的像素数
        /// </summary>
        public static int ScanPixelCalibration { get; set; }
        /// <summary>
        /// 行边缘区域除数因子
        /// </summary>
        public static double ExtendLineMarginDiv { get; set; }
        /// <summary>
        /// 扫描行起始时间[单双向有效]
        /// </summary>
        public static double ScanLineStartTime { get { return Settings.Default.GalvoResponseTime; } }
        /// <summary>
        /// 扫描行保持时间[只对单向扫描有效]
        /// </summary>
        public static double ScanLineHoldTime { get { return Settings.Default.GalvoResponseTime; } }
        /// <summary>
        /// 扫描行结束时间[只对单向扫描有效]
        /// </summary>
        public static double ScanLineEndTime { get { return Settings.Default.GalvoResponseTime * 3; } }

        public RectangleF ScanRange { get; set; }

        public string Text { get; set; }

        ///////////////////////////////////////////////////////////////////////////////////////////
        static ScanArea()
        {
            ExtendLineTime = EXTEND_LINE_TIME_DEFAULT;
            ExtendRowCount = EXTEND_ROW_COUNT_DEFAULT;
            ExtendLineOffset = 0;
            ExtendRowOffset = 0;
            ScanPixelCalibration = 0;
            ExtendLineMarginDiv = 50;
        }

        public ScanArea(RectangleF scanRange)
        {
            ScanRange = scanRange;
            Text = string.Format("[{0}, {1}][{2}, {3}]", ScanRange.X.ToString("0.0"), ScanRange.Y.ToString("0.0"), 
                ScanRange.Width.ToString("0.0"), ScanRange.Height.ToString("0.0"));
        }

        public ScanArea(ScanArea scanArea) 
        {
            ScanRange = new RectangleF(scanArea.ScanRange.Location, scanArea.ScanRange.Size);
            Text = string.Format("[{0}, {1}][{2}, {3}]", ScanRange.X.ToString("0.0"), ScanRange.Y.ToString("0.0"), ScanRange.Width.ToString("0.0"), ScanRange.Height.ToString("0.0"));
        }

        public void Update(RectangleF scanRange)
        {
            ScanRange = scanRange;
            Text = string.Format("[{0}, {1}][{2}, {3}]", ScanRange.X.ToString("0.0"), ScanRange.Y.ToString("0.0"),
                ScanRange.Width.ToString("0.0"), ScanRange.Height.ToString("0.0"));
        }

        public static ScanArea CreateFullScanArea()
        {
            float fullScanRange = Settings.Default.FullScanRange;
            return new ScanArea(new RectangleF(-fullScanRange / 2, -fullScanRange / 2, fullScanRange, fullScanRange));
        }

    }
}
