
namespace CVLabV2
{
    partial class FrmAnnotation
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbMain = new System.Windows.Forms.PictureBox();
            this.btnLoadImageSrc = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbCursorPosition = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pbZoomedSubImage = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbActiveRect = new System.Windows.Forms.TextBox();
            this.clbAnnots = new System.Windows.Forms.CheckedListBox();
            this.rtbLastActivity = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbCrossThickness = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbCursorType = new System.Windows.Forms.ComboBox();
            this.cbUseCustomUpScaling = new System.Windows.Forms.CheckBox();
            this.btnSetAllAnnotsToNotVisible = new System.Windows.Forms.Button();
            this.tbSetAllAnnotsToVisible = new System.Windows.Forms.Button();
            this.cbForceIntegerScaling = new System.Windows.Forms.CheckBox();
            this.cbShowAnnotsAsCrosses = new System.Windows.Forms.CheckBox();
            this.cbEditModeHideOtherAnnots = new System.Windows.Forms.CheckBox();
            this.tbAnnotLabel = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbSelectedClbIndex = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveAnnotsToTxtFile = new System.Windows.Forms.Button();
            this.btnDrawLastDarknetPrediction = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tbState = new System.Windows.Forms.TextBox();
            this.tbUserMode = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tbInterpolationMethod = new System.Windows.Forms.TextBox();
            this.btnLoadDataPrep = new System.Windows.Forms.Button();
            this.pbOuterView = new System.Windows.Forms.PictureBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.cbScopeOutAmount = new System.Windows.Forms.ComboBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.tbSrcFile = new System.Windows.Forms.TextBox();
            this.cbLoadImageScale = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbZoomedSubImage)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOuterView)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbMain
            // 
            this.pbMain.Enabled = false;
            this.pbMain.Location = new System.Drawing.Point(3, 3);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(186, 163);
            this.pbMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbMain.TabIndex = 0;
            this.pbMain.TabStop = false;
            this.pbMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbMain_MouseClick);
            this.pbMain.MouseEnter += new System.EventHandler(this.pbMain_MouseEnter);
            this.pbMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbMain_MouseMove);
            // 
            // btnLoadImageSrc
            // 
            this.btnLoadImageSrc.Location = new System.Drawing.Point(12, 12);
            this.btnLoadImageSrc.Name = "btnLoadImageSrc";
            this.btnLoadImageSrc.Size = new System.Drawing.Size(109, 23);
            this.btnLoadImageSrc.TabIndex = 1;
            this.btnLoadImageSrc.Text = "Load Image";
            this.btnLoadImageSrc.UseVisualStyleBackColor = true;
            this.btnLoadImageSrc.Click += new System.EventHandler(this.btnLoadImageSrc_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pbMain);
            this.panel1.Location = new System.Drawing.Point(289, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(661, 716);
            this.panel1.TabIndex = 2;
            // 
            // tbCursorPosition
            // 
            this.tbCursorPosition.Location = new System.Drawing.Point(6, 22);
            this.tbCursorPosition.Name = "tbCursorPosition";
            this.tbCursorPosition.ReadOnly = true;
            this.tbCursorPosition.Size = new System.Drawing.Size(249, 23);
            this.tbCursorPosition.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbCursorPosition);
            this.groupBox1.Location = new System.Drawing.Point(956, 415);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 56);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cursor Position";
            // 
            // pbZoomedSubImage
            // 
            this.pbZoomedSubImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbZoomedSubImage.Location = new System.Drawing.Point(12, 71);
            this.pbZoomedSubImage.Name = "pbZoomedSubImage";
            this.pbZoomedSubImage.Size = new System.Drawing.Size(265, 265);
            this.pbZoomedSubImage.TabIndex = 5;
            this.pbZoomedSubImage.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbActiveRect);
            this.groupBox2.Location = new System.Drawing.Point(12, 622);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(265, 53);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Active Rectangle";
            // 
            // tbActiveRect
            // 
            this.tbActiveRect.Location = new System.Drawing.Point(6, 22);
            this.tbActiveRect.Name = "tbActiveRect";
            this.tbActiveRect.ReadOnly = true;
            this.tbActiveRect.Size = new System.Drawing.Size(253, 23);
            this.tbActiveRect.TabIndex = 0;
            // 
            // clbAnnots
            // 
            this.clbAnnots.FormattingEnabled = true;
            this.clbAnnots.Location = new System.Drawing.Point(956, 565);
            this.clbAnnots.Name = "clbAnnots";
            this.clbAnnots.Size = new System.Drawing.Size(261, 94);
            this.clbAnnots.TabIndex = 7;
            this.clbAnnots.MouseClick += new System.Windows.Forms.MouseEventHandler(this.clbAnnots_MouseClick);
            this.clbAnnots.SelectedIndexChanged += new System.EventHandler(this.clbAnnots_SelectedIndexChanged);
            this.clbAnnots.MouseEnter += new System.EventHandler(this.clbAnnots_MouseEnter);
            this.clbAnnots.MouseLeave += new System.EventHandler(this.clbAnnots_MouseLeave);
            // 
            // rtbLastActivity
            // 
            this.rtbLastActivity.BackColor = System.Drawing.SystemColors.Control;
            this.rtbLastActivity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbLastActivity.Location = new System.Drawing.Point(956, 665);
            this.rtbLastActivity.Name = "rtbLastActivity";
            this.rtbLastActivity.ReadOnly = true;
            this.rtbLastActivity.Size = new System.Drawing.Size(261, 64);
            this.rtbLastActivity.TabIndex = 8;
            this.rtbLastActivity.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbCrossThickness);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.cbCursorType);
            this.groupBox3.Controls.Add(this.cbUseCustomUpScaling);
            this.groupBox3.Controls.Add(this.btnSetAllAnnotsToNotVisible);
            this.groupBox3.Controls.Add(this.tbSetAllAnnotsToVisible);
            this.groupBox3.Controls.Add(this.cbForceIntegerScaling);
            this.groupBox3.Controls.Add(this.cbShowAnnotsAsCrosses);
            this.groupBox3.Controls.Add(this.cbEditModeHideOtherAnnots);
            this.groupBox3.Location = new System.Drawing.Point(956, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(261, 167);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Options";
            // 
            // tbCrossThickness
            // 
            this.tbCrossThickness.Location = new System.Drawing.Point(190, 92);
            this.tbCrossThickness.Name = "tbCrossThickness";
            this.tbCrossThickness.Size = new System.Drawing.Size(47, 23);
            this.tbCrossThickness.TabIndex = 10;
            this.tbCrossThickness.Text = "1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 15);
            this.label8.TabIndex = 9;
            this.label8.Text = "Cursor";
            // 
            // cbCursorType
            // 
            this.cbCursorType.FormattingEnabled = true;
            this.cbCursorType.Items.AddRange(new object[] {
            "Pointer",
            "Cross"});
            this.cbCursorType.Location = new System.Drawing.Point(55, 137);
            this.cbCursorType.Name = "cbCursorType";
            this.cbCursorType.Size = new System.Drawing.Size(112, 23);
            this.cbCursorType.TabIndex = 8;
            this.cbCursorType.Text = "Pointer";
            // 
            // cbUseCustomUpScaling
            // 
            this.cbUseCustomUpScaling.AutoSize = true;
            this.cbUseCustomUpScaling.BackColor = System.Drawing.SystemColors.Control;
            this.cbUseCustomUpScaling.Checked = true;
            this.cbUseCustomUpScaling.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbUseCustomUpScaling.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbUseCustomUpScaling.Location = new System.Drawing.Point(7, 112);
            this.cbUseCustomUpScaling.Name = "cbUseCustomUpScaling";
            this.cbUseCustomUpScaling.Size = new System.Drawing.Size(151, 19);
            this.cbUseCustomUpScaling.TabIndex = 7;
            this.cbUseCustomUpScaling.Text = "Use Custom Up-Scaling";
            this.cbUseCustomUpScaling.UseVisualStyleBackColor = false;
            this.cbUseCustomUpScaling.CheckedChanged += new System.EventHandler(this.cbUseCustomUpScaling_CheckedChanged);
            // 
            // btnSetAllAnnotsToNotVisible
            // 
            this.btnSetAllAnnotsToNotVisible.Location = new System.Drawing.Point(95, 23);
            this.btnSetAllAnnotsToNotVisible.Name = "btnSetAllAnnotsToNotVisible";
            this.btnSetAllAnnotsToNotVisible.Size = new System.Drawing.Size(75, 23);
            this.btnSetAllAnnotsToNotVisible.TabIndex = 4;
            this.btnSetAllAnnotsToNotVisible.Text = "Hide All";
            this.btnSetAllAnnotsToNotVisible.UseVisualStyleBackColor = true;
            this.btnSetAllAnnotsToNotVisible.Click += new System.EventHandler(this.btnSetAllAnnotsToNotVisible_Click);
            // 
            // tbSetAllAnnotsToVisible
            // 
            this.tbSetAllAnnotsToVisible.Location = new System.Drawing.Point(7, 23);
            this.tbSetAllAnnotsToVisible.Name = "tbSetAllAnnotsToVisible";
            this.tbSetAllAnnotsToVisible.Size = new System.Drawing.Size(82, 23);
            this.tbSetAllAnnotsToVisible.TabIndex = 3;
            this.tbSetAllAnnotsToVisible.Text = "Show All";
            this.tbSetAllAnnotsToVisible.UseVisualStyleBackColor = true;
            this.tbSetAllAnnotsToVisible.Click += new System.EventHandler(this.tbSetAllAnnotsToVisible_Click);
            // 
            // cbForceIntegerScaling
            // 
            this.cbForceIntegerScaling.AutoSize = true;
            this.cbForceIntegerScaling.BackColor = System.Drawing.SystemColors.Control;
            this.cbForceIntegerScaling.Enabled = false;
            this.cbForceIntegerScaling.ForeColor = System.Drawing.Color.Gray;
            this.cbForceIntegerScaling.Location = new System.Drawing.Point(7, 92);
            this.cbForceIntegerScaling.Name = "cbForceIntegerScaling";
            this.cbForceIntegerScaling.Size = new System.Drawing.Size(136, 19);
            this.cbForceIntegerScaling.TabIndex = 2;
            this.cbForceIntegerScaling.Text = "Force Integer Scaling";
            this.cbForceIntegerScaling.UseVisualStyleBackColor = false;
            this.cbForceIntegerScaling.CheckedChanged += new System.EventHandler(this.cbForceIntegerScaling_CheckedChanged);
            // 
            // cbShowAnnotsAsCrosses
            // 
            this.cbShowAnnotsAsCrosses.AutoSize = true;
            this.cbShowAnnotsAsCrosses.Location = new System.Drawing.Point(7, 72);
            this.cbShowAnnotsAsCrosses.Name = "cbShowAnnotsAsCrosses";
            this.cbShowAnnotsAsCrosses.Size = new System.Drawing.Size(225, 19);
            this.cbShowAnnotsAsCrosses.TabIndex = 1;
            this.cbShowAnnotsAsCrosses.Text = "Show Annots As Crosses - View Mode";
            this.cbShowAnnotsAsCrosses.UseVisualStyleBackColor = true;
            this.cbShowAnnotsAsCrosses.CheckedChanged += new System.EventHandler(this.cbShowAnnotsAsCrosses_CheckedChanged);
            // 
            // cbEditModeHideOtherAnnots
            // 
            this.cbEditModeHideOtherAnnots.AutoSize = true;
            this.cbEditModeHideOtherAnnots.Checked = true;
            this.cbEditModeHideOtherAnnots.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEditModeHideOtherAnnots.Location = new System.Drawing.Point(7, 52);
            this.cbEditModeHideOtherAnnots.Name = "cbEditModeHideOtherAnnots";
            this.cbEditModeHideOtherAnnots.Size = new System.Drawing.Size(159, 19);
            this.cbEditModeHideOtherAnnots.TabIndex = 0;
            this.cbEditModeHideOtherAnnots.Text = "Hide Others In Edit Mode";
            this.cbEditModeHideOtherAnnots.UseVisualStyleBackColor = true;
            this.cbEditModeHideOtherAnnots.CheckedChanged += new System.EventHandler(this.cbEditModeHideOtherAnnots_CheckedChanged);
            // 
            // tbAnnotLabel
            // 
            this.tbAnnotLabel.Location = new System.Drawing.Point(6, 22);
            this.tbAnnotLabel.Name = "tbAnnotLabel";
            this.tbAnnotLabel.Size = new System.Drawing.Size(62, 23);
            this.tbAnnotLabel.TabIndex = 5;
            this.tbAnnotLabel.Text = "0";
            this.tbAnnotLabel.MouseLeave += new System.EventHandler(this.tbAnnotLabel_MouseLeave);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tbSelectedClbIndex);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(956, 185);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(261, 144);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Controls";
            // 
            // tbSelectedClbIndex
            // 
            this.tbSelectedClbIndex.Location = new System.Drawing.Point(190, 117);
            this.tbSelectedClbIndex.Name = "tbSelectedClbIndex";
            this.tbSelectedClbIndex.ReadOnly = true;
            this.tbSelectedClbIndex.Size = new System.Drawing.Size(47, 23);
            this.tbSelectedClbIndex.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(181, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "[H] Edit Selected CLB Annotation";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(181, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "[T] Change Interpolation Method";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "[G] Duplicate Last Editted Box";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Retract Box Edges - Edit Mode";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "[A] [S] [D] [R]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Expand Box Edges - Edit Mode";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "[Q] [W] [E] [R]";
            // 
            // btnSaveAnnotsToTxtFile
            // 
            this.btnSaveAnnotsToTxtFile.Location = new System.Drawing.Point(185, 12);
            this.btnSaveAnnotsToTxtFile.Name = "btnSaveAnnotsToTxtFile";
            this.btnSaveAnnotsToTxtFile.Size = new System.Drawing.Size(92, 23);
            this.btnSaveAnnotsToTxtFile.TabIndex = 11;
            this.btnSaveAnnotsToTxtFile.Text = "Save";
            this.btnSaveAnnotsToTxtFile.UseVisualStyleBackColor = true;
            this.btnSaveAnnotsToTxtFile.Click += new System.EventHandler(this.btnSaveAnnotsToTxtFile_Click);
            // 
            // btnDrawLastDarknetPrediction
            // 
            this.btnDrawLastDarknetPrediction.Location = new System.Drawing.Point(12, 42);
            this.btnDrawLastDarknetPrediction.Name = "btnDrawLastDarknetPrediction";
            this.btnDrawLastDarknetPrediction.Size = new System.Drawing.Size(167, 23);
            this.btnDrawLastDarknetPrediction.TabIndex = 12;
            this.btnDrawLastDarknetPrediction.Text = "Draw Last Darknet Prediction";
            this.btnDrawLastDarknetPrediction.UseVisualStyleBackColor = true;
            this.btnDrawLastDarknetPrediction.Click += new System.EventHandler(this.btnDrawLastDarknetPrediction_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tbState);
            this.groupBox5.Controls.Add(this.tbUserMode);
            this.groupBox5.Location = new System.Drawing.Point(956, 477);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(261, 82);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "States";
            // 
            // tbState
            // 
            this.tbState.Location = new System.Drawing.Point(6, 51);
            this.tbState.Name = "tbState";
            this.tbState.ReadOnly = true;
            this.tbState.Size = new System.Drawing.Size(249, 23);
            this.tbState.TabIndex = 1;
            // 
            // tbUserMode
            // 
            this.tbUserMode.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbUserMode.Location = new System.Drawing.Point(6, 22);
            this.tbUserMode.Name = "tbUserMode";
            this.tbUserMode.ReadOnly = true;
            this.tbUserMode.Size = new System.Drawing.Size(249, 23);
            this.tbUserMode.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.tbInterpolationMethod);
            this.groupBox6.Location = new System.Drawing.Point(96, 678);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(181, 51);
            this.groupBox6.TabIndex = 14;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Interpolation Method";
            // 
            // tbInterpolationMethod
            // 
            this.tbInterpolationMethod.Location = new System.Drawing.Point(6, 22);
            this.tbInterpolationMethod.Name = "tbInterpolationMethod";
            this.tbInterpolationMethod.ReadOnly = true;
            this.tbInterpolationMethod.Size = new System.Drawing.Size(169, 23);
            this.tbInterpolationMethod.TabIndex = 15;
            // 
            // btnLoadDataPrep
            // 
            this.btnLoadDataPrep.Location = new System.Drawing.Point(185, 42);
            this.btnLoadDataPrep.Name = "btnLoadDataPrep";
            this.btnLoadDataPrep.Size = new System.Drawing.Size(92, 23);
            this.btnLoadDataPrep.TabIndex = 15;
            this.btnLoadDataPrep.Text = "Data Prep";
            this.btnLoadDataPrep.UseVisualStyleBackColor = true;
            this.btnLoadDataPrep.Click += new System.EventHandler(this.btnLoadDataPrep_Click);
            // 
            // pbOuterView
            // 
            this.pbOuterView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbOuterView.Location = new System.Drawing.Point(12, 351);
            this.pbOuterView.Name = "pbOuterView";
            this.pbOuterView.Size = new System.Drawing.Size(265, 265);
            this.pbOuterView.TabIndex = 16;
            this.pbOuterView.TabStop = false;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.tbAnnotLabel);
            this.groupBox7.Location = new System.Drawing.Point(956, 335);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(74, 56);
            this.groupBox7.TabIndex = 17;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Class ID";
            // 
            // cbScopeOutAmount
            // 
            this.cbScopeOutAmount.FormattingEnabled = true;
            this.cbScopeOutAmount.Items.AddRange(new object[] {
            "2x",
            "3x"});
            this.cbScopeOutAmount.Location = new System.Drawing.Point(6, 22);
            this.cbScopeOutAmount.MaxDropDownItems = 2;
            this.cbScopeOutAmount.Name = "cbScopeOutAmount";
            this.cbScopeOutAmount.Size = new System.Drawing.Size(66, 23);
            this.cbScopeOutAmount.TabIndex = 18;
            this.cbScopeOutAmount.Text = "2x";
            this.cbScopeOutAmount.SelectedIndexChanged += new System.EventHandler(this.cbScopeOutAmount_SelectedIndexChanged);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.cbScopeOutAmount);
            this.groupBox8.Location = new System.Drawing.Point(12, 678);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(78, 51);
            this.groupBox8.TabIndex = 1;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Scope-out";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.tbSrcFile);
            this.groupBox9.Location = new System.Drawing.Point(1036, 335);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(181, 56);
            this.groupBox9.TabIndex = 18;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "File";
            // 
            // tbSrcFile
            // 
            this.tbSrcFile.Location = new System.Drawing.Point(6, 22);
            this.tbSrcFile.Name = "tbSrcFile";
            this.tbSrcFile.ReadOnly = true;
            this.tbSrcFile.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbSrcFile.Size = new System.Drawing.Size(169, 23);
            this.tbSrcFile.TabIndex = 0;
            // 
            // cbLoadImageScale
            // 
            this.cbLoadImageScale.FormattingEnabled = true;
            this.cbLoadImageScale.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cbLoadImageScale.Location = new System.Drawing.Point(127, 12);
            this.cbLoadImageScale.Name = "cbLoadImageScale";
            this.cbLoadImageScale.Size = new System.Drawing.Size(52, 23);
            this.cbLoadImageScale.TabIndex = 19;
            this.cbLoadImageScale.Text = "1";
            // 
            // FrmAnnotation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 734);
            this.Controls.Add(this.cbLoadImageScale);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.pbOuterView);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnLoadDataPrep);
            this.Controls.Add(this.rtbLastActivity);
            this.Controls.Add(this.clbAnnots);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnDrawLastDarknetPrediction);
            this.Controls.Add(this.btnSaveAnnotsToTxtFile);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.pbZoomedSubImage);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnLoadImageSrc);
            this.KeyPreview = true;
            this.Name = "FrmAnnotation";
            this.Text = "Annotate Image";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmAnnotation_FormClosed);
            this.Load += new System.EventHandler(this.FrmAnnotation_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmAnnotation_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbZoomedSubImage)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOuterView)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnLoadImageSrc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbCursorPosition;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbShowAnnotsAsCrosses;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnSaveAnnotsToTxtFile;
        private System.Windows.Forms.Button btnDrawLastDarknetPrediction;
        private System.Windows.Forms.Button btnSetAllAnnotsToNotVisible;
        private System.Windows.Forms.Button tbSetAllAnnotsToVisible;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox6;
        public System.Windows.Forms.TextBox tbActiveRect;
        public System.Windows.Forms.CheckedListBox clbAnnots;
        private System.Windows.Forms.TextBox tbAnnotLabel;
        public System.Windows.Forms.RichTextBox rtbLastActivity;
        public System.Windows.Forms.CheckBox cbEditModeHideOtherAnnots;
        public System.Windows.Forms.TextBox tbState;
        public System.Windows.Forms.TextBox tbUserMode;
        public System.Windows.Forms.PictureBox pbZoomedSubImage;
        public System.Windows.Forms.TextBox tbInterpolationMethod;
        public System.Windows.Forms.CheckBox cbForceIntegerScaling;
        public System.Windows.Forms.CheckBox cbUseCustomUpScaling;
        private System.Windows.Forms.Button btnLoadDataPrep;
        public System.Windows.Forms.PictureBox pbOuterView;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbCursorType;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        public System.Windows.Forms.ComboBox cbScopeOutAmount;
        private System.Windows.Forms.GroupBox groupBox9;
        public System.Windows.Forms.TextBox tbSrcFile;
        public System.Windows.Forms.PictureBox pbMain;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbSelectedClbIndex;
        private System.Windows.Forms.TextBox tbCrossThickness;
        public System.Windows.Forms.ComboBox cbLoadImageScale;
    }
}

