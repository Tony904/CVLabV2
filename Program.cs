using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CVLabV2
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmAnnotation());

            MultiFormContext context = new();

            Application.Run(context);
        }
    }

    public class MultiFormContext : ApplicationContext
    {
        public FrmAnnotation _FrmAnnotation;

        public MultiFormContext()
        {
            _FrmAnnotation = new FrmAnnotation();
            _FrmAnnotation.Show();
        }
    }
}
