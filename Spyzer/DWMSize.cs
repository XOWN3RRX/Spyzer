using GreenshotPlugin.UnmanagedHelpers;
using System.Windows.Forms;

namespace Spyzer
{
    public class DWMSize
    {
        private static readonly int topOffset = 15;
        private static readonly int leftOffset = 5;
        private static readonly int rightAndBottomOffset = 7;

        public static RECT ClientSize(Control control)
        {
            int top = control.Location.Y + topOffset;
            int left = control.Location.X + leftOffset;

            int right = control.Width + rightAndBottomOffset;
            int bottom = control.Height + rightAndBottomOffset;

            return new RECT(left, top, right, bottom);
        }

        public static RECT ClientSize(Form form, bool landscape, bool noneBorderStyle)
        {
            if (landscape)
            {
                int offsetWidth = 16;
                int offsetHeight = 39;

                if (noneBorderStyle)
                {
                    offsetWidth = offsetHeight = 0;
                }

                int width_rect = form.Width - offsetWidth;
                int height_rect = form.Height - offsetHeight;

                int delta1 = width_rect / 16;
                int delta2 = height_rect / 9;

                if (delta1 < delta2)
                {
                    height_rect = delta1 * 9;
                }
                else
                {
                    width_rect = delta2 * 16;
                }

                int x = ((form.Width - offsetWidth) - width_rect) / 2;
                int y = ((form.Height - offsetHeight) - height_rect) / 2;

                return new RECT(x, y, width_rect + x, height_rect + y);
            }
            else
            {
                int offsetWidth = 16;
                int offsetHeight = 39;

                if (noneBorderStyle)
                {
                    offsetWidth = offsetHeight = 0;
                }

                int width_rect = form.Width - offsetWidth;
                int height_rect = form.Height - offsetHeight;

                return new RECT(0, 0, width_rect, height_rect);
            }
        }
    }
}
