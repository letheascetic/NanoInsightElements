using NanoInsight.Engine.Properties;
using System;
using System.Drawing;

namespace NanoInsight.Engine.Core
{
    /// <summary>
    /// 通道增益更新事件委托
    /// </summary>
    /// <param name="channel"></param>
    /// <returns></returns>
    public delegate int ChannelGainChangedEventHandler(ScanChannel channel);

    /// <summary>
    /// 通道偏置更新事件委托
    /// </summary>
    /// <param name="channel"></param>
    /// <returns></returns>
    public delegate int ChannelOffsetChangedEventHandler(ScanChannel channel);

    /// <summary>
    /// 通道功率更新事件委托
    /// </summary>
    /// <param name="channel"></param>
    /// <returns></returns>
    public delegate int ChannelPowerChangedEventHandler(ScanChannel channel);

    /// <summary>
    /// 通道激活状态更新事件委托
    /// </summary>
    /// <param name="channel"></param>
    /// <returns></returns>
    public delegate int ChannelActivateChangedEventHandler(ScanChannel channel);

    /// <summary>
    /// PinHole更新事件
    /// </summary>
    /// <param name="channel"></param>
    /// <returns></returns>
    public delegate int ChannelPinHoleChangedEventHandler(ScanChannel channel);

    /// <summary>
    /// 扫描通道
    /// </summary>
    public class ScanChannel
    {
        ///////////////////////////////////////////////////////////////////////////////////////////
        public const int Channel405 = 0;
        public const int Channel488 = 1;
        public const int Channel561 = 2;
        public const int Channel640 = 3;
        ///////////////////////////////////////////////////////////////////////////////////////////

        public int ID { get; set; }

        public string Name { get; set; }

        public int LaserPower { get; set; }

        public Color LaserColor { get; set; }

        public string LaserWaveLength { get; set; }

        public bool Activated { get; set; }

        public int Gain { get; set; }

        public int PinHole { get; set; }

        public int Offset { get; set; }

        public int Gamma { get; set; }

        public Color PseudoColor { get; set; }

        public ScanChannel(int id)
        {
            switch (id)
            {
                case Channel405:
                    ID = Channel405;
                    Name = "通道1";
                    LaserPower = Settings.Default.ScanChannel405LaserPower;
                    LaserColor = Settings.Default.ScanChannel561LaserColor;
                    LaserWaveLength = "405nm";
                    Activated = Settings.Default.ScanChannel405Activated;
                    Gain = Settings.Default.ScanChannel405Gain;
                    Offset = Settings.Default.ScanChannel405Offset;
                    Gamma = Settings.Default.ScanChannel405Gamma;
                    PseudoColor = Settings.Default.ScanChannel405PseudoColor;
                    PinHole = 1;
                    break;
                case Channel488:
                    ID = Channel488;
                    Name = "通道2";
                    LaserPower = Settings.Default.ScanChannel488LaserPower;
                    LaserColor = Settings.Default.ScanChannel488LaserColor;
                    LaserWaveLength = "488nm";
                    Activated = Settings.Default.ScanChannel488Activated;
                    Gain = Settings.Default.ScanChannel488Gain;
                    Offset = Settings.Default.ScanChannel488Offset;
                    Gamma = Settings.Default.ScanChannel488Gamma;
                    PseudoColor = Settings.Default.ScanChannel488PseudoColor;
                    PinHole = 1;
                    break;
                case Channel561:
                    ID = Channel561;
                    Name = "通道3";
                    LaserPower = Settings.Default.ScanChannel561LaserPower;
                    LaserColor = Settings.Default.ScanChannel561LaserColor;
                    LaserWaveLength = "561nm";
                    Activated = Settings.Default.ScanChannel561Activated;
                    Gain = Settings.Default.ScanChannel561Gain;
                    Offset = Settings.Default.ScanChannel561Offset;
                    Gamma = Settings.Default.ScanChannel561Gamma;
                    PseudoColor = Settings.Default.ScanChannel561PseudoColor;
                    PinHole = 1;
                    break;
                case Channel640:
                    ID = Channel640;
                    Name = "通道4";
                    LaserPower = Settings.Default.ScanChannel640LaserPower;
                    LaserColor = Settings.Default.ScanChannel640LaserColor;
                    LaserWaveLength = "640nm";
                    Activated = Settings.Default.ScanChannel640Activated;
                    Gain = Settings.Default.ScanChannel640Gain;
                    Offset = Settings.Default.ScanChannel640Offset;
                    Gamma = Settings.Default.ScanChannel640Gamma;
                    PseudoColor = Settings.Default.ScanChannel640PseudoColor;
                    PinHole = 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("ID Exception");
            }
        }

    }
}
