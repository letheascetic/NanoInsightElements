using GalaSoft.MvvmLight;
using NanoInsight.Engine.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Viewer.Model
{
    public class GalvoPropertyModel : ObservableObject
    {
        private double xGalvoOffsetVoltage;
        private double yGalvoOffsetVoltage;
        private double y2GalvoOffsetVoltage;

        private double galvoResponseTime;
        private double xGalvoCalibrationVoltage;
        private double yGalvoCalibrationVoltage;

        private string xGalvoChannel;       // X振镜控制电压 - AO输出
        private string yGalvoAoChannel;     // Y振镜控制电压 - AO输出
        private string y2GalvoAoChannel;    // Y补偿镜控制电压 - AO输出

        /// <summary>
        /// X振镜偏置电压
        /// </summary>
        public double XGalvoOffsetVoltage
        {
            get { return xGalvoOffsetVoltage; }
            set { xGalvoOffsetVoltage = value; RaisePropertyChanged(() => XGalvoOffsetVoltage); }
        }
        /// <summary>
        /// Y振镜偏置电压
        /// </summary>
        public double YGalvoOffsetVoltage
        {
            get { return yGalvoOffsetVoltage; }
            set { yGalvoOffsetVoltage = value; RaisePropertyChanged(() => YGalvoOffsetVoltage); }
        }
        /// <summary>
        /// Y2振镜偏置电压
        /// </summary>
        public double Y2GalvoOffsetVoltage
        {
            get { return y2GalvoOffsetVoltage; }
            set { y2GalvoOffsetVoltage = value; RaisePropertyChanged(() => Y2GalvoOffsetVoltage); }
        }
        /// <summary>
        /// 振镜响应时间
        /// </summary>
        public double GalvoResponseTime
        {
            get { return galvoResponseTime; }
            set { galvoResponseTime = value; RaisePropertyChanged(() => GalvoResponseTime); }
        }
        /// <summary>
        /// X振镜校准电压
        /// </summary>
        public double XGalvoCalibrationVoltage
        {
            get { return xGalvoCalibrationVoltage; }
            set { xGalvoCalibrationVoltage = value; RaisePropertyChanged(() => XGalvoCalibrationVoltage); }
        }
        /// <summary>
        /// Y振镜校准电压
        /// </summary>
        public double YGalvoCalibrationVoltage
        {
            get { return yGalvoCalibrationVoltage; }
            set { yGalvoCalibrationVoltage = value; RaisePropertyChanged(() => YGalvoCalibrationVoltage); }
        }
        /// <summary>
        /// X振镜模拟输出通道
        /// </summary>
        public string XGalvoAoChannel
        {
            get { return xGalvoChannel; }
            set { xGalvoChannel = value; RaisePropertyChanged(() => XGalvoAoChannel); }
        }
        /// <summary>
        /// Y振镜模拟输出通道
        /// </summary>
        public string YGalvoAoChannel
        {
            get { return yGalvoAoChannel; }
            set { yGalvoAoChannel = value; RaisePropertyChanged(() => YGalvoAoChannel); }
        }
        /// <summary>
        /// Y2补偿镜模拟输出通道
        /// </summary>
        public string Y2GalvoAoChannel
        {
            get { return y2GalvoAoChannel; }
            set { y2GalvoAoChannel = value; RaisePropertyChanged(() => Y2GalvoAoChannel); }
        }

        public GalvoPropertyModel(GalvoProperty galvoProperty)
        {
            XGalvoOffsetVoltage = galvoProperty.XGalvoOffsetVoltage;
            YGalvoOffsetVoltage = galvoProperty.YGalvoOffsetVoltage;
            Y2GalvoOffsetVoltage = galvoProperty.YGalvoOffsetVoltage;
            GalvoResponseTime = galvoProperty.GalvoResponseTime;
            XGalvoCalibrationVoltage = galvoProperty.XGalvoCalibrationVoltage;
            YGalvoCalibrationVoltage = galvoProperty.YGalvoCalibrationVoltage;

            XGalvoAoChannel = galvoProperty.XGalvoAoChannel;
            YGalvoAoChannel = galvoProperty.YGalvoAoChannel;
            Y2GalvoAoChannel = galvoProperty.Y2GalvoAoChannel;
        }

    }
}
