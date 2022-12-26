using System.Drawing;

namespace ImageSpectrum
{
    public static class Interpolation
    {
        private static float Lerp(float s, float e, float t)
        {
            return s + (e - s) * t;
        }

        private static float Blerp(float c00, float c10, float c01, float c11, float tx, float ty)
        {
            return Lerp(Lerp(c00, c10, tx), Lerp(c01, c11, tx), ty);
        }

        public static Bitmap BilinearInterpolation(Bitmap orig, int newWidth, int newHeight)
        {
            var newBmp = new Bitmap(newWidth, newHeight, orig.PixelFormat);

            for (var x = 0; x < newWidth; x++)
            {
                for (var y = 0; y < newHeight; y++)
                {
                    var gx = (float)x / newWidth * (orig.Width - 1);
                    var gy = (float)y / newHeight * (orig.Height - 1);
                    var gxi = (int)gx;
                    var gyi = (int)gy;
                    var c00 = orig.GetPixel(gxi, gyi);
                    var c10 = orig.GetPixel(gxi + 1, gyi);
                    var c01 = orig.GetPixel(gxi, gyi + 1);
                    var c11 = orig.GetPixel(gxi + 1, gyi + 1);

                    var red = (int)Blerp(c00.R, c10.R, c01.R, c11.R, gx - gxi, gy - gyi);
                    var green = (int)Blerp(c00.G, c10.G, c01.G, c11.G, gx - gxi, gy - gyi);
                    var blue = (int)Blerp(c00.B, c10.B, c01.B, c11.B, gx - gxi, gy - gyi);
                    var rgb = Color.FromArgb(red, green, blue);
                    newBmp.SetPixel(x, y, rgb);
                }
            }

            return newBmp;
        }

        /// <summary>
        /// Интерполяция методом ближайшего соседа.
        /// </summary>
        /// <param name="originBmp">Исходный <see cref="Bitmap"/></param>
        /// <param name="newWidth"></param>
        /// <param name="newHeight"></param>
        /// <returns></returns>
        public static Bitmap NearestNeighbourInterpolation(Bitmap originBmp, int newWidth, int newHeight)
        {
            var newBmp = new Bitmap(newWidth, newHeight);
            var coeffW = (float)originBmp.Width / newBmp.Width;
            var coeffH = (float)originBmp.Height / newBmp.Height;

            for (var w = 0; w < newBmp.Width; w++)
            for (var h = 0; h < newBmp.Height; h++)
            {
                var oldW = (int)(w * coeffW);
                var oldH = (int)(h * coeffH);
                var clrPxl = originBmp.GetPixel(oldW, oldH);
                newBmp.SetPixel(w, h, clrPxl);
            }

            return newBmp;
        }
    }
}