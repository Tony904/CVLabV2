using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CVLabV2
{
    public partial class FrmAnnotation : Form
    {
        public FrmAnnotation()
        {
            InitializeComponent();
        }
        private void FrmAnnotation_Load(object sender, EventArgs e)
        {
            rtbLastActivity.Text = "Form Loaded";
            tbUserMode.Text = STATES.MODE.ToString();
            tbState.Text = STATES.CURSOR.ToString();
            SrcImage.SetFrmAnnotationReference(this);
            tbInterpolationMethod.Text = SrcImage.Interp_Method.ToString();
            pbMain.Cursor = GetCursorTypeFromComboBox();
            panel1.Focus();
        }
        private void btnLoadImageSrc_Click(object sender, EventArgs e)
        {
            SrcImage.SetSrcImageFromFile();
            if (SrcImage.SrcPath.FullPath != String.Empty)
            {
                tbSrcFile.Text = SrcImage.SrcPath.FullPath;
                pbMain.Enabled = true;
                pbMain.Cursor = GetCursorTypeFromComboBox();
                pbMain.Image = SrcImage.Src.ToBitmap();
            }
            
        }
        private void pbMain_MouseClick(object sender, MouseEventArgs e)
        {
            Point cursor = pbMain.PointToClient(Cursor.Position);
            tbCursorPosition.Text = cursor.ToString();

            if (STATES.MODE == USER_MODE.VIEW)
            {
                if (e.Button == MouseButtons.Left)
                {
                    STATES.MODE = USER_MODE.CREATE;
                    STATES.CURSOR = CURSOR_ACTIVITY.DRAWING_NEW_RECT;
                    SrcImage.Active_Rect = new(cursor, new Size(1, 1));
                    if (cbEditModeHideOtherAnnots.Checked)
                    {
                        pbMain.Image = SrcImage.GetTempImageWithTempRect(IMAGE_BASE.ONLY_ACTIVE).ToBitmap();
                    }
                    else
                    {
                        pbMain.Image = SrcImage.GetTempImageWithTempRect(IMAGE_BASE.ONLY_VISIBLE).ToBitmap();
                    }
                }
                else if (e.Button == MouseButtons.Right)
                {
                    if (STATES.CURSOR == CURSOR_ACTIVITY.HOVERING_OVER_GRAB_RECT)
                    {
                        STATES.MODE = USER_MODE.EDIT;
                        STATES.CURSOR = CURSOR_ACTIVITY.NONE;
                        SrcImage.SetZoomedAnnotationImage();
                        SrcImage._UpdateNonTempImages();
                        if (cbEditModeHideOtherAnnots.Checked)
                        {
                            pbMain.Image = SrcImage.Image_OnlyActive.ToBitmap();
                        }
                        else
                        {
                            pbMain.Image = SrcImage.Image_OnlyVisible.ToBitmap();
                        }
                    }
                }
            }
            else if (STATES.MODE == USER_MODE.CREATE)
            {
                if (e.Button == MouseButtons.Left)
                {
                    STATES.MODE = USER_MODE.EDIT;
                    STATES.CURSOR = CURSOR_ACTIVITY.NONE;
                    Rectangle new_rect = SrcImage.GetCreateModeTempRect(cursor);
                    SrcImage.AddNewAnnotToAnnotsList(new_rect, tbAnnotLabel.Text);
                    if (cbEditModeHideOtherAnnots.Checked)
                    {
                        pbMain.Image = SrcImage.Image_OnlyActive.ToBitmap();
                    }
                    else
                    {
                        pbMain.Image = SrcImage.Image_OnlyVisible.ToBitmap();
                    }
                }
            }
            else if (STATES.MODE == USER_MODE.EDIT)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (STATES.CURSOR == CURSOR_ACTIVITY.HOVERING_OVER_GRAB_RECT)
                    {
                        STATES.CURSOR = CURSOR_ACTIVITY.DRAGGING_BY_GRAB_RECT;
                        Rectangle rect = SrcImage.Active_Rect;
                        SrcImage.Cursor_Offset = new(cursor.X - rect.X, cursor.Y - rect.Y);
                    }
                    else if (STATES.CURSOR == CURSOR_ACTIVITY.DRAGGING_BY_GRAB_RECT)
                    {
                        STATES.CURSOR = CURSOR_ACTIVITY.NONE;
                        pbMain.Cursor = GetCursorTypeFromComboBox();
                        Point temp_pnt = new(cursor.X - SrcImage.Cursor_Offset.X, cursor.Y - SrcImage.Cursor_Offset.Y);
                        Size temp_size = new(SrcImage.Active_Rect.Width, SrcImage.Active_Rect.Height);
                        SrcImage.Active_Rect = new(temp_pnt, temp_size);
                        SrcImage.UpdateActiveAnnotWithActiveRect();
                        if (cbEditModeHideOtherAnnots.Checked)
                        {
                            pbMain.Image = SrcImage.GetTempImageWithTempRect(IMAGE_BASE.ONLY_ACTIVE).ToBitmap();
                        }
                        else
                        {
                            pbMain.Image = SrcImage.GetTempImageWithTempRect(IMAGE_BASE.ONLY_VISIBLE).ToBitmap();
                        }
                    }
                    else if (STATES.CURSOR == CURSOR_ACTIVITY.HOVERING_OVER_GRAB_PNT)
                    {
                        STATES.CURSOR = CURSOR_ACTIVITY.SCALING_BY_GRAB_PNT;
                        SrcImage._AdjustActiveRectByGrabPnt(out Cursor cursor_type);
                        pbMain.Cursor = cursor_type;
                        Rectangle rect = SrcImage.Active_Rect;
                        SrcImage.Cursor_Offset = new(cursor.X - rect.X, cursor.Y - rect.Y);
                    }
                    else if (STATES.CURSOR == CURSOR_ACTIVITY.SCALING_BY_GRAB_PNT)
                    {
                        STATES.CURSOR = CURSOR_ACTIVITY.NONE;
                        pbMain.Cursor = GetCursorTypeFromComboBox();
                        if (cbEditModeHideOtherAnnots.Checked)
                        {
                            pbMain.Image = SrcImage.GetTempImageWithScaledRect(cursor, IMAGE_BASE.ALL_HIDDEN).ToBitmap();
                        }
                        else
                        {
                            pbMain.Image = SrcImage.GetTempImageWithScaledRect(cursor, IMAGE_BASE.MINUS_ACTIVE).ToBitmap();
                        }
                        SrcImage.UpdateActiveAnnotWithActiveRect();
                    }
                }
                else if (e.Button == MouseButtons.Right)
                {
                    if (STATES.CURSOR == CURSOR_ACTIVITY.NONE)
                    {
                        STATES.MODE = USER_MODE.VIEW;
                        pbMain.Image = SrcImage.Image_OnlyVisible.ToBitmap();
                        DrawAnnotsAsCrossesIfChecked();
                    }
                }

            }
        }

        private void pbMain_MouseMove(object sender, MouseEventArgs e)
        {
            Point cursor = pbMain.PointToClient(Cursor.Position);
            tbCursorPosition.Text = cursor.ToString();
            IMAGE_BASE default_img = IMAGE_BASE.NO_CHANGE;

            if (STATES.MODE == USER_MODE.CREATE)
            {
                if (STATES.CURSOR == CURSOR_ACTIVITY.DRAWING_NEW_RECT)
                {
                    Rectangle temp_rect = SrcImage.GetCreateModeTempRect(cursor);
                    SrcImage.Active_Rect = temp_rect;
                    if (cbEditModeHideOtherAnnots.Checked)
                    {
                        pbMain.Image = SrcImage.GetTempImageWithTempRect(IMAGE_BASE.ALL_HIDDEN, temp_rect).ToBitmap();
                    }
                    else
                    {
                        pbMain.Image = SrcImage.GetTempImageWithTempRect(IMAGE_BASE.ONLY_VISIBLE, temp_rect).ToBitmap();
                    }
                }
            }
            else if (STATES.MODE == USER_MODE.VIEW)
            {
                int index;
                if (SrcImage.IsPointInAnyGrabRect(cursor, out index))
                {
                    STATES.CURSOR = CURSOR_ACTIVITY.HOVERING_OVER_GRAB_RECT;
                    SrcImage.Active_Annots_Index = index;
                    pbMain.Image = SrcImage.GetHighlightedAnnotImage(index).ToBitmap();
                }
                else
                {
                    STATES.CURSOR = CURSOR_ACTIVITY.NONE;
                    default_img = IMAGE_BASE.ONLY_VISIBLE;
                }
            }
            else if (STATES.MODE == USER_MODE.EDIT)
            {
                if (STATES.CURSOR == CURSOR_ACTIVITY.DRAGGING_BY_GRAB_RECT)
                {
                    Point temp_pnt = new(cursor.X - SrcImage.Cursor_Offset.X, cursor.Y - SrcImage.Cursor_Offset.Y);
                    Size temp_size = new(SrcImage.Active_Rect.Width, SrcImage.Active_Rect.Height);
                    SrcImage.Active_Rect = new(temp_pnt, temp_size);
                    if (cbEditModeHideOtherAnnots.Checked)
                    {
                        pbMain.Image = SrcImage.GetTempImageWithTempRect(IMAGE_BASE.ALL_HIDDEN).ToBitmap();
                    }
                    else
                    {
                        pbMain.Image = SrcImage.GetTempImageWithTempRect(IMAGE_BASE.MINUS_ACTIVE).ToBitmap();
                    }
                }
                else if (STATES.CURSOR == CURSOR_ACTIVITY.SCALING_BY_GRAB_PNT)
                {
                    if (cbEditModeHideOtherAnnots.Checked)
                    {
                        pbMain.Image = SrcImage.GetTempImageWithScaledRect(cursor, IMAGE_BASE.ALL_HIDDEN).ToBitmap();
                    }
                    else
                    {
                        pbMain.Image = SrcImage.GetTempImageWithScaledRect(cursor, IMAGE_BASE.MINUS_ACTIVE).ToBitmap();
                    }
                    pbMain.Cursor = GetScalingCursorByTopLeftPosition(SrcImage.Active_Rect);
                }
                else if (SrcImage.IsPointOverGrabPnt(cursor, out int grabp))
                {
                    STATES.CURSOR = CURSOR_ACTIVITY.HOVERING_OVER_GRAB_PNT;
                    SrcImage.Active_GrabPnt_Index = grabp;
                    pbMain.Image = SrcImage.GetHighlightedGrabPntImage().ToBitmap();
                }
                else if (SrcImage.IsPointInActiveGrabRect(cursor))
                {
                    STATES.CURSOR = CURSOR_ACTIVITY.HOVERING_OVER_GRAB_RECT;
                    pbMain.Cursor = Cursors.SizeAll;
                }
                else
                {
                    STATES.CURSOR = CURSOR_ACTIVITY.NONE;
                    pbMain.Cursor = GetCursorTypeFromComboBox();
                    if (cbEditModeHideOtherAnnots.Checked)
                    {
                        default_img = IMAGE_BASE.ONLY_ACTIVE;
                    }
                    else
                    {
                        default_img = IMAGE_BASE.ONLY_VISIBLE;
                    }
                }
            }
            //Default image for pbMain if not changed.
            if (default_img != IMAGE_BASE.NO_CHANGE)
            {
                pbMain.Image = SrcImage.GetImageByEnum(default_img).ToBitmap();
                DrawAnnotsAsCrossesIfChecked();
            }
        }

        private void FrmAnnotation_KeyUp(object sender, KeyEventArgs e)
        {
            Point cursor = pbMain.PointToClient(Cursor.Position);
            if (e.KeyCode == Keys.G)
            {
                if (NotDrawingRectangle())
                {
                    Rectangle ar = SrcImage.Last_EditMode_Rect;
                    int x = Math.Max(0, cursor.X - ar.Width / 2);
                    int y = Math.Max(0, cursor.Y - ar.Height / 2);
                    Rectangle dupe_rect = new(new Point(x, y), ar.Size);
                    SrcImage.AddNewAnnotToAnnotsList(dupe_rect, tbAnnotLabel.Text);
                    if (cbEditModeHideOtherAnnots.Checked)
                    {
                        pbMain.Image = SrcImage.GetTempImageWithTempRect(IMAGE_BASE.ONLY_ACTIVE).ToBitmap();
                    }
                    else
                    {
                        pbMain.Image = SrcImage.GetTempImageWithTempRect(IMAGE_BASE.ONLY_VISIBLE).ToBitmap();
                    }
                    STATES.MODE = USER_MODE.EDIT;
                }
            }
            else if (STATES.MODE == USER_MODE.VIEW)
            {
                if (STATES.CURSOR == CURSOR_ACTIVITY.HOVERING_OVER_GRAB_RECT)
                {
                    if (e.KeyCode == Keys.Delete)
                    {
                        SrcImage.DeleteActiveAnnot();
                        pbMain.Image = SrcImage.Image_OnlyVisible.ToBitmap();
                    }
                }
            }
            else if (STATES.MODE == USER_MODE.EDIT)
            {
                if (STATES.CURSOR != CURSOR_ACTIVITY.SCALING_BY_GRAB_PNT)
                {
                    if (STATES.CURSOR != CURSOR_ACTIVITY.DRAGGING_BY_GRAB_RECT)
                    {
                        int[] nudge; //left,top,right,bottom
                        if (KeyIsQWERorASDF(e.KeyCode, out nudge))
                        {
                            SrcImage.Active_Rect = NudgeRectangle(SrcImage.Active_Rect, nudge);
                            SrcImage.UpdateActiveAnnotWithActiveRect();
                            pbMain.Image = SrcImage.GetBaseImageByOptions().ToBitmap();
                        }
                        else if (e.KeyCode == Keys.T)
                        {
                            SrcImage.NextInterpMethod();
                        }
                    }
                }
            }
        }
        private bool NotDrawingRectangle()
        {
            if (STATES.CURSOR != CURSOR_ACTIVITY.DRAWING_NEW_RECT)
            {
                if (STATES.CURSOR != CURSOR_ACTIVITY.SCALING_BY_GRAB_PNT)
                {
                    if (STATES.CURSOR != CURSOR_ACTIVITY.DRAGGING_BY_GRAB_RECT)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private Rectangle NudgeRectangle(Rectangle rect, int[] nudge)
        {
            if (nudge[0] != 0) //left
            {
                rect.X -= nudge[0];
                rect.Width += nudge[0];
            }
            else if (nudge[1] != 0) //top
            {
                rect.Y -= nudge[1];
                rect.Height += nudge[1];
            }
            else if (nudge[2] != 0)
            {
                rect.Width += nudge[2];
            }
            else if (nudge[3] != 0)
            {
                rect.Height += nudge[3];
            }
            return rect;
        }
        private bool KeyIsQWERorASDF(Keys e, out int[] nudge)
        {
            nudge = new int[] { 0, 0, 0, 0 };
            bool b = true;
            switch (e)
            {
                case Keys.Q: //expand left
                    nudge[0] = 1;
                    break;

                case Keys.W: //expand top
                    nudge[1] = 1;
                    break;

                case Keys.E: //expand right
                    nudge[2] = 1;
                    break;

                case Keys.R: //expand bottom
                    nudge[3] = 1;
                    break;

                case Keys.A: //retract left
                    nudge[0] = -1;
                    break;

                case Keys.S: //retract top
                    nudge[1] = -1;
                    break;

                case Keys.D: //retract right
                    nudge[2] = -1;
                    break;

                case Keys.F: //retract bottom
                    nudge[3] = -1;
                    break;

                default:
                    b = false;
                    break;
            }
            return b;
        }

        private Cursor GetScalingCursorByTopLeftPosition(Rectangle rect)
        {
            Cursor c;
            if (rect.Width > 0)
            {
                if (rect.Height > 0)
                {
                    //Top-left
                    c = Cursors.PanNW;
                }
                else
                {
                    //Bottom-left
                    c = Cursors.PanSW;
                }
            }
            else
            {
                if (rect.Height > 0)
                {
                    //Top-right
                    c = Cursors.PanNE;
                }
                else
                {
                    //Bottom-right
                    c = Cursors.PanSE;
                }
            }
            return c;
        }
        private void FrmAnnotation_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnSaveAnnotsToTxtFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (SrcImage.Annots.Count > 0)
                {
                    SrcImage.SaveAnnotationsToTxtFile();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void GenerateSpecialTestImage()
        {
            Image<Bgr, byte> img = new(117, 117, new Bgr(255, 255, 255));
            img.Data[9, 9, 0] = (byte)255;
            img.Data[9, 9, 1] = (byte)0;
            img.Data[9, 9, 2] = (byte)0;

            img.Data[10, 10, 0] = (byte)0;
            img.Data[10, 10, 1] = (byte)255;
            img.Data[10, 10, 2] = (byte)0;

            img.Data[11, 11, 0] = (byte)0;
            img.Data[11, 11, 1] = (byte)0;
            img.Data[11, 11, 2] = (byte)255;

            img.Data[12, 12, 0] = (byte)0;
            img.Data[12, 12, 1] = (byte)0;
            img.Data[12, 12, 2] = (byte)0;

            img.Data[13, 13, 0] = (byte)255;
            img.Data[13, 13, 1] = (byte)0;
            img.Data[13, 13, 2] = (byte)0;

            img.Data[14, 14, 0] = (byte)0;
            img.Data[14, 14, 1] = (byte)255;
            img.Data[14, 14, 2] = (byte)0;

            img.Data[15, 15, 0] = (byte)0;
            img.Data[15, 15, 1] = (byte)0;
            img.Data[15, 15, 2] = (byte)255;

            img.Data[16, 16, 0] = (byte)255;
            img.Data[16, 16, 1] = (byte)0;
            img.Data[16, 16, 2] = (byte)0;

            img.Data[17, 17, 0] = (byte)0;
            img.Data[17, 17, 1] = (byte)255;
            img.Data[17, 17, 2] = (byte)0;

            img.Data[18, 18, 0] = (byte)0;
            img.Data[18, 18, 1] = (byte)0;
            img.Data[18, 18, 2] = (byte)255;

            img.Data[19, 19, 0] = (byte)0;
            img.Data[19, 19, 1] = (byte)0;
            img.Data[19, 19, 2] = (byte)0;

            img.Data[20, 20, 0] = (byte)255;
            img.Data[20, 20, 1] = (byte)0;
            img.Data[20, 20, 2] = (byte)0;

            img.Data[21, 21, 0] = (byte)0;
            img.Data[21, 21, 1] = (byte)255;
            img.Data[21, 21, 2] = (byte)0;

            img.Data[9, 10, 0] = (byte)255;
            img.Data[9, 10, 1] = (byte)0;
            img.Data[9, 10, 2] = (byte)0;

            img.Data[9, 11, 0] = (byte)255;
            img.Data[9, 11, 1] = (byte)0;
            img.Data[9, 11, 2] = (byte)0;

            img.Data[9, 12, 0] = (byte)255;
            img.Data[9, 12, 1] = (byte)0;
            img.Data[9, 12, 2] = (byte)0;

            img.Data[9, 13, 0] = (byte)255;
            img.Data[9, 13, 1] = (byte)0;
            img.Data[9, 13, 2] = (byte)0;

            img.Data[9, 14, 0] = (byte)255;
            img.Data[9, 14, 1] = (byte)0;
            img.Data[9, 14, 2] = (byte)0;

            img.Data[9, 15, 0] = (byte)255;
            img.Data[9, 15, 1] = (byte)0;
            img.Data[9, 15, 2] = (byte)0;

            img.Save("C:/Users/EngGroup/Desktop/testimg/testimg.jpg");
        }

        private void btnDrawLastDarknetPrediction_Click(object sender, EventArgs e)
        {
            GenerateSpecialTestImage();
        }

        private void cbForceIntegerScaling_CheckedChanged(object sender, EventArgs e)
        {
            if (SrcImage.Annots.Count > 0)
            {
                SrcImage.SetZoomedAnnotationImage();
            }
            if (cbForceIntegerScaling.Checked)
            {
                cbUseCustomUpScaling.ForeColor = Color.Gray;
                cbUseCustomUpScaling.Enabled = false;
            }
            else
            {
                cbUseCustomUpScaling.ForeColor = Color.Black;
                cbUseCustomUpScaling.Enabled = true;
            }

        }

        private void cbUseCustomUpScaling_CheckedChanged(object sender, EventArgs e)
        {
            if (SrcImage.Annots.Count > 0)
            {
                SrcImage.SetZoomedAnnotationImage();
            }
            if (cbUseCustomUpScaling.Checked)
            {
                cbForceIntegerScaling.ForeColor = Color.Gray;
                cbForceIntegerScaling.Enabled = false;
            }
            else
            {
                cbForceIntegerScaling.ForeColor = Color.Black;
                cbForceIntegerScaling.Enabled = true;
            }
        }
        private void cbShowAnnotsAsCrosses_CheckedChanged(object sender, EventArgs e)
        {
            DrawAnnotsAsCrossesIfChecked();
            if (cbShowAnnotsAsCrosses.Checked == false)
            {
                pbMain.Image = SrcImage.Image_OnlyVisible.ToBitmap();
            }
        }
        private void DrawAnnotsAsCrossesIfChecked()
        {
            if (SrcImage.Annots.Count > 0)
            {
                if (STATES.MODE == USER_MODE.VIEW)
                {
                    if (cbShowAnnotsAsCrosses.Checked)
                    {
                        Image<Bgr, byte> img = SrcImage.Image_None.Clone();
                        foreach (Annot a in SrcImage.Annots)
                        {
                            if (a.Visible)
                            {
                                PointF p;
                                MyUtils.GetRectCenter(a.Rect, out p);
                                float w = (float)a.GrabRect.Width;
                                float h = (float)a.GrabRect.Height;
                                Cross2DF c = new(p, w, h);
                                img.Draw(c, Colors.Red, 1);
                            }
                        }
                        pbMain.Image = img.ToBitmap();
                    }
                }
            }
        }
        private void cbEditModeHideOtherAnnots_CheckedChanged(object sender, EventArgs e)
        {
            if (SrcImage.Annots.Count > 0)
            {
                if (STATES.MODE == USER_MODE.EDIT)
                {
                    if (STATES.CURSOR != CURSOR_ACTIVITY.SCALING_BY_GRAB_PNT)
                    {
                        if (STATES.CURSOR != CURSOR_ACTIVITY.DRAGGING_BY_GRAB_RECT)
                        {
                            if (cbEditModeHideOtherAnnots.Checked)
                            {
                                pbMain.Image = SrcImage.Image_OnlyActive.ToBitmap();
                            }
                            else
                            {
                                pbMain.Image = SrcImage.Image_OnlyVisible.ToBitmap();
                            }
                        }
                    }
                }
            }
        }
        private void tbSetAllAnnotsToVisible_Click(object sender, EventArgs e)
        {
            if (SrcImage.Annots.Count > 0)
            {
                foreach (Annot a in SrcImage.Annots)
                {
                    a.Visible = true;
                }
            }
        }
        private void btnSetAllAnnotsToNotVisible_Click(object sender, EventArgs e)
        {
            if (SrcImage.Annots.Count > 0)
            {
                foreach (Annot a in SrcImage.Annots)
                {
                    a.Visible = false;
                }
            }
        }
        private void btnLoadDataPrep_Click(object sender, EventArgs e)
        {
            FrmDataPrep DataPrepForm = new();
            DataPrepForm.Show();
        }
        private Cursor GetCursorTypeFromComboBox()
        {
            string s = cbCursorType.Text;
            if (s == "Pointer")
            {
                return Cursors.Arrow;
            }
            else if (s == "Cross")
            {
                return Cursors.Cross;
            }
            return Cursors.Arrow;
        }

        private void cbScopeOutAmount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SrcImage.Annots.Count > 0)
            {
                SrcImage.SetZoomedAnnotationImage();
            }
            pbMain.Focus();
        }
    }

}
