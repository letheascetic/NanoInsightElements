using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Engine.Data
{
    public class PmtSampleData
    {
        public short[][] NSamples { get; set; }
        public long[] AcquisitionCount { get; }

        public PmtSampleData(short[][] samples, long[] acquisitionCount)
        {
            NSamples = samples;
            AcquisitionCount = acquisitionCount;
        }
    }
}
