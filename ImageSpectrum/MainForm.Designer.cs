namespace ImageSpectrum
{
	partial class MainForm
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.GroupBox groupBox_paramsDome3;
			System.Windows.Forms.Label label_sigmaY3;
			System.Windows.Forms.Label label_shiftY3;
			System.Windows.Forms.Label label_shiftX3;
			System.Windows.Forms.Label label_sigmaX3;
			System.Windows.Forms.Label label_a3;
			System.Windows.Forms.GroupBox groupBox_paramsDome2;
			System.Windows.Forms.Label label_sigmaY2;
			System.Windows.Forms.Label label_shiftY2;
			System.Windows.Forms.Label label_shiftX2;
			System.Windows.Forms.Label label_sigmaX2;
			System.Windows.Forms.Label label_a2;
			System.Windows.Forms.GroupBox groupBox_paramsDome1;
			System.Windows.Forms.Label label_sigmaY1;
			System.Windows.Forms.Label label_shiftY1;
			System.Windows.Forms.Label label_shiftX1;
			System.Windows.Forms.Label label_sigmaX1;
			System.Windows.Forms.Label label_a1;
			System.Windows.Forms.Label label_SNR;
			System.Windows.Forms.GroupBox groupBox_paramImage;
			System.Windows.Forms.Label label_Height;
			System.Windows.Forms.Label label_Width;
			System.Windows.Forms.GroupBox groupBox_Sko;
			System.Windows.Forms.Label label_SkoInitAndNoise;
			System.Windows.Forms.Label label_SkoInitAndRestore;
			System.Windows.Forms.Label label_CutoffEnergy;
			System.Windows.Forms.GroupBox groupBox_paramFiltered;
			System.Windows.Forms.Label label_radiusCutoff;
			System.Windows.Forms.GroupBox groupBox_AdditionImage;
			this.nuD_sigmaY3 = new System.Windows.Forms.NumericUpDown();
			this.nuD_shiftY3 = new System.Windows.Forms.NumericUpDown();
			this.nuD_shiftX3 = new System.Windows.Forms.NumericUpDown();
			this.nuD_sigmaX3 = new System.Windows.Forms.NumericUpDown();
			this.nuD_a3 = new System.Windows.Forms.NumericUpDown();
			this.nuD_sigmaY2 = new System.Windows.Forms.NumericUpDown();
			this.nuD_shiftY2 = new System.Windows.Forms.NumericUpDown();
			this.nuD_shiftX2 = new System.Windows.Forms.NumericUpDown();
			this.nuD_sigmaX2 = new System.Windows.Forms.NumericUpDown();
			this.nuD_a2 = new System.Windows.Forms.NumericUpDown();
			this.nuD_sigmaY1 = new System.Windows.Forms.NumericUpDown();
			this.nuD_shiftY1 = new System.Windows.Forms.NumericUpDown();
			this.nuD_shiftX1 = new System.Windows.Forms.NumericUpDown();
			this.nuD_sigmaX1 = new System.Windows.Forms.NumericUpDown();
			this.nuD_a1 = new System.Windows.Forms.NumericUpDown();
			this.nuD_height = new System.Windows.Forms.NumericUpDown();
			this.nuD_width = new System.Windows.Forms.NumericUpDown();
			this.textBox_SkoInitAndNoise = new System.Windows.Forms.TextBox();
			this.textBox_SkoInitAndRestore = new System.Windows.Forms.TextBox();
			this.numUpDown_radiusCutoff = new System.Windows.Forms.NumericUpDown();
			this.rB_cutoffSmallEnergy = new System.Windows.Forms.RadioButton();
			this.rB_cutoffCircle = new System.Windows.Forms.RadioButton();
			this.numUpDown_cutoffEnergy = new System.Windows.Forms.NumericUpDown();
			this.rB_bilinearInterpolation = new System.Windows.Forms.RadioButton();
			this.rB_zerosAdding = new System.Windows.Forms.RadioButton();
			this.groupBox_paramsNoise = new System.Windows.Forms.GroupBox();
			this.checkBox_isNoise = new System.Windows.Forms.CheckBox();
			this.numUpDown_snr = new System.Windows.Forms.NumericUpDown();
			this.button_GetSpectrum = new System.Windows.Forms.Button();
			this.button_LoadImage = new System.Windows.Forms.Button();
			this.button_GetImage = new System.Windows.Forms.Button();
			this.button_GetNoiseImage = new System.Windows.Forms.Button();
			this.button_GenerateImage = new System.Windows.Forms.Button();
			this.button_GetFilteredSpectrum = new System.Windows.Forms.Button();
			this.button_GetRestoredImage = new System.Windows.Forms.Button();
			groupBox_paramsDome3 = new System.Windows.Forms.GroupBox();
			label_sigmaY3 = new System.Windows.Forms.Label();
			label_shiftY3 = new System.Windows.Forms.Label();
			label_shiftX3 = new System.Windows.Forms.Label();
			label_sigmaX3 = new System.Windows.Forms.Label();
			label_a3 = new System.Windows.Forms.Label();
			groupBox_paramsDome2 = new System.Windows.Forms.GroupBox();
			label_sigmaY2 = new System.Windows.Forms.Label();
			label_shiftY2 = new System.Windows.Forms.Label();
			label_shiftX2 = new System.Windows.Forms.Label();
			label_sigmaX2 = new System.Windows.Forms.Label();
			label_a2 = new System.Windows.Forms.Label();
			groupBox_paramsDome1 = new System.Windows.Forms.GroupBox();
			label_sigmaY1 = new System.Windows.Forms.Label();
			label_shiftY1 = new System.Windows.Forms.Label();
			label_shiftX1 = new System.Windows.Forms.Label();
			label_sigmaX1 = new System.Windows.Forms.Label();
			label_a1 = new System.Windows.Forms.Label();
			label_SNR = new System.Windows.Forms.Label();
			groupBox_paramImage = new System.Windows.Forms.GroupBox();
			label_Height = new System.Windows.Forms.Label();
			label_Width = new System.Windows.Forms.Label();
			groupBox_Sko = new System.Windows.Forms.GroupBox();
			label_SkoInitAndNoise = new System.Windows.Forms.Label();
			label_SkoInitAndRestore = new System.Windows.Forms.Label();
			label_CutoffEnergy = new System.Windows.Forms.Label();
			groupBox_paramFiltered = new System.Windows.Forms.GroupBox();
			label_radiusCutoff = new System.Windows.Forms.Label();
			groupBox_AdditionImage = new System.Windows.Forms.GroupBox();
			groupBox_paramsDome3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nuD_sigmaY3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nuD_shiftY3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nuD_shiftX3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nuD_sigmaX3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nuD_a3)).BeginInit();
			groupBox_paramsDome2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nuD_sigmaY2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nuD_shiftY2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nuD_shiftX2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nuD_sigmaX2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nuD_a2)).BeginInit();
			groupBox_paramsDome1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nuD_sigmaY1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nuD_shiftY1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nuD_shiftX1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nuD_sigmaX1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nuD_a1)).BeginInit();
			groupBox_paramImage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nuD_height)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nuD_width)).BeginInit();
			groupBox_Sko.SuspendLayout();
			groupBox_paramFiltered.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numUpDown_radiusCutoff)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numUpDown_cutoffEnergy)).BeginInit();
			groupBox_AdditionImage.SuspendLayout();
			this.groupBox_paramsNoise.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numUpDown_snr)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox_paramsDome3
			// 
			groupBox_paramsDome3.Controls.Add(label_sigmaY3);
			groupBox_paramsDome3.Controls.Add(this.nuD_sigmaY3);
			groupBox_paramsDome3.Controls.Add(label_shiftY3);
			groupBox_paramsDome3.Controls.Add(this.nuD_shiftY3);
			groupBox_paramsDome3.Controls.Add(label_shiftX3);
			groupBox_paramsDome3.Controls.Add(this.nuD_shiftX3);
			groupBox_paramsDome3.Controls.Add(label_sigmaX3);
			groupBox_paramsDome3.Controls.Add(this.nuD_sigmaX3);
			groupBox_paramsDome3.Controls.Add(label_a3);
			groupBox_paramsDome3.Controls.Add(this.nuD_a3);
			groupBox_paramsDome3.Location = new System.Drawing.Point(406, 98);
			groupBox_paramsDome3.Name = "groupBox_paramsDome3";
			groupBox_paramsDome3.Size = new System.Drawing.Size(191, 160);
			groupBox_paramsDome3.TabIndex = 9;
			groupBox_paramsDome3.TabStop = false;
			groupBox_paramsDome3.Text = "Параметры 3-го купола";
			// 
			// label_sigmaY3
			// 
			label_sigmaY3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			label_sigmaY3.AutoSize = true;
			label_sigmaY3.Location = new System.Drawing.Point(7, 78);
			label_sigmaY3.Name = "label_sigmaY3";
			label_sigmaY3.Size = new System.Drawing.Size(91, 14);
			label_sigmaY3.TabIndex = 12;
			label_sigmaY3.Text = "Ширина по Y:";
			// 
			// numUpDown_sigmaY3
			// 
			this.nuD_sigmaY3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nuD_sigmaY3.DecimalPlaces = 1;
			this.nuD_sigmaY3.Increment = new decimal(new int[] { 10, 0, 0, 0 });
			this.nuD_sigmaY3.Location = new System.Drawing.Point(104, 76);
			this.nuD_sigmaY3.Maximum = new decimal(new int[] { 512, 0, 0, 0 });
			this.nuD_sigmaY3.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			this.nuD_sigmaY3.Name = "nuD_sigmaY3";
			this.nuD_sigmaY3.Size = new System.Drawing.Size(80, 22);
			this.nuD_sigmaY3.TabIndex = 13;
			this.nuD_sigmaY3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nuD_sigmaY3.Value = new decimal(new int[] { 10, 0, 0, 0 });
			// 
			// label_shiftY3
			// 
			label_shiftY3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			label_shiftY3.AutoSize = true;
			label_shiftY3.Location = new System.Drawing.Point(14, 135);
			label_shiftY3.Name = "label_shiftY3";
			label_shiftY3.Size = new System.Drawing.Size(84, 14);
			label_shiftY3.TabIndex = 10;
			label_shiftY3.Text = "Сдвиг по Y:";
			// 
			// numUpDown_shiftY3
			// 
			this.nuD_shiftY3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nuD_shiftY3.Increment = new decimal(new int[] { 10, 0, 0, 0 });
			this.nuD_shiftY3.Location = new System.Drawing.Point(104, 132);
			this.nuD_shiftY3.Maximum = new decimal(new int[] { 512, 0, 0, 0 });
			this.nuD_shiftY3.Name = "nuD_shiftY3";
			this.nuD_shiftY3.Size = new System.Drawing.Size(80, 22);
			this.nuD_shiftY3.TabIndex = 11;
			this.nuD_shiftY3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nuD_shiftY3.Value = new decimal(new int[] { 384, 0, 0, 0 });
			// 
			// label_shiftX3
			// 
			label_shiftX3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			label_shiftX3.AutoSize = true;
			label_shiftX3.Location = new System.Drawing.Point(14, 107);
			label_shiftX3.Name = "label_shiftX3";
			label_shiftX3.Size = new System.Drawing.Size(84, 14);
			label_shiftX3.TabIndex = 8;
			label_shiftX3.Text = "Сдвиг по Х:";
			// 
			// numUpDown_shiftX3
			// 
			this.nuD_shiftX3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nuD_shiftX3.Increment = new decimal(new int[] { 10, 0, 0, 0 });
			this.nuD_shiftX3.Location = new System.Drawing.Point(104, 104);
			this.nuD_shiftX3.Maximum = new decimal(new int[] { 512, 0, 0, 0 });
			this.nuD_shiftX3.Name = "nuD_shiftX3";
			this.nuD_shiftX3.Size = new System.Drawing.Size(80, 22);
			this.nuD_shiftX3.TabIndex = 9;
			this.nuD_shiftX3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nuD_shiftX3.Value = new decimal(new int[] { 384, 0, 0, 0 });
			// 
			// label_sigmaX3
			// 
			label_sigmaX3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			label_sigmaX3.AutoSize = true;
			label_sigmaX3.Location = new System.Drawing.Point(7, 51);
			label_sigmaX3.Name = "label_sigmaX3";
			label_sigmaX3.Size = new System.Drawing.Size(91, 14);
			label_sigmaX3.TabIndex = 6;
			label_sigmaX3.Text = "Ширина по Х:";
			// 
			// numUpDown_sigmaX3
			// 
			this.nuD_sigmaX3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nuD_sigmaX3.DecimalPlaces = 1;
			this.nuD_sigmaX3.Increment = new decimal(new int[] { 10, 0, 0, 0 });
			this.nuD_sigmaX3.Location = new System.Drawing.Point(104, 48);
			this.nuD_sigmaX3.Maximum = new decimal(new int[] { 512, 0, 0, 0 });
			this.nuD_sigmaX3.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			this.nuD_sigmaX3.Name = "nuD_sigmaX3";
			this.nuD_sigmaX3.Size = new System.Drawing.Size(80, 22);
			this.nuD_sigmaX3.TabIndex = 7;
			this.nuD_sigmaX3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nuD_sigmaX3.Value = new decimal(new int[] { 10, 0, 0, 0 });
			// 
			// label_a3
			// 
			label_a3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			label_a3.AutoSize = true;
			label_a3.Location = new System.Drawing.Point(21, 23);
			label_a3.Name = "label_a3";
			label_a3.Size = new System.Drawing.Size(77, 14);
			label_a3.TabIndex = 5;
			label_a3.Text = "Амплитуда:";
			// 
			// numUpDown_a3
			// 
			this.nuD_a3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nuD_a3.Location = new System.Drawing.Point(104, 20);
			this.nuD_a3.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			this.nuD_a3.Name = "nuD_a3";
			this.nuD_a3.Size = new System.Drawing.Size(80, 22);
			this.nuD_a3.TabIndex = 5;
			this.nuD_a3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nuD_a3.Value = new decimal(new int[] { 1, 0, 0, 0 });
			// 
			// groupBox_paramsDome2
			// 
			groupBox_paramsDome2.Controls.Add(label_sigmaY2);
			groupBox_paramsDome2.Controls.Add(this.nuD_sigmaY2);
			groupBox_paramsDome2.Controls.Add(label_shiftY2);
			groupBox_paramsDome2.Controls.Add(this.nuD_shiftY2);
			groupBox_paramsDome2.Controls.Add(label_shiftX2);
			groupBox_paramsDome2.Controls.Add(this.nuD_shiftX2);
			groupBox_paramsDome2.Controls.Add(label_sigmaX2);
			groupBox_paramsDome2.Controls.Add(this.nuD_sigmaX2);
			groupBox_paramsDome2.Controls.Add(label_a2);
			groupBox_paramsDome2.Controls.Add(this.nuD_a2);
			groupBox_paramsDome2.Location = new System.Drawing.Point(209, 97);
			groupBox_paramsDome2.Name = "groupBox_paramsDome2";
			groupBox_paramsDome2.Size = new System.Drawing.Size(191, 161);
			groupBox_paramsDome2.TabIndex = 8;
			groupBox_paramsDome2.TabStop = false;
			groupBox_paramsDome2.Text = "Параметры 2-го купола";
			// 
			// label_sigmaY2
			// 
			label_sigmaY2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			label_sigmaY2.AutoSize = true;
			label_sigmaY2.Location = new System.Drawing.Point(7, 78);
			label_sigmaY2.Name = "label_sigmaY2";
			label_sigmaY2.Size = new System.Drawing.Size(91, 14);
			label_sigmaY2.TabIndex = 12;
			label_sigmaY2.Text = "Ширина по Y:";
			// 
			// numUpDown_sigmaY2
			// 
			this.nuD_sigmaY2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nuD_sigmaY2.DecimalPlaces = 1;
			this.nuD_sigmaY2.Increment = new decimal(new int[] { 10, 0, 0, 0 });
			this.nuD_sigmaY2.Location = new System.Drawing.Point(104, 76);
			this.nuD_sigmaY2.Maximum = new decimal(new int[] { 512, 0, 0, 0 });
			this.nuD_sigmaY2.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			this.nuD_sigmaY2.Name = "nuD_sigmaY2";
			this.nuD_sigmaY2.Size = new System.Drawing.Size(80, 22);
			this.nuD_sigmaY2.TabIndex = 13;
			this.nuD_sigmaY2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nuD_sigmaY2.Value = new decimal(new int[] { 10, 0, 0, 0 });
			// 
			// label_shiftY2
			// 
			label_shiftY2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			label_shiftY2.AutoSize = true;
			label_shiftY2.Location = new System.Drawing.Point(14, 135);
			label_shiftY2.Name = "label_shiftY2";
			label_shiftY2.Size = new System.Drawing.Size(84, 14);
			label_shiftY2.TabIndex = 10;
			label_shiftY2.Text = "Сдвиг по Y:";
			// 
			// numUpDown_shiftY2
			// 
			this.nuD_shiftY2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nuD_shiftY2.Increment = new decimal(new int[] { 10, 0, 0, 0 });
			this.nuD_shiftY2.Location = new System.Drawing.Point(104, 132);
			this.nuD_shiftY2.Maximum = new decimal(new int[] { 512, 0, 0, 0 });
			this.nuD_shiftY2.Name = "nuD_shiftY2";
			this.nuD_shiftY2.Size = new System.Drawing.Size(80, 22);
			this.nuD_shiftY2.TabIndex = 11;
			this.nuD_shiftY2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nuD_shiftY2.Value = new decimal(new int[] { 384, 0, 0, 0 });
			// 
			// label_shiftX2
			// 
			label_shiftX2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			label_shiftX2.AutoSize = true;
			label_shiftX2.Location = new System.Drawing.Point(14, 107);
			label_shiftX2.Name = "label_shiftX2";
			label_shiftX2.Size = new System.Drawing.Size(84, 14);
			label_shiftX2.TabIndex = 8;
			label_shiftX2.Text = "Сдвиг по Х:";
			// 
			// numUpDown_shiftX2
			// 
			this.nuD_shiftX2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nuD_shiftX2.Increment = new decimal(new int[] { 10, 0, 0, 0 });
			this.nuD_shiftX2.Location = new System.Drawing.Point(104, 104);
			this.nuD_shiftX2.Maximum = new decimal(new int[] { 512, 0, 0, 0 });
			this.nuD_shiftX2.Name = "nuD_shiftX2";
			this.nuD_shiftX2.Size = new System.Drawing.Size(80, 22);
			this.nuD_shiftX2.TabIndex = 9;
			this.nuD_shiftX2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nuD_shiftX2.Value = new decimal(new int[] { 128, 0, 0, 0 });
			// 
			// label_sigmaX2
			// 
			label_sigmaX2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			label_sigmaX2.AutoSize = true;
			label_sigmaX2.Location = new System.Drawing.Point(7, 51);
			label_sigmaX2.Name = "label_sigmaX2";
			label_sigmaX2.Size = new System.Drawing.Size(91, 14);
			label_sigmaX2.TabIndex = 6;
			label_sigmaX2.Text = "Ширина по Х:";
			// 
			// numUpDown_sigmaX2
			// 
			this.nuD_sigmaX2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nuD_sigmaX2.DecimalPlaces = 1;
			this.nuD_sigmaX2.Increment = new decimal(new int[] { 10, 0, 0, 0 });
			this.nuD_sigmaX2.Location = new System.Drawing.Point(104, 48);
			this.nuD_sigmaX2.Maximum = new decimal(new int[] { 512, 0, 0, 0 });
			this.nuD_sigmaX2.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			this.nuD_sigmaX2.Name = "nuD_sigmaX2";
			this.nuD_sigmaX2.Size = new System.Drawing.Size(80, 22);
			this.nuD_sigmaX2.TabIndex = 7;
			this.nuD_sigmaX2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nuD_sigmaX2.Value = new decimal(new int[] { 10, 0, 0, 0 });
			// 
			// label_a2
			// 
			label_a2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			label_a2.AutoSize = true;
			label_a2.Location = new System.Drawing.Point(21, 23);
			label_a2.Name = "label_a2";
			label_a2.Size = new System.Drawing.Size(77, 14);
			label_a2.TabIndex = 5;
			label_a2.Text = "Амплитуда:";
			// 
			// numUpDown_a2
			// 
			this.nuD_a2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nuD_a2.Location = new System.Drawing.Point(104, 20);
			this.nuD_a2.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			this.nuD_a2.Name = "nuD_a2";
			this.nuD_a2.Size = new System.Drawing.Size(80, 22);
			this.nuD_a2.TabIndex = 5;
			this.nuD_a2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nuD_a2.Value = new decimal(new int[] { 1, 0, 0, 0 });
			// 
			// groupBox_paramsDome1
			// 
			groupBox_paramsDome1.Controls.Add(label_sigmaY1);
			groupBox_paramsDome1.Controls.Add(this.nuD_sigmaY1);
			groupBox_paramsDome1.Controls.Add(label_shiftY1);
			groupBox_paramsDome1.Controls.Add(this.nuD_shiftY1);
			groupBox_paramsDome1.Controls.Add(label_shiftX1);
			groupBox_paramsDome1.Controls.Add(this.nuD_shiftX1);
			groupBox_paramsDome1.Controls.Add(label_sigmaX1);
			groupBox_paramsDome1.Controls.Add(this.nuD_sigmaX1);
			groupBox_paramsDome1.Controls.Add(label_a1);
			groupBox_paramsDome1.Controls.Add(this.nuD_a1);
			groupBox_paramsDome1.Location = new System.Drawing.Point(12, 97);
			groupBox_paramsDome1.Name = "groupBox_paramsDome1";
			groupBox_paramsDome1.Size = new System.Drawing.Size(191, 161);
			groupBox_paramsDome1.TabIndex = 7;
			groupBox_paramsDome1.TabStop = false;
			groupBox_paramsDome1.Text = "Параметры 1-го купола";
			// 
			// label_sigmaY1
			// 
			label_sigmaY1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			label_sigmaY1.AutoSize = true;
			label_sigmaY1.Location = new System.Drawing.Point(7, 78);
			label_sigmaY1.Name = "label_sigmaY1";
			label_sigmaY1.Size = new System.Drawing.Size(91, 14);
			label_sigmaY1.TabIndex = 12;
			label_sigmaY1.Text = "Ширина по Y:";
			// 
			// numUpDown_sigmaY1
			// 
			this.nuD_sigmaY1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nuD_sigmaY1.DecimalPlaces = 1;
			this.nuD_sigmaY1.Increment = new decimal(new int[] { 10, 0, 0, 0 });
			this.nuD_sigmaY1.Location = new System.Drawing.Point(104, 76);
			this.nuD_sigmaY1.Maximum = new decimal(new int[] { 512, 0, 0, 0 });
			this.nuD_sigmaY1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			this.nuD_sigmaY1.Name = "nuD_sigmaY1";
			this.nuD_sigmaY1.Size = new System.Drawing.Size(80, 22);
			this.nuD_sigmaY1.TabIndex = 13;
			this.nuD_sigmaY1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nuD_sigmaY1.Value = new decimal(new int[] { 10, 0, 0, 0 });
			// 
			// label_shiftY1
			// 
			label_shiftY1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			label_shiftY1.AutoSize = true;
			label_shiftY1.Location = new System.Drawing.Point(14, 135);
			label_shiftY1.Name = "label_shiftY1";
			label_shiftY1.Size = new System.Drawing.Size(84, 14);
			label_shiftY1.TabIndex = 10;
			label_shiftY1.Text = "Сдвиг по Y:";
			// 
			// numUpDown_shiftY1
			// 
			this.nuD_shiftY1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nuD_shiftY1.Increment = new decimal(new int[] { 10, 0, 0, 0 });
			this.nuD_shiftY1.Location = new System.Drawing.Point(104, 132);
			this.nuD_shiftY1.Maximum = new decimal(new int[] { 512, 0, 0, 0 });
			this.nuD_shiftY1.Name = "nuD_shiftY1";
			this.nuD_shiftY1.Size = new System.Drawing.Size(80, 22);
			this.nuD_shiftY1.TabIndex = 11;
			this.nuD_shiftY1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nuD_shiftY1.Value = new decimal(new int[] { 128, 0, 0, 0 });
			// 
			// label_shiftX1
			// 
			label_shiftX1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			label_shiftX1.AutoSize = true;
			label_shiftX1.Location = new System.Drawing.Point(14, 107);
			label_shiftX1.Name = "label_shiftX1";
			label_shiftX1.Size = new System.Drawing.Size(84, 14);
			label_shiftX1.TabIndex = 8;
			label_shiftX1.Text = "Сдвиг по Х:";
			// 
			// numUpDown_shiftX1
			// 
			this.nuD_shiftX1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nuD_shiftX1.Increment = new decimal(new int[] { 10, 0, 0, 0 });
			this.nuD_shiftX1.Location = new System.Drawing.Point(104, 104);
			this.nuD_shiftX1.Maximum = new decimal(new int[] { 512, 0, 0, 0 });
			this.nuD_shiftX1.Name = "nuD_shiftX1";
			this.nuD_shiftX1.Size = new System.Drawing.Size(80, 22);
			this.nuD_shiftX1.TabIndex = 9;
			this.nuD_shiftX1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nuD_shiftX1.Value = new decimal(new int[] { 256, 0, 0, 0 });
			// 
			// label_sigmaX1
			// 
			label_sigmaX1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			label_sigmaX1.AutoSize = true;
			label_sigmaX1.Location = new System.Drawing.Point(7, 51);
			label_sigmaX1.Name = "label_sigmaX1";
			label_sigmaX1.Size = new System.Drawing.Size(91, 14);
			label_sigmaX1.TabIndex = 6;
			label_sigmaX1.Text = "Ширина по Х:";
			// 
			// numUpDown_sigmaX1
			// 
			this.nuD_sigmaX1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nuD_sigmaX1.DecimalPlaces = 1;
			this.nuD_sigmaX1.Increment = new decimal(new int[] { 10, 0, 0, 0 });
			this.nuD_sigmaX1.Location = new System.Drawing.Point(104, 48);
			this.nuD_sigmaX1.Maximum = new decimal(new int[] { 512, 0, 0, 0 });
			this.nuD_sigmaX1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			this.nuD_sigmaX1.Name = "nuD_sigmaX1";
			this.nuD_sigmaX1.Size = new System.Drawing.Size(80, 22);
			this.nuD_sigmaX1.TabIndex = 7;
			this.nuD_sigmaX1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nuD_sigmaX1.Value = new decimal(new int[] { 10, 0, 0, 0 });
			// 
			// label_a1
			// 
			label_a1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			label_a1.AutoSize = true;
			label_a1.Location = new System.Drawing.Point(21, 23);
			label_a1.Name = "label_a1";
			label_a1.Size = new System.Drawing.Size(77, 14);
			label_a1.TabIndex = 5;
			label_a1.Text = "Амплитуда:";
			// 
			// numUpDown_a1
			// 
			this.nuD_a1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nuD_a1.Location = new System.Drawing.Point(104, 20);
			this.nuD_a1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			this.nuD_a1.Name = "nuD_a1";
			this.nuD_a1.Size = new System.Drawing.Size(80, 22);
			this.nuD_a1.TabIndex = 5;
			this.nuD_a1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nuD_a1.Value = new decimal(new int[] { 1, 0, 0, 0 });
			// 
			// label_SNR
			// 
			label_SNR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			label_SNR.AutoSize = true;
			label_SNR.Location = new System.Drawing.Point(42, 48);
			label_SNR.Name = "label_SNR";
			label_SNR.Size = new System.Drawing.Size(56, 14);
			label_SNR.TabIndex = 5;
			label_SNR.Text = "ОСШ(%):";
			// 
			// groupBox_paramImage
			// 
			groupBox_paramImage.Controls.Add(label_Height);
			groupBox_paramImage.Controls.Add(this.nuD_height);
			groupBox_paramImage.Controls.Add(label_Width);
			groupBox_paramImage.Controls.Add(this.nuD_width);
			groupBox_paramImage.Location = new System.Drawing.Point(12, 12);
			groupBox_paramImage.Name = "groupBox_paramImage";
			groupBox_paramImage.Size = new System.Drawing.Size(191, 79);
			groupBox_paramImage.TabIndex = 15;
			groupBox_paramImage.TabStop = false;
			groupBox_paramImage.Text = "Параметры изображения";
			// 
			// label_Height
			// 
			label_Height.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			label_Height.AutoSize = true;
			label_Height.Location = new System.Drawing.Point(42, 50);
			label_Height.Name = "label_Height";
			label_Height.Size = new System.Drawing.Size(56, 14);
			label_Height.TabIndex = 10;
			label_Height.Text = "Высота:";
			// 
			// numUpDown_height
			// 
			this.nuD_height.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nuD_height.Increment = new decimal(new int[] { 512, 0, 0, 0 });
			this.nuD_height.Location = new System.Drawing.Point(104, 48);
			this.nuD_height.Maximum = new decimal(new int[] { 2048, 0, 0, 0 });
			this.nuD_height.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
			this.nuD_height.Name = "nuD_height";
			this.nuD_height.Size = new System.Drawing.Size(80, 22);
			this.nuD_height.TabIndex = 11;
			this.nuD_height.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nuD_height.Value = new decimal(new int[] { 512, 0, 0, 0 });
			// 
			// label_Width
			// 
			label_Width.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			label_Width.AutoSize = true;
			label_Width.Location = new System.Drawing.Point(42, 22);
			label_Width.Name = "label_Width";
			label_Width.Size = new System.Drawing.Size(56, 14);
			label_Width.TabIndex = 8;
			label_Width.Text = "Ширина:";
			// 
			// numUpDown_width
			// 
			this.nuD_width.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nuD_width.Increment = new decimal(new int[] { 512, 0, 0, 0 });
			this.nuD_width.Location = new System.Drawing.Point(104, 20);
			this.nuD_width.Maximum = new decimal(new int[] { 2048, 0, 0, 0 });
			this.nuD_width.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
			this.nuD_width.Name = "nuD_width";
			this.nuD_width.Size = new System.Drawing.Size(80, 22);
			this.nuD_width.TabIndex = 9;
			this.nuD_width.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nuD_width.Value = new decimal(new int[] { 512, 0, 0, 0 });
			// 
			// groupBox_Sko
			// 
			groupBox_Sko.Controls.Add(label_SkoInitAndNoise);
			groupBox_Sko.Controls.Add(this.textBox_SkoInitAndNoise);
			groupBox_Sko.Controls.Add(label_SkoInitAndRestore);
			groupBox_Sko.Controls.Add(this.textBox_SkoInitAndRestore);
			groupBox_Sko.Location = new System.Drawing.Point(12, 346);
			groupBox_Sko.Name = "groupBox_Sko";
			groupBox_Sko.Size = new System.Drawing.Size(585, 76);
			groupBox_Sko.TabIndex = 20;
			groupBox_Sko.TabStop = false;
			groupBox_Sko.Text = "СКО";
			// 
			// label_SkoInitAndNoise
			// 
			label_SkoInitAndNoise.Anchor = System.Windows.Forms.AnchorStyles.Right;
			label_SkoInitAndNoise.Location = new System.Drawing.Point(297, 24);
			label_SkoInitAndNoise.Name = "label_SkoInitAndNoise";
			label_SkoInitAndNoise.Size = new System.Drawing.Size(196, 22);
			label_SkoInitAndNoise.TabIndex = 3;
			label_SkoInitAndNoise.Text = "Исходного и зашумленного:";
			label_SkoInitAndNoise.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textBox_SkoInitAndNoise
			// 
			this.textBox_SkoInitAndNoise.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.textBox_SkoInitAndNoise.Location = new System.Drawing.Point(499, 21);
			this.textBox_SkoInitAndNoise.Name = "textBox_SkoInitAndNoise";
			this.textBox_SkoInitAndNoise.ReadOnly = true;
			this.textBox_SkoInitAndNoise.Size = new System.Drawing.Size(80, 22);
			this.textBox_SkoInitAndNoise.TabIndex = 2;
			// 
			// label_SkoInitAndRestore
			// 
			label_SkoInitAndRestore.Anchor = System.Windows.Forms.AnchorStyles.Right;
			label_SkoInitAndRestore.Location = new System.Drawing.Point(276, 52);
			label_SkoInitAndRestore.Name = "label_SkoInitAndRestore";
			label_SkoInitAndRestore.Size = new System.Drawing.Size(217, 22);
			label_SkoInitAndRestore.TabIndex = 1;
			label_SkoInitAndRestore.Text = "Исходного и восстановленного:";
			label_SkoInitAndRestore.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textBox_SkoInitAndRestore
			// 
			this.textBox_SkoInitAndRestore.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.textBox_SkoInitAndRestore.Location = new System.Drawing.Point(499, 49);
			this.textBox_SkoInitAndRestore.Name = "textBox_SkoInitAndRestore";
			this.textBox_SkoInitAndRestore.ReadOnly = true;
			this.textBox_SkoInitAndRestore.Size = new System.Drawing.Size(80, 22);
			this.textBox_SkoInitAndRestore.TabIndex = 0;
			// 
			// label_CutoffEnergy
			// 
			label_CutoffEnergy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			label_CutoffEnergy.Location = new System.Drawing.Point(7, 48);
			label_CutoffEnergy.Name = "label_CutoffEnergy";
			label_CutoffEnergy.Size = new System.Drawing.Size(121, 14);
			label_CutoffEnergy.TabIndex = 5;
			label_CutoffEnergy.Text = "Доля энергии(%):";
			// 
			// groupBox_paramFiltered
			// 
			groupBox_paramFiltered.Controls.Add(label_radiusCutoff);
			groupBox_paramFiltered.Controls.Add(this.numUpDown_radiusCutoff);
			groupBox_paramFiltered.Controls.Add(this.rB_cutoffSmallEnergy);
			groupBox_paramFiltered.Controls.Add(this.rB_cutoffCircle);
			groupBox_paramFiltered.Controls.Add(label_CutoffEnergy);
			groupBox_paramFiltered.Controls.Add(this.numUpDown_cutoffEnergy);
			groupBox_paramFiltered.Location = new System.Drawing.Point(209, 264);
			groupBox_paramFiltered.Name = "groupBox_paramFiltered";
			groupBox_paramFiltered.RightToLeft = System.Windows.Forms.RightToLeft.No;
			groupBox_paramFiltered.Size = new System.Drawing.Size(388, 76);
			groupBox_paramFiltered.TabIndex = 21;
			groupBox_paramFiltered.TabStop = false;
			groupBox_paramFiltered.Text = "Параметры фильтрации";
			// 
			// label_radiusCutoff
			// 
			label_radiusCutoff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			label_radiusCutoff.Location = new System.Drawing.Point(197, 48);
			label_radiusCutoff.Name = "label_radiusCutoff";
			label_radiusCutoff.Size = new System.Drawing.Size(128, 14);
			label_radiusCutoff.TabIndex = 9;
			label_radiusCutoff.Text = "Радиус обрезания:";
			// 
			// numUpDown_radiusCutoff
			// 
			this.numUpDown_radiusCutoff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.numUpDown_radiusCutoff.Increment = new decimal(new int[] { 10, 0, 0, 0 });
			this.numUpDown_radiusCutoff.Location = new System.Drawing.Point(331, 44);
			this.numUpDown_radiusCutoff.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
			this.numUpDown_radiusCutoff.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			this.numUpDown_radiusCutoff.Name = "numUpDown_radiusCutoff";
			this.numUpDown_radiusCutoff.Size = new System.Drawing.Size(50, 22);
			this.numUpDown_radiusCutoff.TabIndex = 8;
			this.numUpDown_radiusCutoff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numUpDown_radiusCutoff.Value = new decimal(new int[] { 100, 0, 0, 0 });
			// 
			// rB_cutoffSmallEnergy
			// 
			this.rB_cutoffSmallEnergy.Location = new System.Drawing.Point(7, 22);
			this.rB_cutoffSmallEnergy.Name = "rB_cutoffSmallEnergy";
			this.rB_cutoffSmallEnergy.Size = new System.Drawing.Size(177, 18);
			this.rB_cutoffSmallEnergy.TabIndex = 7;
			this.rB_cutoffSmallEnergy.Text = "Отсечка малых энергий";
			this.rB_cutoffSmallEnergy.UseVisualStyleBackColor = true;
			this.rB_cutoffSmallEnergy.CheckedChanged += new System.EventHandler(this.OnCheckedChangedSmallEnergy);
			// 
			// rB_cutoffCircle
			// 
			this.rB_cutoffCircle.Checked = true;
			this.rB_cutoffCircle.Location = new System.Drawing.Point(204, 20);
			this.rB_cutoffCircle.Name = "rB_cutoffCircle";
			this.rB_cutoffCircle.Size = new System.Drawing.Size(177, 18);
			this.rB_cutoffCircle.TabIndex = 6;
			this.rB_cutoffCircle.TabStop = true;
			this.rB_cutoffCircle.Text = "Отсечка окружностью ";
			this.rB_cutoffCircle.UseVisualStyleBackColor = true;
			this.rB_cutoffCircle.CheckedChanged += new System.EventHandler(this.OnCheckedChangedCutoffCircle);
			// 
			// numUpDown_cutoffEnergy
			// 
			this.numUpDown_cutoffEnergy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.numUpDown_cutoffEnergy.Enabled = false;
			this.numUpDown_cutoffEnergy.Increment = new decimal(new int[] { 10, 0, 0, 0 });
			this.numUpDown_cutoffEnergy.Location = new System.Drawing.Point(134, 44);
			this.numUpDown_cutoffEnergy.Name = "numUpDown_cutoffEnergy";
			this.numUpDown_cutoffEnergy.Size = new System.Drawing.Size(50, 22);
			this.numUpDown_cutoffEnergy.TabIndex = 5;
			this.numUpDown_cutoffEnergy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numUpDown_cutoffEnergy.Value = new decimal(new int[] { 10, 0, 0, 0 });
			// 
			// groupBox_AdditionImage
			// 
			groupBox_AdditionImage.Controls.Add(this.rB_bilinearInterpolation);
			groupBox_AdditionImage.Controls.Add(this.rB_zerosAdding);
			groupBox_AdditionImage.Location = new System.Drawing.Point(209, 12);
			groupBox_AdditionImage.Name = "groupBox_AdditionImage";
			groupBox_AdditionImage.RightToLeft = System.Windows.Forms.RightToLeft.No;
			groupBox_AdditionImage.Size = new System.Drawing.Size(388, 79);
			groupBox_AdditionImage.TabIndex = 22;
			groupBox_AdditionImage.TabStop = false;
			groupBox_AdditionImage.Text = "Дополнение изображения";
			// 
			// rB_bilinearInterpolation
			// 
			this.rB_bilinearInterpolation.Checked = true;
			this.rB_bilinearInterpolation.Location = new System.Drawing.Point(7, 48);
			this.rB_bilinearInterpolation.Name = "rB_bilinearInterpolation";
			this.rB_bilinearInterpolation.Size = new System.Drawing.Size(374, 18);
			this.rB_bilinearInterpolation.TabIndex = 1;
			this.rB_bilinearInterpolation.TabStop = true;
			this.rB_bilinearInterpolation.Text = "Билинейная интерполяция";
			this.rB_bilinearInterpolation.UseVisualStyleBackColor = true;
			// 
			// rB_zerosAdding
			// 
			this.rB_zerosAdding.Location = new System.Drawing.Point(7, 20);
			this.rB_zerosAdding.Name = "rB_zerosAdding";
			this.rB_zerosAdding.Size = new System.Drawing.Size(374, 18);
			this.rB_zerosAdding.TabIndex = 0;
			this.rB_zerosAdding.Text = "Дополнение нулями";
			this.rB_zerosAdding.UseVisualStyleBackColor = true;
			// 
			// groupBox_paramsNoise
			// 
			this.groupBox_paramsNoise.Controls.Add(this.checkBox_isNoise);
			this.groupBox_paramsNoise.Controls.Add(label_SNR);
			this.groupBox_paramsNoise.Controls.Add(this.numUpDown_snr);
			this.groupBox_paramsNoise.Enabled = false;
			this.groupBox_paramsNoise.Location = new System.Drawing.Point(12, 264);
			this.groupBox_paramsNoise.Name = "groupBox_paramsNoise";
			this.groupBox_paramsNoise.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.groupBox_paramsNoise.Size = new System.Drawing.Size(191, 76);
			this.groupBox_paramsNoise.TabIndex = 11;
			this.groupBox_paramsNoise.TabStop = false;
			this.groupBox_paramsNoise.Text = "Параметры шума";
			// 
			// checkBox_isNoise
			// 
			this.checkBox_isNoise.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox_isNoise.AutoSize = true;
			this.checkBox_isNoise.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBox_isNoise.Location = new System.Drawing.Point(67, 21);
			this.checkBox_isNoise.Name = "checkBox_isNoise";
			this.checkBox_isNoise.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.checkBox_isNoise.Size = new System.Drawing.Size(117, 18);
			this.checkBox_isNoise.TabIndex = 6;
			this.checkBox_isNoise.Text = "Добавить шум?";
			this.checkBox_isNoise.UseVisualStyleBackColor = true;
			this.checkBox_isNoise.CheckedChanged += new System.EventHandler(this.OnCheckedChangedCheckBoxIsNoise);
			// 
			// numUpDown_snr
			// 
			this.numUpDown_snr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.numUpDown_snr.Increment = new decimal(new int[] { 10, 0, 0, 0 });
			this.numUpDown_snr.Location = new System.Drawing.Point(104, 45);
			this.numUpDown_snr.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
			this.numUpDown_snr.Name = "numUpDown_snr";
			this.numUpDown_snr.Size = new System.Drawing.Size(80, 22);
			this.numUpDown_snr.TabIndex = 5;
			this.numUpDown_snr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numUpDown_snr.Value = new decimal(new int[] { 30, 0, 0, 0 });
			this.numUpDown_snr.ValueChanged += new System.EventHandler(this.OnAddNoiseToImage);
			// 
			// button_GetSpectrum
			// 
			this.button_GetSpectrum.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.button_GetSpectrum.Enabled = false;
			this.button_GetSpectrum.Location = new System.Drawing.Point(209, 515);
			this.button_GetSpectrum.Name = "button_GetSpectrum";
			this.button_GetSpectrum.Size = new System.Drawing.Size(191, 37);
			this.button_GetSpectrum.TabIndex = 10;
			this.button_GetSpectrum.Text = "Получить спектр изображения";
			this.button_GetSpectrum.UseVisualStyleBackColor = true;
			this.button_GetSpectrum.Click += new System.EventHandler(this.OnGetSpectrumImage);
			// 
			// button_LoadImage
			// 
			this.button_LoadImage.Location = new System.Drawing.Point(406, 428);
			this.button_LoadImage.Name = "button_LoadImage";
			this.button_LoadImage.Size = new System.Drawing.Size(191, 37);
			this.button_LoadImage.TabIndex = 2;
			this.button_LoadImage.Text = "Загрузить изображение";
			this.button_LoadImage.UseVisualStyleBackColor = true;
			this.button_LoadImage.Click += new System.EventHandler(this.OnClickButtonLoadImage);
			// 
			// button_GetImage
			// 
			this.button_GetImage.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.button_GetImage.Enabled = false;
			this.button_GetImage.Location = new System.Drawing.Point(113, 471);
			this.button_GetImage.Name = "button_GetImage";
			this.button_GetImage.Size = new System.Drawing.Size(191, 37);
			this.button_GetImage.TabIndex = 12;
			this.button_GetImage.Text = "Получить исходное изображение";
			this.button_GetImage.UseVisualStyleBackColor = true;
			this.button_GetImage.Click += new System.EventHandler(this.OnGetImage);
			// 
			// button_GetNoiseImage
			// 
			this.button_GetNoiseImage.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.button_GetNoiseImage.Enabled = false;
			this.button_GetNoiseImage.Location = new System.Drawing.Point(310, 471);
			this.button_GetNoiseImage.Name = "button_GetNoiseImage";
			this.button_GetNoiseImage.Size = new System.Drawing.Size(191, 37);
			this.button_GetNoiseImage.TabIndex = 14;
			this.button_GetNoiseImage.Text = "Получить изображение с шумом";
			this.button_GetNoiseImage.UseVisualStyleBackColor = true;
			this.button_GetNoiseImage.Click += new System.EventHandler(this.OnGetNoiseImage);
			// 
			// button_GenerateImage
			// 
			this.button_GenerateImage.Location = new System.Drawing.Point(12, 428);
			this.button_GenerateImage.Name = "button_GenerateImage";
			this.button_GenerateImage.Size = new System.Drawing.Size(191, 37);
			this.button_GenerateImage.TabIndex = 17;
			this.button_GenerateImage.Text = "Сгенерировать изображение";
			this.button_GenerateImage.UseVisualStyleBackColor = true;
			this.button_GenerateImage.Click += new System.EventHandler(this.OnClickButtonGenerateImage);
			// 
			// button_GetFilteredSpectrum
			// 
			this.button_GetFilteredSpectrum.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.button_GetFilteredSpectrum.Enabled = false;
			this.button_GetFilteredSpectrum.Location = new System.Drawing.Point(209, 558);
			this.button_GetFilteredSpectrum.Name = "button_GetFilteredSpectrum";
			this.button_GetFilteredSpectrum.Size = new System.Drawing.Size(191, 37);
			this.button_GetFilteredSpectrum.TabIndex = 18;
			this.button_GetFilteredSpectrum.Text = "Отфильтровать спектр от шума";
			this.button_GetFilteredSpectrum.UseVisualStyleBackColor = true;
			this.button_GetFilteredSpectrum.Click += new System.EventHandler(this.OnGetFilteredSpectrum);
			// 
			// button_GetRestoredImage
			// 
			this.button_GetRestoredImage.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.button_GetRestoredImage.Enabled = false;
			this.button_GetRestoredImage.Location = new System.Drawing.Point(209, 601);
			this.button_GetRestoredImage.Name = "button_GetRestoredImage";
			this.button_GetRestoredImage.Size = new System.Drawing.Size(191, 37);
			this.button_GetRestoredImage.TabIndex = 19;
			this.button_GetRestoredImage.Text = "Получить восстановленное изображение\r\n";
			this.button_GetRestoredImage.UseVisualStyleBackColor = true;
			this.button_GetRestoredImage.Click += new System.EventHandler(this.OnGetRestoredImage);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(605, 646);
			this.Controls.Add(groupBox_AdditionImage);
			this.Controls.Add(groupBox_paramFiltered);
			this.Controls.Add(groupBox_Sko);
			this.Controls.Add(this.button_GetRestoredImage);
			this.Controls.Add(this.button_GetFilteredSpectrum);
			this.Controls.Add(this.button_GenerateImage);
			this.Controls.Add(groupBox_paramImage);
			this.Controls.Add(this.button_GetNoiseImage);
			this.Controls.Add(this.button_GetImage);
			this.Controls.Add(this.groupBox_paramsNoise);
			this.Controls.Add(this.button_GetSpectrum);
			this.Controls.Add(groupBox_paramsDome3);
			this.Controls.Add(groupBox_paramsDome2);
			this.Controls.Add(groupBox_paramsDome1);
			this.Controls.Add(this.button_LoadImage);
			this.Font = new System.Drawing.Font("JetBrains Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Location = new System.Drawing.Point(15, 15);
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "ИСИТ ННГУ | Обработка изображения";
			groupBox_paramsDome3.ResumeLayout(false);
			groupBox_paramsDome3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nuD_sigmaY3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nuD_shiftY3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nuD_shiftX3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nuD_sigmaX3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nuD_a3)).EndInit();
			groupBox_paramsDome2.ResumeLayout(false);
			groupBox_paramsDome2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nuD_sigmaY2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nuD_shiftY2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nuD_shiftX2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nuD_sigmaX2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nuD_a2)).EndInit();
			groupBox_paramsDome1.ResumeLayout(false);
			groupBox_paramsDome1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nuD_sigmaY1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nuD_shiftY1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nuD_shiftX1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nuD_sigmaX1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nuD_a1)).EndInit();
			groupBox_paramImage.ResumeLayout(false);
			groupBox_paramImage.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nuD_height)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nuD_width)).EndInit();
			groupBox_Sko.ResumeLayout(false);
			groupBox_Sko.PerformLayout();
			groupBox_paramFiltered.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numUpDown_radiusCutoff)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numUpDown_cutoffEnergy)).EndInit();
			groupBox_AdditionImage.ResumeLayout(false);
			this.groupBox_paramsNoise.ResumeLayout(false);
			this.groupBox_paramsNoise.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numUpDown_snr)).EndInit();
			this.ResumeLayout(false);
		}

		private System.Windows.Forms.NumericUpDown numUpDown_radiusCutoff;

		private System.Windows.Forms.RadioButton rB_cutoffSmallEnergy;
		private System.Windows.Forms.RadioButton rB_cutoffCircle;

		private System.Windows.Forms.RadioButton rB_zerosAdding;
		private System.Windows.Forms.RadioButton rB_bilinearInterpolation;

		private System.Windows.Forms.NumericUpDown numUpDown_cutoffEnergy;

		private System.Windows.Forms.TextBox textBox_SkoInitAndNoise;

		private System.Windows.Forms.TextBox textBox_SkoInitAndRestore;

		private System.Windows.Forms.Button button_GetFilteredSpectrum;
		private System.Windows.Forms.Button button_GetRestoredImage;

		private System.Windows.Forms.GroupBox groupBox_paramsNoise;

		private System.Windows.Forms.Button button_GenerateImage;

		#endregion
		private System.Windows.Forms.NumericUpDown nuD_sigmaY3;
		private System.Windows.Forms.NumericUpDown nuD_shiftY3;
		private System.Windows.Forms.NumericUpDown nuD_shiftX3;
		private System.Windows.Forms.NumericUpDown nuD_sigmaX3;
		private System.Windows.Forms.NumericUpDown nuD_a3;
		private System.Windows.Forms.NumericUpDown nuD_sigmaY2;
		private System.Windows.Forms.NumericUpDown nuD_shiftY2;
		private System.Windows.Forms.NumericUpDown nuD_shiftX2;
		private System.Windows.Forms.NumericUpDown nuD_sigmaX2;
		private System.Windows.Forms.NumericUpDown nuD_a2;
		private System.Windows.Forms.NumericUpDown nuD_sigmaY1;
		private System.Windows.Forms.NumericUpDown nuD_shiftY1;
		private System.Windows.Forms.NumericUpDown nuD_shiftX1;
		private System.Windows.Forms.NumericUpDown nuD_sigmaX1;
		private System.Windows.Forms.NumericUpDown nuD_a1;
		private System.Windows.Forms.Button button_GetSpectrum;
		private System.Windows.Forms.Button button_LoadImage;
		private System.Windows.Forms.NumericUpDown numUpDown_snr;
		private System.Windows.Forms.Button button_GetImage;
		private System.Windows.Forms.Button button_GetNoiseImage;
		private System.Windows.Forms.CheckBox checkBox_isNoise;
		private System.Windows.Forms.NumericUpDown nuD_height;
		private System.Windows.Forms.NumericUpDown nuD_width;
	}
}

