using NanoInsight.Engine.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Engine.Attribute
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
                new ScanPixel(0),
                new ScanPixel(1),
                new ScanPixel(2),
                new ScanPixel(3),
                new ScanPixel(4),
                new ScanPixel(5),
                new ScanPixel(6)
            };
        }

        public ScanPixel(int id)
        {
            switch (id)
            {
                case 0:
                    ID = 0;
                    IsEnabled = Settings.Default.ScanPixel == 0;
                    Text = "64";
                    Data = 64;
                    break;
                case 1:
                    ID = 1;
                    IsEnabled = Settings.Default.ScanPixel == 1;
                    Text = "128";
                    Data = 128;
                    break;
                case 2:
                    ID = 2;
                    IsEnabled = Settings.Default.ScanPixel == 2;
                    Text = "256";
                    Data = 256;
                    break;
                case 3:
                    ID = 3;
                    IsEnabled = Settings.Default.ScanPixel == 3;
                    Text = "512";
                    Data = 512;
                    break;
                case 4:
                    ID = 4;
                    IsEnabled = Settings.Default.ScanPixel == 4;
                    Text = "1024";
                    Data = 1024;
                    break;
                case 5:
                    ID = 5;
                    IsEnabled = Settings.Default.ScanPixel == 5;
                    Text = "2048";
                    Data = 2048;
                    break;
                case 6:
                    ID = 6;
                    IsEnabled = Settings.Default.ScanPixel == 6;
                    Text = "4096";
                    Data = 4096;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("ID Exception");
            }
        }

        public ScanPixel(ScanPixel scanPixel)
        {
            ID = scanPixel.ID;
            IsEnabled = scanPixel.IsEnabled;
            Text = scanPixel.Text;
            Data = scanPixel.Data;
        }
    }

}
