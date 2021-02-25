using GalaSoft.MvvmLight;
using NanoInsight.Engine.Attribute;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Viewer.Model
{
    public class ScanChannelImageModel : ObservableObject
    {
        ///////////////////////////////////////////////////////////////////////////////////////////
        private int id;                     // 通道ID
        private string name;                // 通道名

        private Color laserColor;           // 激光颜色
        private string laserWaveLength;     // 激光波长
        private bool activated;             // 通道激活状态

        private Color pseudoColor;          // 伪彩色
        private int brightness;             // 亮度
        private int contrast;               // 对比度
        private int gamma;                  // 伽马
        private int gammaMin;               // 伽马校正最小值
        private int gammaMax;               // 伽马校正最大值

        /// <summary>
        /// 通道ID
        /// </summary>
        public int ID
        {
            get { return id; }
            set { id = value; RaisePropertyChanged(() => ID); }
        }

        /// <summary>
        /// 通道名
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; RaisePropertyChanged(() => Name); }
        }

        /// <summary>
        /// 激光颜色
        /// </summary>
        public Color LaserColor
        {
            get { return laserColor; }
            set { laserColor = value; RaisePropertyChanged(() => LaserColor); }
        }

        /// <summary>
        /// 激光波长
        /// </summary>
        public string LaserWaveLength
        {
            get { return laserWaveLength; }
            set { laserWaveLength = value; RaisePropertyChanged(() => LaserWaveLength); }
        }

        /// <summary>
        /// 伽马校正
        /// </summary>
        public int Gamma
        {
            get { return gamma; }
            set { gamma = value; RaisePropertyChanged(() => gamma); }
        }

        /// <summary>
        /// 伪彩色
        /// </summary>
        public Color PseudoColor
        {
            get { return pseudoColor; }
            set { pseudoColor = value; RaisePropertyChanged(() => PseudoColor); }
        }

        /// <summary>
        /// 通道状态：激活 or 关闭
        /// </summary>
        public bool Activated
        {
            get { return activated; }
            set { activated = value; RaisePropertyChanged(() => Activated); }
        }

        /// <summary>
        /// 亮度
        /// </summary>
        public int Brightness
        {
            get { return brightness; }
            set { brightness = value; RaisePropertyChanged(() => Brightness); }
        }

        /// <summary>
        /// 对比度
        /// </summary>
        public int Contrast
        {
            get { return contrast; }
            set { contrast = value; RaisePropertyChanged(() => Contrast); }
        }

        /// <summary>
        /// gamma校正最小值
        /// </summary>
        public int GammaMin
        {
            get { return gammaMin; }
            set { gammaMin = value; RaisePropertyChanged(() => GammaMin); }
        }

        /// <summary>
        /// gamma校正最大值
        /// </summary>
        public int GammaMax
        {
            get { return gammaMax; }
            set { gammaMax = value; RaisePropertyChanged(() => GammaMax); }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        public ScanChannelImageModel(ScanChannel scanChannel)
        {
            ID = scanChannel.ID;
            Name = scanChannel.Name;
            LaserColor = scanChannel.LaserColor;
            LaserWaveLength = scanChannel.LaserWaveLength;
            Activated = scanChannel.Activated;
            Gamma = scanChannel.ImageSettings.Gamma;
            PseudoColor = scanChannel.ImageSettings.PseudoColor;
            Brightness = scanChannel.ImageSettings.Brightness;
            Contrast = scanChannel.ImageSettings.Contrast;
            GammaMin = scanChannel.ImageSettings.ThresholdMin;
            GammaMax = scanChannel.ImageSettings.ThresholdMax;
        }

    }
}
