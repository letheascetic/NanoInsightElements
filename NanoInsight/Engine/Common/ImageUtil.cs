using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Engine.Common
{
    public class ImageUtil
    {
        public static void GenerateColorMapping(Color color, ref Mat colorMappingMat)
        {
            float rCoff = color.R / 256.0f;
            float gCoff = color.G / 256.0f;
            float bCoff = color.B / 256.0f;

            byte[] colorMapping = new byte[256 * 3];
            byte value;
            for (int i = 0; i <= byte.MaxValue; i++)
            {
                value = (byte)i;
                colorMapping[i * 3 + 2] = (byte)(rCoff * value);
                colorMapping[i * 3 + 1] = (byte)(gCoff * value);
                colorMapping[i * 3 + 0] = (byte)(bCoff * value);
            }
            colorMappingMat.SetTo<byte>(colorMapping);
        }

        public static void GenerateGammaMapping(double gamma, ref Mat gammaMappingMat)
        {
            byte[] data = new byte[256];
            for (int i = 0; i < 256; i++)
            {
                data[i] = (byte)(Math.Pow(i / 255.0, gamma) * 255.0);
            }
            gammaMappingMat.SetTo<byte>(data);
        }
    }
}
