
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
            this.pnlModifiedImage = new System.Windows.Forms.Panel();
            this.pbModifyImage = new System.Windows.Forms.PictureBox();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.tbDisplayedImageWidth = new System.Windows.Forms.TextBox();
            this.tbDisplayedImageHeight = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.rtbActivity = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbFilenameSuffix = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbLoadImageHeight = new System.Windows.Forms.TextBox();
            this.tbLoadImageWidth = new System.Windows.Forms.TextBox();
            this.btnNumberFiles = new System.Windows.Forms.Button();
            this.tbNumberFileSuffix = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbNumberFilePrefix = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tbClassToChangeTo = new System.Windows.Forms.TextBox();
            this.btnChangeClassInTxt = new System.Windows.Forms.Button();
            this.btnRotateAnnotations = new System.Windows.Forms.Button();
            this.btnCreateTrainAndTestTxt = new System.Windows.Forms.Button();
            this.btnAdjustBBoxesToSquaredImage = new System.Windows.Forms.Button();
            this.btnSquareAllImages = new System.Windows.Forms.Button();
            this.btnGenerateEmptyTxtFiles = new System.Windows.Forms.Button();
            this.pnlModifiedImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbModifyImage)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnModifyImages
            // 
            this.btnModifyImages.Location = new System.Drawing.Point(6, 15);
            this.btnModifyImages.Name = "btnModifyImages";
            this.btnModifyImages.Size = new System.Drawing.Size(96, 23);
            this.btnModifyImages.TabIndex = 0;
            this.btnModifyImages.Text = "Modify Image";
            this.btnModifyImages.UseVisualStyleBackColor = true;
            this.btnModifyImages.Click += new System.EventHandler(this.btnModifyImages_Click);
            // 
            // tbInterpMethod
            // 
            this.tbInterpMethod.Location = new System.Drawing.Point(6, 84);
            this.tbInterpMethod.Name = "tbInterpMethod";
            this.tbInterpMethod.Size = new System.Drawing.Size(120, 23);
            this.tbInterpMethod.TabIndex = 1;
            this.tbInterpMethod.Text = "LINEAR";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Interpolation Method";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Resize Width";
            // 
            // tbDstImageWidth
            // 
            this.tbDstImageWidth.Location = new System.Drawing.Point(6, 128);
            this.tbDstImageWidth.Name = "tbDstImageWidth";
            this.tbDstImageWidth.Size = new System.Drawing.Size(74, 23);
            this.tbDstImageWidth.TabIndex = 4;
            this.tbDstImageWidth.Text = "704";
            // 
            // tbDstImageHeight
            // 
            this.tbDstImageHeight.Location = new System.Drawing.Point(86, 128);
            this.tbDstImageHeight.Name = "tbDstImageHeight";
            this.tbDstImageHeight.Size = new System.Drawing.Size(78, 23);
            this.tbDstImageHeight.TabIndex = 5;
            this.tbDstImageHeight.Text = "704";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(86, 110);
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
            this.cbCropToSquare.Location = new System.Drawing.Point(6, 44);
            this.cbCropToSquare.Name = "cbCropToSquare";
            this.cbCropToSquare.Size = new System.Drawing.Size(106, 19);
            this.cbCropToSquare.TabIndex = 7;
            this.cbCropToSquare.Text = "Crop To Square";
            this.cbCropToSquare.UseVisualStyleBackColor = true;
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
            this.btnLoadImage.Location = new System.Drawing.Point(6, 15);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(96, 23);
            this.btnLoadImage.TabIndex = 10;
            this.btnLoadImage.Text = "Load Image";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // tbDisplayedImageWidth
            // 
            this.tbDisplayedImageWidth.Location = new System.Drawing.Point(6, 59);
            this.tbDisplayedImageWidth.Name = "tbDisplayedImageWidth";
            this.tbDisplayedImageWidth.ReadOnly = true;
            this.tbDisplayedImageWidth.Size = new System.Drawing.Size(74, 23);
            this.tbDisplayedImageWidth.TabIndex = 11;
            // 
            // tbDisplayedImageHeight
            // 
            this.tbDisplayedImageHeight.Location = new System.Drawing.Point(86, 59);
            this.tbDisplayedImageHeight.Name = "tbDisplayedImageHeight";
            this.tbDisplayedImageHeight.ReadOnly = true;
            this.tbDisplayedImageHeight.Size = new System.Drawing.Size(78, 23);
            this.tbDisplayedImageHeight.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "Width";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(86, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Height";
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.Location = new System.Drawing.Point(6, 15);
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
            this.rtbActivity.Size = new System.Drawing.Size(192, 89);
            this.rtbActivity.TabIndex = 16;
            this.rtbActivity.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnModifyImages);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbCropToSquare);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbDstImageHeight);
            this.groupBox1.Controls.Add(this.tbInterpMethod);
            this.groupBox1.Controls.Add(this.tbDstImageWidth);
            this.groupBox1.Location = new System.Drawing.Point(12, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.groupBox1.Size = new System.Drawing.Size(192, 171);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tbFilenameSuffix);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnSaveImage);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tbDisplayedImageWidth);
            this.groupBox2.Controls.Add(this.tbDisplayedImageHeight);
            this.groupBox2.Location = new System.Drawing.Point(12, 285);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(192, 144);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 15);
            this.label6.TabIndex = 17;
            this.label6.Text = "Filename Suffix";
            // 
            // tbFilenameSuffix
            // 
            this.tbFilenameSuffix.Location = new System.Drawing.Point(6, 115);
            this.tbFilenameSuffix.Name = "tbFilenameSuffix";
            this.tbFilenameSuffix.Size = new System.Drawing.Size(158, 23);
            this.tbFilenameSuffix.TabIndex = 16;
            this.tbFilenameSuffix.Text = "MODIFIED";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.tbLoadImageHeight);
            this.groupBox3.Controls.Add(this.tbLoadImageWidth);
            this.groupBox3.Controls.Add(this.btnLoadImage);
            this.groupBox3.Location = new System.Drawing.Point(12, 14);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(192, 88);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(71, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 15);
            this.label8.TabIndex = 1;
            this.label8.Text = "Height";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Width";
            // 
            // tbLoadImageHeight
            // 
            this.tbLoadImageHeight.Location = new System.Drawing.Point(71, 59);
            this.tbLoadImageHeight.Name = "tbLoadImageHeight";
            this.tbLoadImageHeight.ReadOnly = true;
            this.tbLoadImageHeight.Size = new System.Drawing.Size(58, 23);
            this.tbLoadImageHeight.TabIndex = 12;
            // 
            // tbLoadImageWidth
            // 
            this.tbLoadImageWidth.Location = new System.Drawing.Point(6, 59);
            this.tbLoadImageWidth.Name = "tbLoadImageWidth";
            this.tbLoadImageWidth.ReadOnly = true;
            this.tbLoadImageWidth.Size = new System.Drawing.Size(58, 23);
            this.tbLoadImageWidth.TabIndex = 11;
            // 
            // btnNumberFiles
            // 
            this.btnNumberFiles.Location = new System.Drawing.Point(6, 14);
            this.btnNumberFiles.Name = "btnNumberFiles";
            this.btnNumberFiles.Size = new System.Drawing.Size(139, 52);
            this.btnNumberFiles.TabIndex = 18;
            this.btnNumberFiles.Text = "Number All Files In Folder";
            this.btnNumberFiles.UseVisualStyleBackColor = true;
            this.btnNumberFiles.Click += new System.EventHandler(this.btnNumberFiles_Click);
            // 
            // tbNumberFileSuffix
            // 
            this.tbNumberFileSuffix.Location = new System.Drawing.Point(6, 143);
            this.tbNumberFileSuffix.Name = "tbNumberFileSuffix";
            this.tbNumberFileSuffix.Size = new System.Drawing.Size(139, 23);
            this.tbNumberFileSuffix.TabIndex = 19;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.tbNumberFilePrefix);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.tbNumberFileSuffix);
            this.groupBox4.Controls.Add(this.btnNumberFiles);
            this.groupBox4.Location = new System.Drawing.Point(766, 14);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(151, 172);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 15);
            this.label10.TabIndex = 21;
            this.label10.Text = "Prefix";
            // 
            // tbNumberFilePrefix
            // 
            this.tbNumberFilePrefix.Location = new System.Drawing.Point(6, 99);
            this.tbNumberFilePrefix.Name = "tbNumberFilePrefix";
            this.tbNumberFilePrefix.Size = new System.Drawing.Size(138, 23);
            this.tbNumberFilePrefix.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 125);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 15);
            this.label9.TabIndex = 2;
            this.label9.Text = "Suffix";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tbClassToChangeTo);
            this.groupBox5.Controls.Add(this.btnChangeClassInTxt);
            this.groupBox5.Location = new System.Drawing.Point(766, 192);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(151, 106);
            this.groupBox5.TabIndex = 18;
            this.groupBox5.TabStop = false;
            // 
            // tbClassToChangeTo
            // 
            this.tbClassToChangeTo.Location = new System.Drawing.Point(6, 73);
            this.tbClassToChangeTo.Name = "tbClassToChangeTo";
            this.tbClassToChangeTo.Size = new System.Drawing.Size(139, 23);
            this.tbClassToChangeTo.TabIndex = 1;
            this.tbClassToChangeTo.Text = "0";
            // 
            // btnChangeClassInTxt
            // 
            this.btnChangeClassInTxt.Location = new System.Drawing.Point(6, 15);
            this.btnChangeClassInTxt.Name = "btnChangeClassInTxt";
            this.btnChangeClassInTxt.Size = new System.Drawing.Size(139, 49);
            this.btnChangeClassInTxt.TabIndex = 0;
            this.btnChangeClassInTxt.Text = "Change Class ID For All Annotations In Txt File";
            this.btnChangeClassInTxt.UseVisualStyleBackColor = true;
            this.btnChangeClassInTxt.Click += new System.EventHandler(this.btnChangeClassInTxt_Click);
            // 
            // btnRotateAnnotations
            // 
            this.btnRotateAnnotations.Location = new System.Drawing.Point(766, 313);
            this.btnRotateAnnotations.Name = "btnRotateAnnotations";
            this.btnRotateAnnotations.Size = new System.Drawing.Size(151, 41);
            this.btnRotateAnnotations.TabIndex = 19;
            this.btnRotateAnnotations.Text = "Create Rotated Images With Annotations";
            this.btnRotateAnnotations.UseVisualStyleBackColor = true;
            this.btnRotateAnnotations.Click += new System.EventHandler(this.btnRotateAnnotations_Click);
            // 
            // btnCreateTrainAndTestTxt
            // 
            this.btnCreateTrainAndTestTxt.Location = new System.Drawing.Point(766, 381);
            this.btnCreateTrainAndTestTxt.Name = "btnCreateTrainAndTestTxt";
            this.btnCreateTrainAndTestTxt.Size = new System.Drawing.Size(151, 42);
            this.btnCreateTrainAndTestTxt.TabIndex = 20;
            this.btnCreateTrainAndTestTxt.Text = "Create train.txt and test.txt";
            this.btnCreateTrainAndTestTxt.UseVisualStyleBackColor = true;
            this.btnCreateTrainAndTestTxt.Click += new System.EventHandler(this.btnCreateTrainAndTestTxt_Click);
            // 
            // btnAdjustBBoxesToSquaredImage
            // 
            this.btnAdjustBBoxesToSquaredImage.Location = new System.Drawing.Point(766, 438);
            this.btnAdjustBBoxesToSquaredImage.Name = "btnAdjustBBoxesToSquaredImage";
            this.btnAdjustBBoxesToSquaredImage.Size = new System.Drawing.Size(151, 46);
            this.btnAdjustBBoxesToSquaredImage.TabIndex = 21;
            this.btnAdjustBBoxesToSquaredImage.Text = "Adjust BBoxes to squared image";
            this.btnAdjustBBoxesToSquaredImage.UseVisualStyleBackColor = true;
            this.btnAdjustBBoxesToSquaredImage.Click += new System.EventHandler(this.btnAdjustBBoxesToSquaredImage_Click);
            // 
            // btnSquareAllImages
            // 
            this.btnSquareAllImages.Enabled = false;
            this.btnSquareAllImages.Location = new System.Drawing.Point(18, 438);
            this.btnSquareAllImages.Name = "btnSquareAllImages";
            this.btnSquareAllImages.Size = new System.Drawing.Size(158, 28);
            this.btnSquareAllImages.TabIndex = 22;
            this.btnSquareAllImages.Text = "Square All Images In Folder";
            this.btnSquareAllImages.UseVisualStyleBackColor = true;
            this.btnSquareAllImages.Click += new System.EventHandler(this.btnSquareAllImages_Click);
            // 
            // btnGenerateEmptyTxtFiles
            // 
            this.btnGenerateEmptyTxtFiles.Enabled = false;
            this.btnGenerateEmptyTxtFiles.Location = new System.Drawing.Point(766, 502);
            this.btnGenerateEmptyTxtFiles.Name = "btnGenerateEmptyTxtFiles";
            this.btnGenerateEmptyTxtFiles.Size = new System.Drawing.Size(151, 36);
            this.btnGenerateEmptyTxtFiles.TabIndex = 23;
            this.btnGenerateEmptyTxtFiles.Text = "Generate Empty Txt Files";
            this.btnGenerateEmptyTxtFiles.UseVisualStyleBackColor = true;
            this.btnGenerateEmptyTxtFiles.Click += new System.EventHandler(this.btnGenerateEmptyTxtFiles_Click);
            // 
            // FrmDataPrep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 588);
            this.Controls.Add(this.btnGenerateEmptyTxtFiles);
            this.Controls.Add(this.btnSquareAllImages);
            this.Controls.Add(this.btnAdjustBBoxesToSquaredImage);
            this.Controls.Add(this.btnCreateTrainAndTestTxt);
            this.Controls.Add(this.btnRotateAnnotations);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rtbActivity);
            this.Controls.Add(this.pnlModifiedImage);
            this.Name = "FrmDataPrep";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Prep";
            this.pnlModifiedImage.ResumeLayout(false);
            this.pnlModifiedImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbModifyImage)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Panel pnlModifiedImage;
        public System.Windows.Forms.PictureBox pbModifyImage;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.TextBox tbDisplayedImageWidth;
        private System.Windows.Forms.TextBox tbDisplayedImageHeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSaveImage;
        private System.Windows.Forms.RichTextBox rtbActivity;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbFilenameSuffix;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbLoadImageHeight;
        private System.Windows.Forms.TextBox tbLoadImageWidth;
        private System.Windows.Forms.Button btnNumberFiles;
        private System.Windows.Forms.TextBox tbNumberFileSuffix;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox tbClassToChangeTo;
        private System.Windows.Forms.Button btnChangeClassInTxt;
        private System.Windows.Forms.Button btnRotateAnnotations;
        private System.Windows.Forms.Button btnCreateTrainAndTestTxt;
        private System.Windows.Forms.Button btnAdjustBBoxesToSquaredImage;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbNumberFilePrefix;
        private System.Windows.Forms.Button btnSquareAllImages;
        private System.Windows.Forms.Button btnGenerateEmptyTxtFiles;
    }
}