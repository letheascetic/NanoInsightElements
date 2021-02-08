using Emgu.CV;
using Emgu.CV.CvEnum;
using MathNet.Numerics.LinearAlgebra.Double;
using NanoInsight.Engine.Attribute;
using NumSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Engine.Common
{
    public class MatrixUtil
    {
        /// <summary>
        /// 求解矩阵运算Ax=B中的x
        /// </summary>
        /// <param name="matrixData">矩阵A</param>
        /// <param name="matrixResult">结果B</param>
        /// <returns></returns>
        public static double[] SolveMatrix(double[,] matrixData, double[] matrixResult)
        {
            DenseMatrix a = DenseMatrix.OfArray(matrixData);
            DenseVector b = new DenseVector(matrixResult);
            var x = a.LU().Solve(b);
            return x.AsArray();
        }

        /// <summary>
        /// 负电压转换成正电压
        /// </summary>
        /// <param name="samples"></param>
        public static void ToPositive(ref ushort[] samples)
        {
            for (int i = 0; i < samples.Length; i++)
            {
                if (samples[i] >= short.MaxValue)
                {
                    samples[i] = (ushort)(ushort.MaxValue - samples[i]);
                }
            }
        }

        /// <summary>
        /// 负电压转正电压
        /// </summary>
        /// <param name="samples"></param>
        public static void ToPositive(ref short[] samples)
        {
            for (int i = 0; i < samples.Length; i++)
            {
                if (samples[i] < 0)
                {
                    samples[i] = (short)(-samples[i]);
                }
            }
        }

        /// <summary>
        /// 计算脉冲数差值
        /// </summary>
        /// <param name="samples"></param>
        /// <param name="samplesPerRow"></param>
        public static void ToCounter(int[] samples, int samplesPerRow)
        {
            for (int i = 0; i < samples.Length - 1; i++)
            {
                samples[i] = samples[i + 1] - samples[i];
            }
            for (int i = samplesPerRow - 1; i < samples.Length; i += samplesPerRow)
            {
                samples[i] = samples[i - 1];
            }
        }

        /// <summary>
        /// 将单次采集的样本转换成矩阵数据
        /// </summary>
        /// <param name="samples">单次采集的样本</param>
        /// <param name="samplesPerPixel">单像素包含的样本数，每个像素等于多个样本的和</param>
        /// <param name="pixelsPerRow">初始矩阵单行的像素数</param>
        /// <param name="pixelsPerCol">矩阵包含的行数</param>
        /// <param name="scanDirection">扫描方向标志位</param>
        /// <param name="pixelOffset">Bank矩阵相对于初始矩阵的行偏置</param>
        /// <param name="pixelCalibration">双向扫描时，Bank矩阵偶数行相对于初始矩阵的错位补偿</param>
        /// <param name="matrixWidth">Bank矩阵单行的像素数</param>
        /// <returns></returns>
        public static NDArray ToMatrix(int[] samples, int samplesPerPixel, int pixelsPerRow, int pixelsPerCol, int scanDirection, int pixelOffset, int pixelCalibration, int matrixWidth)
        {
            var origin = np.array<int>(samples, false).reshape(samplesPerPixel, pixelsPerRow, pixelsPerCol);
            var matrix = origin.sum(0).T;
            if (scanDirection == ScanDirection.Unidirection)
            {
                matrix = matrix["...", string.Format("{0}:{1}", pixelOffset, pixelOffset + matrixWidth)];
                return matrix;
            }
            var cy = matrix["1::2", "::-1"].copy();
            matrix = matrix["...", string.Format("{0}:{1}", pixelOffset, pixelOffset + matrixWidth)];
            matrix["1::2"] = cy["...", string.Format("{0}:{1}", pixelCalibration, pixelCalibration + matrixWidth)];
            return matrix;
        }

        /// <summary>
        /// 将矩阵数据转换成Bank图像数据
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="image"></param>
        public static void ToBankImage(NDArray matrix, ref Mat image, int pixelOffset, int pixelCalibration)
        {
            NDArray subMatrix = matrix["...", string.Format("{0}:{1}", pixelOffset, pixelOffset + image.Width)];
            subMatrix["1::2"] = matrix["1::2", string.Format("{0}:{1}", pixelCalibration, pixelCalibration + image.Width)];
            image.SetTo<int>(subMatrix.ToArray<int>());
        }

        public static void ToBankImage(NDArray matrix, ref Mat image)
        {
            image.SetTo<int>(matrix.ToArray<int>());
        }

        public static void ToGrayImage(Mat originImage, ref Mat grayImage, double scale, int offset)
        {
            originImage.ConvertTo(grayImage, DepthType.Cv8U, scale, offset);
        }

    }
}
