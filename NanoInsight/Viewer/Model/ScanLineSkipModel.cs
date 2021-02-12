using GalaSoft.MvvmLight;
using NanoInsight.Engine.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Viewer.Model
{
    public class ScanLineSkipModel : ObservableObject
    {
        private int id;
        private string text;
        private int data;

        public int ID
        {
            get { return id; }
            set { id = value; RaisePropertyChanged(() => ID); }
        }

        public string Text
        {
            get { return text; }
            set { text = value; RaisePropertyChanged(() => Text); }
        }

        public int Data
        {
            get { return data; }
            set { this.data = value; RaisePropertyChanged(() => Data); }
        }

        public ScanLineSkipModel(ScanLineSkip scanLineSkip)
        {
            ID = scanLineSkip.ID;
            Text = scanLineSkip.Text;
            Data = scanLineSkip.Data;
        }

    }
}
