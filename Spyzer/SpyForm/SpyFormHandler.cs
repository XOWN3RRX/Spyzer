using GreenshotPlugin.Core;
using GreenshotPlugin.UnmanagedHelpers;
using Spyzer.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Spyzer.SpyForm
{
    public partial class SpyFormHandler : Form
    {
        private IntPtr _spyHandler;
        private IntPtr _spyWindowHandle;
        private DWM_THUMBNAIL_PROPERTIES _dwm_THUMBNAIL_PROPERTIES;
        private WindowDetails window;
        private Pen pen;

        private const int offsetResize = 10;

        public SpyFormHandler(IntPtr incomingHandler)
        {
            InstanceCounter.Instance.Increment();

            _spyHandler = incomingHandler;
            window = new WindowDetails(_spyHandler);
            pen = new Pen(Settings.Default.DefaultColor);

            InitializeComponent();
        }

        private void SpyFormHandler_Load(object sender, EventArgs e)
        {
            this.TransparencyKey = Color.FromArgb(255, 2, 3, 4);
            this.BackColor = Color.FromArgb(255, 2, 3, 4);

            this.TopMost = Settings.Default.DefaultTop;
            this.topToolStripMenuItem.Checked = Settings.Default.DefaultTop;
            this.landscapeToolStripMenuItem.Checked = Settings.Default.DefaultLandscape;
            this.drawMarginToolStripMenuItem.Checked = Settings.Default.DefaultDrawMargin;

            _dwm_THUMBNAIL_PROPERTIES = new DWM_THUMBNAIL_PROPERTIES
            {
                Opacity = byte.MaxValue,
                Visible = true,
                SourceClientAreaOnly = false,
                Destination = DWMSize.ClientSize(this, this.landscapeToolStripMenuItem.Checked, this.FormBorderStyle == FormBorderStyle.None)
            };

            ShowThumbnail(_spyHandler);
        }

        private void SpyFormHandler_Resize(object sender, EventArgs e)
        {
            _dwm_THUMBNAIL_PROPERTIES.Destination = DWMSize.ClientSize(this, this.landscapeToolStripMenuItem.Checked, this.FormBorderStyle == FormBorderStyle.None);
            ShowThumbnail(_spyHandler);

            this.Invalidate();
        }

        public void UnregisterThumbnail()
        {
            if (this._spyWindowHandle != IntPtr.Zero)
            {
                DWM.DwmUnregisterThumbnail(this._spyWindowHandle);
                this._spyWindowHandle = IntPtr.Zero;
            }
        }

        public void ShowThumbnail(IntPtr thumbnailHandle)
        {
            this.UnregisterThumbnail();

            DWM.DwmRegisterThumbnail(this.Handle, thumbnailHandle, out this._spyWindowHandle);

            if (this._spyWindowHandle != IntPtr.Zero)
            {
                DWM.DwmQueryThumbnailSourceSize(this._spyWindowHandle, out SIZE size);
                DWM.DwmUpdateThumbnailProperties(this._spyWindowHandle, ref _dwm_THUMBNAIL_PROPERTIES);
            }
        }

        private void SpyFormHandler_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.FormBorderStyle == FormBorderStyle.Sizable)
            {
                this.FormBorderStyle = FormBorderStyle.None;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
            }
        }

        private void SpyFormHandler_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                FormAction.ReleaseCapture();
                FormAction.SendMessage(this.Handle, FormAction.WM_NCLBUTTONDOWN, FormAction.HT_CAPTION, 0);
            }
        }

        private void SpyFormHandler_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStripSpyForm.Show(PointToScreen(e.Location));
            }
            else if (e.Button == MouseButtons.Middle)
            {
                ActivateForm();
            }
        }

        private void topToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.topToolStripMenuItem.Checked = !this.topToolStripMenuItem.Checked;
            this.TopMost = this.topToolStripMenuItem.Checked;
        }

        private void drawMarginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.drawMarginToolStripMenuItem.Checked = !this.drawMarginToolStripMenuItem.Checked;

            this.Invalidate();
        }

        private void landscapeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.landscapeToolStripMenuItem.Checked = !this.landscapeToolStripMenuItem.Checked;

            _dwm_THUMBNAIL_PROPERTIES.Destination = DWMSize.ClientSize(this, this.landscapeToolStripMenuItem.Checked, this.FormBorderStyle == FormBorderStyle.None);
            ShowThumbnail(_spyHandler);
        }

        private void activateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActivateForm();
        }

        private void ActivateForm()
        {
            window.ToForeground();
        }

        private void SpyFormHandler_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.UnregisterThumbnail();

            InstanceCounter.Instance.Decrement();
        }

        private void SpyFormHandler_Paint(object sender, PaintEventArgs e)
        {
            if (this.FormBorderStyle == FormBorderStyle.None && this.drawMarginToolStripMenuItem.Checked)
            {
                e.Graphics.DrawLine(pen, new Point(0, 0), new Point(this.Width, 0));
                e.Graphics.DrawLine(pen, new Point(0, 0), new Point(0, this.Height));
                e.Graphics.DrawLine(pen, new Point(0, this.Height - 1), new Point(this.Width, this.Height - 1));
                e.Graphics.DrawLine(pen, new Point(this.Width - 1, 0), new Point(this.Width - 1, this.Height));

                if (this.Width > offsetResize * 4 && this.Height > offsetResize * 4)
                {
                    int smallResizeRectangle = offsetResize / 2;

                    // left top
                    e.Graphics.FillRectangle(pen.Brush, new Rectangle(0, 0, offsetResize, smallResizeRectangle));
                    e.Graphics.FillRectangle(pen.Brush, new Rectangle(0, 0, smallResizeRectangle, offsetResize));

                    // right bottom
                    e.Graphics.FillRectangle(pen.Brush, new Rectangle(this.Width - offsetResize, this.Height - smallResizeRectangle, offsetResize, smallResizeRectangle));
                    e.Graphics.FillRectangle(pen.Brush, new Rectangle(this.Width - smallResizeRectangle, this.Height - offsetResize, smallResizeRectangle, offsetResize));

                    // right top
                    e.Graphics.FillRectangle(pen.Brush, new Rectangle(this.Width - offsetResize, 0, offsetResize, smallResizeRectangle));
                    e.Graphics.FillRectangle(pen.Brush, new Rectangle(this.Width - smallResizeRectangle, 0, smallResizeRectangle, offsetResize));

                    // left bottom
                    e.Graphics.FillRectangle(pen.Brush, new Rectangle(0, this.Height - smallResizeRectangle, offsetResize, smallResizeRectangle));
                    e.Graphics.FillRectangle(pen.Brush, new Rectangle(0, this.Height - offsetResize, smallResizeRectangle, offsetResize));
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);

                // bottom right
                if (pos.X >= this.ClientSize.Width - offsetResize && pos.Y >= this.ClientSize.Height - offsetResize)
                {
                    m.Result = (IntPtr)17; // HTBOTTOMRIGHT
                    return;
                }
                // top left
                if (pos.X <= offsetResize && pos.Y <= offsetResize)
                {
                    m.Result = (IntPtr)13; // HTBOTTOMRIGHT
                    return;
                }
                // bottom left
                if (pos.X <= offsetResize && pos.Y >= this.ClientSize.Height - offsetResize)
                {
                    m.Result = (IntPtr)16; // HTBOTTOMRIGHT
                    return;
                }
                // top right
                if (pos.X >= this.ClientSize.Width - offsetResize && pos.Y <= offsetResize)
                {
                    m.Result = (IntPtr)14; // HTBOTTOMRIGHT
                    return;
                }
            }
            base.WndProc(ref m);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
