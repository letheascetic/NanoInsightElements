using C1.Win.C1Ribbon;
using log4net;
using NanoInsight.Viewer.Model;
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
    public partial class ScanParasView : C1RibbonForm
    {
        ///////////////////////////////////////////////////////////////////////////////////////////
        private static readonly ILog Logger = LogManager.GetLogger("info");
        ///////////////////////////////////////////////////////////////////////////////////////////

        private ScanParasViewModel mScanParasVM;

        public ScanParasView()
        {
            InitializeComponent();
        }

        private void Initialize()
        {
            mScanParasVM = new ScanParasViewModel();
        }

        private void RegisterEvents()
        {

        }

        private void SetDataBindings()
        {

        }


    }
}
