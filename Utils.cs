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
    public class FilePath
    {
        private string _full_path;
        
        public string FullPath
        {
            get
            {
                return _full_path;
            }
        }
        public string FullPathMinusExt
        {
            get
            {
                int start_index = _full_path.LastIndexOf('.');
                string outpt = _full_path.Remove(start_index);
                return outpt;
            }
        }
        public string FileNameNoExt
        {
            get
            {
                int start_index = _full_path.LastIndexOf('\\');
                int end_index = _full_path.LastIndexOf('.');
                int length = end_index - start_index - 2;
                string outpt = _full_path.Substring(start_index + 1, length);
                return outpt;                
            }
        }
        public string FileNamePlusExt
        {
            get
            {
                int start_index = _full_path.LastIndexOf('\\');
                string outpt = _full_path.Substring(start_index + 1);
                return outpt;
            }
        }
        public string Directory
        {
            get
            {
                int index = _full_path.LastIndexOf('\\');
                string outpt = _full_path.Remove(index + 1);
                return outpt;
            }
        }

        public FilePath(string full_path)
        {
            _full_path = full_path;
        }
    }
    public static class Colors
    {
        public static Bgr Blue = new Bgr(255, 0, 0);
        public static Bgr Green = new Bgr(0, 255, 0);
        public static Bgr Red = new Bgr(0, 0, 255);
        public static Bgr Black = new Bgr(0, 0, 0);
        public static Bgr White = new Bgr(255, 255, 255);
        public static Bgr Gray = new Bgr(127, 127, 127);
    }
    public static class CustomToString
    {
        public static string RectToString(Rectangle rect)
        {
            string x = "X: " + rect.X.ToString() + " ";
            string y = "Y: " + rect.Y.ToString() + " ";
            string w = "W: " + rect.Width.ToString() + " ";
            string h = "H: " + rect.Height.ToString();

            return x + y + w + h;
        }
    }
    public static class MyUtils
    {
        public static Rectangle FixRectNegatives(Rectangle rect)
        {
            if(rect.Width < 0)
            {
                rect.Width *= -1;
                rect.X -= rect.Width;
            }
            if(rect.Height < 0)
            {
                rect.Height *= -1;
                rect.Y -= rect.Height;
            }
            return rect;
        }
        public static Rectangle OffsetRectTopAndLeftForDrawing(Rectangle rect)
        {
            int x = rect.X - 1;
            x = Math.Max(0, x);
            int y = rect.Y - 1;
            y = Math.Max(0, y);
            rect.X = x;
            rect.Y = y;
            rect.Width++;
            rect.Height++;
            return rect;
        }
        public static void CustomImageUpScale(Image<Bgr, byte> src, int scale, out Image<Bgr, byte> dst)
        {
            src = src.Clone();
            if (scale > 1)
            {
                int rows = src.Height;
                int cols = src.Width;
                dst = new(cols * scale, rows * scale, Colors.Red);
                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < cols; c++)
                    {
                        byte bval = src.Data[r, c, 0];
                        byte gval = src.Data[r, c, 1];
                        byte rval = src.Data[r, c, 1];
                        for (int sr = 0; sr < scale; sr++)
                        {
                            for (int sc = 0; sc < scale; sc++)
                            {
                                dst.Data[r * scale + sr, c * scale + sc, 0] = bval;
                                dst.Data[r * scale + sr, c * scale + sc, 1] = gval;
                                dst.Data[r * scale + sr, c * scale + sc, 2] = rval;
                            }
                        }
                    }
                }
            }
            else
            {
                dst = src.Clone();
            }
        }
        public static void GetRectCenter(Rectangle src, out Point dst)
        {
            dst = new();
            dst.X = src.X + src.Width / 2;
            dst.Y = src.Y + src.Height / 2;
        }
        public static void GetRectCenter(Rectangle src, out PointF dst)
        {
            dst = new();
            dst.X = (float)src.X + (float)src.Width / 2f;
            dst.Y = (float)src.Y + (float)src.Height / 2f;
        }
        public static int RoundUp(double d)
        {
            int i = (int)d;
            if(d - (double)i > 0.001d)
            {
                i++;
            }
            return i;
        }
    }
    
}
