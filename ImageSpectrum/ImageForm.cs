using System.Drawing;
using System.Windows.Forms;

namespace ImageSpectrum
{
	public partial class ImageForm : Form
	{
		public ImageForm(Bitmap bitmap)
		{
			InitializeComponent();
			pictBox_Image.Image = bitmap;
			Clipboard.SetImage(bitmap);
		}
	}
}
