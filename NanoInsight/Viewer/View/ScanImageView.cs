using C1.Win.C1Ribbon;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.UI;
using log4net;
using NanoInsight.Engine.Common;
using NanoInsight.Engine.Core;
using NumSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NanoInsight.Viewer.View
{
    public partial class ScanImageView : C1RibbonForm
    {
        ///////////////////////////////////////////////////////////////////////////////////////////
        private static readonly ILog Logger = LogManager.GetLogger("info");
        ///////////////////////////////////////////////////////////////////////////////////////////

        private TabPage[] mTabPages;
        private ImageBox[] mImages;

        public ScanImageView(ScanTask scanTask)
        {
            InitializeComponent();

        }

        private void ButtonClick(object sender, EventArgs e)
        {
            short[] data = new short[2 * 20 * 10];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (short)i;
            }
            NDArray matrix = MatrixUtil.ToMatrix(data, 2, 20, 10, 1, 4, 2, 16);
            Mat image = new Mat(10, 16, DepthType.Cv32S, 1);
            MatrixUtil.ToBankImage(matrix, ref image);
        }
    }
}
