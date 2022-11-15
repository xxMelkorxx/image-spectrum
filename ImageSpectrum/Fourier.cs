using System;
using System.Numerics;

namespace ImageSpectrum
{
    /// <summary>
    /// Быстрое преобразование Фурье.
    /// </summary>
    public static class Fourier
    {
        /// <summary>
        /// Быстрое преобразование Фурье.
        /// </summary>
        /// <param name="frame">Массив комлексных чисел.</param>
        /// <param name="direct">Прямой ход?</param>
        /// <returns></returns>
        public static Complex[] FFT(Complex[] frame, bool direct)
        {
            if (frame.Length == 1) return frame;
            var halfSize = frame.Length >> 1;
            var size = frame.Length;

            var arg = direct ? -2 * Math.PI / size : 2 * Math.PI / size;
			var omegaPowBase = new Complex(Math.Cos(arg), Math.Sin(arg));
			var omega = Complex.One;
            var spectrum = new Complex[size];

            for (var j = 0; j < halfSize; j++)
            {
                spectrum[j] = frame[j] + frame[j + halfSize];
                spectrum[j + halfSize] = omega * (frame[j] - frame[j + halfSize]);
                omega *= omegaPowBase;
            }

            var yTop = new Complex[halfSize];
            var yBottom = new Complex[halfSize];
            for (var i = 0; i < halfSize; i++)
            {
                yTop[i] = spectrum[i];
                yBottom[i] = spectrum[i + halfSize];
            }

            yTop = FFT(yTop, direct);
            yBottom = FFT(yBottom, direct);
            for (var i = 0; i < halfSize; i++)
            {
                var j = i << 1;
                spectrum[j] = yTop[i];
                spectrum[j + 1] = yBottom[i];
            }

            return spectrum;
        }

        public static ComplexMatrix FFT_2D(ComplexMatrix frame, bool direct)
        {
            var width = frame.Width;
            var height = frame.Height;
            var result = new ComplexMatrix(width, height, !frame.IsSpectrum);
            
            if (!direct) frame = AngularTransform(frame);
            for (var i = 0; i < width; i++)
                result.Matrix[i] = FFT(frame.Matrix[i], direct);
            result = Transform(result);
            for (var i = 0; i < height; i++)
                result.Matrix[i] = FFT(result.Matrix[i], direct);
            result = Transform(result);
            if (direct) result = AngularTransform(result);

            if (!direct)
                for (var i = 0; i < width; i++)
                for (var j = 0; j < height; j++)
                    result.Matrix[i][j] /= width * height;

            return result;
        }

        /// <summary>
        /// Транспонирование матрицы.
        /// </summary>
        /// <param name="init">Исходная матрица</param>
        /// <returns>Трансвонированная матрица</returns>
        public static ComplexMatrix Transform(ComplexMatrix init)
        {
            var width = init.Width;
            var height = init.Height;
            var result = new ComplexMatrix(height, width, init.IsSpectrum);
            
            for (var i = 0; i < height; i++)
            for (var j = 0; j < width; j++)
                result.Matrix[i][j] = init.Matrix[j][i];
            
            return result;
        }

        /// <summary>
        /// Трансформация спектра, чтобы основная энергия была сконцентрирована в центре.
        /// </summary>
        public static ComplexMatrix AngularTransform(ComplexMatrix spectrum)
        {
            var width = spectrum.Width;
            var height = spectrum.Height;
            var halfWidth = width >> 1;
            var halfHeight = height >> 1;
            var result = new ComplexMatrix(width, height, spectrum.IsSpectrum);

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