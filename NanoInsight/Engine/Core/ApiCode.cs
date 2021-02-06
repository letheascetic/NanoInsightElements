using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Engine.Core
{
    public static class ApiCode
    {
        public const int Success = 0x00000000;
        public const int Failed = 0x10000000;

        /// <summary>
        /// 是否成功
        /// </summary>
        /// <param name="apiCode"></param>
        /// <returns></returns>
        public static bool IsSuccessful(int apiCode)
        {
            return (Success & apiCode) == Success;
        }

    }
}
