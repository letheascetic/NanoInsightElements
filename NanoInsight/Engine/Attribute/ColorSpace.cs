﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Engine.Attribute
{
    public class ColorSpace
    {
        ///////////////////////////////////////////////////////////////////////////////////////////
        public const int GrayScale = 0;
        public const int LaserLight = 1;
        public const int Pseudo = 2;
        ///////////////////////////////////////////////////////////////////////////////////////////
        public int ID { get; set; }
        public string Name { get; set; }

        public static List<ColorSpace> Initialize()
        {
            return new List<ColorSpace>()
            {
                new ColorSpace(GrayScale),
                new ColorSpace(LaserLight),
                new ColorSpace(Pseudo),
            };
        }

        public ColorSpace(ColorSpace colorSpace)
        {
            ID = colorSpace.ID;
            Name = colorSpace.Name;
        }

        public ColorSpace(int id)
        {
            switch (id)
            {
                case GrayScale:
                    ID = GrayScale;
                    Name = "灰度图";
                    break;
                case LaserLight:
                    ID = LaserLight;
                    Name = "激发色";
                    break;
                case Pseudo:
                    ID = Pseudo;
                    Name = "伪彩色";
                    break;
                default:
                    throw new ArgumentOutOfRangeException("ID Exception");
            }
        }

    }
}
