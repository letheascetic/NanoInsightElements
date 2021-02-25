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
    public class ScanChannelModel : ObservableObject
    {
        ///////////////////////////////////////////////////////////////////////////////////////////
        private int id;                     // 通道ID
        private string name;                // 通道名

        private int laserPower;             // 激光功率
        private Color laserColor;           // 激光颜色
        private string laserWaveLength;     // 激光波长

        private bool activated;             // 通道激活状态
        private int gain;                   // 增益
        private int offset;                 // 偏置
        private int gamma;                  // 伽马
        private Color pseudoColor;          // 伪彩色
        private int pinHole;

        ///////////////////////////////////////////////////////////////////////////////////////////
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
        /// 激光功率
        /// </summary>
        public int LaserPower
        {
            get { return laserPower; }
            set { laserPower = value; RaisePropertyChanged(() => LaserPower); }
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
        /// 通道状态：激活 or 关闭
        /// </summary>
        public bool Activated
        {
            get { return activated; }
            set { activated = value; RaisePropertyChanged(() => Activated); }
        }

        /// <summary>
        /// 小孔孔径
        /// </summary>
        public int PinHole
        {
            get { return pinHole; }
            set { pinHole = value; RaisePropertyChanged(() => PinHole); }
        }

        /// <summary>
        /// 增益
        /// </summary>
        public int Gain
        {
            get { return gain; }
            set { gain = value; RaisePropertyChanged(() => Gain); }
        }

        /// <summary>
        /// 偏置
        /// </summary>
        public int Offset
        {
            get { return offset; }
            set { offset = value; RaisePropertyChanged(() => Offset); }
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

        public ScanChannelModel(ScanChannel scanChannel)
        {
            ID = scanChannel.ID;
            Name = scanChannel.Name;
            LaserPower = scanChannel.LaserPower;
            LaserColor = scanChannel.LaserColor;
            LaserWaveLength = scanChannel.LaserWaveLength;
            Activated = scanChannel.Activated;
            Gain = scanChannel.Gain;
            Offset = scanChannel.ImageSettings.Offset;
            Gamma = scanChannel.ImageSettings.Gamma;
            PseudoColor = scanChannel.ImageSettings.PseudoColor;
            PinHole = scanChannel.PinHole;
        }

    }
}
