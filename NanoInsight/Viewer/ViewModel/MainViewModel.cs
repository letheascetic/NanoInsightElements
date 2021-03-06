﻿using GalaSoft.MvvmLight;
using NanoInsight.Engine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Viewer.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly Scheduler mScheduler;

        public Scheduler Engine
        {
            get { return mScheduler; }
        }

        public MainViewModel()
        {
            mScheduler = Scheduler.CreateInstance();
        }


    }
}
