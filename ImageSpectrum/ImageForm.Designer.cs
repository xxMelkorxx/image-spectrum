namespace ImageSpectrum
{
	partial class ImageForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.pictBox_Image = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictBox_Image)).BeginInit();
			this.SuspendLayout();
			// 
			// pictBox_Image
			// 
			this.pictBox_Image.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.pictBox_Image.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictBox_Image.Location = new System.Drawing.Point(12, 12);
			this.pictBox_Image.Name = "pictBox_Image";
			this.pictBox_Image.Size = new System.Drawing.Size(512, 512);
			this.pictBox_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictBox_Image.TabIndex = 1;
			this.pictBox_Image.TabStop = false;
			// 
			// ImageForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(536, 536);
			this.Controls.Add(this.pictBox_Image);
			this.MaximizeBox = false;
			this.Name = "ImageForm";
			this.Text = "ImageForm";
			((System.ComponentModel.ISupportInitialize)(this.pictBox_Image)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.PictureBox pictBox_Image;
	}
}