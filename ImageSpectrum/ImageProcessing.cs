using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace ImageSpectrum
{
    internal class ImageProcessing
    {
        public int Width => InitImage.Width;
        public int Height => InitImage.Height;

        public MatrixImage InitImage;
        public MatrixImage NoiseImage;
        public MatrixImage SpectrumImage;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="width">Ширина изображения</param>
        /// <param name="height">Высота изображения</param>
        public ImageProcessing(int width, int height)
        {
            InitImage = new MatrixImage(width, height);
        }

        public ImageProcessing(Bitmap bitmap)
        {
            InitImage = new MatrixImage(bitmap.Width, bitmap.Height);
            for (var i = 0; i < Width; i++)
            for (var j = 0; j < Height; j++)
            {
                var pixel = bitmap.GetPixel(i, j);
                InitImage.Matrix[i, j] = 0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B;
            }
            InitImage.Matrix = ZerosAdding(InitImage.Matrix);
        }

        /// <summary>
        /// Функция двумерного Гауссова купола.
        /// </summary>
        /// <param name="x">Координата Х</param>
        /// <param name="y">Координата Y</param>
        /// <param name="a">Амплитуда</param>
        /// <param name="sigmaX">Ширина купола по Х</param>
        /// <param name="sigmaY">Ширина купола по Y</param>
        /// <param name="shiftX">Сдвиг по X</param>
        /// <param name="shiftY">Сдвиг по Y.</param>
        /// <returns>Возвращает значение в точке (x,y).</returns>
        private static double GaussFunction(double x, double y, double a, double sigmaX, double sigmaY, double shiftX,
            double shiftY)
        {
            return a * Math.Exp(-(Math.Pow((x - shiftX) / sigmaX, 2) + Math.Pow((y - shiftY) / sigmaY, 2)));
        }

        /// <summary>
        /// Создание изображения из Гауссовых куполов.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="sigmaX"></param>
        /// <param name="sigmaY"></param>
        /// <param name="shiftX"></param>
        /// <param name="shiftY"></param>
        public void CreateSurfaceGauss(double[] a, double[] sigmaX, double[] sigmaY, double[] shiftX,
            double[] shiftY)
        {
            for (var i = 0; i < Width; i++)
            for (var j = 0; j < Height; j++)
            for (var k = 0; k < a.Length; k++)
                InitImage.Matrix[i, j] += GaussFunction(i, j, a[k], sigmaX[k], sigmaY[k], shiftX[k], shiftY[k]);
        }

        /// <summary>
        /// Добавление шума на изображение
        /// </summary>
        /// <param name="snr">Отношение сигнал/шум (%)</param>
        public void AddNoise(double snr)
        {
            var rnd = new Random(DateTime.Now.Millisecond);
            var randomValues = new double[Width, Height];
            double energyRandValues = 0;
            for (var i = 0; i < Width; i++)
            for (var j = 0; j < Height; j++)
            {
                randomValues[i, j] = rnd.NextDouble();
                // randomValues[i, j] = 0;
                // for (int n = 0; n < 12; n++)
                //     randomValues[i, j] += rnd.Next(-100, 100);
                // randomValues[i, j] /= 12;
                energyRandValues += randomValues[i, j] * randomValues[i, j];
            }

            // Подсчёт энергии шума относительно энергии.
            double energySignal = 0;
            for (var i = 0; i < Width; i++)
            for (var j = 0; j < Height; j++)
                energySignal += InitImage.Matrix[i, j].Magnitude * InitImage.Matrix[i, j].Magnitude;
            var energyNoise = energySignal * (snr / 100.0);

            // Нормировка случайной последовательности.
            for (var i = 0; i < Width; i++)
            for (var j = 0; j < Height; j++)
                randomValues[i, j] = randomValues[i, j] * Math.Sqrt(energyNoise / energyRandValues);

            // Накладывание шума на исходный сигнал.
            NoiseImage = new MatrixImage(Width, Height);
            for (var i = 0; i < Width; i++)
            for (var j = 0; j < Height; j++)
                NoiseImage.Matrix[i, j] = InitImage.Matrix[i, j] + randomValues[i, j];
        }

        /// <summary>
        /// Трансформация спектра, чтобы основная энергия была сконцентрирована в центре.
        /// </summary>
        public void TransformSpectrum()
        {
            var tempSpectrum = new Complex[Width, Height];
            for (var i = 0; i < Width; i++)
            for (var j = 0; j < Height; j++)
                tempSpectrum[i, j] = SpectrumImage.Matrix[i, j];

            var halfWidth = Width / 2;
            var halfHeight = Height / 2;
            for (var i = 0; i < halfWidth; i++)
            for (var j = 0; j < halfHeight; j++)
            {
                SpectrumImage.Matrix[i, j] = tempSpectrum[i + halfWidth, j + halfHeight];
                SpectrumImage.Matrix[i + halfWidth, j] = tempSpectrum[i, j + halfHeight];
                SpectrumImage.Matrix[i, j + halfHeight] = tempSpectrum[i + halfWidth, j];
                SpectrumImage.Matrix[i + halfWidth, j + halfHeight] = tempSpectrum[i, j];
            }
        }

        /// <summary>
        /// Вычисление Фурье для изображения.
        /// </summary>
        /// <param name="direct"></param>
        /// <param name="isNoiseImage"></param>
        public void CalculateFurie(bool direct, bool isNoiseImage = false)
        {
            SpectrumImage = new MatrixImage(Width, Height, true);

            if (isNoiseImage)
                SpectrumImage.Matrix = FFT.FFT_2D(NoiseImage.Matrix, direct);
            else SpectrumImage.Matrix = FFT.FFT_2D(InitImage.Matrix, direct);
        }

        public static Complex[,] ZerosAdding(Complex[,] matrix)
        {
            var width = matrix.GetLength(0);
            var height = matrix.GetLength(1);
            for (var x = 2;; x *= 2)
                if (x > width)
                {
                    width = x;
                    break;
                }

            for (var y = 2;; y *= 2)
                if (y > height)
                {
                    height = y;
                    break;
                }

            var newMatrix = new Complex[width, height];
            for (var i = 0; i < width; i++)
            for (var j = 0; j < height; j++)
            {
                if (i < matrix.GetLength(0) && j < matrix.GetLength(1))
                    newMatrix[i, j] = matrix[i, j];
                else newMatrix[i, j] = 0;
            }

            return newMatrix;
        }
    }

    public struct MatrixImage
    {
        public int Width => Matrix.GetLength(0);
        public int Height => Matrix.GetLength(1);
        
        public Complex[,] Matrix;
        public bool IsSpectrum;

        public MatrixImage(int width, int height, bool isSpectrum = false)
        {
            IsSpectrum = isSpectrum;
            Matrix = new Complex[width, height];
        }

        public Bitmap Bitmap
        {
            get
            {
                var bmp = new Bitmap(Width, Height);
                var matRgb = MatrixRgb;

                for (var i = 0; i < Width; i++)
                for (var j = 0; j < Height; j++)
                    bmp.SetPixel(i, j, Color.FromArgb(matRgb[i, j], matRgb[i, j], matRgb[i, j]));

                return bmp;
            }
        }

        public int[,] MatrixRgb
        {
            get
            {
                double max = 0;

                if (!IsSpectrum)
                {
                    for (var i = 0; i < Width; i++)
                    for (var j = 0; j < Height; j++)
                        if (Matrix[i, j].Magnitude > max)
                            max = Matrix[i, j].Magnitude;
                }

                var matrixRgb = new int[Width, Height];
                for (var i = 0; i < Width; i++)
                for (var j = 0; j < Height; j++)
                {
                    if (IsSpectrum)
                    {
                        matrixRgb[i, j] = (int)(Math.Log10(1 + Matrix[i, j].Magnitude) * 255);
                        if (matrixRgb[i, j] > 255) matrixRgb[i, j] = 255;
                    }
                    else matrixRgb[i, j] = (int)Math.Abs(Matrix[i, j].Magnitude / max * 255);
                }

                return matrixRgb;
            }
        }
    }
}