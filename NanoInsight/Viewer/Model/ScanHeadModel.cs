using NanoInsight.Engine.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Viewer.Model
{
    public class ScanHeadModel : ScanPropertyBaseModel
    {
        public ScanHeadModel(ScanHead scanHead)
        {
            ID = scanHead.ID;
            Text = scanHead.Text;
            IsEnabled = scanHead.IsEnabled;
        }
    }
}
