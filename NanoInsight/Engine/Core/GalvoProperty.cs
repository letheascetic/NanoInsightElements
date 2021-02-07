using NanoInsight.Engine.Device;
using NanoInsight.Engine.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Engine.Core
{
    public class GalvoProperty
    {
        /// <summary>
        /// X振镜偏置电压
        /// </summary>
        public double XGalvoOffsetVoltage { get; set; }
        /// <summary>
        /// Y振镜偏置电压
        /// </summary>
        public double YGalvoOffsetVoltage { get; set; }
        /// <summary>
        /// Y2振镜偏置电压
        /// </summary>
        public double Y2GalvoOffsetVoltage { get; set; }

        /// <summary>
        /// 振镜响应时间
        /// </summary>
        public double GalvoResponseTime { get; set; }

        /// <summary>
        /// X振镜校准电压
        /// </summary>
        public double XGalvoCalibrationVoltage { get; set; }

        /// <summary>
        /// Y振镜校准电压
        /// </summary>
        public double YGalvoCalibrationVoltage { get; set; }

        /// <summary>
        /// X振镜模拟输出通道
        /// </summary>
        public string XGalvoAoChannel { get; set; }

        /// <summary>
        /// Y振镜模拟输出通道
        /// </summary>
        public string YGalvoAoChannel { get; set; }

        /// <summary>
        /// Y2补偿镜模拟输出通道
        /// </summary>
        public string Y2GalvoAoChannel { get; set; }

        public GalvoProperty()
        {
            XGalvoOffsetVoltage = Settings.Default.XGalvoOffsetVoltage;
            YGalvoOffsetVoltage = Settings.Default.YGalvoOffsetVoltage;
            Y2GalvoOffsetVoltage = Settings.Default.Y2GalvoOffsetVoltage;
            GalvoResponseTime = Settings.Default.GalvoResponseTime;
            XGalvoCalibrationVoltage = Settings.Default.XGalvoCalibrationVoltage;
            YGalvoCalibrationVoltage = Settings.Default.YGalvoCalibrationVoltage;

            string[] devices = NiDaq.GetDeviceNames();
            string deviceName = devices.Length > 0 ? devices[0] : Settings.Default.NiDeviceName;

            XGalvoAoChannel = string.Concat(deviceName, Settings.Default.XGalvoAoChannel);
            YGalvoAoChannel = string.Concat(deviceName, Settings.Default.YGalvoAoChannel);
            Y2GalvoAoChannel = string.Concat(deviceName, Settings.Default.Y2GalvoAoChannel);
        }

        /// <summary>
        /// X坐标->X振镜电压
        /// </summary>
        /// <param name="xCoordinate"></param>
        /// <returns></returns>
        public double XCoordinateToVoltage(double xCoordinate)
        {
            return xCoordinate * XGalvoCalibrationVoltage / 1000 + XGalvoOffsetVoltage;
        }

        /// <summary>
        /// X坐标序列->X振镜电压序列
        /// </summary>
        /// <param name="xCoordinates"></param>
        /// <returns></returns>
        public double[] XCoordinateToVoltage(double[] xCoordinates)
        {
            double calibrationVoltage = XGalvoCalibrationVoltage / 1000;
            double[] xVoltages = new double[xCoordinates.Length];
            for (int i = 0; i < xCoordinates.Length; i++)
            {
                xVoltages[i] = xCoordinates[i] * calibrationVoltage + XGalvoOffsetVoltage;
            }
            return xVoltages;
        }

        /// <summary>
        /// Y坐标->Y振镜电压
        /// </summary>
        /// <param name="yCoordinate"></param>
        /// <returns></returns>
        public double YCoordinateToVoltage(double yCoordinate)
        {
            return yCoordinate * YGalvoCalibrationVoltage / 1000 + YGalvoOffsetVoltage;
        }

        /// <summary>
        /// Y坐标序列->Y振镜电压序列
        /// </summary>
        /// <param name="yCoordinates"></param>
        /// <returns></returns>
        public double[] YCoordinateToVoltage(double[] yCoordinates)
        {
            double calibrationVoltage = YGalvoCalibrationVoltage / 1000;
            double[] yVoltages = new double[yCoordinates.Length];
            for (int i = 0; i < yCoordinates.Length; i++)
            {
                yVoltages[i] = yCoordinates[i] * calibrationVoltage + YGalvoOffsetVoltage;
            }
            return yVoltages;
        }

        /// <summary>
        /// X振镜电压->X坐标
        /// </summary>
        /// <param name="xVoltage"></param>
        /// <returns></returns>
        public double XVoltageToCoordinate(double xVoltage)
        {
            return (xVoltage - XGalvoOffsetVoltage) / XGalvoCalibrationVoltage * 1000;
        }

        /// <summary>
        /// X振镜电压序列->X坐标序列
        /// </summary>
        /// <param name="xVoltages"></param>
        /// <returns></returns>
        public double[] XVoltageToCoordinate(double[] xVoltages)
        {
            double calibrationVoltage = XGalvoCalibrationVoltage / 1000;
            double[] xCoordinates = new double[xVoltages.Length];
            for (int i = 0; i < xVoltages.Length; i++)
            {
                xCoordinates[i] = (xVoltages[i] - XGalvoOffsetVoltage) / calibrationVoltage;
            }
            return xCoordinates;
        }

        /// <summary>
        /// Y振镜电压->Y坐标
        /// </summary>
        /// <param name="yVoltage"></param>
        /// <returns></returns>
        public double YVoltageToCoordinate(double yVoltage)
        {
            return (yVoltage - YGalvoOffsetVoltage) / YGalvoCalibrationVoltage * 1000;
        }

        /// <summary>
        /// Y振镜电压序列->Y坐标序列
        /// </summary>
        /// <param name="yVoltages"></param>
        /// <returns></returns>
        public double[] YVoltageToCoordinate(double[] yVoltages)
        {
            double calibrationVoltage = YGalvoCalibrationVoltage / 1000;
            double[] yCoordinates = new double[yVoltages.Length];
            for (int i = 0; i < yVoltages.Length; i++)
            {
                yCoordinates[i] = (yVoltages[i] - YGalvoOffsetVoltage) / calibrationVoltage;
            }
            return yCoordinates;
        }

        /// <summary>
        /// X坐标->X振镜电压
        /// </summary>
        /// <param name="xCoordinate"></param>
        /// <param name="galvoPrpperty"></param>
        /// <returns></returns>
        public static double XCoordinateToVoltage(double xCoordinate, GalvoProperty galvoPrpperty)
        {
            return xCoordinate * galvoPrpperty.XGalvoCalibrationVoltage / 1000 + galvoPrpperty.XGalvoOffsetVoltage;
        }

        /// <summary>
        /// X坐标序列->X振镜电压序列
        /// </summary>
        /// <param name="xCoordinates"></param>
        /// <returns></returns>
        public static double[] XCoordinateToVoltage(double[] xCoordinates, GalvoProperty galvoPrpperty)
        {
            double calibrationVoltage = galvoPrpperty.XGalvoCalibrationVoltage / 1000;
            double[] xVoltages = new double[xCoordinates.Length];
            for (int i = 0; i < xCoordinates.Length; i++)
            {
                xVoltages[i] = xCoordinates[i] * calibrationVoltage + galvoPrpperty.XGalvoOffsetVoltage;
            }
            return xVoltages;
        }

        /// <summary>
        /// Y坐标->Y振镜电压
        /// </summary>
        /// <param name="yCoordinate"></param>
        /// <param name="galvoPrpperty"></param>
        /// <returns></returns>
        public static double YCoordinateToVoltage(double yCoordinate, GalvoProperty galvoPrpperty)
        {
            return yCoordinate * galvoPrpperty.YGalvoCalibrationVoltage / 1000 + galvoPrpperty.YGalvoOffsetVoltage;
        }

        /// <summary>
        /// Y坐标序列->Y振镜电压序列
        /// </summary>
        /// <param name="yCoordinates"></param>
        /// <param name="galvoPrpperty"></param>
        /// <returns></returns>
        public static double[] YCoordinateToVoltage(double[] yCoordinates, GalvoProperty galvoPrpperty)
        {
            double calibrationVoltage = galvoPrpperty.YGalvoCalibrationVoltage / 1000;
            double[] yVoltages = new double[yCoordinates.Length];
            for (int i = 0; i < yCoordinates.Length; i++)
            {
                yVoltages[i] = yCoordinates[i] * calibrationVoltage + galvoPrpperty.YGalvoOffsetVoltage;
            }
            return yVoltages;
        }

        /// <summary>
        /// X振镜电压->X坐标
        /// </summary>
        /// <param name="xVoltage"></param>
        /// <param name="galvoPrpperty"></param>
        /// <returns></returns>
        public static double XVoltageToCoordinate(double xVoltage, GalvoProperty galvoPrpperty)
        {
            return (xVoltage - galvoPrpperty.XGalvoOffsetVoltage) / galvoPrpperty.XGalvoCalibrationVoltage * 1000;
        }

        /// <summary>
        /// X振镜电压序列->X坐标序列
        /// </summary>
        /// <param name="xVoltages"></param>
        /// <param name="galvoPrpperty"></param>
        /// <returns></returns>
        public static double[] XVoltageToCoordinate(double[] xVoltages, GalvoProperty galvoPrpperty)
        {
            double calibrationVoltage = galvoPrpperty.XGalvoCalibrationVoltage / 1000;
            double[] xCoordinates = new double[xVoltages.Length];
            for (int i = 0; i < xVoltages.Length; i++)
            {
                xCoordinates[i] = (xVoltages[i] - galvoPrpperty.XGalvoOffsetVoltage) / calibrationVoltage;
            }
            return xCoordinates;
        }

        /// <summary>
        /// Y振镜电压->Y坐标
        /// </summary>
        /// <param name="yVoltage"></param>
        /// <param name="galvoPrpperty"></param>
        /// <returns></returns>
        public static double YVoltageToCoordinate(double yVoltage, GalvoProperty galvoPrpperty)
        {
            return (yVoltage - galvoPrpperty.YGalvoOffsetVoltage) / galvoPrpperty.YGalvoCalibrationVoltage * 1000;
        }

        /// <summary>
        /// Y振镜电压序列->Y坐标序列
        /// </summary>
        /// <param name="yVoltages"></param>
        /// <param name="galvoPrpperty"></param>
        /// <returns></returns>
        public static double[] YVoltageToCoordinate(double[] yVoltages, GalvoProperty galvoPrpperty)
        {
            double calibrationVoltage = galvoPrpperty.YGalvoCalibrationVoltage / 1000;
            double[] yCoordinates = new double[yVoltages.Length];
            for (int i = 0; i < yVoltages.Length; i++)
            {
                yCoordinates[i] = (yVoltages[i] - galvoPrpperty.YGalvoOffsetVoltage) / calibrationVoltage;
            }
            return yCoordinates;
        }
    }
}
