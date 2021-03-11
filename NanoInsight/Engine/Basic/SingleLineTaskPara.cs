using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Engine.Basic
{
    /// <summary>
    /// 单线扫描任务参数
    /// 必须在同一水平面内，可以是任意方向，只能是单向，支持单个通道，也支持多个通道，支持PMT采集，也支持APD采集
    /// </summary>
    public class SingleLineTaskPara
    {
        /// <summary>
        /// Z轴
        /// </summary>
        public double Z { get; set; }
        /// <summary>
        /// 扫描使用的通道
        /// </summary>
        public int ScanChannelMask { get; set; }
        /// <summary>
        /// 扫描模式：振镜/压电
        /// </summary>
        public int ScanMode { get; set; }
        /// <summary>
        /// 停留时间
        /// </summary>
        public int ScanPixelDwell { get; set; }
    }
}
