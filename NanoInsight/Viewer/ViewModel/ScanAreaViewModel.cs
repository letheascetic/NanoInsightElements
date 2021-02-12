using Emgu.CV;
using Emgu.CV.CvEnum;
using GalaSoft.MvvmLight;
using NanoInsight.Engine.Core;
using NanoInsight.Viewer.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Viewer.ViewModel
{
    /// <summary>
    /// 扫描区域ViewModel
    /// </summary>
    public class ScanAreaViewModel : ViewModelBase
    {
        private readonly Scheduler mScheduler;

        private int pixelDwell;
        private int scanWidth;
        private int scanHeight;
        private int zoomFactor;
        private Mat scanImage;

        private ScanAreaModel selectedScanArea;
        private ScanAreaModel fullScanArea;
        private float scanPixelSize;

        private List<ScanPixelModel> scanPixelList;
        private ScanPixelModel selectedScanPixel;

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

        /// <summary>
        /// 当前选择的扫描区域
        /// </summary>
        public ScanAreaModel SelectedScanArea
        {
            get { return selectedScanArea; }
            set { selectedScanArea = value; RaisePropertyChanged(() => SelectedScanArea); }
        }
        /// <summary>
        /// 全视场
        /// </summary>
        public ScanAreaModel FullScanArea
        {
            get { return fullScanArea; }
            set { fullScanArea = value; RaisePropertyChanged(() => FullScanArea); }
        }
        /// <summary>
        /// 扫描像素尺寸
        /// </summary>
        public float ScanPixelSize
        {
            get { return scanPixelSize; }
            set { scanPixelSize = value; RaisePropertyChanged(() => ScanPixelSize); }
        }

        /// <summary>
        /// 扫描像素列表
        /// </summary>
        public List<ScanPixelModel> ScanPixelList
        {
            get { return scanPixelList; }
            set { scanPixelList = value; RaisePropertyChanged(() => ScanPixelList); }
        }
        /// <summary>
        /// 选择的扫描像素 
        /// </summary>
        public ScanPixelModel SelectedScanPixel
        {
            get { return selectedScanPixel; }
            set { selectedScanPixel = value; RaisePropertyChanged(() => SelectedScanPixel); }
        }

        public Scheduler Engine
        {
            get { return mScheduler; }
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

            FullScanArea = new ScanAreaModel(mScheduler.Configuration.FullScanArea);
            SelectedScanArea = new ScanAreaModel(mScheduler.Configuration.SelectedScanArea);
            ScanPixelSize = mScheduler.Configuration.ScanPixelSize;

            ScanPixelList = ScanPixelModel.Initialize(mScheduler.Configuration.ScanPixelList);
            SelectedScanPixel = ScanPixelList.Where(p => p.IsEnabled).First();
        }

        /// <summary>
        /// 扫描范围转换成扫描像素范围
        /// </summary>
        /// <param name="scanRange"></param>
        /// <returns></returns>
        public Rectangle ScanRangeToScanPixelRange(RectangleF scanRange)
        {
            int x = (int)((scanRange.X - SelectedScanArea.ScanRange.X) / ScanPixelSize);
            int y = (int)((scanRange.Y - SelectedScanArea.ScanRange.Y) / ScanPixelSize);
            int width = (int)(scanRange.Width / ScanPixelSize);
            int height = (int)(scanRange.Height / ScanPixelSize);
            return new Rectangle(x, y, width, height);
        }

        /// <summary>
        /// 扫描像素范围转换成扫描范围
        /// </summary>
        /// <param name="scanPixelRange"></param>
        /// <returns></returns>
        public RectangleF ScanPixelRangeToScanRange(Rectangle scanPixelRange)
        {
            float x = SelectedScanArea.ScanRange.X + ScanPixelSize * scanPixelRange.X;
            float y = SelectedScanArea.ScanRange.Y + ScanPixelSize * scanPixelRange.Y;
            float width = ScanPixelSize * scanPixelRange.Width;
            float height = ScanPixelSize * scanPixelRange.Height;
            return new RectangleF(x, y, width, height);
        }

        public int SelectScanPixel(int id)
        {
            foreach (ScanPixelModel scanPixel in ScanPixelList)
            {
                if (scanPixel.ID == id)
                {
                    SelectedScanPixel = scanPixel;
                    scanPixel.IsEnabled = true;
                }
                else
                {
                    scanPixel.IsEnabled = false;
                }
            }
            int code = mScheduler.SelectScanPixel(SelectedScanPixel.ID);
            ScanPixelSize = mScheduler.Configuration.ScanPixelSize;
            ScanWidth = mScheduler.Configuration.SelectedScanPixel.Data;
            ScanHeight = mScheduler.Configuration.SelectedScanPixel.Data;
            return code;
        }

        public int ScanPixelChangedEventHandler(int id)
        {
            foreach (ScanPixelModel scanPixel in ScanPixelList)
            {
                if (scanPixel.ID == id)
                {
                    SelectedScanPixel = scanPixel;
                    scanPixel.IsEnabled = true;
                }
                else
                {
                    scanPixel.IsEnabled = false;
                }
            }
            ScanPixelSize = mScheduler.Configuration.ScanPixelSize;
            return ApiCode.Success;
        }

        public int SetScanArea(RectangleF scanRange)
        {
            SelectedScanArea.Update(scanRange);
            int code = mScheduler.SetScanArea(scanRange);
            ScanPixelSize = mScheduler.Configuration.ScanPixelSize;
            return code;
        }

        public int ScanAreaChangedEventHandler(RectangleF scanRange)
        {
            SelectedScanArea.Update(scanRange);
            ScanPixelSize = mScheduler.Configuration.ScanPixelSize;
            return ApiCode.Success;
        }

        public int FullScanAreaChangedEventHandler(RectangleF scanRange)
        {
            FullScanArea.Update(scanRange);
            return ApiCode.Success;
        }

    }
}
