using NanoInsight.Engine.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Engine.Core
{

    /// <summary>
    /// 扫描头更新事件委托
    /// </summary>
    /// <param name="scanHead"></param>
    /// <returns></returns>
    public delegate int ScanHeadChangedEventHandler(ScanHead scanHead);

    /// <summary>
    /// 扫描头
    /// </summary>
    public class ScanHead : ScanProperty
    {
        ///////////////////////////////////////////////////////////////////////////////////////////
        public const int TwoGalvo = 0;
        public const int ThreeGalvo = 1;
        ///////////////////////////////////////////////////////////////////////////////////////////

        public ScanHead(int id)
        {
            if (id == TwoGalvo)
            {
                ID = TwoGalvo;
                Text = "双镜";
                IsEnabled = Settings.Default.ScanHead == TwoGalvo;
            }
            else if (id == ThreeGalvo)
            {
                ID = ThreeGalvo;
                Text = "三镜";
                IsEnabled = Settings.Default.ScanHead == ThreeGalvo;
            }
            else
            {
                throw new ArgumentOutOfRangeException("ID Exception");
            }
        }

    }
}
