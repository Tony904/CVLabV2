﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using System.IO;

namespace CVLabV2
{
    public partial class FrmDataPrep : Form
    {
        public FrmDataPrep()
        {
            InitializeComponent();
        }
        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                DataPrep.Src = new(ofd.FileName);
                DataPrep.SrcPath = new(ofd.FileName);
                pbModifyImage.Image = DataPrep.Src.ToBitmap();
                rtbActivity.Text = "File Loaded.\n" + DataPrep.SrcPath.FullPath;
            }
        }
        private void btnModifyImages_Click(object sender, EventArgs e)
        {
            Image<Bgr, byte> src = DataPrep.Src.Clone();
            Image<Bgr, byte> dst;
            if (cbCropToSquare.Checked)
            {
                DataPrep.CropImageToSquare(src, out dst);
            }
            else
            {
                dst = src.Clone();
            }
            int new_w = Int32.Parse(tbDstImageWidth.Text);
            int new_h = Int32.Parse(tbDstImageHeight.Text);

            dst = dst.Resize(new_w, new_h, DataPrep.Interp_Method);
            DataPrep.CurrentModifiedImage = dst.Clone();
            pbModifyImage.Image = dst.ToBitmap();
            tbDisplayedImageWidth.Text = dst.Width.ToString();
            tbDisplayedImageHeight.Text = dst.Height.ToString();
        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            if (DataPrep.SrcPath.FullPath.Any())
            {
                DataPrep.CurrentModifiedImage.Save(DataPrep.SrcPath.FullPathMinusExt + "MODIFIED.jpg");
            }
        }
    }
    public static class DataPrep
    {
        public static Image<Bgr, byte> _src;
        public static Image<Bgr, byte> Src
        {
            get => _src.Clone();
            set
            {
                _src = value.Clone();
            }
        }
        public static FilePath SrcPath;

        public static Image<Bgr, byte> CurrentModifiedImage;

        public static Emgu.CV.CvEnum.Inter Interp_Method = Emgu.CV.CvEnum.Inter.Linear;

        public static void CropImageToSquare(Image<Bgr, byte> src, out Image<Bgr, byte> dst)
        {
            src = src.Clone();
            int w = src.Width;
            int h = src.Height;
            if (w != h)
            {
                Rectangle rect = new();
                if (w > h)
                {
                    int d = (w - h) / 2;
                    rect.X = d;
                    rect.Y = 0;
                    rect.Width = h;
                    rect.Height = h;
                }
                else
                {
                    int d = (h - w) / 2;
                    rect.X = d;
                    rect.Y = 0;
                    rect.Width = w;
                    rect.Height = w;
                }
                dst = src.GetSubRect(rect).Clone();
            }
            else
            {
                dst = src.Clone();
            }
        }
    }
}