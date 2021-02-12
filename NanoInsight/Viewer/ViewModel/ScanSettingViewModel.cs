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
    public class ScanSettingViewModel : ViewModelBase
    {
        private Scheduler mScheduler;

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
        public ScanSettingViewModel()
        {
            mScheduler = Scheduler.CreateInstance();
            ScanLiveMode = new ScanAcquisitionModel(mScheduler.Configuration.ScanLiveMode);
            ScanCaptureMode = new ScanAcquisitionModel(mScheduler.Configuration.ScanCaptureMode);
        }
    }
}
