using System;
using System.Numerics;

namespace ImageSpectrum
{
    /// <summary>
    /// Быстрое преобразование Фурье.
    /// </summary>
    public static class FFT
    {
        public const double DoublePi = 2 * Math.PI;
        /// <summary>
        /// Децимация по частоте.
        /// </summary>
        /// <param name="frame">Массив комлексных чисел.</param>
        /// <param name="direct">Прямой ход?</param>
        /// <returns></returns>
        public static Complex[] DecimationInFrequency(Complex[] frame, bool direct)
        {
            if (frame.Length == 1) return frame;
            int halfSampleSize = frame.Length >> 1; // frame.Length/2;
            int fullSampleSize = frame.Length;

            double arg = direct ? -DoublePi / fullSampleSize : DoublePi / fullSampleSize;
            Complex omegaPowBase = new Complex(Math.Cos(arg), Math.Sin(arg));
            Complex omega = Complex.One;
            Complex[] spectrum = new Complex[fullSampleSize];

            for (int j = 0; j < halfSampleSize; j++)
            {
                spectrum[j] = frame[j] + frame[j + halfSampleSize];
                spectrum[j + halfSampleSize] = omega * (frame[j] - frame[j + halfSampleSize]);
                omega *= omegaPowBase;
            }

            Complex[] yTop = new Complex[halfSampleSize];
            Complex[] yBottom = new Complex[halfSampleSize];
            for (int i = 0; i < halfSampleSize; i++)
            {
                yTop[i] = spectrum[i];
                yBottom[i] = spectrum[i + halfSampleSize];
            }

            yTop = DecimationInFrequency(yTop, direct);
            yBottom = DecimationInFrequency(yBottom, direct);
            for (int i = 0; i < halfSampleSize; i++)
            {
                int j = i << 1; // i = 2*j;
                spectrum[j] = yTop[i];
                spectrum[j + 1] = yBottom[i];
            }

            return spectrum;
        }

        public static Complex[,] FFT_2D(Complex[,] frame, bool direct)
        {
            int width = frame.GetLength(0);
            int height = frame.GetLength(1);

            Complex[,] spectrum = new Complex[width, height];
            Complex[] row = new Complex[width];
            Complex[] column = new Complex[height];

            for (int h = 0; h < height; h++)
            {
                for (int w = 0; w < width; w++)
                    row[w] = frame[h, w];
                row = DecimationInFrequency(row, direct);
                for (int w = 0; w < width; w++)
                    spectrum[h, w] = row[w];
            }

            for (int w = 0; w < width; w++)
            {
                for (int h = 0; h < width; h++)
                    column[h] = spectrum[h, w];
                column = DecimationInFrequency(column, direct);
                for (int h = 0; h < width; h++)
                    spectrum[h, w] = column[h];
            }

            return spectrum;
        }
    }
}