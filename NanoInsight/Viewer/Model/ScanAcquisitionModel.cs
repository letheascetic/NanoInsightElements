using NanoInsight.Engine.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Viewer.Model
{
    /// <summary>
    /// 采集模式：实时、捕捉
    /// </summary>
    public class ScanAcquisitionModel : ScanPropertyBaseModel
    {
        public ScanAcquisitionModel(ScanAcquisition scanAcquisition)
        {
            ID = scanAcquisition.ID;
            IsEnabled = scanAcquisition.IsEnabled;
            Text = scanAcquisition.Text;
        }
    }
}
