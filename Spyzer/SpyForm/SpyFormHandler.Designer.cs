namespace Spyzer.SpyForm
{
    partial class SpyFormHandler
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpyFormHandler));
            this.contextMenuStripSpyForm = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.topToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.landscapeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawMarginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripSpyForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStripSpyForm
            // 
            this.contextMenuStripSpyForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.topToolStripMenuItem,
            this.landscapeToolStripMenuItem,
            this.drawMarginToolStripMenuItem,
            this.activateToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.contextMenuStripSpyForm.Name = "contextMenuStripSpyForm";
            this.contextMenuStripSpyForm.Size = new System.Drawing.Size(181, 136);
            // 
            // topToolStripMenuItem
            // 
            this.topToolStripMenuItem.Name = "topToolStripMenuItem";
            this.topToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.topToolStripMenuItem.Text = "Top";
            this.topToolStripMenuItem.Click += new System.EventHandler(this.topToolStripMenuItem_Click);
            // 
            // landscapeToolStripMenuItem
            // 
            this.landscapeToolStripMenuItem.Name = "landscapeToolStripMenuItem";
            this.landscapeToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.landscapeToolStripMenuItem.Text = "Landscape";
            this.landscapeToolStripMenuItem.Click += new System.EventHandler(this.landscapeToolStripMenuItem_Click);
            // 
            // activateToolStripMenuItem
            // 
            this.activateToolStripMenuItem.Name = "activateToolStripMenuItem";
            this.activateToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.activateToolStripMenuItem.Text = "Activate";
            this.activateToolStripMenuItem.Click += new System.EventHandler(this.activateToolStripMenuItem_Click);
            // 
            // drawMarginToolStripMenuItem
            // 
            this.drawMarginToolStripMenuItem.Name = "drawMarginToolStripMenuItem";
            this.drawMarginToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.drawMarginToolStripMenuItem.Text = "Draw Margin";
            this.drawMarginToolStripMenuItem.Click += new System.EventHandler(this.drawMarginToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // SpyFormHandler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 231);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SpyFormHandler";
            this.Text = "SpyForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SpyFormHandler_FormClosing);
            this.Load += new System.EventHandler(this.SpyFormHandler_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SpyFormHandler_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SpyFormHandler_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.SpyFormHandler_MouseDoubleClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SpyFormHandler_MouseMove);
            this.Resize += new System.EventHandler(this.SpyFormHandler_Resize);
            this.contextMenuStripSpyForm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStripSpyForm;
        private System.Windows.Forms.ToolStripMenuItem topToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem landscapeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawMarginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    }
}