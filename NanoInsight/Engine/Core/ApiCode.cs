using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Engine.Core
{
    // 60 61 62
    public static class ApiCode
    {
        public const int Success = 0x00000000;
        public const int Failed = 0x1F000000;
        /* error for laser */
        public const int LaserExecuteFailed = 0x11000000;
        public const int LaserConnectFailed = 0x11000001;
        public const int LaserReleaseFailed = 0x11000002;
        public const int LaserOpenChannelFailed = 0x11000004;
        public const int LaserCloseChannelFailed = 0x11000008;
        public const int LaserSetPowerFailed = 0x11000010;
        /* error for ni card */

        /* error for usb dac */
        public const int UsbDacExecuteFailed = 0x12000000;
        public const int UsbDacOpenFailed = 0x12000001;
        public const int UsbDacReleaseFailed = 0x12000002;
        public const int UsbDacSetAllOutFailed = 0x12000004;
        public const int UsbDacSetChannelOutFailed = 0x12000008;
        public const int UsbDacSetZeroCalibrationFailed = 0x12000010;
        public const int UsbDacSetGainCalibrationFailed = 0x12000020;
        public const int UsbDacSetRegisterFailed = 0x12000040;
        public const int UsbDacReadConfigFailed = 0x12000080;
        public const int UsbDacWriteConfigFailed = 0x12000100;
        /* error for config */
        public const int ConfigExecuteFailed = 0x13000000;
        public const int ConfigStartAcquisitionFailed = 0x13000001;
        public const int ConfigSetScanHeadFailed = 0x13000002;
        public const int ConfigSetScanDirectionFailed = 0x13000004;
        public const int ConfigSetScanModeFailed = 0x13000008;
        public const int ConfigSelectScanPixelFailed = 0x1300010;
        public const int ConfigSelectScanPixelDwellFailed = 0x13000020;
        public const int ConfigScanPixelCalibrationFailed = 0x13000040;
        public const int ConfigScanPixelOffsetFailed = 0x13000080;
        public const int ConfigScanPixelScaleFailed = 0x13000100;
        public const int ConfigSelectLineSkipFailed = 0x13000200;
        public const int ConfigSetChannelGainFailed = 0x13000400;
        public const int ConfigSetChannelLaserPowerFailed = 0x13000800;
        public const int ConfigSetChannelOffsetFailed = 0x13001000;
        public const int ConfigSetChannelStatusFailed = 0x13002000;
        public const int ConfigSetChannelLaserColorFailed = 0x13004000;
        public const int ConfigSetChannelPseudoColorFailed = 0x13008000;
        public const int ConfigSetChannelPinHoleFailed = 0x13010000;
        public const int ConfigSetChannelGammaFailed = 0x13020000;
        public const int ConfigSetScanAreaFailed = 0x13040000;


        /// <summary>
        /// 是否成功
        /// </summary>
        /// <param name="apiCode"></param>
        /// <returns></returns>
        public static bool IsSuccessful(int apiCode)
        {
            return (Success & apiCode) == Success;
        }

    }
}
