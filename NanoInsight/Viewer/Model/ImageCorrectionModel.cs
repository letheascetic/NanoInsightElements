using GalaSoft.MvvmLight;
using NanoInsight.Engine.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Viewer.Model
{
    /// <summary>
    /// 图像校正
    /// </summary>
    public class ImageCorrectionModel : ObservableObject
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

        public ImageCorrectionModel(ImageCorrection imageCorrection)
        {
            ID = imageCorrection.ID;
            Name = imageCorrection.Name;
        }

        public static List<ImageCorrectionModel> Initialize(List<ImageCorrection> imageCorrectionList)
        {
            List<ImageCorrectionModel> list = new List<ImageCorrectionModel>();
            foreach (ImageCorrection imageCorrection in imageCorrectionList)
            {
                list.Add(new ImageCorrectionModel(imageCorrection));
            }
            return list;
        }

    }
}
