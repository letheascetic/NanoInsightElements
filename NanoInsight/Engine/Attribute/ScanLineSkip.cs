using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Engine.Attribute
{
    public delegate int LineSkipStatusChangedEventHandler(bool status);

    /// <summary>
    /// 跳行扫描参数更新事件委托
    /// </summary>
    /// <param name="lineSkip"></param>
    /// <returns></returns>
    public delegate int LineSkipChangedEventHandler(ScanLineSkip lineSkip);

    /// <summary>
    /// 跳行扫描
    /// </summary>
    public class ScanLineSkip
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public int Data { get; set; }

        public static List<ScanLineSkip> Initialize()
        {
            return new List<ScanLineSkip>()
            {
                new ScanLineSkip(){ ID = 0, Text = "2x", Data = 2 },
                new ScanLineSkip(){ ID = 1, Text = "4x", Data = 4 },
                new ScanLineSkip(){ ID = 2, Text = "8x", Data = 8 },
                new ScanLineSkip(){ ID = 3, Text = "16x", Data = 16 },
            };
        }
    }
}
