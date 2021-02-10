using GalaSoft.MvvmLight;
using NanoInsight.Engine.Attribute;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Viewer.Model
{
    public class ScanAreaModel : ObservableObject
    {
        private RectangleF scanRange;
        private string text;

        /// <summary>
        /// 扫描范围
        /// </summary>
        public RectangleF ScanRange
        {
            get { return scanRange; }
            set { scanRange = value; RaisePropertyChanged(() => ScanRange); }
        }

        public string Text
        {
            get { return text; }
            set { text = value; RaisePropertyChanged(() => Text); }
        }

        public ScanAreaModel(ScanArea scanArea)
        {
            ScanRange = scanArea.ScanRange;
            Text = scanArea.Text;
        }

    }
}
