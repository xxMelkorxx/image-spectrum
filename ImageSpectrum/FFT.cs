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
            var halfSampleSize = frame.Length >> 1;
            var fullSampleSize = frame.Length;

            var arg = direct ? -DoublePi / fullSampleSize : DoublePi / fullSampleSize;
            var omegaPowBase = new Complex(Math.Cos(arg), Math.Sin(arg));
            var omega = Complex.One;
            var spectrum = new Complex[fullSampleSize];

            for (var j = 0; j < halfSampleSize; j++)
            {
                spectrum[j] = frame[j] + frame[j + halfSampleSize];
                spectrum[j + halfSampleSize] = omega * (frame[j] - frame[j + halfSampleSize]);
                omega *= omegaPowBase;
            }

            var yTop = new Complex[halfSampleSize];
            var yBottom = new Complex[halfSampleSize];
            for (var i = 0; i < halfSampleSize; i++)
            {
                yTop[i] = spectrum[i];
                yBottom[i] = spectrum[i + halfSampleSize];
            }

            yTop = DecimationInFrequency(yTop, direct);
            yBottom = DecimationInFrequency(yBottom, direct);
            for (var i = 0; i < halfSampleSize; i++)
            {
                var j = i << 1; // i = 2*j;
                spectrum[j] = yTop[i];
                spectrum[j + 1] = yBottom[i];
            }

            return spectrum;
        }

        public static MatrixImage FFT_2D(MatrixImage frame, bool direct)
        {
            var width = frame.Width;
            var height = frame.Height;
            var spectrum = new MatrixImage(width, height, !frame.IsSpectrum);
            
            if (!direct) frame = AngularTransform(frame);
            for (var i = 0; i < width; i++)
                spectrum.Matrix[i] = DecimationInFrequency(frame.Matrix[i], direct);
            spectrum = Transform(spectrum);
            for (var i = 0; i < height; i++)
                spectrum.Matrix[i] = DecimationInFrequency(spectrum.Matrix[i], direct);
            spectrum = Transform(spectrum);
            if (direct) spectrum = AngularTransform(spectrum);

            if (!direct)
                for (var i = 0; i < width; i++)
                for (var j = 0; j < height; j++)
                    spectrum.Matrix[i][j] /= width * height;

            return spectrum;
        }

        /// <summary>
        /// Транспонирование матрицы.
        /// </summary>
        /// <param name="init">Исходная матрица</param>
        /// <returns>Трансвонированная матрица</returns>
        public static MatrixImage Transform(MatrixImage init)
        {
            var width = init.Width;
            var height = init.Height;
            var result = new MatrixImage(height, width, init.IsSpectrum);
            
            for (var i = 0; i < height; i++)
            for (var j = 0; j < width; j++)
                result.Matrix[i][j] = init.Matrix[j][i];
            
            return result;
        }

        /// <summary>
        /// Трансформация спектра, чтобы основная энергия была сконцентрирована в центре.
        /// </summary>
        public static MatrixImage AngularTransform(MatrixImage spectrum)
        {
            var width = spectrum.Width;
            var height = spectrum.Height;
            var halfWidth = width >> 1;
            var halfHeight = height >> 1;
            var result = new MatrixImage(width, height, spectrum.IsSpectrum);

            for (var i = 0; i < halfWidth; i++)
            for (var j = 0; j < halfHeight; j++)
            {
                result.Matrix[i][j] = spectrum.Matrix[i + halfWidth][j + halfHeight];
                result.Matrix[i + halfWidth][j] = spectrum.Matrix[i][j + halfHeight];
                result.Matrix[i][j + halfHeight] = spectrum.Matrix[i + halfWidth][j];
                result.Matrix[i + halfWidth][j + halfHeight] = spectrum.Matrix[i][j];
            }

            return result;
        }
    }
}