using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Engine.Core
{
    public class Config
    {
        ///////////////////////////////////////////////////////////////////////////////////////////
        private static readonly ILog Logger = LogManager.GetLogger("info");
        private volatile static Config pConfig = null;
        private static readonly object locker = new object();
        private const int ChannelNum = 4;
        ///////////////////////////////////////////////////////////////////////////////////////////
        public bool Debugging { get; set; }
        public double InputSampleRate { get; set; }                         // 像素速率[采样速率]

        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 实时模式
        /// </summary>
        public ScanAcquisition ScanLiveMode { get; set; }
        /// <summary>
        /// 捕捉模式
        /// </summary>
        public ScanAcquisition ScanCaptureMode { get; set; }
        /// <summary>
        /// 扫描状态
        /// </summary>
        public bool IsScanning
        {
            get { return ScanLiveMode.IsEnabled || ScanCaptureMode.IsEnabled; }
        }
        /// <summary>
        /// 当前的采集模式
        /// </summary>
        public ScanAcquisition SelectedScanAcquisition
        {
            get
            {
                if (!IsScanning)
                {
                    return null;
                }
                return ScanLiveMode.IsEnabled ? ScanLiveMode : ScanCaptureMode;
            }
        }

        /// <summary>
        /// 启动指定的采集模式
        /// </summary>
        /// <param name="id"></param>
        public int StartAcquisition(int id)
        {
            if (id != ScanLiveMode.ID && id != ScanCaptureMode.ID)
            {
                return ApiCode.ConfigStartAcquisitionFailed;
            }
            ScanLiveMode.IsEnabled = id == ScanLiveMode.ID;
            ScanCaptureMode.IsEnabled = !ScanLiveMode.IsEnabled;
            Logger.Info(string.Format("Scan Acquisition Mode [{0}:{1}].", IsScanning, IsScanning ? SelectedScanAcquisition.Text : "None"));
            return ApiCode.Success;
        }
        /// <summary>
        /// 停止采集
        /// </summary>
        public void StopAcquisition()
        {
            ScanLiveMode.IsEnabled = false;
            ScanCaptureMode.IsEnabled = false;
            Logger.Info(string.Format("Scan Acquisition Mode [{0}:{1}].", IsScanning, IsScanning ? SelectedScanAcquisition.Text : "None"));
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 双振镜
        /// </summary>
        public ScanHead TwoGalvo { get; set; }
        /// <summary>
        /// 三振镜
        /// </summary>
        public ScanHead ThreeGalvo { get; set; }
        /// <summary>
        /// 选择的扫描头
        /// </summary>
        public ScanHead SelectedScanHead
        {
            get { return TwoGalvo.IsEnabled ? TwoGalvo : ThreeGalvo; }
        }
        /// <summary>
        /// 设置扫描头
        /// </summary>
        /// <param name="id"></param>
        public int SetScanHead(int id)
        {
            if (id != TwoGalvo.ID && id != ThreeGalvo.ID)
            {
                return ApiCode.ConfigSetScanHeadFailed;
            }
            TwoGalvo.IsEnabled = id == TwoGalvo.ID;
            ThreeGalvo.IsEnabled = !TwoGalvo.IsEnabled;
            Logger.Info(string.Format("Scan Header [{0}].", SelectedScanHead.Text));
            return ApiCode.Success;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 单向扫描
        /// </summary>
        public ScanDirection Unidirection { get; set; }
        /// <summary>
        /// 双向
        /// </summary>
        public ScanDirection Bidirection { get; set; }
        /// <summary>
        /// 选择的扫描方向
        /// </summary>
        public ScanDirection SelectedScanDirection
        {
            get { return Unidirection.IsEnabled ? Unidirection : Bidirection; }
        }
        
        /// <summary>
        /// 设置扫描方向
        /// </summary>
        /// <param name="id"></param>
        public int SetScanDirection(int id)
        {
            if (id != Unidirection.ID && id != Bidirection.ID)
            {
                return ApiCode.ConfigSetScanDirectionFailed;
            }
            Unidirection.IsEnabled = id == Unidirection.ID;
            Bidirection.IsEnabled = !Unidirection.IsEnabled;
            Logger.Info(string.Format("Scan Direction [{0}].", SelectedScanDirection.Text));
            return ApiCode.Success;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Galvo扫描模式
        /// </summary>
        public ScanMode Galvano { get; set; }
        /// <summary>
        /// Resonant扫描模式
        /// </summary>
        public ScanMode Resonant { get; set; }
        /// <summary>
        /// 选择的扫描模式
        /// </summary>
        public ScanMode SelectedScanMode
        {
            get { return Galvano.IsEnabled ? Galvano : Resonant; }
        }
        /// <summary>
        /// 设置扫描模式
        /// </summary>
        /// <param name="id"></param>
        public int SetScanMode(int id)
        {
            if (id != Resonant.ID && id != Galvano.ID)
            {
                return ApiCode.ConfigSetScanModeFailed;
            }
            Resonant.IsEnabled = id == Resonant.ID;
            Galvano.IsEnabled = !Resonant.IsEnabled;
            Logger.Info(string.Format("Scan Mode [{0}].", SelectedScanMode.Text));
            return ApiCode.Success;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 扫描像素列表
        /// </summary>
        public List<ScanPixel> ScanPixelList { get; set; }
        /// <summary>
        /// 选择的扫描像素 
        /// </summary>
        public ScanPixel SelectedScanPixel { get; set; }
        /// <summary>
        /// 设置扫描像素
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int SetScanPixel(int id)
        {
            if (ScanPixelList.Where(p => p.ID == id).FirstOrDefault() == null)
            {
                return ApiCode.ConfigSetScanPixelFailed;
            }
            foreach (ScanPixel scanPixel in ScanPixelList)
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
            return ApiCode.Success;
        }



    }
}
