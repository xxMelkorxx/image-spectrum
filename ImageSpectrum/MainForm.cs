using System;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace ImageSpectrum
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void OnLoadMainForm(object sender, EventArgs e)
		{
			OnClickButtonShow(null, null);
		}

		private void OnClickButtonShow(object sender, EventArgs e)
		{
			bool isNoise = checkBox_isNoise.Checked;

			Task task = Task.Factory.StartNew(() =>
			{
				Surface surface = new Surface(512, 512);
				surface.CreateSurfaceGauss(
					new double[] { (double)numUpDown_a1.Value, (double)numUpDown_a2.Value, (double)numUpDown_a3.Value },
					new double[] { (double)numUpDown_sigmaX1.Value, (double)numUpDown_sigmaX2.Value, (double)numUpDown_sigmaX3.Value },
					new double[] { (double)numUpDown_sigmaY1.Value, (double)numUpDown_sigmaY2.Value, (double)numUpDown_sigmaY3.Value },
					new double[] { (double)numUpDown_shiftX1.Value, (double)numUpDown_shiftX2.Value, (double)numUpDown_shiftX3.Value },
					new double[] { (double)numUpDown_shiftY1.Value, (double)numUpDown_shiftY2.Value, (double)numUpDown_shiftY3.Value }
					);

				if (isNoise)
					surface.AddNoise((double)numUpDown_SNR.Value);

				pictBox_Image.Image = Surface.GetBitmap(surface.matrix);

				double[,] spectrum = surface.GetSpectrum();
				pictBox_ImageSpectrum.Image = Surface.GetBitmap(spectrum);

				Application.DoEvents();
			});

			while (!task.IsCompleted)
				Application.DoEvents();
		}

		private void OnClickButtonLoadImage(object sender, EventArgs e)
		{

		}

		private void OnCheckedChangedCheckBoxIsNoise(object sender, EventArgs e)
		{
			if (checkBox_isNoise.Checked)
			{
				numUpDown_SNR.Enabled = true;
				OnClickButtonShow(null, null);
			}
			else
			{
				numUpDown_SNR.Enabled = false;
				OnClickButtonShow(null, null);
			}
		}
	}
}
