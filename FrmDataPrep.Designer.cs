
namespace CVLabV2
{
    partial class FrmDataPrep
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
            this.btnModifyImages = new System.Windows.Forms.Button();
            this.tbInterpMethod = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDstImageWidth = new System.Windows.Forms.TextBox();
            this.tbDstImageHeight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbCropToSquare = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlModifiedImage = new System.Windows.Forms.Panel();
            this.pbModifyImage = new System.Windows.Forms.PictureBox();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.tbDisplayedImageWidth = new System.Windows.Forms.TextBox();
            this.tbDisplayedImageHeight = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.rtbActivity = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.pnlModifiedImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbModifyImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnModifyImages
            // 
            this.btnModifyImages.Location = new System.Drawing.Point(6, 22);
            this.btnModifyImages.Name = "btnModifyImages";
            this.btnModifyImages.Size = new System.Drawing.Size(96, 23);
            this.btnModifyImages.TabIndex = 0;
            this.btnModifyImages.Text = "Modify Image";
            this.btnModifyImages.UseVisualStyleBackColor = true;
            this.btnModifyImages.Click += new System.EventHandler(this.btnModifyImages_Click);
            // 
            // tbInterpMethod
            // 
            this.tbInterpMethod.Location = new System.Drawing.Point(6, 91);
            this.tbInterpMethod.Name = "tbInterpMethod";
            this.tbInterpMethod.Size = new System.Drawing.Size(120, 23);
            this.tbInterpMethod.TabIndex = 1;
            this.tbInterpMethod.Text = "LINEAR";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Interpolation Method";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Resize Width";
            // 
            // tbDstImageWidth
            // 
            this.tbDstImageWidth.Location = new System.Drawing.Point(6, 135);
            this.tbDstImageWidth.Name = "tbDstImageWidth";
            this.tbDstImageWidth.Size = new System.Drawing.Size(74, 23);
            this.tbDstImageWidth.TabIndex = 4;
            this.tbDstImageWidth.Text = "512";
            // 
            // tbDstImageHeight
            // 
            this.tbDstImageHeight.Location = new System.Drawing.Point(86, 135);
            this.tbDstImageHeight.Name = "tbDstImageHeight";
            this.tbDstImageHeight.Size = new System.Drawing.Size(78, 23);
            this.tbDstImageHeight.TabIndex = 5;
            this.tbDstImageHeight.Text = "512";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(86, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Resize Height";
            // 
            // cbCropToSquare
            // 
            this.cbCropToSquare.AutoSize = true;
            this.cbCropToSquare.Checked = true;
            this.cbCropToSquare.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCropToSquare.Location = new System.Drawing.Point(6, 51);
            this.cbCropToSquare.Name = "cbCropToSquare";
            this.cbCropToSquare.Size = new System.Drawing.Size(106, 19);
            this.cbCropToSquare.TabIndex = 7;
            this.cbCropToSquare.Text = "Crop To Square";
            this.cbCropToSquare.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnModifyImages);
            this.groupBox1.Controls.Add(this.cbCropToSquare);
            this.groupBox1.Controls.Add(this.tbInterpMethod);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbDstImageHeight);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbDstImageWidth);
            this.groupBox1.Location = new System.Drawing.Point(12, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(174, 174);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // pnlModifiedImage
            // 
            this.pnlModifiedImage.AutoScroll = true;
            this.pnlModifiedImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlModifiedImage.Controls.Add(this.pbModifyImage);
            this.pnlModifiedImage.Location = new System.Drawing.Point(210, 22);
            this.pnlModifiedImage.Name = "pnlModifiedImage";
            this.pnlModifiedImage.Size = new System.Drawing.Size(550, 550);
            this.pnlModifiedImage.TabIndex = 9;
            // 
            // pbModifyImage
            // 
            this.pbModifyImage.Location = new System.Drawing.Point(3, 3);
            this.pbModifyImage.Name = "pbModifyImage";
            this.pbModifyImage.Size = new System.Drawing.Size(100, 100);
            this.pbModifyImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbModifyImage.TabIndex = 0;
            this.pbModifyImage.TabStop = false;
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(18, 22);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(96, 23);
            this.btnLoadImage.TabIndex = 10;
            this.btnLoadImage.Text = "Load Image";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // tbDisplayedImageWidth
            // 
            this.tbDisplayedImageWidth.Location = new System.Drawing.Point(18, 359);
            this.tbDisplayedImageWidth.Name = "tbDisplayedImageWidth";
            this.tbDisplayedImageWidth.Size = new System.Drawing.Size(74, 23);
            this.tbDisplayedImageWidth.TabIndex = 11;
            // 
            // tbDisplayedImageHeight
            // 
            this.tbDisplayedImageHeight.Location = new System.Drawing.Point(98, 359);
            this.tbDisplayedImageHeight.Name = "tbDisplayedImageHeight";
            this.tbDisplayedImageHeight.Size = new System.Drawing.Size(78, 23);
            this.tbDisplayedImageHeight.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 338);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "Width";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(98, 338);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Height";
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.Location = new System.Drawing.Point(18, 312);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(120, 23);
            this.btnSaveImage.TabIndex = 15;
            this.btnSaveImage.Text = "Save Current Image";
            this.btnSaveImage.UseVisualStyleBackColor = true;
            this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
            // 
            // rtbActivity
            // 
            this.rtbActivity.Location = new System.Drawing.Point(12, 483);
            this.rtbActivity.Name = "rtbActivity";
            this.rtbActivity.Size = new System.Drawing.Size(174, 89);
            this.rtbActivity.TabIndex = 16;
            this.rtbActivity.Text = "";
            // 
            // FrmDataPrep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 588);
            this.Controls.Add(this.rtbActivity);
            this.Controls.Add(this.btnSaveImage);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbDisplayedImageHeight);
            this.Controls.Add(this.tbDisplayedImageWidth);
            this.Controls.Add(this.btnLoadImage);
            this.Controls.Add(this.pnlModifiedImage);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmDataPrep";
            this.Text = "Data Prep";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlModifiedImage.ResumeLayout(false);
            this.pnlModifiedImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbModifyImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnModifyImages;
        private System.Windows.Forms.TextBox tbInterpMethod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDstImageWidth;
        private System.Windows.Forms.TextBox tbDstImageHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbCropToSquare;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel pnlModifiedImage;
        public System.Windows.Forms.PictureBox pbModifyImage;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.TextBox tbDisplayedImageWidth;
        private System.Windows.Forms.TextBox tbDisplayedImageHeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSaveImage;
        private System.Windows.Forms.RichTextBox rtbActivity;
    }
}