using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImageSpectrum
{
    public partial class MainForm : Form
    {
        private ImageProcessing _imageProcessing;
        private Bitmap _initImage;
        private bool _isLoad;

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Событие генерации изображения из Гауссовых куполов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickButtonGenerateImage(object sender, EventArgs e)
        {
            var width = (int)numUpDown_width.Value;
            var height = (int)numUpDown_height.Value;

            _imageProcessing = new ImageProcessing(width, height);
            _imageProcessing.CreateGaussImage(
                new[] { (double)numUpDown_a1.Value, (double)numUpDown_a2.Value, (double)numUpDown_a3.Value },
                new[] { (double)numUpDown_sigmaX1.Value, (double)numUpDown_sigmaX2.Value, (double)numUpDown_sigmaX3.Value },
                new[] { (double)numUpDown_sigmaY1.Value, (double)numUpDown_sigmaY2.Value, (double)numUpDown_sigmaY3.Value },
                new[] { (double)numUpDown_shiftX1.Value, (double)numUpDown_shiftX2.Value, (double)numUpDown_shiftX3.Value },
                new[] { (double)numUpDown_shiftY1.Value, (double)numUpDown_shiftY2.Value, (double)numUpDown_shiftY3.Value }
            );

            _isLoad = false;
            button_GetImage.Enabled = true;
            button_GetSpectrum.Enabled = true;
            button_GetFilteredSpectrum.Enabled = false;
            button_GetRestoredImage.Enabled = false;
            groupBox_paramsNoise.Enabled = true;

            OnGetImage(null, null);
        }

        /// <summary>
        /// Событие загрузки изображения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickButtonLoadImage(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Image Files(*.BMP;*.PNG;*.JPG)|*.BMP;*.PNG;*.JPG|All files (*.*)|*.*"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _initImage = new Bitmap(dialog.FileName);
                    if (rB_zerosAdding.Checked)
                        _imageProcessing = new ImageProcessing(_initImage);
                    else if (rB_bilinearInterpolation.Checked)
                    {
                        var width = (int)numUpDown_width.Value;
                        var height = (int)numUpDown_height.Value;
                        _imageProcessing = new ImageProcessing(_initImage, width, height);
                    }

                    _isLoad = true;
                    button_GetImage.Enabled = true;
                    button_GetSpectrum.Enabled = true;
                    button_GetFilteredSpectrum.Enabled = false;
                    button_GetRestoredImage.Enabled = false;
                    groupBox_paramsNoise.Enabled = true;
                    checkBox_isNoise.Checked = false;

                    CallImageForm("Исходное изображение", _imageProcessing.InitImage);
                    CallImageForm("Исходное изображение (интерполированное)", _imageProcessing.InitMatrix.GetBitmap());
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Ошибка!");
                }
            }
        }

        /// <summary>
        /// Событие на отображения исходного изображения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnGetImage(object sender, EventArgs e)
        {
            CallImageForm("Исходное изображение", _imageProcessing.InitImage);
            if (_isLoad)
                CallImageForm("Исходное изображение (интерполированное)", _imageProcessing.InitMatrix.GetBitmap());
        }

        /// <summary>
        /// Событие на отображение зашёмленного изображения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnGetNoiseImage(object sender, EventArgs e)
        {
            CallImageForm("Зашумлённое изображение", _imageProcessing.NoiseMatrix.GetBitmap());
        }

        /// <summary>
        /// Событие на отображение спектра изображения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnGetSpectrumImage(object sender, EventArgs e)
        {
            _imageProcessing.CalculateSpectrum(checkBox_isNoise.Checked);

            if (checkBox_isNoise.Checked)
                button_GetFilteredSpectrum.Enabled = true;
            else button_GetRestoredImage.Enabled = true;

            CallImageForm("Спектр изображения", _imageProcessing.SpectrumMatrix.GetBitmap());
        }

        /// <summary>
        /// Событие на отображение отфильтрованного изображения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void OnGetFilteredSpectrum(object sender, EventArgs e)
        {
            if (rB_cutoffCircle.Checked)
                _imageProcessing.FilteredSpectrumCircleCutoff((double)numUpDown_radiusCutoff.Value);
            else if (rB_cutoffSmallEnergy.Checked)
                _imageProcessing.FilteredSpectrumSmallEnergyCutoff((double)numUpDown_cutoffEnergy.Value);

            CallImageForm("Отфильтрованный спектр", _imageProcessing.FilteredSpectrumMatrix.GetBitmap());

            button_GetRestoredImage.Enabled = true;
        }

        /// <summary>
        /// Событие на отборажение восстановленного изображения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnGetRestoredImage(object sender, EventArgs e)
        {
            _imageProcessing.RestoringImage(checkBox_isNoise.Checked);
            CallImageForm("Восстановленное изображение", _imageProcessing.RestoredMatrix.GetBitmap());
            if (_isLoad)
                CallImageForm("Восстановленное изображение (интерполированное)", _imageProcessing.RestoredImage);
            var sko = ImageProcessing.GetStandardDeviation(_imageProcessing.InitMatrix, _imageProcessing.RestoredMatrix);
            textBox_SkoInitAndRestore.Text = sko.ToString("F5");
        }

        /// <summary>
        /// Событие на добавление шума в исходное изображение.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnAddNoiseToImage(object sender, EventArgs e)
        {
            if (checkBox_isNoise.Checked)
            {
                _imageProcessing.AddNoise((double)numUpDown_snr.Value);
                var sko = ImageProcessing.GetStandardDeviation(_imageProcessing.InitMatrix, _imageProcessing.NoiseMatrix);
                textBox_SkoInitAndNoise.Text = sko.ToString("F5");
            }
        }

        /// <summary>
        /// Событие на проверку наличия шума в изображении.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCheckedChangedCheckBoxIsNoise(object sender, EventArgs e)
        {
            button_GetRestoredImage.Enabled = false;
            if (checkBox_isNoise.Checked)
            {
                button_GetNoiseImage.Enabled = true;
                OnAddNoiseToImage(null, null);
            }
            else
            {
                button_GetNoiseImage.Enabled = false;
                button_GetFilteredSpectrum.Enabled = false;
            }
        }

        private void OnCheckedChangedCutoffCircle(object sender, EventArgs e)
        {
            numUpDown_radiusCutoff.Enabled = rB_cutoffCircle.Checked;
        }

        private void OnCheckedChangedSmallEnergy(object sender, EventArgs e)
        {
            numUpDown_cutoffEnergy.Enabled = rB_cutoffSmallEnergy.Checked;
        }

        /// <summary>
        /// Функция вызовы формы с изображением.
        /// </summary>
        /// <param name="header">Название формы</param>
        /// <param name="bitmap">Изображение в формате Bitmap</param>
        private static void CallImageForm(string header, Bitmap bitmap)
        {
            var imageForm = new ImageForm(bitmap)
            {
                Text = header,
            };
            imageForm.Show();
        }
    }
}