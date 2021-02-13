using NanoInsight.Engine.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Viewer.Model
{
    public class ScanPixelDwellModel : ScanPropertyWithValueBaseModel<int>
    {
        private int scanPixelCalibration;
        private int scanPixelOffset;
        private int scanPixelCalibrationMaximum;
        private int scanPixelScale;

        public int ScanPixelCalibration
        {
            get { return scanPixelCalibration; }
            set { scanPixelCalibration = value; RaisePropertyChanged(() => ScanPixelCalibration); }
        }
        /// <summary>
        /// 扫描像素偏置
        /// </summary>
        public int ScanPixelOffset
        {
            get { return scanPixelOffset; }
            set { scanPixelOffset = value; RaisePropertyChanged(() => ScanPixelOffset); }
        }
        /// <summary>
        /// 扫描像素补偿最大值
        /// </summary>
        public int ScanPixelCalibrationMaximum
        {
            get { return scanPixelCalibrationMaximum; }
            set { scanPixelCalibrationMaximum = value; RaisePropertyChanged(() => ScanPixelCalibrationMaximum); }
        }
        /// <summary>
        /// 扫描像素缩放系数
        /// </summary>
        public int ScanPixelScale
        {
            get { return scanPixelScale; }
            set { scanPixelScale = value; RaisePropertyChanged(() => ScanPixelScale); }
        }

        public ScanPixelDwellModel(ScanPixelDwell scanPixelDwell)
        {
            ID = scanPixelDwell.ID;
            IsEnabled = scanPixelDwell.IsEnabled;
            Text = scanPixelDwell.Text;
            Data = scanPixelDwell.Data;
            ScanPixelCalibration = scanPixelDwell.ScanPixelCalibration;
            ScanPixelCalibrationMaximum = scanPixelDwell.ScanPixelCalibrationMaximum;
            ScanPixelScale = scanPixelDwell.ScanPixelScale;
            ScanPixelOffset = scanPixelDwell.ScanPixelOffset;
        }

        public static List<ScanPixelDwellModel> Initialize(List<ScanPixelDwell> scanPixelDwells)
        {
            List<ScanPixelDwellModel> scanPixelDwellList = new List<ScanPixelDwellModel>();
            foreach (ScanPixelDwell scanPixelDwell in scanPixelDwells)
            {
                scanPixelDwellList.Add(new ScanPixelDwellModel(scanPixelDwell));
            }
            return scanPixelDwellList;
        }

    }
}
