using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schooly
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("ar-MA");
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = culture;
            ////***********
            AppDomain.CurrentDomain.SetData("DataDirectory",
                                 Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            //***********


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                double daysToLeft = -1;
            if (Properties.Settings.Default.DaysLeft != "")
            { daysToLeft = Convert.ToDouble(Properties.Settings.Default.DaysLeft); }
              

                if (daysToLeft > 700)
                {
                    Properties.Settings.Default.licType = "-1";
                }
                          
                if (daysToLeft < 0 )
                {
                    Application.Run(new FrmActivate());


                }
                else
                {
                    Application.Run(new Frm_Main());

                }
            }
            catch (Exception)
            {

                Application.Run(new Frm_Error());


            }

        }
    }
}
