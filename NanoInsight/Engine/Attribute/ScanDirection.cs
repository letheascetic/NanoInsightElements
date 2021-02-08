using NanoInsight.Engine.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Engine.Attribute
{
    /// <summary>
    /// 扫描方向更新事件委托
    /// </summary>
    /// <param name="scanDirection"></param>
    /// <returns></returns>
    public delegate int ScanDirectionChangedEventHandler(ScanDirection scanDirection);

    /// <summary>
    /// 扫描方向
    /// </summary>
    public class ScanDirection : ScanProperty
    {
        ///////////////////////////////////////////////////////////////////////////////////////////
        public const int Unidirection = 0;
        public const int Bidirection = 1;
        ///////////////////////////////////////////////////////////////////////////////////////////

        public ScanDirection(int id)
        {
            if (id == Unidirection)
            {
                ID = Unidirection;
                Text = "单向";
                IsEnabled = Settings.Default.ScanDirection == Unidirection;
            }
            else if (id == Bidirection)
            {
                ID = Bidirection;
                Text = "双向";
                IsEnabled = Settings.Default.ScanDirection == Bidirection;
            }
            else
            {
                throw new ArgumentOutOfRangeException("ID Exception");
            }
        }
    }
}
