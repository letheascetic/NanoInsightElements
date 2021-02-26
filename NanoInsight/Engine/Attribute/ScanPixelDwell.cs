using NanoInsight.Engine.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Engine.Attribute
{
    /// <summary>
    /// 扫描像素时间更新事件
    /// </summary>
    /// <param name="scanPixel"></param>
    /// <returns></returns>
    public delegate int ScanPixelDwellChangedEventHandler(ScanPixelDwell scanPixelDwell);
    /// <summary>
    /// 扫描像素偏置更新事件
    /// </summary>
    /// <param name="scanPixelDwell"></param>
    /// <returns></returns>
    public delegate int ScanPixelOffsetChangedEventHandler(ScanPixelDwell scanPixelDwell);
    /// <summary>
    /// 扫描像素补偿更新事件
    /// </summary>
    /// <param name="scanPixelDwell"></param>
    /// <returns></returns>
    public delegate int ScanPixelCalibrationChangedEventHandler(ScanPixelDwell scanPixelDwell);
    /// <summary>
    /// 扫描像素缩放系数更新事件
    /// </summary>
    /// <param name="scanPixelDwell"></param>
    /// <returns></returns>
    public delegate int ScanPixelScaleChangedEventHandler(ScanPixelDwell scanPixelDwell);

    /// <summary>
    /// 像素停留时间
    /// </summary>
    public class ScanPixelDwell : ScanPropertyWithValue<int>
    {
        /// <summary>
        /// 扫描像素校准
        /// 双向扫描时，回程过程中采集的像素中的位置偏移量
        /// </summary>
        public int ScanPixelCalibration { get; set; }

        /// <summary>
        /// 扫描像素偏置
        /// 在每行采集的像素中截取时的位置偏移量，0表示从第一个像素开始截取
        /// </summary>
        public int ScanPixelOffset { get; set; }

        /// <summary>
        /// 扫描像素校准最大值
        /// </summary>
        public int ScanPixelCalibrationMaximum{ get; set; }

        /// <summary>
        /// 扫描像素缩放系数
        /// </summary>
        public int ScanPixelScale { get; set; }

        public static List<ScanPixelDwell> Initialize()
        {
            return new List<ScanPixelDwell>()
            {
                new ScanPixelDwell(0),
                new ScanPixelDwell(1),
                new ScanPixelDwell(2),
                new ScanPixelDwell(3),
                new ScanPixelDwell(4),
                new ScanPixelDwell(5),
                new ScanPixelDwell(6),
                new ScanPixelDwell(7)
            };
        }

        public ScanPixelDwell(int id)
        {
            switch (id)
            {
                case 0:
                    ID = 0;
                    IsEnabled = Settings.Default.ScanPixelDwell == 0;
                    Text = "2";
                    Data = 2;
                    ScanPixelCalibrationMaximum = 50;
                    ScanPixelOffset = 25;
                    ScanPixelCalibration = 25;
                    ScanPixelScale = 7;
                    break;
                case 1:
                    ID = 1;
                    IsEnabled = Settings.Default.ScanPixelDwell == 1;
                    Text = "4";
                    Data = 4;
                    ScanPixelCalibrationMaximum = 24;
                    ScanPixelOffset = 12;
                    ScanPixelCalibration = 12;
                    ScanPixelScale = 7;
                    break;
                case 2:
                    ID = 2;
                    IsEnabled = Settings.Default.ScanPixelDwell == 2;
                    Text = "6";
                    Data = 6;
                    ScanPixelCalibrationMaximum = 16;
                    ScanPixelOffset = 8;
                    ScanPixelCalibration = 8;
                    ScanPixelScale = 7;
                    break;
                case 3:
                    ID = 3;
                    IsEnabled = Settings.Default.ScanPixelDwell == 3;
                    Text = "8";
                    Data = 8;
                    ScanPixelCalibrationMaximum = 12;
                    ScanPixelOffset = 6;
                    ScanPixelCalibration = 6;
                    ScanPixelScale = 7;
                    break;
                case 4:
                    ID = 4;
                    IsEnabled = Settings.Default.ScanPixelDwell == 4;
                    Text = "10";
                    Data = 10;
                    ScanPixelCalibrationMaximum = 10;
                    ScanPixelOffset = 5;
                    ScanPixelCalibration = 5;
                    ScanPixelScale = 7;
                    break;
                case 5:
                    ID = 5;
                    IsEnabled = Settings.Default.ScanPixelDwell == 5;
                    Text = "20";
                    Data = 20;
                    ScanPixelCalibrationMaximum = 4;
                    ScanPixelOffset = 2;
                    ScanPixelCalibration = 2;
                    ScanPixelScale = 7;
                    break;
                case 6:
                    ID = 6;
                    IsEnabled = Settings.Default.ScanPixelDwell == 6;
                    Text = "50";
                    Data = 50;
                    ScanPixelCalibrationMaximum = 2;
                    ScanPixelOffset = 1;
                    ScanPixelCalibration = 1;
                    ScanPixelScale = 7;
                    break;
                case 7:
                    ID = 7;
                    IsEnabled = Settings.Default.ScanPixelDwell == 7;
                    Text = "100";
                    Data = 100;
                    ScanPixelCalibrationMaximum = 0;
                    ScanPixelOffset = 0;
                    ScanPixelCalibration = 0;
                    ScanPixelScale = 7;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("ID Exception");
            }
                

        }

        public ScanPixelDwell(ScanPixelDwell scanPixelDwell)
        {
            ID = scanPixelDwell.ID;
            IsEnabled = scanPixelDwell.IsEnabled;
            Text = scanPixelDwell.Text;
            Data = scanPixelDwell.Data;
            ScanPixelCalibrationMaximum = scanPixelDwell.ScanPixelCalibrationMaximum;
            ScanPixelOffset = scanPixelDwell.ScanPixelOffset;
            ScanPixelCalibration = scanPixelDwell.ScanPixelCalibration;
        }

    }

}
