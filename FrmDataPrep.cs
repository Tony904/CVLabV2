using System;
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
                tbLoadImageWidth.Text = DataPrep.Src.Width.ToString();
                tbLoadImageHeight.Text = DataPrep.Src.Height.ToString();
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
                string suffix = tbFilenameSuffix.Text;
                string path = DataPrep.SrcPath.FullPathMinusExt + suffix + ".jpg";
                DataPrep.CurrentModifiedImage.Save(path);
                rtbActivity.Text = "Saved image to:\n" + path;
            }
        }

        private void btnNumberFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FilePath folder = new(ofd.FileName);
                string dir = folder.Directory.Remove(folder.Directory.Length - 1);
                string suffix = tbNumberFileSuffix.Text;
                int i = 1;
                foreach (var file in Directory.EnumerateFiles(dir, "*.jpg"))
                {
                    Image<Bgr, byte> img = new(file);
                    FilePath name_test = new(folder.Directory + i.ToString() + suffix + ".jpg");
                    string new_name = name_test.FullPath;
                    if(File.Exists(name_test.FullPath))
                    {
                        new_name = name_test.FullPathMinusExt + "COPY" + ".jpg";
                    }
                    img.Save(new_name);
                    i++;
                }
                rtbActivity.Text = "Enumerated files. Count: " + (i - 1).ToString();
            }
        }

        private void btnChangeClassInTxt_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new();
            ofd.Title = "Select a .txt file.";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                string txt_file = ofd.FileName;
                string all_lines = String.Empty;
                using (StreamReader sr = File.OpenText(txt_file))
                {
                    string s = String.Empty;
                    string new_label = tbClassToChangeTo.Text;
                    while ((s = sr.ReadLine()) != null)
                    {
                        DarknetObj darkobj = new(s);
                        darkobj.Label = new_label;
                        all_lines += darkobj.MakeTxtFileLine();
                    }
                }
                File.WriteAllText(txt_file, all_lines);
                rtbActivity.Text = "Class ID change complete.\n" + txt_file;
            }
        }

        private void btnRotateAnnotations_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FilePath folder = new(ofd.FileName);
                string dir = folder.Directory.Remove(folder.Directory.Length - 1);
                foreach (var file in Directory.EnumerateFiles(dir, "*.jpg"))
                {
                    Image<Bgr, byte> img = new(file);
                    FilePath fp = new(file);
                    string txt = fp.FullPathMinusExt + ".txt";
                    if (File.Exists(txt))
                    {
                        string txt90 = String.Empty;
                        string txt180 = String.Empty;
                        string txt270 = String.Empty;
                        using (StreamReader sr = File.OpenText(txt))
                        {
                            string s;
                            while ((s = sr.ReadLine()) != null)
                            {
                                DarknetObj darkobj = new(s);
                                List<string> rotations = darkobj.GetRotatedBBoxes();
                                txt90 += rotations[0] + "\n";
                                txt180 += rotations[1] + "\n";
                                txt270 += rotations[2] + "\n";
                            }
                        }
                        File.WriteAllText(fp.FullPathMinusExt + "_r90.txt", txt90);
                        File.WriteAllText(fp.FullPathMinusExt + "_r180.txt", txt180);
                        File.WriteAllText(fp.FullPathMinusExt + "_r270.txt", txt270);

                        float size = img.Width; //Assuming square image.
                        PointF center = new(size, size);
                        Image<Bgr, byte> img90 = img.Rotate(90, center, Emgu.CV.CvEnum.Inter.Nearest, Colors.Black, false);
                        Image<Bgr, byte> img180 = img.Rotate(180, center, Emgu.CV.CvEnum.Inter.Nearest, Colors.Black, false);
                        Image<Bgr, byte> img270 = img.Rotate(270, center, Emgu.CV.CvEnum.Inter.Nearest, Colors.Black, false);
                        img90.Save(fp.FullPathMinusExt + "_r90.jpg");
                        img180.Save(fp.FullPathMinusExt + "_r180.jpg");
                        img270.Save(fp.FullPathMinusExt + "_r270.jpg");
                    }
                    
                }
                rtbActivity.Text = "Images and annotations rotated.";
            }
        }

        private void btnCreateTrainAndTestTxt_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FilePath folder = new(ofd.FileName);
                string dir = folder.Directory.Remove(folder.Directory.Length - 1);
                string s = "data/obj/";
                string all_lines = String.Empty;
                foreach (var file in Directory.EnumerateFiles(dir, "*.jpg"))
                {
                    FilePath fp = new(file);
                    all_lines += s + fp.FileNamePlusExt + "\n";
                }
                File.WriteAllText(folder.Directory + "train.txt", all_lines);
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
