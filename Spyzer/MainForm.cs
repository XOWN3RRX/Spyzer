using GreenshotPlugin.Core;
using GreenshotPlugin.UnmanagedHelpers;
using Spyzer.Properties;
using Spyzer.SpyForm;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spyzer
{
    public partial class MainForm : Form
    {
        private IntPtr _currentHandle;
        private IntPtr _spyWindowHandle;
        private DWM_THUMBNAIL_PROPERTIES _dwm_THUMBNAIL_PROPERTIES;


        public MainForm()
        {
            InitializeComponent();
        }

        private async void MainForm_Load(object sender, System.EventArgs e)
        {
            _currentHandle = IntPtr.Zero;
            _spyWindowHandle = IntPtr.Zero;

            _dwm_THUMBNAIL_PROPERTIES = new DWM_THUMBNAIL_PROPERTIES
            {
                Opacity = byte.MaxValue,
                Visible = true,
                SourceClientAreaOnly = false,
                Destination = DWMSize.ClientSize(groupBoxPreview)
            };

            await Task.Delay(500);
            RefreshActiveProcess();
        }

        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            // clear grid
            dataGridViewProcess.Rows.Clear();
            // clear handler
            _currentHandle = IntPtr.Zero;
            // refresh active process
            RefreshActiveProcess();
        }

        public void RefreshActiveProcess()
        {
            try
            {
                foreach (WindowDetails windowDetails in WindowDetails.GetTopLevelWindows())
                {
                    string processName = windowDetails.Text;
                    Image processIcon = windowDetails.DisplayIcon;
                    IntPtr processHandle = windowDetails.Handle;

                    if (processIcon == null)
                    {
                        processIcon = SystemIcons.Application.ToBitmap();
                    }

                    if (processName == null)
                    {
                        processName = "Unknown";
                    }

                    if (processHandle == IntPtr.Zero)
                    {
                        continue;
                    }

                    DataGridViewRow row = new DataGridViewRow();

                    row.Cells.Add(new DataGridViewImageCell
                    {
                        Value = processIcon
                    });

                    row.Cells.Add(new DataGridViewTextBoxCell
                    {
                        Value = processName
                    });

                    row.Tag = processHandle;

                    dataGridViewProcess.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Get Active Process Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewProcess_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && dataGridViewProcess.HitTest(e.X, e.Y).RowIndex >= 0)
            {
                int row = dataGridViewProcess.HitTest(e.X, e.Y).RowIndex;

                IntPtr handle = (IntPtr)dataGridViewProcess.Rows[row].Tag;
                _currentHandle = handle;

                ShowThumbnail(handle);
            }
        }

        private void dataGridViewProcess_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && dataGridViewProcess.HitTest(e.X, e.Y).RowIndex >= 0)
            {
                int row = dataGridViewProcess.HitTest(e.X, e.Y).RowIndex;

                IntPtr handle = (IntPtr)dataGridViewProcess.Rows[row].Tag;
                _currentHandle = handle;

                ShowThumbnail(handle);

                if (_currentHandle != IntPtr.Zero)
                {
                    new SpyFormHandler(_currentHandle).Show();
                }
            }
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

        private void MainForm_Resize(object sender, EventArgs e)
        {
            _dwm_THUMBNAIL_PROPERTIES.Destination = DWMSize.ClientSize(groupBoxPreview);

            if (_currentHandle != IntPtr.Zero)
            {
                ShowThumbnail(_currentHandle);
            }
        }

        private void btnSpy_Click(object sender, EventArgs e)
        {
            if (_currentHandle != IntPtr.Zero)
            {
                SpyFormHandler sp = new SpyFormHandler(_currentHandle);
                sp.Show();
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            new SpyFormSettings().ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (InstanceCounter.Instance.Instances > 0)
            {
                if (MessageBox.Show($"{InstanceCounter.Instance.Instances} alive, do you want to close all?", "Instance Counter", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
