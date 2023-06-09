using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;

namespace Schooly.Tools
{
     class BulkExcel
    {
        internal string openFileExcel(string titel)
        {
            var filePath = string.Empty;
            OpenFileDialog OpenFile = new OpenFileDialog();

            OpenFile.Filter = "Excel Files|*.xl*"; //Filter for excel file  
            OpenFile.Multiselect = false;
            OpenFile.Title = titel;
            OpenFile.FilterIndex = 2;  //Don't know what it mean  
            OpenFile.RestoreDirectory = true;

            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file  
                filePath = OpenFile.FileName;
            }
            return filePath;
        }

        internal Workbook wb (string filePath)
        {
            Workbook wb = null;
            try
            {
                System.IO.FileInfo file = new System.IO.FileInfo(filePath);
                    if (file.Exists)
                    {
                        var excapp = new Microsoft.Office.Interop.Excel.Application();
                    if(filePath!=string.Empty)
                        wb = excapp.Workbooks.Open(file.FullName);
                    }
                    else
                    {
                        wb.Close();
                    }
                           }
            catch (Exception)
            {
                foreach (var process in Process.GetProcessesByName("Microsoft Excel"))
                {
                    process.Kill();
                }
            }
            return wb;
        }
    }
}
