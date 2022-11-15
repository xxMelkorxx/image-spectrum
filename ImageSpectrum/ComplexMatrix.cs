using System;
using System.Drawing;
using System.Numerics;

namespace ImageSpectrum
{
    public struct ComplexMatrix
    {
        public int Width => Matrix.Length;
        public int Height => Matrix[0].Length;

        public Complex[][] Matrix;
        public bool IsSpectrum;

        /// <summary>
        /// Конструктор. Инициализирует MatrixImage с указанным размером.
        /// </summary>
        /// <param name="width">Ширина</param>
        /// <param name="height">Спектр</param>
        /// <param name="isSpectrum">Является спектром?</param>
        public ComplexMatrix(int width, int height, bool isSpectrum = false)
        {
            IsSpectrum = isSpectrum;
            Matrix = new Complex[width][];
            for (var i = 0; i < width; i++)
                Matrix[i] = new Complex[height];
        }

        /// <summary>
        /// Конструктор. Создаёт из bitmap.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="isSpectrum"></param>
        public ComplexMatrix(Bitmap bitmap, bool isSpectrum = false)
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

        /// <summary>
        /// Матрица в виде формате Bitmap. 
        /// </summary>
        public Bitmap GetBitmap()
        {
            var bmp = new Bitmap(Width, Height);
            var matRgb = GetMatrixRgb();

            for (var i = 0; i < Width; i++)
            for (var j = 0; j < Height; j++)
                bmp.SetPixel(i, j, Color.FromArgb(matRgb[i][j], matRgb[i][j], matRgb[i][j]));

            return bmp;
        }

        /// <summary>
        /// Отнормализованная матрица со значенияими в пределах от 0 до 255.  
        /// </summary>
        public byte[][] GetMatrixRgb()
        {
            var max = double.MinValue;
            for (var i = 0; i < Width; i++)
            for (var j = 0; j < Height; j++)
                max = Math.Max(max, Matrix[i][j].Magnitude);

            var normMatrix = new double[Width][];
            var matrixRgb = new byte[Width][];
            for (var i = 0; i < Width; i++)
            {
                normMatrix[i] = new double[Height];
                matrixRgb[i] = new byte[Height];
                for (var j = 0; j < Height; j++)
                    normMatrix[i][j] = Matrix[i][j].Magnitude / max * 255;
            }

            if (!IsSpectrum)
                for (var i = 0; i < Width; i++)
                for (var j = 0; j < Height; j++)
                    matrixRgb[i][j] = (byte)normMatrix[i][j];
            else
            {
                var logMax = double.MinValue;
                for (var i = 0; i < Width; i++)
                for (var j = 0; j < Height; j++)
                    logMax = Math.Max(logMax, Math.Sqrt(Math.Log(1 + normMatrix[i][j])));

                for (var i = 0; i < Width; i++)
                for (var j = 0; j < Height; j++)
                    matrixRgb[i][j] = (byte)(Math.Sqrt(Math.Log(1 + normMatrix[i][j])) / logMax * 255);
            }

            return matrixRgb;
        }
    }
}