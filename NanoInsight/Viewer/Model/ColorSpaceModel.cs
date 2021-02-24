using GalaSoft.MvvmLight;
using NanoInsight.Engine.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Viewer.Model
{
    public class ColorSpaceModel : ObservableObject
    {
        private int id;
        private string name;

        public int ID
        {
            get { return id; }
            set { id = value; RaisePropertyChanged(() => ID); }
        }

        public string Name
        {
            get { return name; }
            set { name = value; RaisePropertyChanged(() => Name); }
        }

        public ColorSpaceModel(ColorSpace colorSpace)
        {
            ID = colorSpace.ID;
            Name = colorSpace.Name;
        }

        public static List<ColorSpaceModel> Initialize(List<ColorSpace> colorSpaceList)
        {
            List<ColorSpaceModel> list = new List<ColorSpaceModel>();
            foreach (ColorSpace colorSpace in colorSpaceList)
            {
                list.Add(new ColorSpaceModel(colorSpace));
            }
            return list;
        }

    }
}
