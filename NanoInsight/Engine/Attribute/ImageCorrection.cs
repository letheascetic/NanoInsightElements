using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Engine.Attribute
{
    /// <summary>
    /// 图像校正方式改变
    /// </summary>
    /// <param name="imageCorrection"></param>
    /// <returns></returns>
    public delegate int ImageCorrectionChangedEventHandler(ImageCorrection imageCorrection);

    /// <summary>
    /// 图像校正方式：①gamma ②对比度+亮度
    /// </summary>
    public class ImageCorrection
    {
        ///////////////////////////////////////////////////////////////////////////////////////////
        public const int Gamma = 0;
        public const int ContrastBrightness = 1;
        ///////////////////////////////////////////////////////////////////////////////////////////
        public int ID { get; set; }
        public string Name { get; set; }

        public static List<ImageCorrection> Initialize()
        {
            return new List<ImageCorrection>()
            {
                new ImageCorrection(Gamma),
                new ImageCorrection(ContrastBrightness)
            };
        }

        public ImageCorrection(int id)
        {
            if (id == Gamma)
            {
                ID = Gamma;
                Name = "伽马校正";
            }
            else if (id == ContrastBrightness)
            {
                ID = ContrastBrightness;
                Name = "对比度亮度校正";
            }
            else
            {
                throw new ArgumentOutOfRangeException("ID Exception");
            }
        }

        public ImageCorrection(ImageCorrection imageCorrection)
        {
            ID = imageCorrection.ID;
            Name = imageCorrection.Name;
        }
    }
}
