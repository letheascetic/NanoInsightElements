using C1.Win.C1Ribbon;
using log4net;
using NanoInsight.Engine.Core;
using NanoInsight.Viewer.Model;
using NanoInsight.Viewer.ViewModel;
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
    public partial class ScanAreaView : C1RibbonForm
    {       
        ///////////////////////////////////////////////////////////////////////////////////////////
        private static readonly ILog Logger = LogManager.GetLogger("info");
        ///////////////////////////////////////////////////////////////////////////////////////////
        private Point mMouseDownPosition;    // 鼠标在图像区域按下时的坐标
        private Point mMousePosition;        // 鼠标在图像区域的坐标
        private Point mPixelPosition;        // 鼠标在图像区域的像素坐标

        private bool mCoordinateChanged;
        private Rectangle mCoordinate;       // 控件中的扫描范围
        private Rectangle mScanPixelRange;   // 图像中的扫描范围
        private RectangleF mScanRange;       // 视场中的扫描范围（包含未确定状态）

        private Bitmap mScanAreaBmp;         // 扫描范围图层的Bitmap
        private Graphics mScanAreaGra;       // 扫描范围图层的画图句柄[在Bitmap上的画图操作不会丢失，直接在pbxScanArea上画图会丢失]

        private ScanAreaViewModel mScanAreaVM;

        public ScanAreaView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Initialize()
        {
            pbxScanArea.Parent = pictureBox;
            pbxScanArea.Location = new Point(0, 0);
            pbxScanArea.Size = pictureBox.Size;

            contextMenu.CommandLinks.Add(cmdLinkFullRange);
            contextMenu.CommandLinks.Add(cmdLinkLastScanRange);
            contextMenu.CommandLinks.Add(cmdLinkConfirm);

            mScanAreaVM = new ScanAreaViewModel();
            mScanRange = mScanAreaVM.SelectedScanArea.ScanRange;
            mScanPixelRange = mScanAreaVM.ScanRangeToScanPixelRange(mScanRange);
            mCoordinate = ScanPixelRangeToCoordinate(mScanPixelRange);
            mCoordinateChanged = false;

            mMousePosition = new Point();
            mPixelPosition = new Point();

            pictureBox.Image = mScanAreaVM.ScanImage;
            mScanAreaBmp = new Bitmap(pbxScanArea.ClientSize.Width, pbxScanArea.ClientSize.Height);
            mScanAreaGra = Graphics.FromImage(mScanAreaBmp);
            mScanAreaGra.Clear(Color.Transparent);
            pbxScanArea.Image = mScanAreaBmp;

            DrawScanArea(mCoordinate, mScanAreaGra, pbxScanArea);

        }
        
        /// <summary>
        /// 注册事件
        /// </summary>
        private void RegisterEvents()
        {
            mScanAreaVM.Engine.ScanAcquisitionChangedEvent += ScanAcquisitionChangedEventHandler;
            mScanAreaVM.Engine.ScanPixelChangedEvent += ScanPixelChangedEventHandler;
            mScanAreaVM.Engine.ScanAreaChangedEvent += ScanAreaChangedEventHandler;

            cbxScanPixel.ChangeCommitted += ScanPixelChanged;
            pbxScanArea.MouseEnter += MouseEnterImage;
            pbxScanArea.MouseLeave += MouseLeaveImage;
            pbxScanArea.MouseWheel += ScanRangeZoomed;
        }

        /// <summary>
        /// 设置数据绑定
        /// </summary>
        private void SetDataBindings()
        {
            // 扫描像素
            cbxScanPixel.DataSource = mScanAreaVM.ScanPixelList;
            cbxScanPixel.DisplayMember = "Text";
            cbxScanPixel.ValueMember = "Data";
            cbxScanPixel.DataBindings.Add("SelectedItem", mScanAreaVM, "SelectedScanPixel");

            // 显示的数据
            lbScanWidth.DataBindings.Add("Text", mScanAreaVM, "ScanWidth");
            lbScanHeight.DataBindings.Add("Text", mScanAreaVM, "ScanHeight");
            lbPixelDwellValue.DataBindings.Add("Text", mScanAreaVM, "PixelDwell", true, DataSourceUpdateMode.OnPropertyChanged, null, "0.0 us");
            lbPixelSizeValue.DataBindings.Add("Text", mScanAreaVM, "ScanPixelSize", true, DataSourceUpdateMode.OnPropertyChanged, null, "0.00 um");

            lbScanRangeValue.DataBindings.Add("Text", mScanAreaVM.SelectedScanArea, "Text");
            lbMaxScanRangeValue.DataBindings.Add("Text", mScanAreaVM.FullScanArea, "Text");
        }

        /// <summary>
        /// 像素范围转换成坐标
        /// </summary>
        /// <param name="scanPixelRange"></param>
        /// <returns></returns>
        private Rectangle ScanPixelRangeToCoordinate(Rectangle scanPixelRange)
        {
            float ratio = (float)mScanAreaVM.ScanWidth / pictureBox.ClientSize.Width;
            int x = (int)(scanPixelRange.X / ratio);
            int y = (int)(scanPixelRange.Y / ratio);
            int width = (int)(scanPixelRange.Width / ratio);
            int height = (int)(scanPixelRange.Height / ratio);
            return new Rectangle(x, y, width, height);
        }

        /// <summary>
        /// 坐标转换成像素范围
        /// </summary>
        /// <param name="scanCoordinateRange"></param>
        /// <param name="ratio"></param>
        /// <returns></returns>
        private Rectangle CoordinateToScanPixelRange(Rectangle scanCoordinate)
        {
            float ratio = (float)mScanAreaVM.ScanWidth / pictureBox.ClientSize.Width;
            int x = (int)(scanCoordinate.X * ratio);
            int y = (int)(scanCoordinate.Y * ratio);
            int width = (int)(scanCoordinate.Width * ratio);
            int height = (int)(scanCoordinate.Height * ratio);
            return new Rectangle(x, y, width, height);
        }

        /// <summary>
        /// 绘制扫描区域
        /// </summary>
        /// <param name="rectangle"></param>
        /// <param name="graphics"></param>
        /// <param name="control"></param>
        private void DrawScanArea(Rectangle rectangle, Graphics graphics, Control control)
        {
            control.Invalidate();
            control.Update();
            graphics.Clear(Color.Transparent);
            Pen pen = mCoordinateChanged ? new Pen(Color.Red, 5) : new Pen(Color.Green, 5);
            graphics.DrawRectangle(pen, rectangle);
        }
        
        /// <summary>
        /// 扫描采集变更处理事件
        /// </summary>
        /// <param name="scanAcquisition"></param>
        /// <returns></returns>
        private int ScanAcquisitionChangedEventHandler(Engine.Attribute.ScanAcquisition scanAcquisition)
        {
            if (scanAcquisition != null)
            {
                mImageTimer.Start();
            }
            else
            {
                mImageTimer.Stop();
            }
            return ApiCode.Success;
        }

        /// <summary>
        /// 鼠标进入图像区域
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseEnterImage(object sender, EventArgs e)
        {
            mCursorTimer.Start();
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// 鼠标离开图像区域
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseLeaveImage(object sender, EventArgs e)
        {
            mCursorTimer.Stop();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 计算鼠标所在像素点在图像中的坐标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerTick(object sender, EventArgs e)
        {
            mMousePosition = pictureBox.PointToClient(MousePosition);
            mPixelPosition.X = (int)((float)mScanAreaVM.ScanWidth / pictureBox.Width * mMousePosition.X);
            mPixelPosition.Y = (int)((float)mScanAreaVM.ScanHeight / pictureBox.Height * mMousePosition.Y);
            lbPixelPosition.Text = string.Format("[{0}:{1}]", mPixelPosition.X, mPixelPosition.Y);
        }

        /// <summary>
        /// 扫描范围缩放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScanRangeZoomed(object sender, MouseEventArgs e)
        {
            Rectangle coordinate = mCoordinate;
            // 缩放
            if (e.Delta > 0)
            {
                coordinate.Width += mScanAreaVM.ZoomFactor;
                coordinate.Height += mScanAreaVM.ZoomFactor;
            }
            else
            {
                coordinate.Width -= mScanAreaVM.ZoomFactor;
                coordinate.Height -= mScanAreaVM.ZoomFactor;
            }
            // 缩放后判断是否还在区域内部 & 是否小于最小尺寸
            if (coordinate.Right > pbxScanArea.Right || coordinate.Bottom > pbxScanArea.Bottom)
            {
                return;
            }
            else if (coordinate.Width < 20 || coordinate.Height < 20)
            {
                return;
            }
            // 标记坐标范围已经改变
            mCoordinateChanged = true;
            mCoordinate = coordinate;
            DrawScanArea(mCoordinate, mScanAreaGra, pbxScanArea);
        }

        /// <summary>
        /// 扫描范围移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScanRangeMoved(object sender, MouseEventArgs e)
        {
            // 按下左键移动
            if (e.Button == MouseButtons.Left)
            {
                // Logger.Info(string.Format("Coordinate [{0}].", mCoordinate.ToString()));
                if (mCoordinate.Contains(mMouseDownPosition))
                {
                    // Logger.Info(string.Format("Mouse Down Position [{0}].", mMouseDownPosition));
                    Rectangle coordinate = mCoordinate;
                    coordinate.X += e.X - mMouseDownPosition.X;
                    coordinate.Y += e.Y - mMouseDownPosition.Y;
                    if (coordinate.Left < pbxScanArea.Left || coordinate.Right > pbxScanArea.Right || coordinate.Top < pbxScanArea.Top || coordinate.Bottom > pbxScanArea.Bottom)
                    {
                        return;
                    }
                    mMouseDownPosition = e.Location;
                    mCoordinateChanged = true;
                    mCoordinate = coordinate;
                    DrawScanArea(mCoordinate, mScanAreaGra, pbxScanArea);
                }
            }
        }

        /// <summary>
        /// 图像区域鼠标按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseDownChanged(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mMouseDownPosition = e.Location;
                // Logger.Info(string.Format("Mouse Down Position [{0}].", mMouseDownPosition));
            }
            else if (e.Button == MouseButtons.Right)
            {
                contextMenu.ShowContextMenu(pbxScanArea, e.Location);
            }
        }

        private void ScanAreaViewLoad(object sender, EventArgs e)
        {
            Initialize();
            SetDataBindings();
            RegisterEvents();
        }

        /// <summary>
        /// 扫描像素变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScanPixelChanged(object sender, EventArgs e)
        {
            ScanPixelModel scanPixel = (ScanPixelModel)cbxScanPixel.SelectedItem;
            if (scanPixel.IsEnabled)
            {
                return;
            }
            mScanAreaVM.SelectScanPixel(scanPixel.ID);
        }

        /// <summary>
        /// 扫描像素变化事件处理
        /// </summary>
        /// <param name="scanPixel"></param>
        /// <returns></returns>
        private int ScanPixelChangedEventHandler(Engine.Attribute.ScanPixel scanPixel)
        {
            if(scanPixel.ID == ((ScanPixelModel)cbxScanPixel.SelectedItem).ID)
            {
                return ApiCode.Success;
            }
            return mScanAreaVM.ScanPixelChangedEventHandler(scanPixel.ID);
        }

        /// <summary>
        /// 使用最大视场范围
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FullRangeClick(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            mScanAreaVM.SetScanArea(mScanAreaVM.Engine.Configuration.FullScanArea.ScanRange);
            mScanRange = mScanAreaVM.SelectedScanArea.ScanRange;
            mScanPixelRange = mScanAreaVM.ScanRangeToScanPixelRange(mScanRange);
            mCoordinate = ScanPixelRangeToCoordinate(mScanPixelRange);
            mCoordinateChanged = false;

            DrawScanArea(mCoordinate, mScanAreaGra, pbxScanArea);
            DrawScanArea(mCoordinate, mScanAreaGra, pbxScanArea);
        }

        /// <summary>
        /// 使用上一个扫描范围
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LastScanRangeClick(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            mScanRange = mScanAreaVM.SelectedScanArea.ScanRange;
            mScanPixelRange = mScanAreaVM.ScanRangeToScanPixelRange(mScanRange);
            mCoordinate = ScanPixelRangeToCoordinate(mScanPixelRange);
            mCoordinateChanged = false;

            DrawScanArea(mCoordinate, mScanAreaGra, pbxScanArea);
            DrawScanArea(mCoordinate, mScanAreaGra, pbxScanArea);
        }

        /// <summary>
        /// 使用当前扫描范围
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScanRangeConfirmClick(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            mScanPixelRange = CoordinateToScanPixelRange(mCoordinate);
            mScanRange = mScanAreaVM.ScanPixelRangeToScanRange(mScanPixelRange);
            mScanAreaVM.SetScanArea(mScanRange);

            mScanRange = mScanAreaVM.SelectedScanArea.ScanRange;
            mScanPixelRange = mScanAreaVM.ScanRangeToScanPixelRange(mScanRange);
            mCoordinate = ScanPixelRangeToCoordinate(mScanPixelRange);
            mCoordinateChanged = false;

            DrawScanArea(mCoordinate, mScanAreaGra, pbxScanArea);
            DrawScanArea(mCoordinate, mScanAreaGra, pbxScanArea);
        }

        private int ScanAreaChangedEventHandler(Engine.Attribute.ScanArea scanArea)
        {
            return mScanAreaVM.ScanAreaChangedEventHandler(scanArea.ScanRange);
        }

    }
}
