using log4net;
using NanoInsight.Engine.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Engine.Core
{
    public class ScanSequence
    {
        ///////////////////////////////////////////////////////////////////////////////////////////
        private static readonly ILog Logger = LogManager.GetLogger("info");
        private volatile static ScanSequence pSequence = null;
        private static readonly object locker = new object();
        ///////////////////////////////////////////////////////////////////////////////////////////
        private static readonly int TRIGGER_WIDTH_DEFAULT = 4;
        private static readonly double ACQUISITION_INTERVAL_DEFAULT = 50;
        ///////////////////////////////////////////////////////////////////////////////////////////

        private byte[] triggerWave;
        private double[] xWave;
        private double[] y1Wave;
        private double[] y2Wave;
        private int outputSampleCountPerFrame;
        private int outputRoundTripCountPerFrame;
        private int outputSampleCountPerRoundTrip;
        private double outputSampleRate;
        private double triggerOutputSampleRate;
        private double inputSampleRate;
        private int inputSampleCountPerRoundTrip;
        private int inputRoundTripCountPerFrame;
        private int inputSampleCountPerFrame;
        private int inputSampleCountPerPixel;
        private int inputSampleCountPerAcquisition;
        private int inputPixelCountPerAcquisition;
        private int inputRoundTripCountPerAcquisition;
        private int inputAcquisitionCountPerFrame;
        private int inputSampleCountPerRow;
        private int inputPixelCountPerRow;
        private double fps;
        private double frameTime;

        private double[] yCoordinates;
        private double[] xCoordinates;
        private double[] xVoltages;
        private double[] yVoltaegs;
        private byte[] triggerVoltages;

        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 触发波形
        /// </summary>
        public byte[] TriggerWave
        {
            get { return triggerWave; }
            set { triggerWave = value; }
        }
        /// <summary>
        /// X振镜波形
        /// </summary>
        public double[] XWave
        {
            get { return xWave; }
            set { xWave = value; }
        }
        /// <summary>
        /// Y1振镜波形
        /// </summary>
        public double[] Y1Wave
        {
            get { return y1Wave; }
            set { y1Wave = value; }
        }
        /// <summary>
        /// Y2振镜波形
        /// </summary>
        public double[] Y2Wave
        {
            get { return y2Wave; }
            set { y2Wave = value; }
        }
        /// <summary>
        /// 单帧输出样本数
        /// </summary>
        public int OutputSampleCountPerFrame
        {
            get { return outputSampleCountPerFrame; }
            set { outputSampleCountPerFrame = value; }
        }
        /// <summary>
        /// 单帧往返次数
        /// </summary>
        public int OutputRoundTripCountPerFrame
        {
            get { return outputRoundTripCountPerFrame; }
            set { outputRoundTripCountPerFrame = value; }
        }
        /// <summary>
        /// 单次往返样本数
        /// </summary>
        public int OutputSampleCountPerRoundTrip
        {
            get { return outputSampleCountPerRoundTrip; }
            set { outputSampleCountPerRoundTrip = value; }
        }
        /// <summary>
        /// 样本输出速率
        /// </summary>
        public double OutputSampleRate
        {
            get { return outputSampleRate; }
            set { outputSampleRate = value; }
        }
        /// <summary>
        /// 触发输出速率
        /// </summary>
        public double TriggerOutputSampleRate
        {
            get { return triggerOutputSampleRate; }
            set { triggerOutputSampleRate = value; }
        }
        /// <summary>
        /// 样本采样速率
        /// </summary>
        public double InputSampleRate
        {
            get { return inputSampleRate; }
            set { inputSampleRate = value; }
        }
        /// <summary>
        /// 单次往返采集的样本数
        /// </summary>
        public int InputSampleCountPerRoundTrip
        {
            get { return inputSampleCountPerRoundTrip; }
            set { inputSampleCountPerRoundTrip = value; }
        }
        /// <summary>
        /// 单帧的往返次数
        /// </summary>
        public int InputRoundTripCountPerFrame
        {
            get { return inputRoundTripCountPerFrame; }
            set { inputRoundTripCountPerFrame = value; }
        }
        /// <summary>
        /// 单帧采集的样本数
        /// </summary>
        public int InputSampleCountPerFrame
        {
            get { return inputSampleCountPerFrame; }
            set { inputSampleCountPerFrame = value; }
        }
        /// <summary>
        /// 单像素采集的样本数
        /// </summary>
        public int InputSampleCountPerPixel
        {
            get { return inputSampleCountPerPixel; }
            set { inputSampleCountPerPixel = value; }
        }
        /// <summary>
        /// 单次采集的样本数
        /// </summary>
        public int InputSampleCountPerAcquisition
        {
            get { return inputSampleCountPerAcquisition; }
            set { inputSampleCountPerAcquisition = value; }
        }
        /// <summary>
        /// 单次采集的像素数
        /// </summary>
        public int InputPixelCountPerAcquisition
        {
            get { return inputPixelCountPerAcquisition; }
            set { inputPixelCountPerAcquisition = value; }
        }
        /// <summary>
        /// 单次采集的往返次数
        /// </summary>
        public int InputRoundTripCountPerAcquisition
        {
            get { return inputRoundTripCountPerAcquisition; }
            set { inputRoundTripCountPerAcquisition = value; }
        }
        /// <summary>
        /// 单帧包含的采集次数
        /// </summary>
        public int InputAcquisitionCountPerFrame
        {
            get { return inputAcquisitionCountPerFrame; }
            set { inputAcquisitionCountPerFrame = value; }
        }
        /// <summary>
        /// 每行采集的样本数
        /// </summary>
        public int InputSampleCountPerRow
        {
            get { return inputSampleCountPerRow; }
            set { inputSampleCountPerRow = value; }
        }
        /// <summary>
        /// 每行采集的像素数
        /// </summary>
        public int InputPixelCountPerRow
        {
            get { return inputPixelCountPerRow; }
            set { inputPixelCountPerRow = value; }
        }

        /// <summary>
        /// 帧率
        /// </summary>
        public double FPS
        {
            get { return fps; }
            set { fps = value; }
        }
        /// <summary>
        /// 帧时间
        /// </summary>
        public double FrameTime
        {
            get { return frameTime; }
            set { frameTime = value; }
        }
        /// <summary>
        /// X坐标序列[单次往返]
        /// </summary>
        public double[] XCoordinates
        {
            get { return xCoordinates; }
            set { xCoordinates = value; }
        }
        /// <summary>
        /// Y坐标序列
        /// </summary>
        public double[] YCoordinates
        {
            get { return yCoordinates; }
            set { yCoordinates = value; }
        }
        /// <summary>
        /// X电压序列[单次往返]
        /// </summary>
        public double[] XVoltages
        {
            get { return xVoltages; }
            set { xVoltages = value; }
        }
        /// <summary>
        /// Y电压序列
        /// </summary>
        public double[] YVoltages
        {
            get { return yVoltaegs; }
            set { yVoltaegs = value; }
        }
        /// <summary>
        /// 触发信号序列
        /// </summary>
        public byte[] TriggerVoltages
        {
            get { return triggerVoltages; }
            set { triggerVoltages = value; }
        }

        public static ScanSequence CreateInstance()
        {
            if (pSequence == null)
            {
                lock (locker)
                {
                    if (pSequence == null)
                    {
                        pSequence = new ScanSequence();
                    }
                }
            }
            return pSequence;
        }

        /// <summary>
        /// 生成扫描范围序列和电压序列
        /// </summary>
        public void GenerateScanCoordinates()
        {
            Config config = Config.GetConfig();
            ScanArea extendScanArea = config.GetExtendScanArea();

            if (config.SelectedScanDirection.ID == ScanDirection.Unidirection)
            {
                int lineStartSampleCount = (int)(ScanArea.ScanLineStartTime / config.SelectedScanPixelDwell.Data);
                double scale = extendScanArea.ScanRange.Width / ScanArea.ExtendLineMarginDiv;
                double step0 = -Math.PI / ScanArea.ScanLineStartTime * config.SelectedScanPixelDwell.Data;
                double[] lineSatrtSamples = CreateSinArray(scale, step0, lineStartSampleCount, extendScanArea.ScanRange.X);

                int lineHoldSampleCount = (int)(ScanArea.ScanLineHoldTime / config.SelectedScanPixelDwell.Data);
                double step1 = Math.PI / ScanArea.ScanLineHoldTime * config.SelectedScanPixelDwell.Data;
                double[] lineHoldSamples = CreateSinArray(scale, step1, lineHoldSampleCount, extendScanArea.ScanRange.Right);

                int lineEndSampleCount = (int)(ScanArea.ScanLineEndTime / config.SelectedScanPixelDwell.Data);
                double[] lineEndSamples = CreateLinearArray(extendScanArea.ScanRange.Right, extendScanArea.ScanRange.X, lineEndSampleCount);

                int lineScanSampleCount = config.GetExtendScanXPixels();
                double[] lineScanSamples = CreateLinearArray(extendScanArea.ScanRange.X, extendScanArea.ScanRange.Right, lineScanSampleCount);

                int lineSamples = lineStartSampleCount + lineHoldSampleCount + lineEndSampleCount + lineScanSampleCount;
                XCoordinates = new double[lineSamples];
                Array.Copy(lineSatrtSamples, 0, XCoordinates, 0, lineStartSampleCount);
                Array.Copy(lineScanSamples, 0, XCoordinates, lineStartSampleCount, lineScanSampleCount);
                Array.Copy(lineHoldSamples, 0, XCoordinates, lineStartSampleCount + lineScanSampleCount, lineHoldSampleCount);
                Array.Copy(lineEndSamples, 0, XCoordinates, lineSamples - lineEndSampleCount, lineEndSampleCount);

                int ySamplesCount = config.GetExtendScanYPixels();
                YCoordinates = CreateLinearArray(extendScanArea.ScanRange.Y, extendScanArea.ScanRange.Bottom, ySamplesCount);

                if (config.Detector.CurrentDetecor.ID == DetectorType.Pmt)
                {
                    TriggerVoltages = Enumerable.Repeat<byte>(0x00, lineSamples).ToArray();
                    for (int n = 0; n < TRIGGER_WIDTH_DEFAULT; n++)
                    {
                        TriggerVoltages[lineStartSampleCount + n] = 0x01;
                    }
                }
                else
                {
                    TriggerVoltages = Enumerable.Repeat<byte>(0x00, lineSamples * 2).ToArray();
                    int start = lineStartSampleCount * 2;
                    int end = (lineStartSampleCount + lineScanSampleCount) * 2;
                    for (int i = start; i < end; i += 2)
                    {
                        TriggerVoltages[i] = 0x01;
                    }
                }
            }
            else
            {
                int lineStartSampleCount = (int)(ScanArea.ScanLineStartTime / config.SelectedScanPixelDwell.Data);
                double scale = extendScanArea.ScanRange.Width / ScanArea.ExtendLineMarginDiv;
                double step0 = -Math.PI / ScanArea.ScanLineStartTime * config.SelectedScanPixelDwell.Data;
                double[] lineSatrtSamples = CreateSinArray(scale, step0, lineStartSampleCount, extendScanArea.ScanRange.X);

                // 双向扫描中，ScanLineHoldTime应默认为ScanLineStartTime
                int lineHoldSampleCount = (int)(ScanArea.ScanLineStartTime / config.SelectedScanPixelDwell.Data);
                double step1 = Math.PI / ScanArea.ScanLineStartTime * config.SelectedScanPixelDwell.Data;
                double[] lineHoldSamples = CreateSinArray(scale, step1, lineHoldSampleCount, extendScanArea.ScanRange.Right);

                int lineScanSampleCount = config.GetExtendScanXPixels();
                double[] lineScanSamples = CreateLinearArray(extendScanArea.ScanRange.X, extendScanArea.ScanRange.Right, lineScanSampleCount);

                // 双向扫描中，lineEndSamples=回程的ScanSamples
                int lineEndSampleCount = lineScanSampleCount;
                double[] lineEndSamples = CreateLinearArray(extendScanArea.ScanRange.Right, extendScanArea.ScanRange.X, lineEndSampleCount);

                int lineSamples = lineStartSampleCount + lineHoldSampleCount + lineEndSampleCount + lineScanSampleCount;
                XCoordinates = new double[lineSamples];
                Array.Copy(lineSatrtSamples, 0, XCoordinates, 0, lineStartSampleCount);
                Array.Copy(lineScanSamples, 0, XCoordinates, lineStartSampleCount, lineScanSampleCount);
                Array.Copy(lineHoldSamples, 0, XCoordinates, lineStartSampleCount + lineScanSampleCount, lineHoldSampleCount);
                Array.Copy(lineEndSamples, 0, XCoordinates, lineSamples - lineEndSampleCount, lineEndSampleCount);

                int ySamplesCount = config.GetExtendScanYPixels();
                YCoordinates = CreateLinearArray(extendScanArea.ScanRange.Y, extendScanArea.ScanRange.Bottom, ySamplesCount);

                if (config.Detector.CurrentDetecor.ID == DetectorType.Pmt)
                {
                    TriggerVoltages = Enumerable.Repeat<byte>(0x00, lineSamples).ToArray();
                    for (int n = 0; n < TRIGGER_WIDTH_DEFAULT; n++)
                    {
                        TriggerVoltages[lineStartSampleCount + n] = 0x01;
                        TriggerVoltages[lineSamples - lineEndSampleCount + n] = 0x01;
                    }
                }
                else
                {
                    TriggerVoltages = Enumerable.Repeat<byte>(0x00, lineSamples * 2).ToArray();
                    int start = lineStartSampleCount * 2;
                    int end = (lineStartSampleCount + lineScanSampleCount) * 2;
                    for (int i = start; i < end; i += 2)
                    {
                        TriggerVoltages[i] = 0x01;
                    }
                    start = (lineStartSampleCount + lineHoldSampleCount + lineScanSampleCount) * 2;
                    end = lineSamples * 2;
                    for (int i = start; i < end; i += 2)
                    {
                        TriggerVoltages[i] = 0x01;
                    }
                }
            }

            XVoltages = config.GalvoAttr.XCoordinateToVoltage(XCoordinates);
            YVoltages = config.GalvoAttr.YCoordinateToVoltage(YCoordinates);

            // 计算输出相关参数
            OutputSampleRate = 1e6 / config.SelectedScanPixelDwell.Data;
            TriggerOutputSampleRate = config.Detector.CurrentDetecor.ID == DetectorType.Pmt ? OutputSampleRate : OutputSampleRate * 2;
            OutputSampleCountPerRoundTrip = XVoltages.Length;
            OutputRoundTripCountPerFrame = config.SelectedScanDirection.ID == ScanDirection.Unidirection ? YVoltages.Length : YVoltages.Length / 2;
            OutputSampleCountPerFrame = OutputSampleCountPerRoundTrip * OutputRoundTripCountPerFrame;

            // 计算采集相关参数
            InputSampleRate = config.Detector.CurrentDetecor.ID == DetectorType.Pmt ? config.InputSampleRate : OutputSampleRate;
            InputSampleCountPerPixel = (int)(InputSampleRate / OutputSampleRate);
            InputRoundTripCountPerFrame = OutputRoundTripCountPerFrame;
            if (config.SelectedScanDirection.ID == ScanDirection.Unidirection)
            {
                InputSampleCountPerRoundTrip = config.GetExtendScanXPixels() * InputSampleCountPerPixel;
                InputSampleCountPerRow = InputSampleCountPerRoundTrip;
            }
            else
            {
                InputSampleCountPerRoundTrip = config.GetExtendScanXPixels() * InputSampleCountPerPixel * 2;
                InputSampleCountPerRow = InputSampleCountPerRoundTrip / 2;
            }
            InputSampleCountPerFrame = InputRoundTripCountPerFrame * InputSampleCountPerRoundTrip;

            double roundTripTime = OutputSampleCountPerRoundTrip * config.SelectedScanPixelDwell.Data / 1e3;
            int nRoundTrips = (int)Math.Ceiling(ACQUISITION_INTERVAL_DEFAULT / roundTripTime);
            while (nRoundTrips > 1)
            {
                if (OutputRoundTripCountPerFrame % nRoundTrips == 0)
                {
                    break;
                }
                nRoundTrips--;
            }
            InputRoundTripCountPerAcquisition = nRoundTrips;                                // 单次采集的往返次数
            InputSampleCountPerAcquisition = InputSampleCountPerRoundTrip * nRoundTrips;    // 单次采集的样本数
            InputPixelCountPerAcquisition = InputSampleCountPerAcquisition / InputSampleCountPerPixel;  // 单次采集的像素数
            InputAcquisitionCountPerFrame = InputRoundTripCountPerFrame / nRoundTrips;      // 单帧包含的采集次数

            // 帧率和帧时间
            FrameTime = OutputSampleCountPerFrame * config.SelectedScanPixelDwell.Data / 1e6;
            FPS = 1.0 / FrameTime;

            InputPixelCountPerRow = InputSampleCountPerRow / InputSampleCountPerPixel;
        }

        /// <summary>
        /// 生成帧电压序列
        /// </summary>
        public void GenerateFrameScanWaves()
        {
            Config config = Config.GetConfig();
            WaveInitialize();

            if (config.SelectedScanDirection.ID == ScanDirection.Unidirection)
            {
                int index = -OutputSampleCountPerRoundTrip;
                for (int n = 0; n < OutputRoundTripCountPerFrame; n++)
                {
                    index += OutputSampleCountPerRoundTrip;
                    Array.Copy(XVoltages, 0, XWave, index, OutputSampleCountPerRoundTrip);
                    Array.Copy(Enumerable.Repeat<double>(YVoltages[n], OutputSampleCountPerRoundTrip).ToArray(), 0, Y1Wave, index, OutputSampleCountPerRoundTrip);
                    if (config.SelectedScanHead.ID == ScanHead.ThreeGalvo)
                    {
                        Array.Copy(Enumerable.Repeat<double>(YVoltages[n] * 2, OutputSampleCountPerRoundTrip).ToArray(), 0, Y2Wave, index, OutputSampleCountPerRoundTrip);
                    }
                }
            }
            else
            {
                int index = -OutputSampleCountPerRoundTrip;
                for (int n = 0; n < OutputRoundTripCountPerFrame; n++)
                {
                    index += OutputSampleCountPerRoundTrip;
                    Array.Copy(XVoltages, 0, XWave, index, OutputSampleCountPerRoundTrip);
                    Array.Copy(Enumerable.Repeat<double>(YVoltages[2 * n], OutputSampleCountPerRoundTrip >> 1).ToArray(), 0, Y1Wave, index, OutputSampleCountPerRoundTrip >> 1);
                    Array.Copy(Enumerable.Repeat<double>(YVoltages[2 * n + 1], OutputSampleCountPerRoundTrip >> 1).ToArray(), 0, Y1Wave, index + (OutputSampleCountPerRoundTrip >> 1), OutputSampleCountPerRoundTrip >> 1);
                    if (config.SelectedScanHead.ID == ScanHead.ThreeGalvo)
                    {
                        Array.Copy(Enumerable.Repeat<double>(YVoltages[2 * n] * 2, OutputSampleCountPerRoundTrip >> 1).ToArray(), 0, Y2Wave, index, OutputSampleCountPerRoundTrip >> 1);
                        Array.Copy(Enumerable.Repeat<double>(YVoltages[2 * n + 1] * 2, OutputSampleCountPerRoundTrip >> 1).ToArray(), 0, Y2Wave, index + (OutputSampleCountPerRoundTrip >> 1), OutputSampleCountPerRoundTrip >> 1);
                    }
                }
            }

            Array.Copy(TriggerVoltages, TriggerWave, TriggerVoltages.Length);

            int resetSampleCount = (int)(ScanArea.ScanLineStartTime / config.SelectedScanPixelDwell.Data);
            double[] y1ResetVoltages = CreateLinearArray(YVoltages.Last(), YVoltages[0], resetSampleCount);
            Array.Copy(y1ResetVoltages, 0, Y1Wave, 0, resetSampleCount);
            if (config.SelectedScanHead.ID == ScanHead.ThreeGalvo)
            {
                double[] y2ResetVoltages = CreateLinearArray(YVoltages.Last() * 2, YVoltages[0] * 2, resetSampleCount);
                Array.Copy(y2ResetVoltages, 0, Y2Wave, 0, resetSampleCount);
            }
        }

        /// <summary>
        /// 生成线性序列
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static double[] CreateLinearArray(double start, double end, int count)
        {
            double[] array = new double[count];
            double step = (end - start) / count;
            for (int n = 0; n < count; n++)
            {
                array[n] = start + step * n;
            }
            return array;
        }

        /// <summary>
        /// 生成正弦函数序列
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static double[] CreateSinArray(double scale, double step, int count, double offset)
        {
            double[] array = new double[count];
            for (int n = 0; n < count; n++)
            {
                array[n] = scale * Math.Sin(step * n) + offset;
            }
            return array;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void WaveInitialize()
        {
            if (TriggerWave == null || TriggerWave.Length != TriggerVoltages.Length)
            {
                TriggerWave = new byte[TriggerVoltages.Length];
            }

            if (XWave == null || XWave.Length != OutputSampleCountPerFrame)
            {
                XWave = new double[OutputSampleCountPerFrame];
            }

            if (Y1Wave == null || Y1Wave.Length != OutputSampleCountPerFrame)
            {
                Y1Wave = new double[OutputSampleCountPerFrame];
            }

            if (Config.GetConfig().SelectedScanHead.ID == ScanHead.ThreeGalvo)
            {
                if (Y2Wave == null || Y2Wave.Length != OutputSampleCountPerFrame)
                {
                    Y2Wave = new double[OutputSampleCountPerFrame];
                }
            }
        }

        private ScanSequence()
        {
            GenerateScanCoordinates();
        }
    }
}
