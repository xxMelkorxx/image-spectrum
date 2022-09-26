using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace ImageSpectrum
{
    public partial class MainForm : Form
    {
        private ImageProcessing _imageProcessing;

        public MainForm()
        {
            InitializeComponent();
        }

        private void OnClickButtonGenerateImage(object sender, EventArgs e)
        {
            var width = (int)numUpDown_Width.Value;
            var height = (int)numUpDown_Height.Value;

            _imageProcessing = new ImageProcessing(width, height);
            _imageProcessing.CreateSurfaceGauss(
                new[] { (double)numUpDown_a1.Value, (double)numUpDown_a2.Value, (double)numUpDown_a3.Value },
                new[]
                {
                    (double)numUpDown_sigmaX1.Value, (double)numUpDown_sigmaX2.Value, (double)numUpDown_sigmaX3.Value
                },
                new[]
                {
                    (double)numUpDown_sigmaY1.Value, (double)numUpDown_sigmaY2.Value, (double)numUpDown_sigmaY3.Value
                },
                new[]
                {
                    (double)numUpDown_shiftX1.Value, (double)numUpDown_shiftX2.Value, (double)numUpDown_shiftX3.Value
                },
                new[]
                {
                    (double)numUpDown_shiftY1.Value, (double)numUpDown_shiftY2.Value, (double)numUpDown_shiftY3.Value
                }
            );

            button_GetSpectrum.Enabled = true;
            groupBox_paramsNoise.Enabled = true;
            OnGetImage(null, null);
        }

        private void OnClickButtonLoadImage(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Image Files(*.BMP;*.PNG;*.JPG)|*.BMP;*.PNG;*.JPG|All files (*.*)|*.*",
                InitialDirectory = AppDomain.CurrentDomain.BaseDirectory
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var bmp = new Bitmap(dialog.FileName);
                    _imageProcessing = new ImageProcessing(bmp);
                    button_GetSpectrum.Enabled = true;
                    groupBox_paramsNoise.Enabled = true;
                    CallImageForm("Исходное изображение", bmp);
                    CallImageForm("Исходное изображение (полутоновое)", _imageProcessing.InitImage.Bitmap);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Ошибка!");
                    throw;
                }
            }
        }

        private void OnClickButtonCalculate(object sender, EventArgs e)
        {
            
        }

        private void OnGetImage(object sender, EventArgs e)
        {
            CallImageForm("Исходное изображение", _imageProcessing.InitImage.Bitmap);
        }

        private void OnGetNoiseImage(object sender, EventArgs e)
        {
            _imageProcessing.AddNoise((double)numUpDown_SNR.Value);
            CallImageForm("Зашумлённое изображение", _imageProcessing.NoiseImage.Bitmap);
        }

        private void OnGetSpectrumImage(object sender, EventArgs e)
        {
            if (checkBox_isNoise.Checked)
                _imageProcessing.CalculateFurie(true, true);
            else
                _imageProcessing.CalculateFurie(true);
            _imageProcessing.TransformSpectrum();
            CallImageForm("Спектр изображения", _imageProcessing.SpectrumImage.Bitmap);
        }

        private void OnCheckedChangedCheckBoxIsNoise(object sender, EventArgs e)
        {
            if (checkBox_isNoise.Checked)
                button_GetNoiseImage.Enabled = true;
            else button_GetNoiseImage.Enabled = false;
        }

        private static void CallImageForm(string header, Bitmap bmp)
        {
            var imageForm = new ImageForm(header, bmp);
            imageForm.Show();
        }
    }
}