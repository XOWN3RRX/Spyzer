using System.Drawing;

namespace Spyzer
{
    public static class BitmapExtension
    {
        public static void FillColor(this Bitmap bmp, Color fillColor)
        {
            using (Graphics gfx = Graphics.FromImage(bmp))
            using (SolidBrush brush = new SolidBrush(fillColor))
            {
                gfx.FillRectangle(brush, 0, 0, bmp.Width, bmp.Height);
            }
        }
    }
}
