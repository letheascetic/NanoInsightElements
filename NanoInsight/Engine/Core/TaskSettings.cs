using NanoInsight.Engine.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Engine.Core
{
    /// <summary>
    /// 扫描任务的配置参数
    /// </summary>
    public class TaskSettings
    {
        ///////////////////////////////////////////////////////////////////////////////////////////

        public ScanAcquisition SelectedScanAcquisition { get; }

        public ScanHead SelectedScanHead { get; }

        public ScanDirection SelectedScanDirection { get; }

        public ScanMode SelectedScanMode { get; }

        public ScanPixel SelectedScanPixel { get; }

        public float ScanPixelSize { get; }

        public bool FastModeEnabled { get; }

        public ScanPixelDwell SelectedScanPixelDwell { get; }

        public bool ScanLineSkipEnabled { get; }

        public ScanLineSkip SelectedScanLineSkip { get; }

        public ScanChannel ScanChannel405 { get; set; }

        public ScanChannel ScanChannel488 { get; set; }

        public ScanChannel ScanChannel561 { get; set; }

        public ScanChannel ScanChannel640 { get; set; }

        public ScanChannel[] ScanChannels { get; set; }

        public ScanAreaType SelectedScanAreaType { get; }

        public ScanArea SelectedScanArea { get; }

        public ScanArea FullScanArea { get; }

        public ColorSpace SelectedColorSpace { get; set; }

        public ImageCorrection SelectedImageCorrection { get; set; }

        public ScanSequence Sequence { get; }

        ///////////////////////////////////////////////////////////////////////////////////////////

        public TaskSettings(Config config, ScanSequence sequence)
        {
            SelectedScanAcquisition = new ScanAcquisition(config.SelectedScanAcquisition);
            SelectedScanHead = new ScanHead(config.SelectedScanHead);
            SelectedScanDirection = new ScanDirection(config.SelectedScanDirection);
            SelectedScanMode = new ScanMode(config.SelectedScanMode);
            SelectedScanPixel = new ScanPixel(config.SelectedScanPixel);
            ScanPixelSize = config.ScanPixelSize;
            FastModeEnabled = config.FastModeEnabled;
            SelectedScanPixelDwell = new ScanPixelDwell(config.SelectedScanPixelDwell);
            ScanLineSkipEnabled = config.ScanLineSkipEnabled;
            SelectedScanLineSkip = new ScanLineSkip(config.SelectedScanLineSkip);
            ScanChannel405 = new ScanChannel(config.ScanChannel405);
            ScanChannel488 = new ScanChannel(config.ScanChannel488);
            ScanChannel561 = new ScanChannel(config.ScanChannel561);
            ScanChannel640 = new ScanChannel(config.ScanChannel640);
            ScanChannels = new ScanChannel[] { ScanChannel405, ScanChannel488, ScanChannel561, ScanChannel640 };
            SelectedScanAreaType = new ScanAreaType(config.SelectedScanAreaType);
            SelectedScanArea = new ScanArea(config.SelectedScanArea);
            FullScanArea = new ScanArea(config.FullScanArea);
            SelectedColorSpace = new ColorSpace(config.SelectedColorSpace);
            SelectedImageCorrection = new ImageCorrection(config.SelectedImageCorrection);
            Sequence = new ScanSequence(sequence);
        }

        /// <summary>
        /// 通道数量
        /// </summary>
        /// <returns></returns>
        public int GetChannelNum()
        {
            return ScanChannels.Length;
        }

        /// <summary>
        /// 当前激活的通道数
        /// </summary>
        /// <returns></returns>
        public int GetActivatedChannelNum()
        {
            int activatedChannelNum = 0;
            activatedChannelNum += ScanChannel405.Activated ? 1 : 0;
            activatedChannelNum += ScanChannel488.Activated ? 1 : 0;
            activatedChannelNum += ScanChannel561.Activated ? 1 : 0;
            activatedChannelNum += ScanChannel640.Activated ? 1 : 0;
            return activatedChannelNum;
        }



    }
}
