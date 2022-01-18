using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace CVLabV2
{
    public static class SrcImage
    {
        /// <summary>
        /// Fields
        /// </summary>
        private static Image<Bgr, byte> _src;
        public static Image<Bgr, byte> Src
        {
            get => _src.Clone();
        }
        private static FilePath _src_path = new(String.Empty);
        public static FilePath SrcPath
        {
            get => _src_path;
        }
        public static List<Annot> Annots = new();

        private static int _next_uid = 0;
        private static int NextAnnotID
        {
            get
            {
                _next_uid++;
                return _next_uid - 1;
            }
        }

        public static int _active_annots_index = -1;
        public static int Active_Annots_Index
        {
            get => _active_annots_index;
            set
            {
                _active_annots_index = value;
                Active_Rect = Annots[value].Rect;
            }
        }
        public static int Active_GrabPnt_Index = -1;
        private static Rectangle _active_rect = new();
        public static Rectangle Active_Rect
        {
            get => _active_rect;
            set
            {
                AnnotationForm.tbActiveRect.Text = CustomToString.RectToString(value);
                _active_rect = value;
            }
        }
        public static Rectangle Last_EditMode_Rect;
        public static Point Cursor_Offset;

        public static Image<Bgr, byte> Image_None;
        public static Image<Bgr, byte> Image_OnlyVisible;
        public static Image<Bgr, byte> Image_OnlyActive;
        public static Image<Bgr, byte> Image_MinusActive;

        public static Image<Bgr, byte> Image_None_Temp;
        public static Image<Bgr, byte> Image_OnlyVisible_Temp;
        public static Image<Bgr, byte> Image_OnlyActive_Temp;
        public static Image<Bgr, byte> Image_MinusActive_Temp;

        public static Emgu.CV.CvEnum.Inter Interp_Method = Emgu.CV.CvEnum.Inter.Nearest;

        public static FrmAnnotation AnnotationForm;
        /// <summary>
        /// Methods
        /// </summary>
        public static void SetSrcImageFromFile()
        {
            try
            {
                OpenFileDialog ofd = new();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string fname = ofd.FileName;
                    _src = new(fname);
                    _src_path = new(fname);
                    InitializeMembers();
                    STATES.InitializeMembers();
                    CheckForExistingTxtFile();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public static void CheckForExistingTxtFile()
        {
            string txt_file = _src_path.FullPathMinusExt + ".txt";
            string s = String.Empty;
            if (File.Exists(txt_file))
            {
                using (StreamReader sr = File.OpenText(txt_file))
                {
                    while ((s = sr.ReadLine()) != null)
                    {
                        DarknetObj darkobj = new(s);
                        Annot annot = new(darkobj, NextAnnotID);
                        Annots.Add(annot);
                    }
                }
                Active_Annots_Index = Annots.Count - 1;
                UpdateClbAnnots();
                AnnotationForm.rtbLastActivity.Text = "Found associated txt file.\nLoaded existing annotations.";
                _UpdateNonTempImages();
                SetZoomedAnnotationImage();
                Last_EditMode_Rect = Active_Rect;
            }
        }
        private static void InitializeMembers()
        {
            Annots = new();
            UpdateClbAnnots();
            _next_uid = 0;
            _active_annots_index = -1;
            Active_GrabPnt_Index = -1;
            Active_Rect = new();
            Cursor_Offset = new(0, 0);
            Interp_Method = Emgu.CV.CvEnum.Inter.Nearest;
            _UpdateNonTempImages();
        }
        public static void SetFrmAnnotationReference(FrmAnnotation form)
        {
            AnnotationForm = form;
        }
        public static void SaveAnnotationsToTxtFile()
        {
            string save_path = _src_path.FullPathMinusExt + ".txt";
            string all_text = "";
            foreach(Annot a in Annots)
            {
                all_text += a.DarkObj.MakeTxtFileLine();
            }
            File.WriteAllText(save_path, all_text);
            AnnotationForm.rtbLastActivity.Text = "Annotations saved to:\n" + save_path;
        }
        public static DarknetObj ConvertRectangleToDarknetFormat(Rectangle rect, string label="-1")
        {
            float x = ((float)rect.X + (float)rect.Width / 2f) / (float)_src.Width;
            float y = ((float)rect.Y + (float)rect.Height / 2f) / (float)_src.Height;
            float w = (float)rect.Width / (float)_src.Width;
            float h = (float)rect.Height / (float)_src.Height;

            DarknetObj outpt = new(x, y, w, h, label);
            return outpt;
        }
        public static void _UpdateNonTempImages()
        {
            Image_None = _src.Clone();
            Image_OnlyVisible = _src.Clone();
            Image_OnlyActive = _src.Clone();
            Image_MinusActive = _src.Clone();

            try
            {
                if (Annots.Count > 0)
                {
                    int aix = Math.Max(0, Active_Annots_Index);
                    Rectangle rect = MyUtils.OffsetRectTopAndLeftForDrawing(Annots[aix].Rect);
                    Image_OnlyActive.Draw(rect, Colors.Red);

                    for (int i = 0; i < Annots.Count; i++)
                    {
                        if (Annots[i].Visible)
                        {
                            rect = MyUtils.OffsetRectTopAndLeftForDrawing(Annots[i].Rect);
                            if (i != aix)
                            {
                                Image_MinusActive.Draw(rect, Colors.Red);
                            }
                            Image_OnlyVisible.Draw(rect, Colors.Red);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
        public static Image<Bgr, byte> GetTempImageWithTempRect(IMAGE_BASE base_type)
        {
            return GetTempImageWithTempRect(base_type, Active_Rect);
        }
        public static Image<Bgr, byte> GetTempImageWithTempRect(IMAGE_BASE base_type, Rectangle temp_rect)
        {
            temp_rect = MyUtils.OffsetRectTopAndLeftForDrawing(temp_rect);
            if(base_type == IMAGE_BASE.ONLY_VISIBLE)
            {
                Image_OnlyVisible_Temp = Image_OnlyVisible.Clone();
                Image_OnlyVisible_Temp.Draw(temp_rect, Colors.Red);
                return Image_OnlyVisible_Temp;
            }
            else if(base_type == IMAGE_BASE.ONLY_ACTIVE)
            {
                Image_OnlyActive_Temp = Image_OnlyActive.Clone();
                Image_OnlyActive_Temp.Draw(temp_rect, Colors.Red);
                return Image_OnlyActive_Temp;
            }
            else if(base_type == IMAGE_BASE.ALL_HIDDEN)
            {
                Image_None_Temp = Image_None.Clone();
                Image_None_Temp.Draw(temp_rect, Colors.Red);
                return Image_None_Temp;
            }
            else if(base_type == IMAGE_BASE.MINUS_ACTIVE)
            {
                Image_MinusActive_Temp = Image_MinusActive.Clone();
                Image_MinusActive_Temp.Draw(temp_rect, Colors.Red);
                return Image_MinusActive_Temp;
            }
            return new Image<Bgr, byte>(100, 100, Colors.Gray);
        }
        public static Rectangle GetCreateModeTempRect(Point cursor)
        {
            Size size = new(cursor.X - Active_Rect.X, cursor.Y - Active_Rect.Y);
            return new(Active_Rect.Location, size);
        }
        public static void AddNewAnnotToAnnotsList(Rectangle rect, string label)
        {
            Annot annot = new(rect, NextAnnotID, label);
            Annots.Add(annot);
            Active_Annots_Index = Annots.Count - 1;
            AnnotationForm.clbAnnots.Items.Add(annot.GetClbString(), true);
            AnnotationForm.rtbLastActivity.Text = "Added New Annotation:\n" + annot.GetClbString();
            _UpdateNonTempImages();
            SetZoomedAnnotationImage();
        }
        public static void UpdateActiveAnnotWithActiveRect()
        {
            Active_Rect = MyUtils.FixRectNegatives(Active_Rect);
            Annots[Active_Annots_Index].Rect = Active_Rect;
            Last_EditMode_Rect = Active_Rect;
            _UpdateNonTempImages();
            UpdateClbAnnots();
            SetZoomedAnnotationImage();
            AnnotationForm.rtbLastActivity.Text = "Modified Annotation: " + Active_Annots_Index.ToString();
        }
        private static void UpdateClbAnnots()
        {
            AnnotationForm.clbAnnots.Items.Clear();
            if(Annots.Count > 0)
            {
                foreach (Annot a in Annots)
                {
                    AnnotationForm.clbAnnots.Items.Add(a.GetClbString(), a.Visible);
                }
            }
        }
        public static Image<Bgr, byte> GetBaseImageByOptions()
        {
            if (STATES.MODE == USER_MODE.EDIT)
            {
                if (AnnotationForm.cbEditModeHideOtherAnnots.Checked)
                {
                    return Image_OnlyActive.Clone();
                }
                else
                {
                    return Image_OnlyVisible.Clone();
                }
            }
            else if(STATES.MODE == USER_MODE.CREATE)
            {
                if (AnnotationForm.cbEditModeHideOtherAnnots.Checked)
                {
                    return Image_OnlyActive.Clone();
                }
                else
                {
                    return Image_OnlyVisible.Clone();
                }
            }
            else if(STATES.MODE == USER_MODE.VIEW)
            {
                return Image_OnlyVisible.Clone();
            }
            else
            {
                return new Image<Bgr, byte>(100, 100, Colors.Gray);
            }
        }
        public static bool IsPointInAnyGrabRect(Point p, out int Annot_Index)
        {
            int i = 0;
            foreach(Annot annot in Annots)
            {
                if (annot.Visible)
                {
                    if(p.X > annot.GrabRect.Left)
                    {
                        if(p.X < annot.GrabRect.Right)
                        {
                            if(p.Y > annot.GrabRect.Top)
                            {
                                if(p.Y < annot.GrabRect.Bottom)
                                {
                                    Annot_Index = i;
                                    return true;
                                }
                            }
                        }
                    }
                }
                i++;
            }
            Annot_Index = -1;
            return false;
        }
        public static bool IsPointInActiveGrabRect(Point p)
        {
            Annot a = Annots[Active_Annots_Index];
            if (a.Visible)
            {
                if (p.X > a.GrabRect.Left)
                {
                    if (p.X < a.GrabRect.Right)
                    {
                        if (p.Y > a.GrabRect.Top)
                        {
                            if (p.Y < a.GrabRect.Bottom)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        public static bool IsPointOverGrabPnt(Point p, out int grabp_num)
        {
            Rectangle g1 = Annots[Active_Annots_Index].GrabP(1);
            Rectangle g2 = Annots[Active_Annots_Index].GrabP(2);
            Rectangle g3 = Annots[Active_Annots_Index].GrabP(3);
            Rectangle g4 = Annots[Active_Annots_Index].GrabP(4);
            if (p.X > g1.Left)
            {
                if(p.X < g2.Right)
                {
                    if(p.Y > g1.Top)
                    {
                        if(p.Y < g3.Bottom)
                        {
                            if(p.X < g1.Right)
                            {
                                //maybe g1 or g3
                                if(p.Y < g1.Bottom)
                                {
                                    //is g1
                                    grabp_num = 1;
                                    return true;
                                }
                                else if(p.Y > g3.Top)
                                {
                                    //is g3
                                    grabp_num = 3;
                                    return true;
                                }
                                else
                                {
                                    //none
                                }
                            }
                            else if(p.X > g2.Left)
                            {
                                //maybe g2 or g4
                                if(p.Y < g2.Bottom)
                                {
                                    //is g2
                                    grabp_num = 2;
                                    return true;
                                }
                                else if(p.Y > g4.Top)
                                {
                                    //is g4
                                    grabp_num = 4;
                                    return true;
                                }
                                else
                                {
                                    //none
                                }
                            }
                            else
                            {
                                //none
                            }
                        }
                    }
                }
            }
            grabp_num = 0;
            return false;
        }
        public static Image<Bgr, byte> GetHighlightedGrabPntImage()
        {
            if (AnnotationForm.cbEditModeHideOtherAnnots.Checked)
            {
                Image<Bgr, byte> img = Image_OnlyActive.Clone();
                img.Draw(Annots[Active_Annots_Index].GrabP(Active_GrabPnt_Index), Colors.Blue, -1);
                return img;
            }
            else
            {
                Image<Bgr, byte> img = Image_OnlyVisible.Clone();
                img.Draw(Annots[Active_Annots_Index].GrabP(Active_GrabPnt_Index), Colors.Blue, -1);
                return img;
            }
        }
        public static void _AdjustActiveRectByGrabPnt(out Cursor cursor_type)
        {
            Rectangle rect = Active_Rect;
            int g = Active_GrabPnt_Index;
            if(g == 2)
            {
                rect.X += rect.Width;
                rect.Width *= -1;
                cursor_type = Cursors.PanNE;
            }
            else if(g == 3)
            {
                rect.Y += rect.Height;
                rect.Height *= -1;
                cursor_type = Cursors.PanSW;
            }
            else if(g == 4)
            {
                rect.X += rect.Width;
                rect.Width *= -1;
                rect.Y += rect.Height;
                rect.Height *= -1;
                cursor_type = Cursors.PanSE;
            }
            else //g == 1
            {
                cursor_type = Cursors.PanNW;
            }
            Active_Rect = rect;
        }
        public static Image<Bgr, byte> GetTempImageWithScaledRect(Point cursor, IMAGE_BASE img_base)
        {
            Point p = new(cursor.X - Cursor_Offset.X, cursor.Y - Cursor_Offset.Y);
            Size s = new(Active_Rect.Width + (Active_Rect.X - p.X), Active_Rect.Height + (Active_Rect.Y - p.Y));
            Rectangle temp_rect = new(p, s);
            Active_Rect = temp_rect;

            return GetTempImageWithTempRect(img_base, temp_rect);
        }
        public static Image<Bgr, byte> GetHighlightedAnnotImage(int index)
        {
            Image<Bgr, byte> img = Image_OnlyVisible.Clone();
            img.Draw(Annots[index].Rect, Colors.Blue, 2);
            return img;
        }
        public static Image<Bgr, byte> GetImageByEnum(IMAGE_BASE img_base)
        {
            if(img_base == IMAGE_BASE.ONLY_ACTIVE)
            {
                return Image_OnlyActive.Clone();
            }
            else if(img_base == IMAGE_BASE.ONLY_VISIBLE)
            {
                return Image_OnlyVisible.Clone();
            }
            else if(img_base == IMAGE_BASE.ALL_HIDDEN)
            {
                return Image_None.Clone();
            }
            else if(img_base == IMAGE_BASE.MINUS_ACTIVE)
            {
                return Image_MinusActive.Clone();
            }
            else
            {
                Image<Bgr, byte> error_img = new(100, 100, Colors.Gray);
                error_img.Draw("ERROR", new Point(0, 50), Emgu.CV.CvEnum.FontFace.HersheyPlain, 20d, Colors.Red);
                return error_img;
            }
        }
        public static void DeleteActiveAnnot()
        {
            Annots.RemoveAt(Active_Annots_Index);
            AnnotationForm.rtbLastActivity.Text = "Annotation deleted: " + Active_Annots_Index.ToString();
            Active_Annots_Index = 0;
            UpdateClbAnnots();
            _UpdateNonTempImages();
        }
        public static void SetZoomedAnnotationImage()
        {
            int w = AnnotationForm.pbZoomedSubImage.Width;
            int h = AnnotationForm.pbZoomedSubImage.Height;
            AnnotationForm.pbZoomedSubImage.Image = GetZoomedSubImage(w, h).ToBitmap();
            w = AnnotationForm.pbOuterView.Width;
            h = AnnotationForm.pbOuterView.Height;
            AnnotationForm.pbOuterView.Image = GetOuterSubImage(w, h).ToBitmap();
        }
        private static Image<Bgr, byte> GetZoomedSubImage(int pictureBox_width, int pictureBox_height)
        {
            Rectangle rect = Active_Rect;
            Image<Bgr, byte> img = Image_None.Clone();
            Image<Bgr, byte> sub_img = img.GetSubRect(rect);
            double wscale = (double)pictureBox_width / (double)sub_img.Width;
            double hscale = (double)pictureBox_height / (double)sub_img.Height;
            double scale = Math.Min(wscale, hscale);
            if(AnnotationForm.cbUseCustomUpScaling.Checked)
            {
                AnnotationForm.tbInterpolationMethod.Text = "Custom: Strictly pixel copying.";
                Image<Bgr, byte> dst;
                MyUtils.CustomImageUpScale(sub_img, (int)scale, out dst);
                return dst.Clone();
            }
            if (AnnotationForm.cbForceIntegerScaling.Checked)
            {
                scale = (double)((int)scale);
            }
            AnnotationForm.tbInterpolationMethod.Text = Interp_Method.ToString();
            Image<Bgr, byte> zimg = sub_img.Resize(scale, Interp_Method);
            return zimg;
        }
        private static Image<Bgr, byte> GetOuterSubImage(int pb_width, int pb_height)
        {
            Rectangle ar = Active_Rect;
            int i = GetScopedOutSubImageValue();
            int x = ar.X - ar.Width / i;
            x = Math.Max(0, x);
            int y = ar.Y - ar.Height / i;
            y = Math.Max(0, y);
            int w = ar.Width + (ar.Width / i) * 2;
            int h = ar.Height + (ar.Height / i) * 2;
            if(x + w > Src.Width)
            {
                int d = x + w - Src.Width;
                w -= d;
            }
            if(y + h > Src.Height)
            {
                int d = y + h - Src.Height;
                h -= d;
            }
            Rectangle rect = new(x, y, w, h);
            Image<Bgr, byte> img = Image_None.Clone();
            Image<Bgr, byte> sub_img = img.GetSubRect(rect);
            double wscale = (double)pb_width / (double)sub_img.Width;
            double hscale = (double)pb_height / (double)sub_img.Height;
            double scale = Math.Min(wscale, hscale);
            rect.X = ar.X - rect.X;
            rect.Y = ar.Y - rect.Y;
            rect.Width = ar.Width;
            rect.Height = ar.Height;
            if (AnnotationForm.cbUseCustomUpScaling.Checked)
            {
                Image<Bgr, byte> dst;
                MyUtils.CustomImageUpScale(sub_img, (int)scale, out dst);
                int iscale = (int)scale;
                rect.X *= iscale;
                rect.Y *= iscale;
                rect.Width *= iscale;
                rect.Height *= iscale;
                dst.Draw(rect, Colors.Red);
                return dst.Clone();
            }
            else if (AnnotationForm.cbForceIntegerScaling.Checked)
            {
                scale = (double)((int)scale);
                Image<Bgr, byte> dst = sub_img.Resize(scale, Interp_Method);
                int iscale = (int)scale;
                rect.X *= iscale;
                rect.Y *= iscale;
                rect.Width *= iscale;
                rect.Height *= iscale;
                dst.Draw(rect, Colors.Red);
                return dst.Clone();
            }
            Image<Bgr, byte> rimg = sub_img.Resize(scale, Interp_Method);
            return rimg;
        }
        private static int GetScopedOutSubImageValue()
        {
            string s = AnnotationForm.cbScopeOutAmount.Text;
            if(s == "2x")
            {
                return 2;
            }
            else if (s == "3x")
            {
                return 1;
            }
            return 2;
        }
        public static void NextInterpMethod()
        {
            Emgu.CV.CvEnum.Inter t = Interp_Method;
            if (t == Emgu.CV.CvEnum.Inter.Nearest)
            {
                Interp_Method = Emgu.CV.CvEnum.Inter.Linear;
            }
            else if(t == Emgu.CV.CvEnum.Inter.Linear)
            {
                Interp_Method = Emgu.CV.CvEnum.Inter.Cubic;
            }
            else if(t == Emgu.CV.CvEnum.Inter.Cubic)
            {
                Interp_Method = Emgu.CV.CvEnum.Inter.Lanczos4;
            }
            else if(t == Emgu.CV.CvEnum.Inter.Lanczos4)
            {
                Interp_Method = Emgu.CV.CvEnum.Inter.Area;
            }
            else if(t == Emgu.CV.CvEnum.Inter.Area)
            {
                Interp_Method = Emgu.CV.CvEnum.Inter.Nearest;
            }
            SetZoomedAnnotationImage();
        }
    }

    public class Annot
    {
        private Rectangle _cvlab_bbox;
        public Rectangle Rect
        {
            get => _cvlab_bbox;
            set
            {
                _cvlab_bbox = value;
                _SetGrabRect();
                _SetGrabPts();
                _UpdateDarkObjFrom_cvlab_bbox();
            }
        }
        private Rectangle _grab_rect;
        public Rectangle GrabRect { get => _grab_rect; }
        private Rectangle _grab_p1; //top-left
        private Rectangle _grab_p2; //top-right
        private Rectangle _grab_p3; //bottom-left
        private Rectangle _grab_p4; //bottom-right
        public Rectangle GrabP(int i)
        {
            if(i == 1) { return _grab_p1; }
            else if(i == 2) { return _grab_p2; }
            else if(i == 3) { return _grab_p3; }
            else if(i == 4) { return _grab_p4; }
            else { return new Rectangle(); }
        }

        public DarknetObj DarkObj;

        private readonly int _uid;
        public int ID
        {
            get => _uid;
        }

        public bool Visible = true;

        public Annot(Rectangle CVLab_rect, int unique_id, string label)
        {
            Rectangle rect = MyUtils.FixRectNegatives(CVLab_rect);
            DarkObj = SrcImage.ConvertRectangleToDarknetFormat(rect, label);
            _cvlab_bbox = rect;
            _uid = unique_id;
            _SetGrabRect();
            _SetGrabPts();
        }
        public Annot(DarknetObj darkobj, int unique_id)
        {
            DarkObj = darkobj;
            _SetCVLabRectFromDarkObj();
            _uid = unique_id;
            _SetGrabRect();
            _SetGrabPts();
        }
        private void _UpdateDarkObjFrom_cvlab_bbox()
        {
            string label = DarkObj.Label;
            DarkObj = SrcImage.ConvertRectangleToDarknetFormat(_cvlab_bbox, label);
        }
        private void _SetCVLabRectFromDarkObj()
        {
            float srcw = (float)SrcImage.Src.Width;
            float srch = (float)SrcImage.Src.Height;
            int x = (int)((DarkObj.X - (DarkObj.W / 2f)) * srcw);
            int y = (int)((DarkObj.Y - (DarkObj.H / 2f)) * srch);
            int w = (int)(DarkObj.W * srcw);
            int h = (int)(DarkObj.H * srch);
            Rectangle rect = new(x, y, w, h);
            _cvlab_bbox = rect;
        }
        private void _SetGrabRect()
        {
            int grab_x = _cvlab_bbox.X + _cvlab_bbox.Width / 4;
            int grab_y = _cvlab_bbox.Y + _cvlab_bbox.Height / 4;
            int grab_w = _cvlab_bbox.Width / 2;
            int grab_h = _cvlab_bbox.Height / 2;
            _grab_rect = new(grab_x, grab_y, grab_w, grab_h);
        }
        private void _SetGrabPts()
        {
            int size = 12;
            int s = size / 2;
            _grab_p1 = new(_cvlab_bbox.X - s, _cvlab_bbox.Y - s, size, size);
            _grab_p2 = new(_cvlab_bbox.Right - s, _cvlab_bbox.Y - s, size, size);
            _grab_p3 = new(_cvlab_bbox.X - s, _cvlab_bbox.Bottom - s, size, size);
            _grab_p4 = new(_cvlab_bbox.Right - s, _cvlab_bbox.Bottom - s, size, size);
        }
        public string GetClbString()
        {
            return CustomToString.RectToString(Rect) + " Lbl: " + DarkObj.Label + " ID: " + ID.ToString();
        }
    }
    public class DarknetObj
    {
        public float X;
        public float Y;
        public float W;
        public float H;
        public string Label;

        public DarknetObj(float center_x, float center_y, float bbox_width, float bbox_height, string label)
        {
            X = center_x;
            Y = center_y;
            W = bbox_width;
            H = bbox_height;
            Label = label;
        }
        public DarknetObj(string darknet_bbox_line)
        {
            string s = darknet_bbox_line;
            string[] split = s.Split(' ');
            Label = split[0];
            X = float.Parse(split[1]);
            Y = float.Parse(split[2]);
            W = float.Parse(split[3]);
            H = float.Parse(split[4]);
        }
        public string MakeTxtFileLine()
        {
            string line = Label + " " + X.ToString() + " " + Y.ToString() + " " + W.ToString() + " " + H.ToString() + "\n";
            return line;
        }
    }

    static class STATES
    {
        private static USER_MODE _mode;
        public static USER_MODE MODE
        {
            get => _mode;
            set
            {
                _mode = value;
                SrcImage.AnnotationForm.tbUserMode.Text = value.ToString();
                if(value == USER_MODE.EDIT)
                {
                    SrcImage.AnnotationForm.tbUserMode.BackColor = Color.LightBlue;
                }
                else
                {
                    SrcImage.AnnotationForm.tbUserMode.BackColor = Color.White;
                }
            }
        }
        private static CURSOR_ACTIVITY _cursor;
        public static CURSOR_ACTIVITY CURSOR
        {
            get => _cursor;
            set
            {
                _cursor = value;
                SrcImage.AnnotationForm.tbState.Text = value.ToString();
            }
        }

        public static void InitializeMembers()
        {
            MODE = USER_MODE.VIEW;
            CURSOR = CURSOR_ACTIVITY.NONE;
        }
    }

    public enum USER_MODE
    {
        VIEW,
        CREATE,
        EDIT
    }
    public enum CURSOR_ACTIVITY
    {
        NONE,
        HOVERING_OVER_GRAB_RECT,
        HOVERING_OVER_GRAB_PNT,
        HOVERING_OVER_GRAB_P1,
        HOVERING_OVER_GRAB_P2,
        HOVERING_OVER_GRAB_P3,
        HOVERING_OVER_GRAB_P4,
        SCALING_BY_GRAB_PNT,
        DRAGGING_BY_GRAB_RECT,
        DRAWING_NEW_RECT
    }
    public enum IMAGE_BASE
    {
        ALL_HIDDEN, //All Annots are hidden
        ONLY_ACTIVE, //All Annots are hidden except Active
        ONLY_VISIBLE, //Only show Annots with Visible==True, including Active
        MINUS_ACTIVE, //All Annots with Visible==True are shown, except for Active
        NO_CHANGE
    }
}
