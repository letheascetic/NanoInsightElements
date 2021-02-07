using NanoInsight.Engine.Device;
using NanoInsight.Engine.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Engine.Attribute
{
    /// <summary>
    /// 探测器类型：Apd or Pmt
    /// </summary>
    public class DetectorType : ScanProperty
    {
        ///////////////////////////////////////////////////////////////////////////////////////////
        public const int Pmt = 0;
        public const int Apd = 1;
        ///////////////////////////////////////////////////////////////////////////////////////////

        public DetectorType(int id)
        {
            if (id == Pmt)
            {
                ID = id;
                Text = "PMT";
                IsEnabled = Settings.Default.DetectorType == Pmt;
            }
            else if (id == Apd)
            {
                ID = id;
                Text = "Apd";
                IsEnabled = Settings.Default.DetectorType == Apd;
            }
            else
            {
                throw new ArgumentOutOfRangeException("ID Exception");
            }
        }
    }

    /// <summary>
    /// Pmt配置
    /// </summary>
    public class PmtChannel
    {
        public int ID { get; set; }
        public string AiChannel { get; set; }
        
        public PmtChannel(int id)
        {
            string[] devices = NiDaq.GetDeviceNames();
            string deviceName = devices.Length > 0 ? devices[0] : Settings.Default.NiDeviceName;

            if (id >= 0 && id <= 3)
            {
                ID = id;
                AiChannel = string.Concat(deviceName, string.Format("/ai{0}", id));
            }
            else
            {
                throw new ArgumentOutOfRangeException("ID Exception");
            }
        }
    }

    /// <summary>
    /// Apd配置
    /// </summary>
    public class ApdChannel
    {
        public int ID { get; set; }
        /// <summary>
        /// 使用的计数器名
        /// </summary>
        public string CiSource { get; set; }
        /// <summary>
        /// 使用的计数器的输入端
        /// </summary>
        public string CiChannel { get; set; }

        public ApdChannel(int id)
        {
            string[] devices = NiDaq.GetDeviceNames();
            string deviceName = devices.Length > 0 ? devices[0] : Settings.Default.NiDeviceName;

            switch (id)
            {
                case 0:
                    ID = id;
                    CiSource = string.Concat(deviceName, "/ctr0");
                    CiChannel = string.Concat("/", deviceName, "/PFI8");
                    break;
                case 1:
                    ID = id;
                    CiSource = string.Concat(deviceName, "/ctr1");
                    CiChannel = string.Concat("/", deviceName, "/PFI3");
                    break;
                case 2:
                    ID = id;
                    CiSource = string.Concat(deviceName, "/ctr2");
                    CiChannel = string.Concat("/", deviceName, "/PFI0");
                    break;
                case 3:
                    ID = id;
                    CiSource = string.Concat(deviceName, "/ctr3");
                    CiChannel = string.Concat("/", deviceName, "/PFI5");
                    break;
                default:
                    throw new ArgumentOutOfRangeException("ID Exception");
            }
        }
    }

    /// <summary>
    /// 探测器配置
    /// </summary>
    public class DetectorProperty
    {
        public DetectorType Pmt { get; set; }
        public DetectorType Apd { get; set; }

        public DetectorType CurrentDetecor
        {
            get { return Pmt.IsEnabled ? Pmt : Apd; }
        }
        
        /// <summary>
        /// 启动同步源
        /// </summary>
        public string StartTrigger { get; set; }

        /// <summary>
        /// 触发信号[输出端]
        /// </summary>
        public string TriggerSignal { get; set; }

        /// <summary>
        /// 触发接收端
        /// </summary>
        public string TriggerReceive { get; set; }

        public PmtChannel PmtChannel405 { get; set; }
        public PmtChannel PmtChannel488 { get; set; }
        public PmtChannel PmtChannel561 { get; set; }
        public PmtChannel PmtChannel640 { get; set; }

        public ApdChannel ApdChannel405 { get; set; }
        public ApdChannel ApdChannel488 { get; set; }
        public ApdChannel ApdChannel561 { get; set; }
        public ApdChannel ApdChannel640 { get; set; }

        public DetectorProperty()
        {
            Apd = new DetectorType(DetectorType.Apd);
            Pmt = new DetectorType(DetectorType.Pmt);

            string[] devices = NiDaq.GetDeviceNames();
            string deviceName = devices.Length > 0 ? devices[0] : Settings.Default.NiDeviceName;

            StartTrigger = string.Concat("/", deviceName, Settings.Default.StartTrigger);
            TriggerSignal = string.Concat(deviceName, Settings.Default.TriggerSignal);
            TriggerReceive = string.Concat("/", deviceName, Settings.Default.TriggerReceive);

            PmtChannel405 = new PmtChannel(0);
            PmtChannel488 = new PmtChannel(1);
            PmtChannel561 = new PmtChannel(2);
            PmtChannel640 = new PmtChannel(3);

            ApdChannel405 = new ApdChannel(0);
            ApdChannel488 = new ApdChannel(1);
            ApdChannel561 = new ApdChannel(2);
            ApdChannel640 = new ApdChannel(3);

        }

        public PmtChannel FindPmtChannel(int id)
        {
            switch (id)
            {
                case 0:
                    return PmtChannel405;
                case 1:
                    return PmtChannel488;
                case 2:
                    return PmtChannel561;
                case 3:
                    return PmtChannel640;
                default:
                    return null;
            }
        }

        public ApdChannel FindApdChannel(int id)
        {
            switch (id)
            {
                case 0:
                    return ApdChannel405;
                case 1:
                    return ApdChannel488;
                case 2:
                    return ApdChannel561;
                case 3:
                    return ApdChannel640;
                default:
                    return null;
            }
        }

    }

}
