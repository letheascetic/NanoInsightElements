using NanoInsight.Engine.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Viewer.Model
{
    public class ScanModeModel : ScanPropertyBaseModel
    {
        public ScanModeModel(ScanMode scanMode)
        {
            ID = scanMode.ID;
            Text = scanMode.Text;
            IsEnabled = scanMode.IsEnabled;
        }
    }
}
