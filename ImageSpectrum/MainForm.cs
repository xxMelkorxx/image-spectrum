using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Numerics;

namespace ImageSpectrum
{
	public partial class MainForm : Form
	{
		private Picture picture;

		public MainForm()
		{
			InitializeComponent();
		}

		private void OnClickButtonCalculate(object sender, EventArgs e)
		{
			int width = (int)numUpDown_Width.Value;
			int height = (int)numUpDown_Height.Value;

			picture = new Picture(width, height);

			picture.CreateSurfaceGauss(
				new double[] { (double)numUpDown_a1.Value, (double)numUpDown_a2.Value, (double)numUpDown_a3.Value },
				new double[] { (double)numUpDown_sigmaX1.Value, (double)numUpDown_sigmaX2.Value, (double)numUpDown_sigmaX3.Value },
				new double[] { (double)numUpDown_sigmaY1.Value, (double)numUpDown_sigmaY2.Value, (double)numUpDown_sigmaY3.Value },
				new double[] { (double)numUpDown_shiftX1.Value, (double)numUpDown_shiftX2.Value, (double)numUpDown_shiftX3.Value },
				new double[] { (double)numUpDown_shiftY1.Value, (double)numUpDown_shiftY2.Value, (double)numUpDown_shiftY3.Value }
			);

			if (checkBox_isNoise.Checked)
				picture.AddNoise((double)numUpDown_SNR.Value);

			picture.CalculateFurie(true);
			picture.TransformSpectrum();

			if (checkBox_isNoise.Checked)
			{
				ImageForm noiseImageForm = new ImageForm();
				noiseImageForm.Text = "Зашумлённое изображение";
				noiseImageForm.pictBox_Image.Image = picture.noiseImage.bitmap;
				noiseImageForm.Show();

				button_GetNoiseImage.Enabled = true;
			}
			else
			{
				ImageForm initImageForm = new ImageForm();
				initImageForm.Text = "Исходное изображение";
				initImageForm.pictBox_Image.Image = picture.initImage.bitmap;
				initImageForm.Show();

			}

			ImageForm imageForm = new ImageForm();
			imageForm.Text = "Спектр изображения";
			imageForm.pictBox_Image.Image = picture.spectrumImage.bitmap;
			imageForm.Show();

			button_GetSpectrum.Enabled = true;
			button_GetImage.Enabled = true;
		}

		private void OnClickButtonGetImage(object sender, EventArgs e)
		{
			ImageForm imageForm = new ImageForm();
			imageForm.Text = "Исходное изображение";
			imageForm.pictBox_Image.Image = picture.initImage.bitmap;
			imageForm.Show();
		}

		private void OnClickButtonGetNoiseImage(object sender, EventArgs e)
		{
			ImageForm imageForm = new ImageForm();
			imageForm.Text = "Зашумлённое изображение";
			imageForm.pictBox_Image.Image = picture.noiseImage.bitmap;
			imageForm.Show();
		}

		private void OnClickButtonGetSpectrumImage(object sender, EventArgs e)
		{

			ImageForm imageForm = new ImageForm();
			imageForm.Text = "Спектр изображения";
			imageForm.pictBox_Image.Image = picture.spectrumImage.bitmap;
			imageForm.Show();
		}

		private void OnClickButtonLoadImage(object sender, EventArgs e)
		{

		}

		private void OnCheckedChangedCheckBoxIsNoise(object sender, EventArgs e)
		{
			if (checkBox_isNoise.Checked)
			{
				numUpDown_SNR.Enabled = true;
				//button_GetNoiseImage.Enabled = true;
			}
			else
			{
				numUpDown_SNR.Enabled = false;
				//button_GetNoiseImage.Enabled = false;
			}
		}


	}
}
