using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Engine.Attribute
{
    /// <summary>
    /// 扫描区域类型变化事件
    /// </summary>
    /// <param name="scanAreaType"></param>
    /// <returns></returns>
    public delegate int ScanAreaTypeChangedEventHandler(ScanAreaType scanAreaType);

    /// <summary>
    /// 扫描区域形状
    /// </summary>
    public class ScanAreaType : ScanProperty
    {
        ///////////////////////////////////////////////////////////////////////////////////////////
        public static readonly int Square = 0;
        public static readonly int Bank = 1;
        public static readonly int Line = 2;
        ///////////////////////////////////////////////////////////////////////////////////////////

        public ScanAreaType(int id)
        {
            if (id == Square)
            {
                ID = Square;
                Text = "方形";
                IsEnabled = true;
            }
            else if (id == Bank)
            {
                ID = Bank;
                Text = "矩形";
                IsEnabled = false;
            }
            else if (id == Line)
            {
                ID = Line;
                Text = "线条";
                IsEnabled = false;
            }
            else
            {
                throw new ArgumentOutOfRangeException("ID Exception");
            }
        }

        public ScanAreaType(ScanAreaType scanAreaType)
        {
            ID = scanAreaType.ID;
            Text = scanAreaType.Text;
            IsEnabled = scanAreaType.IsEnabled;
        }

    }
}
