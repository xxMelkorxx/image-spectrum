using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace ImageSpectrum
{
    public enum TypeInterpolation
    {
        Bilinear,
        ZerosAdding,
        None
    }

    internal class ImageProcessing
    {
        public ComplexMatrix InitMatrix;
        public ComplexMatrix NoiseMatrix;
        public ComplexMatrix SpectrumMatrix;
        public ComplexMatrix FilteredSpectrumMatrix;
        public ComplexMatrix RestoredMatrix;
        
        public Bitmap InitImage;

        public Bitmap RestoredImage
        {
            get
            {
                if (_typeInterpolation == TypeInterpolation.Bilinear)
                    return Interpolation.BilinearInterpolation(RestoredMatrix.GetBitmap(), _oldWidth, _oldHeight);
                if (_typeInterpolation == TypeInterpolation.ZerosAdding)
                    return ZerosCutoff(RestoredMatrix, _oldWidth, _oldHeight).GetBitmap();
                return RestoredMatrix.GetBitmap();
            }
        }
        
        private int Width => InitMatrix.Width;
        private int Height => InitMatrix.Height;

        private TypeInterpolation _typeInterpolation;
        private int _oldWidth;
        private int _oldHeight;
        
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="width">Ширина изображения</param>
        /// <param name="height">Высота изображения</param>
        public ImageProcessing(int width, int height)
        {
            _typeInterpolation = TypeInterpolation.None;
            InitMatrix = new ComplexMatrix(width, height);
        }

        /// <summary>
        /// Конструктор с дополнением к изображению нулей.
        /// </summary>
        /// <param name="bitmap"></param>
        public ImageProcessing(Bitmap bitmap)
        {
            _typeInterpolation = TypeInterpolation.ZerosAdding;
            _oldWidth = bitmap.Width;
            _oldHeight = bitmap.Height;

            InitImage = ConvertToHalftone(bitmap);
            InitMatrix = new ComplexMatrix(InitImage);
            InitMatrix = ZerosAdding(InitMatrix);
        }

        /// <summary>
        /// Конструктор с интерполяцией изображения.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="width">Ширина изображения</param>
        /// <param name="height">Высота изображения</param>
        public ImageProcessing(Bitmap bitmap, int width, int height)
        {
            _typeInterpolation = TypeInterpolation.Bilinear;
            _oldWidth = bitmap.Width;
            _oldHeight = bitmap.Height;

            InitImage = ConvertToHalftone(bitmap);
            InitMatrix = new ComplexMatrix(Interpolation.BilinearInterpolation(InitImage, width, height));
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
        private static double GaussFunction(double x, double y, double a, double sigmaX, double sigmaY, double shiftX, double shiftY)
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
        public void CreateGaussImage(double[] a, double[] sigmaX, double[] sigmaY, double[] shiftX, double[] shiftY)
        {
            for (var i = 0; i < Width; i++)
            for (var j = 0; j < Height; j++)
            for (var k = 0; k < a.Length; k++)
                InitMatrix.Matrix[i][j] += GaussFunction(i, j, a[k], sigmaX[k], sigmaY[k], shiftX[k], shiftY[k]);
            
            InitImage = InitMatrix.GetBitmap();
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
                energyRandValues += randomValues[i, j] * randomValues[i, j];
            }

            // Подсчёт энергии шума относительно энергии.
            double energySignal = 0;
            for (var i = 0; i < Width; i++)
                energySignal += InitMatrix.Matrix[i].Sum(j => j.Magnitude * j.Magnitude);
            var energyNoise = energySignal * (snr / 100.0);

            // Нормировка случайной последовательности.
            for (var i = 0; i < Width; i++)
            for (var j = 0; j < Height; j++)
                randomValues[i, j] *= Math.Sqrt(energyNoise / energyRandValues);

            // Накладывание шума на исходный сигнал.
            NoiseMatrix = new ComplexMatrix(Width, Height);
            for (var i = 0; i < Width; i++)
            for (var j = 0; j < Height; j++)
                NoiseMatrix.Matrix[i][j] = InitMatrix.Matrix[i][j] + randomValues[i, j];
        }

        /// <summary>
        /// Вычисление спектра изображения.
        /// </summary>
        /// <param name="isNoiseImage"></param>
        public void CalculateSpectrum(bool isNoiseImage = false)
        {
            if (isNoiseImage) SpectrumMatrix = Fourier.FFT_2D(NoiseMatrix, true);
            else SpectrumMatrix = Fourier.FFT_2D(InitMatrix, true);
        }

        /// <summary>
        /// Фильтрация спектра от шума.
        /// </summary>
        /// <param name="cutoff">Процент энергии относительно энергии спектра, отсекаемая для фильтрации</param>
        public void FilteredSpectrumSmallEnergyCutoff(double cutoff)
        {
            FilteredSpectrumMatrix = new ComplexMatrix(Width, Height, true);
            var array = new List<IndexsValue>();

            double sumEnergy = 0;
            for (var i = 0; i < Width; i++)
            for (var j = 0; j < Height; j++)
            {
                sumEnergy += SpectrumMatrix.Matrix[i][j].Magnitude;

                FilteredSpectrumMatrix.Matrix[i][j] = SpectrumMatrix.Matrix[i][j];
                // Запись всех точек спектра в List.
                array.Add(new IndexsValue(i, j, SpectrumMatrix.Matrix[i][j].Magnitude));
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
                FilteredSpectrumMatrix.Matrix[p.X][p.Y] = 0;
        }

        public void FilteredSpectrumCircleCutoff(double rCutoff)
        {
            var halfWidth = Width >> 1;
            var halfHeight = Height >> 1;

            FilteredSpectrumMatrix = new ComplexMatrix(Width, Height, true);
            for (var i = 0; i < Width; i++)
            for (var j = 0; j < Height; j++)
            {
                if (Math.Pow(halfWidth - i, 2) + Math.Pow(halfHeight - j, 2) <= rCutoff * rCutoff)
                    FilteredSpectrumMatrix.Matrix[i][j] = SpectrumMatrix.Matrix[i][j];
                else FilteredSpectrumMatrix.Matrix[i][j] = Complex.Zero;
            }
        }

        /// <summary>
        /// Восстановление изображения из спектра.
        /// </summary>
        /// <param name="isNoiseImage">Есть шум?</param>
        public void RestoringImage(bool isNoiseImage = false)
        {
            if (isNoiseImage) RestoredMatrix = Fourier.FFT_2D(FilteredSpectrumMatrix, false);
            else RestoredMatrix = Fourier.FFT_2D(SpectrumMatrix, false);
        }

		/// <summary>
		/// Подсчёт среднеквадратичного отклонения между двумя матрицами.
		/// </summary>
		/// <param name="m1">Первая матрица.</param>
		/// <param name="m2">Вторая матрица.</param>
		/// <returns></returns>
		public static double GetStandardDeviation(ComplexMatrix m1, ComplexMatrix m2)
		{
			if (m1.Width != m2.Width ||
				m1.Height != m2.Height)
				return 0;

			var w = m1.Width;
			var h = m1.Height;
			double sumUp = 0, sumDown = 0;
			for (var i = 0; i < w; i++)
				for (var j = 0; j < h; j++)
				{
					sumUp += (m1.Matrix[i][j].Magnitude - m2.Matrix[i][j].Magnitude) * (m1.Matrix[i][j].Magnitude - m2.Matrix[i][j].Magnitude);
					sumDown += m1.Matrix[i][j].Magnitude * m2.Matrix[i][j].Magnitude;
				}

			return sumUp / sumDown;
		}

		/// <summary>
		/// Конвертация изображения в полутоновое.
		/// </summary>
		/// <param name="bitmap"></param>
		/// <returns></returns>
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

        public static ComplexMatrix ZerosAdding(ComplexMatrix complexMatrix)
        {
            var width = complexMatrix.Width;
            var height = complexMatrix.Height;

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

            var newMatrix = new ComplexMatrix(width, height, complexMatrix.IsSpectrum);
            for (var i = 0; i < width; i++)
            for (var j = 0; j < height; j++)
            {
                if (i < complexMatrix.Width && j < complexMatrix.Height)
                    newMatrix.Matrix[i][j] = complexMatrix.Matrix[i][j];
                else newMatrix.Matrix[i][j] = 0;
            }

            return newMatrix;
        }

        /// <summary>
        /// Обрезание нулей у матрицы.
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="oldWidth"></param>
        /// <param name="oldHeight"></param>
        /// <returns></returns>
        public static ComplexMatrix ZerosCutoff(ComplexMatrix matrix, int oldWidth, int oldHeight)
        {
            var newMatrix = new ComplexMatrix(oldWidth, oldHeight, matrix.IsSpectrum);
            for (var i = 0; i < oldWidth; i++)
            for (var j = 0; j < oldHeight; j++)
                newMatrix.Matrix[i][j] = matrix.Matrix[i][j];

            return newMatrix;
        }
    }

    public struct IndexsValue
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