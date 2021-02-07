using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Engine.Attribute
{
    /// <summary>
    /// 采集模式更新事件委托
    /// </summary>
    /// <param name="scanAcquisition"></param>
    /// <returns></returns>
    public delegate int ScanAcquisitionChangedEventHandler(ScanAcquisition scanAcquisition);

    /// <summary>
    /// 采集模式
    /// </summary>
    public class ScanAcquisition : ScanProperty
    {
        ///////////////////////////////////////////////////////////////////////////////////////////
        public const int Live = 0;
        public const int Capture = 1;
        ///////////////////////////////////////////////////////////////////////////////////////////

        public ScanAcquisition(int id)
        {
            if (id == Live)
            {
                ID = Live;
                IsEnabled = false;
                Text = "实时";
            }
            else if (id == Capture)
            {
                ID = Capture;
                IsEnabled = false;
                Text = "捕捉";
            }
            else
            {
                throw new ArgumentOutOfRangeException("ID Exception");
            }
        }
    }
}
