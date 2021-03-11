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
        public static void GenerateColorMapping(Color color, ref Mat colorMapLookupTable)
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
            colorMapLookupTable.SetTo<byte>(colorMapping);
        }

        public static void GenerateGammaMapping(double gamma, ref Mat gammaMapLookupTable)
        {
            byte[] data = new byte[256];
            for (int i = 0; i < 256; i++)
            {
                data[i] = (byte)(Math.Pow(i / 255.0, gamma) * 255.0);
            }
            gammaMapLookupTable.SetTo<byte>(data);
        }

        public static void GenerateGammaMapping(int gammaCoff, ref Mat gammaMapLookupTable)
        {
            double gamma = Math.Pow(2, gammaCoff / 100.0);
            GenerateGammaMapping(gamma, ref gammaMapLookupTable);
        }

        public static void GenerateGammaMapping(int gammaCoff, int gammaMin, int gammaMax, ref Mat gammaMapLookupTable)
        {
            double gamma = Math.Pow(2, gammaCoff / 100.0);
            byte[] data = new byte[256];
            for (int i = 0; i < 256; i++)
            {
                if (i < gammaMin || i > gammaMax)
                {
                    data[i] = (byte)i;
                }
                else
                {
                    data[i] = (byte)(Math.Pow(i / 255.0, gamma) * 255.0);
                }
            }
            gammaMapLookupTable.SetTo<byte>(data);
        }

    }
}
