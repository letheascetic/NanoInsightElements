using NanoInsight.Engine.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Viewer.Model
{
    public class ScanPixelModel : ScanPropertyWithValueBaseModel<int>
    {
        public static List<ScanPixelModel> Initialize(List<ScanPixel> scanPixelList)
        {
            List<ScanPixelModel> scanPixels = new List<ScanPixelModel>();
            foreach (ScanPixel scanPixel in scanPixelList)
            {
                scanPixels.Add(new ScanPixelModel(scanPixel));
            }
            return scanPixels;
        }

        public ScanPixelModel(ScanPixel scanPixel)
        {
            ID = scanPixel.ID;
            IsEnabled = scanPixel.IsEnabled;
            Text = scanPixel.Text;
            Data = scanPixel.Data;
        }
    }
}
