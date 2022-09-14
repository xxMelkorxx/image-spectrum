using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace ImageSpectrum
{
	class Picture
	{
		public int width, height;
		public PictureMatrix initImage;
		public PictureMatrix noiseImage;
		public PictureMatrix spectrumImage;

		public Picture(int width, int height)
		{
			this.width = width;
			this.height = height;
			initImage = new PictureMatrix(width, height);
		}

		private double GaussFunction(double x, double y, double a, double sigma_x, double sigma_y, double shift_x, double shift_y)
		{
			return a * Math.Exp(-(Math.Pow((x - shift_x) / sigma_x, 2) + Math.Pow((y - shift_y) / sigma_y, 2)));
		}

		public void CreateSurfaceGauss(double[] a, double[] sigma_x, double[] sigma_y, double[] shift_x, double[] shift_y)
		{
			for (int i = 0; i < width; i++)
				for (int j = 0; j < height; j++)
					for (int k = 0; k < a.Length; k++)
						initImage.matrix[i, j] += GaussFunction(i, j, a[k], sigma_x[k], sigma_y[k], shift_x[k], shift_y[k]);
		}

		public void AddNoise(double snr)
		{
			Random rnd = new Random(DateTime.Now.Millisecond);

			double[,] randomValues = new double[width, height];
			double energyRandValues = 0;
			for (int i = 0; i < width; i++)
				for (int j = 0; j < height; j++)
				{
					randomValues[i, j] = 0;
					for (int n = 0; n < 12; n++)
						randomValues[i, j] += rnd.Next(0, 100);
					randomValues[i, j] /= 12;
					energyRandValues += randomValues[i, j] * randomValues[i, j];
				}

			// Подсчёт энергии шума относительно энергии.
			double energySignal = 0;
			for (int i = 0; i < width; i++)
				for (int j = 0; j < height; j++)
					energySignal += initImage.matrix[i, j].Magnitude * initImage.matrix[i, j].Magnitude;
			double energyNoise = energySignal * (snr / 100.0);

			// Нормировка случайной последовательности.
			for (int i = 0; i < width; i++)
				for (int j = 0; j < height; j++)
					randomValues[i, j] = randomValues[i, j] * Math.Sqrt(energyNoise / energyRandValues);

			// Накладывание шума на исходный сигнал.
			noiseImage = new PictureMatrix(width, height);
			for (int i = 0; i < width; i++)
				for (int j = 0; j < height; j++)
					noiseImage.matrix[i, j] = initImage.matrix[i, j] + randomValues[i, j];
		}

		public void TransformSpectrum()
		{
			Complex[,] tempSpectrum = new Complex[width, height];
			for (int i = 0; i < width; i++)
				for (int j = 0; j < height; j++)
					tempSpectrum[i, j] = spectrumImage.matrix[i, j];

			int half_width = width / 2;
			int half_height = height / 2;
			for (int i = 0; i < half_width; i++)
				for (int j = 0; j < half_height; j++)
				{
					spectrumImage.matrix[i, j] = tempSpectrum[i + half_width, j + half_height];
					spectrumImage.matrix[i + half_width, j] = tempSpectrum[i, j + half_height];
					spectrumImage.matrix[i, j + half_height] = tempSpectrum[i + half_width, j];
					spectrumImage.matrix[i + half_width, j + half_height] = tempSpectrum[i, j];
				}
        }

		public void CalculateFurie(bool direct)
		{
			spectrumImage = new PictureMatrix(width, height);

			if (noiseImage.matrix != null)
				spectrumImage.matrix = FFT.FFT_2D(noiseImage.matrix, direct);
			else spectrumImage.matrix = FFT.FFT_2D(initImage.matrix, direct);
		}
	}

	public struct PictureMatrix
	{
		public int width, height;
		public Complex[,] matrix;

		public PictureMatrix(int width, int height)
		{
			this.width = width;
			this.height = height;
			matrix = new Complex[width, height];
		}

		public Bitmap bitmap
		{
			get
			{
				Bitmap bmp = new Bitmap(width, height);
				int[,] matRGB = matrixRGB;
				for (int i = 0; i < width; i++)
					for (int j = 0; j < height; j++)
						bmp.SetPixel(i, j, Color.FromArgb(matRGB[i, j], matRGB[i, j], matRGB[i, j]));

				return bmp;
			}
		}

		public int[,] matrixRGB
		{
			get
			{
				double max = 0;
				for (int i = 0; i < width; i++)
					for (int j = 0; j < height; j++)
						if (matrix[i, j].Magnitude > max) max = matrix[i, j].Magnitude;

				int[,] matrixRGB = new int[width, height];
				for (int i = 0; i < width; i++)
					for (int j = 0; j < height; j++)
						matrixRGB[i, j] = (int)Math.Abs(matrix[i, j].Magnitude / max * 255);

				return matrixRGB;
			}
		}
	}
}