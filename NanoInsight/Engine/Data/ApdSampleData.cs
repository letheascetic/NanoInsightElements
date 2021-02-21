using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Engine.Data
{
    /// <summary>
    /// APD采集数据
    /// </summary>
    public class ApdSampleData
    {
        public long CurrentFrame { get; set; }
        public int CurrentBank { get; set; }
        public int[] NSamples { get; set; }
        public int ChannelIndex { get; set; }
        public long AcquisitionCount { get; }

        public ApdSampleData(int[] samples, int channelIndex, long acquisitionCount, long currentFrame, int currentBank)
        {
            NSamples = samples;
            ChannelIndex = channelIndex;
            AcquisitionCount = acquisitionCount;
            CurrentFrame = currentFrame;
            CurrentBank = currentBank;
        }
    }
}
