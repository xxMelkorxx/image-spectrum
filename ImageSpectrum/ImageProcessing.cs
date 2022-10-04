using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace ImageSpectrum
{
    public enum TypeAddOn
    {
        ZerosAdding,
        BilinearInterpolation
    }
    
    internal class ImageProcessing
    {
        public int Width => InitImage.Width;
        public int Height => InitImage.Height;

        public MatrixImage InitImage;
        public MatrixImage NoiseImage;
        public MatrixImage SpectrumImage;
        public MatrixImage FilteredSpectrumImage;
        public MatrixImage RestoreImage;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="width">Ширина изображения</param>
        /// <param name="height">Высота изображения</param>
        public ImageProcessing(int width, int height)
        {
            InitImage = new MatrixImage(width, height);
        }

        /// <summary>
        /// Конструктор с дополнением к изображению нулей.
        /// </summary>
        /// <param name="bitmap"></param>
        public ImageProcessing(Bitmap bitmap)
        {
            InitImage = new MatrixImage(bitmap);
            InitImage = ZerosAdding(InitImage);
        }
            
        /// <summary>
        /// Конструктор с интерполяцией изображения.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="width">Ширина изображения</param>
        /// <param name="height">Высота изображения</param>
        public ImageProcessing(Bitmap bitmap, int width, int height)
        {
            var newBitmap = Interpolation.BilinearInterpolation(bitmap, width, height);
            InitImage = new MatrixImage(newBitmap);
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
        public void CreateGaussImage(double[] a, double[] sigmaX, double[] sigmaY, double[] shiftX,
            double[] shiftY)
        {
            for (var i = 0; i < Width; i++)
            for (var j = 0; j < Height; j++)
            for (var k = 0; k < a.Length; k++)
                InitImage.Matrix[i][j] += GaussFunction(i, j, a[k], sigmaX[k], sigmaY[k], shiftX[k], shiftY[k]);
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
                energySignal += InitImage.Matrix[i].Sum(j => j.Magnitude * j.Magnitude);
            var energyNoise = energySignal * (snr / 100.0);

            // Нормировка случайной последовательности.
            for (var i = 0; i < Width; i++)
            for (var j = 0; j < Height; j++)
                randomValues[i, j] *= Math.Sqrt(energyNoise / energyRandValues);

            // Накладывание шума на исходный сигнал.
            NoiseImage = new MatrixImage(Width, Height);
            for (var i = 0; i < Width; i++)
            for (var j = 0; j < Height; j++)
                NoiseImage.Matrix[i][j] = InitImage.Matrix[i][j] + randomValues[i, j];
        }

        /// <summary>
        /// Вычисление спектра изображения.
        /// </summary>
        /// <param name="isNoiseImage"></param>
        public void CalculateSpectrum(bool isNoiseImage = false)
        {
            if (isNoiseImage) SpectrumImage = FFT.FFT_2D(NoiseImage, true);
            else SpectrumImage = FFT.FFT_2D(InitImage, true);
        }

        /// <summary>
        /// Фильтрация спектра от шума.
        /// </summary>
        /// <param name="cutoff">Процент энергии относительно энергии спектра, отсекаемая для фильтрации</param>
        public void FilteredSpectrum(double cutoff)
        {
            FilteredSpectrumImage = new MatrixImage(Width, Height, true);
            var array = new List<IndexsValue>();

            double sumEnergy = 0;
            for (var i = 0; i < Width; i++)
            for (var j = 0; j < Height; j++)
            {
                // Подсчёт суммарной энергии.
                sumEnergy += SpectrumImage.Matrix[i][j].Magnitude;

                FilteredSpectrumImage.Matrix[i][j] = SpectrumImage.Matrix[i][j];
                // Запись всех точек спектра в List.
                array.Add(new IndexsValue(i, j, SpectrumImage.Matrix[i][j].Magnitude));
            }

            // Подсчёт пороговой энергии.
            var thresholdEnergy = (1.0 - cutoff / 100.0) * sumEnergy;

            // Сортировка точек спектра по убыванию.
            var orderedArray = from i in array
                orderby i.Value descending
                select i;

            // Запись отсекаемых точек энергий.
            var points = new List<Point>();
            sumEnergy = 0;
            foreach (var i in orderedArray)
                if (sumEnergy < thresholdEnergy) sumEnergy += i.Value;
                else points.Add(new Point(i.I, i.J));

            // Зануление отсекаемых точек энергий на спектре. 
            foreach (var p in points)
                FilteredSpectrumImage.Matrix[p.X][p.Y] = 0;
        }

        /// <summary>
        /// Восстановление изображения из спектра.
        /// </summary>
        /// <param name="isNoiseImage"></param>
        public void RestoringImage(bool isNoiseImage = false)
        {
            if (isNoiseImage) RestoreImage = FFT.FFT_2D(FilteredSpectrumImage, false);
            else RestoreImage = FFT.FFT_2D(SpectrumImage, false);
        }

        /// <summary>
        /// Подсчёт среднеквадратичного отклонения между двумя матрицами.
        /// </summary>
        /// <param name="matrix1">Первая матрица.</param>
        /// <param name="matrix2">Вторая матрица.</param>
        /// <returns></returns>
        public static double GetStandardDeviation(MatrixImage matrix1, MatrixImage matrix2)
        {
            if (matrix1.Width != matrix2.Width ||
                matrix1.Height != matrix2.Height)
                return 0;

            var width = matrix1.Width;
            var height = matrix1.Height;
            double sumUp = 0, sumDown = 0;
            for (var i = 0; i < width; i++)
            for (var j = 0; j < height; j++)
                sumUp += (matrix1.Matrix[i][j].Magnitude - matrix2.Matrix[i][j]).Magnitude *
                         (matrix1.Matrix[i][j].Magnitude - matrix2.Matrix[i][j].Magnitude);

            for (var i = 0; i < width; i++)
            for (var j = 0; j < height; j++)
                sumDown += matrix1.Matrix[i][j].Magnitude * matrix2.Matrix[i][j].Magnitude;

            return sumUp / sumDown;
        }

        public static Bitmap ConvertToHalftone(Bitmap bitmap)
        {
            var newBitmap = new Bitmap(bitmap.Width, bitmap.Height);
            
            for (var i = 0; i < bitmap.Width; i++)
            for (var j = 0; j < bitmap.Height; j++)
            {
                var pixel = bitmap.GetPixel(i, j);
                var halftoneValue = (int)(0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B);
                newBitmap.SetPixel(i, j, Color.FromArgb(halftoneValue, halftoneValue, halftoneValue));
            }

            return newBitmap;
        }

        public static void SizeDegreesOfTwo(ref int width, ref int height)
        {
            for (var newWidth = 2;; newWidth *= 2)
                if (newWidth > width)
                {
                    width = newWidth;
                    break;
                }

            for (var newHeight = 2;; newHeight *= 2)
                if (newHeight > height)
                {
                    height = newHeight;
                    break;
                }
        } 
        
        public static MatrixImage ZerosAdding(MatrixImage matrix)
        {
            var width = matrix.Width;
            var height = matrix.Height;
            SizeDegreesOfTwo(ref width, ref height);

            var newMatrix = new MatrixImage(width, height, matrix.IsSpectrum);
            for (var i = 0; i < width; i++)
            for (var j = 0; j < height; j++)
            {
                if (i < matrix.Width && j < matrix.Height)
                    newMatrix.Matrix[i][j] = matrix.Matrix[i][j];
                else newMatrix.Matrix[i][j] = 0;
            }

            return newMatrix;
        }
    }

    public struct MatrixImage
    {
        public int Width => Matrix.Length;
        public int Height => Matrix[0].Length;

        public Complex[][] Matrix;
        public bool IsSpectrum;

        public MatrixImage(int width, int height, bool isSpectrum = false)
        {
            IsSpectrum = isSpectrum;
            Matrix = new Complex[width][];
            for (var i = 0; i < width; i++)
                Matrix[i] = new Complex[height];
        }
        
        public MatrixImage(Bitmap bitmap, bool isSpectrum = false)
        {
            IsSpectrum = isSpectrum;
            Matrix = new Complex[bitmap.Width][];
            for (var i = 0; i < Width; i++)
            {
                Matrix[i] = new Complex[bitmap.Height];
                for (var j = 0; j < Height; j++)
                    Matrix[i][j] = bitmap.GetPixel(i, j).R;
            }
        }

        public Bitmap Bitmap
        {
            get
            {
                var bmp = new Bitmap(Width, Height);
                var matRgb = MatrixRgb;

                for (var i = 0; i < Width; i++)
                for (var j = 0; j < Height; j++)
                    bmp.SetPixel(i, j, Color.FromArgb(matRgb[i][j], matRgb[i][j], matRgb[i][j]));

                return bmp;
            }
        }

        public int[][] MatrixRgb
        {
            get
            {
                double max = 0;
                for (var i = 0; i < Width; i++)
                    if (Matrix[i].Max(j => j.Magnitude) > max)
                        max = Matrix[i].Max(j => j.Magnitude);

                var normMatrix = new double[Width][];
                for (var i = 0; i < Width; i++)
                {
                    normMatrix[i] = new double[Height];
                    for (var j = 0; j < Height; j++)
                        normMatrix[i][j] = Matrix[i][j].Magnitude / max * 255;
                }

                var matrixRgb = new int[Width][];
                for (var i = 0; i < Width; i++)
                    matrixRgb[i] = new int[Height];

                if (!IsSpectrum)            
                    for (var i = 0; i < Width; i++)
                    for (var j = 0; j < Height; j++)
                        matrixRgb[i][j] = (int)normMatrix[i][j];
                else
                {
                    double logMax = 0;
                    for (var i = 0; i < Width; i++)
                    for (var j = 0; j < Height; j++)
                    {
                        var value = Math.Sqrt(Math.Log(1 + normMatrix[i][j]));
                        if (value > logMax)
                            logMax = value;
                    }

                    for (var i = 0; i < Width; i++)
                    for (var j = 0; j < Height; j++)
                        matrixRgb[i][j] = (int)(Math.Sqrt(Math.Log(1 + normMatrix[i][j])) / logMax * 255);
                }

                return matrixRgb;
            }
        }
    }

    struct IndexsValue
    {
        public int I, J;
        public double Value;

        public IndexsValue(int i, int j, double value)
        {
            I = i;
            J = j;
            Value = value;
        }
    }
}