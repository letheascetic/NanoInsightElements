using NanoInsight.Engine.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Viewer.Model
{
    public class ScanDirectionModel : ScanPropertyBaseModel
    {
        public ScanDirectionModel(ScanDirection scanDirection)
        {
            ID = scanDirection.ID;
            Text = scanDirection.Text;
            IsEnabled = scanDirection.IsEnabled;
        }
    }
}
