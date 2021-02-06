using NanoInsight.Engine.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Engine.Core
{
    /// <summary>
    /// 扫描像素更新事件委托
    /// </summary>
    /// <param name="scanPixel"></param>
    /// <returns></returns>
    public delegate int ScanPixelChangedEventHandler(ScanPixel scanPixel);

    /// <summary>
    /// 扫描像素
    /// </summary>
    public class ScanPixel : ScanPropertyWithValue<int>
    {
        public static List<ScanPixel> Initialize()
        {
            return new List<ScanPixel>()
            {
                new ScanPixel(){ ID = 0, IsEnabled = Settings.Default.ScanPixel == 0, Text = "64", Data = 64 },
                new ScanPixel(){ ID = 1, IsEnabled = Settings.Default.ScanPixel == 1, Text = "128", Data = 128 },
                new ScanPixel(){ ID = 2, IsEnabled = Settings.Default.ScanPixel == 2, Text = "256", Data = 256 },
                new ScanPixel(){ ID = 3, IsEnabled = Settings.Default.ScanPixel == 3, Text = "512", Data = 512 },
                new ScanPixel(){ ID = 4, IsEnabled = Settings.Default.ScanPixel == 4, Text = "1024", Data = 1024 },
                new ScanPixel(){ ID = 5, IsEnabled = Settings.Default.ScanPixel == 5, Text = "2048", Data = 2048 },
                new ScanPixel(){ ID = 6, IsEnabled = Settings.Default.ScanPixel == 6, Text = "4096", Data = 4096 }
            };
        }
    }

}
