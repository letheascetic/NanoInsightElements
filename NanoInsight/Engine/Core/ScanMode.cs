﻿using NanoInsight.Engine.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Engine.Core
{
    public class ScanMode : ScanProperty
    {
        ///////////////////////////////////////////////////////////////////////////////////////////
        public const int Resonant = 0;
        public const int Galvano = 1;
        ///////////////////////////////////////////////////////////////////////////////////////////

        public ScanMode(int id)
        {
            switch (id)
            {
                case Resonant:
                    ID = Resonant;
                    Text = "Resonant";
                    IsEnabled = Settings.Default.ScanMode == Resonant;
                    break;
                case Galvano:
                    ID = Galvano;
                    Text = "Galvano";
                    IsEnabled = Settings.Default.ScanMode == Galvano;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("ID Exception");
            }
        }

    }
}
