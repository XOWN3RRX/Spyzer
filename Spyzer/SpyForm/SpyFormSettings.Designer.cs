namespace Spyzer.SpyForm
{
    partial class SpyFormSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpyFormSettings));
            this.checkBoxTop = new System.Windows.Forms.CheckBox();
            this.checkBoxLandscape = new System.Windows.Forms.CheckBox();
            this.checkBoxDrawMargin = new System.Windows.Forms.CheckBox();
            this.pictureBoxDrawColor = new System.Windows.Forms.PictureBox();
            this.colorDialogDraw = new System.Windows.Forms.ColorDialog();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDrawColor)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxTop
            // 
            this.checkBoxTop.AutoSize = true;
            this.checkBoxTop.Location = new System.Drawing.Point(12, 12);
            this.checkBoxTop.Name = "checkBoxTop";
            this.checkBoxTop.Size = new System.Drawing.Size(117, 17);
            this.checkBoxTop.TabIndex = 0;
            this.checkBoxTop.Text = "TopMost by default";
            this.checkBoxTop.UseVisualStyleBackColor = true;
            this.checkBoxTop.CheckedChanged += new System.EventHandler(this.checkBoxTop_CheckedChanged);
            // 
            // checkBoxLandscape
            // 
            this.checkBoxLandscape.AutoSize = true;
            this.checkBoxLandscape.Location = new System.Drawing.Point(12, 35);
            this.checkBoxLandscape.Name = "checkBoxLandscape";
            this.checkBoxLandscape.Size = new System.Drawing.Size(158, 17);
            this.checkBoxLandscape.TabIndex = 1;
            this.checkBoxLandscape.Text = "Landscape Mode by default";
            this.checkBoxLandscape.UseVisualStyleBackColor = true;
            this.checkBoxLandscape.CheckedChanged += new System.EventHandler(this.checkBoxLandscape_CheckedChanged);
            // 
            // checkBoxDrawMargin
            // 
            this.checkBoxDrawMargin.AutoSize = true;
            this.checkBoxDrawMargin.Location = new System.Drawing.Point(12, 58);
            this.checkBoxDrawMargin.Name = "checkBoxDrawMargin";
            this.checkBoxDrawMargin.Size = new System.Drawing.Size(86, 17);
            this.checkBoxDrawMargin.TabIndex = 2;
            this.checkBoxDrawMargin.Text = "Draw Margin";
            this.checkBoxDrawMargin.UseVisualStyleBackColor = true;
            this.checkBoxDrawMargin.CheckedChanged += new System.EventHandler(this.checkBoxDrawMargin_CheckedChanged);
            // 
            // pictureBoxDrawColor
            // 
            this.pictureBoxDrawColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxDrawColor.Location = new System.Drawing.Point(12, 82);
            this.pictureBoxDrawColor.Name = "pictureBoxDrawColor";
            this.pictureBoxDrawColor.Size = new System.Drawing.Size(13, 13);
            this.pictureBoxDrawColor.TabIndex = 3;
            this.pictureBoxDrawColor.TabStop = false;
            this.pictureBoxDrawColor.Click += new System.EventHandler(this.pictureBoxDrawColor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Location = new System.Drawing.Point(28, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Default Color";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // SpyFormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(186, 114);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxDrawColor);
            this.Controls.Add(this.checkBoxDrawMargin);
            this.Controls.Add(this.checkBoxLandscape);
            this.Controls.Add(this.checkBoxTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SpyFormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SpyFormSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDrawColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxTop;
        private System.Windows.Forms.CheckBox checkBoxLandscape;
        private System.Windows.Forms.CheckBox checkBoxDrawMargin;
        private System.Windows.Forms.PictureBox pictureBoxDrawColor;
        private System.Windows.Forms.ColorDialog colorDialogDraw;
        private System.Windows.Forms.Label label1;
    }
}