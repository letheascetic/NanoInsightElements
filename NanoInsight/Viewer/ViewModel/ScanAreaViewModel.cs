using Emgu.CV;
using Emgu.CV.CvEnum;
using GalaSoft.MvvmLight;
using NanoInsight.Engine.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Viewer.ViewModel
{
    public class ScanAreaViewModel : ViewModelBase
    {

        private readonly Scheduler mScheduler;

        private int pixelDwell;
        private int scanWidth;
        private int scanHeight;
        private int zoomFactor;
        private Mat scanImage;

        public int PixelDwell
        {
            get { return pixelDwell; }
            set { pixelDwell = value; RaisePropertyChanged(() => PixelDwell); }
        }
        /// <summary>
        /// 扫描宽度
        /// </summary>
        public int ScanWidth
        {
            get { return scanWidth; }
            set { scanWidth = value; RaisePropertyChanged(() => ScanWidth); }
        }
        /// <summary>
        /// 扫描高度
        /// </summary>
        public int ScanHeight
        {
            get { return scanHeight; }
            set { scanHeight = value; RaisePropertyChanged(() => ScanHeight); }
        }
        /// <summary>
        /// 扫描区域缩放因子
        /// </summary>
        public int ZoomFactor
        {
            get { return zoomFactor; }
            set { zoomFactor = value; RaisePropertyChanged(() => ZoomFactor); }
        }
        /// <summary>
        /// 扫描图像
        /// </summary>
        public Mat ScanImage
        {
            get { return scanImage; }
            set { scanImage = value; RaisePropertyChanged(() => ScanImage); }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////

        public ScanAreaViewModel()
        {
            mScheduler = Scheduler.CreateInstance();

            PixelDwell = mScheduler.Configuration.SelectedScanPixelDwell.Data;
            ScanWidth = mScheduler.Configuration.SelectedScanPixel.Data;
            ScanHeight = mScheduler.Configuration.SelectedScanPixel.Data;

            ZoomFactor = 5;
            ScanImage = new Mat(ScanWidth, ScanHeight, DepthType.Cv8U, 3);
        }

        /// <summary>
        /// 扫描范围转换成扫描像素范围
        /// </summary>
        /// <param name="scanRange"></param>
        /// <returns></returns>
        public Rectangle ScanRangeToScanPixelRange(RectangleF scanRange)
        {
            int x = (int)((scanRange.X - mScheduler.Configuration.SelectedScanArea.ScanRange.X) / mScheduler.Configuration.ScanPixelSize);
            int y = (int)((scanRange.Y - mScheduler.Configuration.SelectedScanArea.ScanRange.Y) / mScheduler.Configuration.ScanPixelSize);
            int width = (int)(scanRange.Width / mScheduler.Configuration.ScanPixelSize);
            int height = (int)(scanRange.Height / mScheduler.Configuration.ScanPixelSize);
            return new Rectangle(x, y, width, height);
        }

    }
}
