using GalaSoft.MvvmLight;
using NanoInsight.Engine.Core;
using NanoInsight.Viewer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Viewer.ViewModel
{
    public class ScanSettingsViewModel : ViewModelBase
    {
        private readonly Scheduler mScheduler;

        public Scheduler Engine
        {
            get { return mScheduler; }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        private ScanAcquisitionModel scanLiveMode;
        private ScanAcquisitionModel scanCaptureMode;

        /// <summary>
        /// 实时模式
        /// </summary>
        public ScanAcquisitionModel ScanLiveMode
        {
            get { return scanLiveMode; }
            set { scanLiveMode = value; RaisePropertyChanged(() => ScanLiveMode); }
        }
        /// <summary>
        /// 捕捉模式
        /// </summary>
        public ScanAcquisitionModel ScanCaptureMode
        {
            get { return scanCaptureMode; }
            set { scanCaptureMode = value; RaisePropertyChanged(() => ScanCaptureMode); }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        private ScanHeadModel twoGalvo;
        private ScanHeadModel threeGalvo;

        /// <summary>
        /// 双镜
        /// </summary>
        public ScanHeadModel TwoGalvo
        {
            get { return twoGalvo; }
            set { twoGalvo = value; RaisePropertyChanged(() => TwoGalvo); }
        }
        /// <summary>
        /// 三镜
        /// </summary>
        public ScanHeadModel ThreeGalvo
        {
            get { return threeGalvo; }
            set { threeGalvo = value; RaisePropertyChanged(() => ThreeGalvo); }
        }
        /// <summary>
        /// 选择的扫描头
        /// </summary>
        public ScanHeadModel SelectedScanHead
        {
            get { return TwoGalvo.IsEnabled ? TwoGalvo : ThreeGalvo; }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        private ScanModeModel galvano;
        private ScanModeModel resonant;

        /// <summary>
        /// 选择的扫描模式
        /// </summary>
        public ScanModeModel SelectedScanMode
        {
            get { return Galavano.IsEnabled ? Galavano : Resonant; }
        }
        /// <summary>
        /// Galvano扫描模式
        /// </summary>
        public ScanModeModel Galavano
        {
            get { return galvano; }
            set { galvano = value; RaisePropertyChanged(() => Galavano); }
        }
        /// <summary>
        /// Resonant扫描模式
        /// </summary>
        public ScanModeModel Resonant
        {
            get { return resonant; }
            set { resonant = value; RaisePropertyChanged(() => Resonant); }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        private ScanDirectionModel unidirection;
        private ScanDirectionModel bidirection;

        /// <summary>
        /// 选择的扫描方向
        /// </summary>
        public ScanDirectionModel SelectedScanDirection
        {
            get { return Unidirection.IsEnabled ? Unidirection : Bidirection; }
        }
        /// <summary>
        /// 单向
        /// </summary>
        public ScanDirectionModel Unidirection
        {
            get { return unidirection; }
            set { unidirection = value; RaisePropertyChanged(() => Unidirection); }
        }
        /// <summary>
        /// 双向
        /// </summary>
        public ScanDirectionModel Bidirection
        {
            get { return bidirection; }
            set { bidirection = value; RaisePropertyChanged(() => Bidirection); }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        private List<ScanPixelModel> scanPixelList;
        private ScanPixelModel selectedScanPixel;

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

        ///////////////////////////////////////////////////////////////////////////////////////////
        private bool fastModeEnabled;
        private List<ScanPixelDwellModel> scanPixelDwellList;
        private ScanPixelDwellModel selectedScanPixelDwell;

        private int scanPixelCalibration;
        private int scanPixelOffset;
        private int scanPixelCalibrationMaximum;
        private int scanPixelScale;

        /// <summary>
        /// 快速模式使能
        /// </summary>
        public bool FastModeEnabled
        {
            get { return fastModeEnabled; }
            set { fastModeEnabled = value; RaisePropertyChanged(() => FastModeEnabled); }
        }
        /// <summary>
        /// 像素停留时间列表
        /// </summary>
        public List<ScanPixelDwellModel> ScanPixelDwellList
        {
            get { return scanPixelDwellList; }
            set { scanPixelDwellList = value; RaisePropertyChanged(() => ScanPixelDwellList); }
        }
        /// <summary>
        /// 选择的像素停留时间
        /// </summary>
        public ScanPixelDwellModel SelectedScanPixelDwell
        {
            get { return selectedScanPixelDwell; }
            set { selectedScanPixelDwell = value; RaisePropertyChanged(() => SelectedScanPixelDwell); }
        }

        /// <summary>
        /// 扫描像素补偿
        /// </summary>
        public int ScanPixelCalibration
        {
            get { return scanPixelCalibration; }
            set { scanPixelCalibration = value; RaisePropertyChanged(() => ScanPixelCalibration); }
        }
        /// <summary>
        /// 扫描像素偏置
        /// </summary>
        public int ScanPixelOffset
        {
            get { return scanPixelOffset; }
            set { scanPixelOffset = value; RaisePropertyChanged(() => ScanPixelOffset); }
        }
        /// <summary>
        /// 扫描像素补偿最大值
        /// </summary>
        public int ScanPixelCalibrationMaximum
        {
            get { return scanPixelCalibrationMaximum; }
            set { scanPixelCalibrationMaximum = value; RaisePropertyChanged(() => ScanPixelCalibrationMaximum); }
        }
        /// <summary>
        /// 扫描像素缩放系数
        /// </summary>
        public int ScanPixelScale
        {
            get { return scanPixelScale; }
            set { scanPixelScale = value; RaisePropertyChanged(() => ScanPixelScale); }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        private bool scanLineSkipEnabled;
        private ScanLineSkipModel selectedScanLineSkip;
        private List<ScanLineSkipModel> scanLineSkipList;

        /// <summary>
        /// 跳行扫描使能
        /// </summary>
        public bool ScanLineSkipEnabled
        {
            get { return scanLineSkipEnabled; }
            set { scanLineSkipEnabled = value; RaisePropertyChanged(() => ScanLineSkipEnabled); }
        }
        /// <summary>
        /// 选择的跳行扫描
        /// </summary>
        public ScanLineSkipModel SelectedScanLineSkip
        {
            get { return selectedScanLineSkip; }
            set { selectedScanLineSkip = value; RaisePropertyChanged(() => SelectedScanLineSkip); }
        }
        /// <summary>
        /// 跳行扫描列表
        /// </summary>
        public List<ScanLineSkipModel> ScanLineSkipList
        {
            get { return scanLineSkipList; }
            set { scanLineSkipList = value; RaisePropertyChanged(() => SelectedScanLineSkip); }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        private ScanChannelModel scanChannel405;
        private ScanChannelModel scanChannel488;
        private ScanChannelModel scanChannel561;
        private ScanChannelModel scanChannel640;
        private ScanChannelModel[] scanChannels;

        /// <summary>
        /// 405nm通道
        /// </summary>
        public ScanChannelModel ScanChannel405
        {
            get { return scanChannel405; }
            set { scanChannel405 = value; RaisePropertyChanged(() => ScanChannel405); }
        }
        /// <summary>
        /// 488nm通道
        /// </summary>
        public ScanChannelModel ScanChannel488
        {
            get { return scanChannel488; }
            set { scanChannel488 = value; RaisePropertyChanged(() => ScanChannel488); }
        }
        /// <summary>
        /// 561nm通道
        /// </summary>
        public ScanChannelModel ScanChannel561
        {
            get { return scanChannel561; }
            set { scanChannel561 = value; RaisePropertyChanged(() => ScanChannel561); }
        }
        /// <summary>
        /// 640nm通道
        /// </summary>
        public ScanChannelModel ScanChannel640
        {
            get { return scanChannel640; }
            set { scanChannel640 = value; RaisePropertyChanged(() => ScanChannel640); }
        }
        public ScanChannelModel[] ScanChannels
        {
            get { return scanChannels; }
            set { scanChannels = value; RaisePropertyChanged(() => ScanChannels); }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        public ScanSettingsViewModel()
        {
            mScheduler = Scheduler.CreateInstance();
            // 采集模式
            ScanLiveMode = new ScanAcquisitionModel(mScheduler.Configuration.ScanLiveMode);
            ScanCaptureMode = new ScanAcquisitionModel(mScheduler.Configuration.ScanCaptureMode);
            // 扫描头
            TwoGalvo = new ScanHeadModel(mScheduler.Configuration.TwoGalvo);
            ThreeGalvo = new ScanHeadModel(mScheduler.Configuration.ThreeGalvo);
            // 采集模式
            ScanLiveMode = new ScanAcquisitionModel(mScheduler.Configuration.ScanLiveMode);
            ScanCaptureMode = new ScanAcquisitionModel(mScheduler.Configuration.ScanCaptureMode);
            // 扫描模式
            Resonant = new ScanModeModel(mScheduler.Configuration.Resonant);
            Galavano = new ScanModeModel(mScheduler.Configuration.Galvano);
            // 扫描方向
            Unidirection = new ScanDirectionModel(mScheduler.Configuration.Unidirection);
            Bidirection = new ScanDirectionModel(mScheduler.Configuration.Bidirection);
            // 像素时间
            FastModeEnabled = mScheduler.Configuration.FastModeEnabled;
            ScanPixelDwellList = ScanPixelDwellModel.Initialize(mScheduler.Configuration.ScanPixelDwellList);
            SelectedScanPixelDwell = ScanPixelDwellList.Where(p => p.IsEnabled).First();
            ScanPixelCalibrationMaximum = SelectedScanPixelDwell.ScanPixelCalibrationMaximum;
            ScanPixelCalibration = SelectedScanPixelDwell.ScanPixelCalibration;
            ScanPixelOffset = SelectedScanPixelDwell.ScanPixelOffset;
            ScanPixelScale = SelectedScanPixelDwell.ScanPixelScale;
            // 扫描像素
            ScanPixelList = ScanPixelModel.Initialize(mScheduler.Configuration.ScanPixelList);
            SelectedScanPixel = ScanPixelList.Where(p => p.IsEnabled).First();
            // 跳行扫描
            ScanLineSkipEnabled = mScheduler.Configuration.ScanLineSkipEnabled;
            ScanLineSkipList = ScanLineSkipModel.Initialize(mScheduler.Configuration.ScanLineSkipList);
            SelectedScanLineSkip = ScanLineSkipList.Where(p => p.ID == mScheduler.Configuration.SelectedScanLineSkip.ID).First();
            // 扫描通道
            ScanChannel405 = new ScanChannelModel(mScheduler.Configuration.ScanChannel405);
            ScanChannel488 = new ScanChannelModel(mScheduler.Configuration.ScanChannel488);
            ScanChannel561 = new ScanChannelModel(mScheduler.Configuration.ScanChannel561);
            ScanChannel640 = new ScanChannelModel(mScheduler.Configuration.ScanChannel640);
            ScanChannels = new ScanChannelModel[] { ScanChannel405, ScanChannel488, ScanChannel561, ScanChannel640 };

        }
    }
}
