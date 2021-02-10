using log4net;
using NanoInsight.Engine.Attribute;
using NanoInsight.Engine.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        public int SelectScanPixel(int id)
        {
            if (ScanPixelList.Where(p => p.ID == id).FirstOrDefault() == null)
            {
                return ApiCode.ConfigSelectScanPixelFailed;
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
            ScanPixelSize = SelectedScanArea.ScanRange.Width / SelectedScanPixel.Data;
            Logger.Info(string.Format("Scan Pixel [{0}].", SelectedScanPixel.Text));
            return ApiCode.Success;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 快速模式开关
        /// </summary>
        public bool FastModeEnabled { get; set; }
        /// <summary>
        /// 像素时间列表
        /// </summary>
        public List<ScanPixelDwell> ScanPixelDwellList { get; set; }
        /// <summary>
        /// 选择的像素时间
        /// </summary>
        public ScanPixelDwell SelectedScanPixelDwell { get; set; }

        /// <summary>
        /// 选择像素时间
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int SelectScanPixelDwell(int id)
        {
            if (ScanPixelDwellList.Where(p => p.ID == id).FirstOrDefault() == null)
            {
                return ApiCode.ConfigSelectScanPixelFailed;
            }
            foreach (ScanPixelDwell pixelDwell in ScanPixelDwellList)
            {
                if (pixelDwell.ID == id)
                {
                    pixelDwell.IsEnabled = true;
                    SelectedScanPixelDwell = pixelDwell;
                }
                else
                {
                    pixelDwell.IsEnabled = false;
                }
            }
            return ApiCode.Success;
        }
        /// <summary>
        /// 设置双向扫描时候的像素补偿
        /// </summary>
        /// <param name="id"></param>
        /// <param name="scanPixelCalibration"></param>
        /// <returns></returns>
        public int SetScanPixelCalibration(int id, int scanPixelCalibration)
        {
            ScanPixelDwell scanPixelDwell = ScanPixelDwellList.Find(p => p.ID == id);
            if (scanPixelDwell == null)
            {
                return ApiCode.ConfigScanPixelCalibrationFailed;
            }
            scanPixelDwell.ScanPixelCalibration = scanPixelCalibration;
            return ApiCode.Success;
        }
        /// <summary>
        /// 设置每行采集像素截取时的偏移量
        /// </summary>
        /// <param name="id"></param>
        /// <param name="scanPixelOffset"></param>
        /// <returns></returns>
        public int SetScanPixelOffset(int id, int scanPixelOffset)
        {
            ScanPixelDwell scanPixelDwell = ScanPixelDwellList.Find(p => p.ID == id);
            if (scanPixelDwell == null)
            {
                return ApiCode.ConfigScanPixelCalibrationFailed;
            }
            scanPixelDwell.ScanPixelOffset = scanPixelOffset;
            return ApiCode.Success;
        }
        /// <summary>
        /// 设置扫描像素缩放系数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="scanPixelScale"></param>
        /// <returns></returns>
        public int SetScanPixelScale(int id, int scanPixelScale)
        {
            ScanPixelDwell scanPixelDwell = ScanPixelDwellList.Find(p => p.ID == id);
            if (scanPixelDwell == null)
            {
                return ApiCode.ConfigScanPixelCalibrationFailed;
            }
            scanPixelDwell.ScanPixelScale = scanPixelScale;
            return ApiCode.Success;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 跳行扫描开关
        /// </summary>
        public bool ScanLineSkipEnabled { get; set; }
        /// <summary>
        /// 跳行扫描列表
        /// </summary>
        public List<ScanLineSkip> ScanLineSkipList { get; set; }
        /// <summary>
        /// 选择的跳行扫描
        /// </summary>
        public ScanLineSkip SelectedScanLineSkip { get; set; }
        /// <summary>
        /// 选择跳行扫描
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int SelectLineSkip(int id)
        {
            ScanLineSkip scanLineSkip = ScanLineSkipList.Find(p => p.ID == id);
            if (scanLineSkip == null)
            {
                return ApiCode.ConfigSelectLineSkipFailed;
            }
            SelectedScanLineSkip = scanLineSkip;
            return ApiCode.Success;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        
        public ScanChannel ScanChannel405 { get; set; }

        public ScanChannel ScanChannel488 { get; set; }

        public ScanChannel ScanChannel561 { get; set; }

        public ScanChannel ScanChannel640 { get; set; }

        public ScanChannel[] ScanChannels { get; set; }

        public int SetChannelGain(int id, int gain)
        {
            ScanChannel scanChannel = ScanChannels.FirstOrDefault(p => p.ID == id);
            if (scanChannel == null)
            {
                return ApiCode.ConfigSetChannelGainFailed;
            }
            scanChannel.Gain = gain;
            Logger.Info(string.Format("Channel Gain [{0}:{1}].", id, gain));
            return ApiCode.Success;
        }

        public int SetChannelOffset(int id, int offset)
        {
            ScanChannel scanChannel = ScanChannels.FirstOrDefault(p => p.ID == id);
            if (scanChannel == null)
            {
                return ApiCode.ConfigSetChannelOffsetFailed;
            }
            scanChannel.Offset = offset;
            Logger.Info(string.Format("Channel Offset [{0}:{1}].", id, offset));
            return ApiCode.Success;
        }

        public int SetChannelPower(int id, int power)
        {
            ScanChannel scanChannel = ScanChannels.FirstOrDefault(p => p.ID == id);
            if (scanChannel == null)
            {
                return ApiCode.ConfigSetChannelLaserPowerFailed;
            }
            scanChannel.LaserPower = power;
            Logger.Info(string.Format("Channel Power [{0}:{1}].", id, power));
            return ApiCode.Success;
        }

        public int SetChannelLaserColor(int id, Color color)
        {
            ScanChannel scanChannel = ScanChannels.FirstOrDefault(p => p.ID == id);
            if (scanChannel == null)
            {
                return ApiCode.ConfigSetChannelLaserColorFailed;
            }
            scanChannel.LaserColor = color;
            Logger.Info(string.Format("Channel Laser Color [{0}:{1}].", id, color));
            return ApiCode.Success;
        }

        public int SetChannelPseudoColor(int id, Color color)
        {
            ScanChannel scanChannel = ScanChannels.FirstOrDefault(p => p.ID == id);
            if (scanChannel == null)
            {
                return ApiCode.ConfigSetChannelPseudoColorFailed;
            }
            scanChannel.PseudoColor = color;
            Logger.Info(string.Format("Channel Pseudo Color [{0}:{1}].", id, color));
            return ApiCode.Success;
        }

        public int SetChannelPinHole(int id, int pinHole)
        {
            ScanChannel scanChannel = ScanChannels.FirstOrDefault(p => p.ID == id);
            if (scanChannel == null)
            {
                return ApiCode.ConfigSetChannelPinHoleFailed;
            }
            scanChannel.PinHole = pinHole;
            Logger.Info(string.Format("Channel Pin Hole [{0}:{1}].", id, pinHole));
            return ApiCode.Success;
        }

        public int SetChannelStatus(int id, bool activated)
        {
            ScanChannel scanChannel = ScanChannels.FirstOrDefault(p => p.ID == id);
            if (scanChannel == null)
            {
                return ApiCode.ConfigSetChannelStatusFailed;
            }
            scanChannel.Activated = activated;
            Logger.Info(string.Format("Channel Status [{0}:{1}].", id, activated));
            return ApiCode.Success;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 扫描区域类型列表
        /// </summary>
        public List<ScanAreaType> ScanAreaTypeList { get; set; }
        /// <summary>
        /// 选择的扫描区域类型
        /// </summary>
        public ScanAreaType SelectedScanAreaType { get; set; }
        /// <summary>
        /// 选择的扫描区域
        /// </summary>
        public ScanArea SelectedScanArea { get; set; }
        /// <summary>
        /// 全视场
        /// </summary>
        public ScanArea FullScanArea { get; set; }
        /// <summary>
        /// 像素尺寸
        /// </summary>
        public float ScanPixelSize { get; set; }
        /// <summary>
        /// 设置扫描区域
        /// </summary>
        /// <param name="scanRange"></param>
        /// <returns></returns>
        public int SetScanArea(RectangleF scanRange)
        {
            if (!FullScanArea.ScanRange.Contains(scanRange))
            {
                return ApiCode.ConfigSetScanAreaFailed;
            }
            SelectedScanArea.Update(scanRange);
            ScanPixelSize = SelectedScanArea.ScanRange.Width / SelectedScanPixel.Data;
            Logger.Info(string.Format("Selected Scan Area [{0}].", SelectedScanArea.ScanRange));
            return ApiCode.Success;
        }
        /// <summary>
        /// 设置全视场的扫描范围
        /// </summary>
        /// <param name="scanRange"></param>
        /// <returns></returns>
        public int SetFullScanArea(RectangleF scanRange)
        {
            FullScanArea.Update(scanRange);
            Logger.Info(string.Format("Full Scan Area [{0}].", FullScanArea.ScanRange));
            return ApiCode.Success;
        }
        /// <summary>
        /// 设置全视场的扫描范围
        /// </summary>
        /// <param name="scanRange"></param>
        /// <returns></returns>
        public int SetFullScanArea(float scanRange)
        {
            FullScanArea.Update(new System.Drawing.RectangleF(-scanRange / 2, -scanRange / 2, scanRange, scanRange));
            Logger.Info(string.Format("Full Scan Area [{0}].", FullScanArea.ScanRange));
            return ApiCode.Success;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 扫描振镜属性
        /// </summary>
        public GalvoProperty GalvoAttr { get; set; }
        /// <summary>
        /// 探测器属性
        /// </summary>
        public DetectorProperty Detector { get; set; }

        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 激光器端口
        /// </summary>
        public string LaserPort { get; set; }

        ///////////////////////////////////////////////////////////////////////////////////////////
        public static Config GetConfig()
        {
            if (pConfig == null)
            {
                lock (locker)
                {
                    if (pConfig == null)
                    {
                        pConfig = new Config();
                    }
                }
            }
            return pConfig;
        }

        /// <summary>
        /// 通道数量
        /// </summary>
        /// <returns></returns>
        public int GetChannelNum()
        {
            return ChannelNum;
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

        public ScanChannel FindScanChannel(int id)
        {
            return ScanChannels.FirstOrDefault(p => p.ID == id);
        }

        /// <summary>
        /// 扩展后的扫描范围
        /// </summary>
        /// <returns></returns>
        public ScanArea GetExtendScanArea()
        {
            RectangleF scanRange = SelectedScanArea.ScanRange;
            float xExtendRange = ScanArea.ExtendLineTime * scanRange.Width / (SelectedScanPixelDwell.Data * SelectedScanPixel.Data);
            float yExtendRange = ScanArea.ExtendRowCount * ScanPixelSize;
            return new ScanArea(new RectangleF(scanRange.X - xExtendRange / 2, scanRange.Y - yExtendRange / 2, scanRange.Width + xExtendRange, scanRange.Height + yExtendRange));
        }

        /// <summary>
        /// 扩展后的X像素数
        /// </summary>
        /// <returns></returns>
        public int GetExtendScanXPixels()
        {
            return SelectedScanPixel.Data + (ScanArea.ExtendLineTime >> 1) / SelectedScanPixelDwell.Data * 2;
        }

        /// <summary>
        /// 扩展后的Y像素数
        /// </summary>
        /// <returns></returns>
        public int GetExtendScanYPixels()
        {
            return SelectedScanPixel.Data + ScanArea.ExtendRowCount;
        }

        private Config()
        {
            InputSampleRate = 5e5;
            // 采集模式
            ScanLiveMode = new ScanAcquisition(ScanAcquisition.Live);
            ScanCaptureMode = new ScanAcquisition(ScanAcquisition.Capture);
            // 扫描头
            TwoGalvo = new ScanHead(ScanHead.TwoGalvo);
            ThreeGalvo = new ScanHead(ScanHead.ThreeGalvo);
            // 扫描模式
            Resonant = new ScanMode(ScanMode.Resonant);
            Galvano = new ScanMode(ScanMode.Galvano);
            // 扫描方向
            Unidirection = new ScanDirection(ScanDirection.Unidirection);
            Bidirection = new ScanDirection(ScanDirection.Bidirection);
            // 像素时间
            FastModeEnabled = false;
            ScanPixelDwellList = ScanPixelDwell.Initialize();
            SelectedScanPixelDwell = ScanPixelDwellList.Where(p => p.IsEnabled).First();
            // 扫描像素
            ScanPixelList = ScanPixel.Initialize();
            SelectedScanPixel = ScanPixelList.Where(p => p.IsEnabled).First();
            // 跳行扫描
            ScanLineSkipEnabled = Settings.Default.ScanLineSkipEnabled;
            ScanLineSkipList = ScanLineSkip.Initialize();
            SelectedScanLineSkip = ScanLineSkipList.Where(p => p.ID == Settings.Default.ScanLineSkip).First();
            // 扫描通道
            ScanChannel405 = new ScanChannel(ScanChannel.Channel405);
            ScanChannel488 = new ScanChannel(ScanChannel.Channel488);
            ScanChannel561 = new ScanChannel(ScanChannel.Channel561);
            ScanChannel640 = new ScanChannel(ScanChannel.Channel640);
            ScanChannels = new ScanChannel[] { ScanChannel405, ScanChannel488, ScanChannel561, ScanChannel640 };
            // 扫描类型 & 范围
            ScanAreaTypeList = new List<ScanAreaType>()
            {
                new ScanAreaType(ScanAreaType.Square),
                new ScanAreaType(ScanAreaType.Bank),
                new ScanAreaType(ScanAreaType.Line)
            };
            FullScanArea = ScanArea.CreateFullScanArea();
            SelectedScanArea = ScanArea.CreateFullScanArea();
            // 像素尺寸
            ScanPixelSize = SelectedScanArea.ScanRange.Width / SelectedScanPixel.Data;
            // 振镜参数和探测器参数
            GalvoAttr = new GalvoProperty();
            Detector = new DetectorProperty();
            // 激光端口
            LaserPort = "COM2";
        }

    }
}
