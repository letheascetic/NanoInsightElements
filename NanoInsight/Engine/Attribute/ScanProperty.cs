using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Engine.Attribute
{
    public class ScanProperty
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public bool IsEnabled { get; set; }
    }

    public class ScanPropertyWithValue<T> : ScanProperty
    {
        public T Data { get; set; }
    }

}
