using log4net;
using NanoInsight.Engine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Engine.Device
{
    public class Laser
    {
        ///////////////////////////////////////////////////////////////////////////////////////////
        [DllImport("laserlib2.dll")]
        static extern bool LaserLib2_Open(string portName);
        [DllImport("laserlib2.dll")]
        static extern bool LaserLib2_Close();
        [DllImport("laserlib2.dll")]
        static extern bool LaserLib2_Active(int channel, bool fOn);
        [DllImport("laserlib2.dll")]
        static extern bool LaserLib2_SetPower(int channel, float power);
        [DllImport("laserlib2.dll")]
        static extern bool LaserLib2_SetParam(float p1, float p2, float p3, float p4, float c1, float c2, float c3, float c4);
        ///////////////////////////////////////////////////////////////////////////////////////////
        private static readonly ILog Logger = LogManager.GetLogger("info");
        ///////////////////////////////////////////////////////////////////////////////////////////

        private static bool m_connected;

        static Laser()
        {
            m_connected = false;
        }

        public static bool IsConnected()
        {
            return m_connected;
        }

        /// <summary>
        /// 连接激光端口
        /// </summary>
        /// <param name="portName"></param>
        /// <returns></returns>
        public static int Connect(string portName)
        {
            try
            {
                if (!LaserLib2_Open(portName))
                {
                    Logger.Info(string.Format("Laser connect failed:[LaserLib2_Open][{0}].", ApiCode.LaserConnectFailed));
                    return ApiCode.LaserConnectFailed;
                }
                if (!LaserLib2_SetParam(1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f))
                {
                    Logger.Error(string.Format("Laser connect failed:[LaserLib2_SetParam][{0}].", ApiCode.LaserConnectFailed));
                    return ApiCode.LaserConnectFailed;
                }
                m_connected = true;
                Logger.Info(string.Format("Laser connect success:[{0}].", ApiCode.Success));
                return ApiCode.Success;
            }
            catch (Exception e)
            {
                Logger.Error(string.Format("Laser connect exception: [{0}].", e));
                return ApiCode.LaserConnectFailed;
            }
        }

        /// <summary>
        /// 关闭激光端口
        /// </summary>
        /// <returns></returns>
        public static int Release()
        {
            if (m_connected == false)
            {
                Logger.Info(string.Format("Laser already released."));
                return ApiCode.Success;
            }

            try
            {
                if (!LaserLib2_Close())
                {
                    Logger.Error(string.Format("Laser release failed:[LaserLib2_Close][{0}].", ApiCode.LaserReleaseFailed));
                    return ApiCode.LaserReleaseFailed;
                }
                m_connected = false;
                Logger.Info(string.Format("Laser release success:[{0}].", ApiCode.Success));
                return ApiCode.Success;
            }
            catch (Exception e)
            {
                Logger.Error(string.Format("Laser release exception: [{0}].", e));
                return ApiCode.LaserReleaseFailed;
            }
        }

        /// <summary>
        /// 打开激光通道
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int OpenChannel(int id)
        {
            int channel = GetChannelIndex(id);
            try
            {
                if (!LaserLib2_Active(channel, true))
                {
                    Logger.Error(string.Format("Laser open channel[{0}] failed:[LaserLib2_Active][{1}].", id, ApiCode.LaserOpenChannelFailed));
                    return ApiCode.LaserOpenChannelFailed;
                }
                Logger.Info(string.Format("Laser open channel[{0}] success:[LaserLib2_Active][{1}].", id, ApiCode.Success));
                return ApiCode.Success;
            }
            catch (Exception e)
            {
                Logger.Error(string.Format("Laser open channel[{0}] exception: [{1}].", id, e));
                return ApiCode.LaserOpenChannelFailed;
            }
        }

        /// <summary>
        /// 关闭激光通道
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int CloseChannel(int id)
        {
            int channel = GetChannelIndex(id);
            try
            {
                if (!LaserLib2_Active(channel, false))
                {
                    Logger.Error(string.Format("Laser close channel[{0}] failed:[LaserLib2_Active][{1}].", id, ApiCode.LaserCloseChannelFailed));
                    return ApiCode.LaserCloseChannelFailed;
                }
                Logger.Info(string.Format("Laser close channel[{0}] success:[LaserLib2_Active][{1}].", id, ApiCode.Success));
                return ApiCode.Success;
            }
            catch (Exception e)
            {
                Logger.Error(string.Format("Laser close channel[{0}] exception: [{1}].", id, e));
                return ApiCode.LaserCloseChannelFailed;
            }
        }

        /// <summary>
        /// 设置激光功率
        /// </summary>
        /// <param name="id"></param>
        /// <param name="power"></param>
        /// <returns></returns>
        public static int SetChannelPower(int id, double power)
        {
            int channel = GetChannelIndex(id);
            int configValue = PowerToConfigValue(power);
            try
            {
                if (!LaserLib2_SetPower(channel, configValue))
                {
                    Logger.Error(string.Format("Laser set channel[{0}] power[{1}] failed:[LaserLib2_SetPower][{2}].", id, power, ApiCode.LaserSetPowerFailed));
                    return ApiCode.LaserSetPowerFailed;
                }
                Logger.Info(string.Format("Laser set channel[{0}] power[{1}] success:[LaserLib2_SetPower][{2}].", id, power, ApiCode.Success));
                return ApiCode.Success;
            }
            catch (Exception e)
            {
                Logger.Error(string.Format("Laser set channel[{0}] power[{1}] exception: [{2}].", id, power, e));
                return ApiCode.LaserSetPowerFailed;
            }
        }

        private static int GetChannelIndex(int id)
        {
            switch (id)
            {
                case 0:
                    return 2;
                case 1:
                    return 1;
                case 2:
                    return 4;
                case 3:
                    return 3;
                default:
                    throw new ArgumentOutOfRangeException("ID Exception");
            }
        }

        public static int PowerToConfigValue(double power)
        {
            return (int)(power * 10.0);
        }

        public static double ConfigValueToPower(int configValue)
        {
            return (double)configValue / 10.0;
        }

    }
}
