using GalaSoft.MvvmLight;
using NanoInsight.Engine.Core;
using NanoInsight.Viewer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Viewer.ViewModel
{
    public class ImageSettingsViewModel : ViewModelBase
    {
        private List<ColorSpaceModel> mColorSpaceList;
        private ColorSpaceModel mSelectedColorSpace;

        private ScanChannelImageModel mScanChannel405;
        private ScanChannelImageModel mScanChannel488;
        private ScanChannelImageModel mScanChannel561;
        private ScanChannelImageModel mScanChannel640;
        private ScanChannelImageModel[] mScanChannels;

        public List<ColorSpaceModel> ColorSpaceList
        {
            get { return mColorSpaceList; }
            set { mColorSpaceList = value; RaisePropertyChanged(() => ColorSpaceList); }
        }

        public ColorSpaceModel SelectedColorSpace
        {
            get { return mSelectedColorSpace; }
            set { mSelectedColorSpace = value; RaisePropertyChanged(() => SelectedColorSpace); }
        }

        public ScanChannelImageModel ScanChannel405
        {
            get { return mScanChannel405; }
            set { mScanChannel405 = value; RaisePropertyChanged(() => ScanChannel405); }
        }

        public ScanChannelImageModel ScanChannel488
        {
            get { return mScanChannel488; }
            set { mScanChannel488 = value; RaisePropertyChanged(() => ScanChannel488); }
        }

        public ScanChannelImageModel ScanChannel561
        {
            get { return mScanChannel561; }
            set { mScanChannel561 = value; RaisePropertyChanged(() => ScanChannel561); }
        }

        public ScanChannelImageModel ScanChannel640
        {
            get { return mScanChannel640; }
            set { mScanChannel640 = value; RaisePropertyChanged(() => ScanChannel640); }
        }

        public ScanChannelImageModel[] ScanChannels
        {
            get { return mScanChannels; }
            set { mScanChannels = value; RaisePropertyChanged(() => ScanChannels); }
        }

        private readonly Scheduler mScheduler;

        public Scheduler Engine
        {
            get { return mScheduler; }
        }

        public ImageSettingsViewModel()
        {
            mScheduler = Scheduler.CreateInstance();
            ColorSpaceList = ColorSpaceModel.Initialize(Engine.Configuration.ColorSpaceList);
            SelectedColorSpace = ColorSpaceList.Where(p => p.ID == Engine.Configuration.SelectedColorSpace.ID).First();
            ScanChannel405 = new ScanChannelImageModel(Engine.Configuration.ScanChannel405);
            ScanChannel488 = new ScanChannelImageModel(Engine.Configuration.ScanChannel488);
            ScanChannel561 = new ScanChannelImageModel(Engine.Configuration.ScanChannel561);
            ScanChannel640 = new ScanChannelImageModel(Engine.Configuration.ScanChannel640);
        }

    }
}
