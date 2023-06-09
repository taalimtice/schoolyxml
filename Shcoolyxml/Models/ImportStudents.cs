using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schooly.Models
{
    class ImportStudents
    {

       
        internal void ImportListStudentsUpdate()
        {
            Tools.BulkExcel be = new Tools.BulkExcel();

            Workbook wb = be.wb(be.openFileExcel("حدد لائحة الإكسل المتضمنة للوائح المحينة"));
            if (wb != null)
            {
                string etab = wb.Worksheets[1].UsedRange.Value2[8, 6];
                //************
                string message = "المؤسسة هي "+" "+etab;
                string title = "تأكيد المؤسسة";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    
              

                //***************
                string gresa = Tools.Globals.GRESA;
                StudentsListDataContext stdt = new StudentsListDataContext();
               
                List< StudentListUpdate> stUpToDel = (from st in stdt.StudentListUpdates where st.gresa_Up == gresa select st).ToList();
                if (stUpToDel != null)
                {
                    stdt.StudentListUpdates.DeleteAllOnSubmit(stUpToDel);
                    stdt.SubmitChanges();
                }
                var allStudents = stdt.StudentListUpdates.Select(st =>st.cMassar_Up).ToList();

                List<StudentListUpdate> stUp = new List<StudentListUpdate>();
                    for (int j = 1; j <= wb.Worksheets.Count; j++)
                {
                    var vc = wb.Worksheets[j].UsedRange.Value2;

                    for (int i = 1; i <= vc.GetLength(0); i++)
                    {
                        Boolean IscountainDigit = true;
                        string cm = vc[i, 22];

                        if (cm != null)
                        { IscountainDigit = cm.Any(c => char.IsDigit(c)); }
                     
                        if (IscountainDigit && cm != null  )
                        {
                            if (allStudents.Contains(cm))
                            {
                                StudentListUpdate todel = stdt.StudentListUpdates.Where(w => w.cMassar_Up == cm).First();
                                stdt.StudentListUpdates.DeleteOnSubmit(todel);
                            }
                           
                            stUp.Add(new StudentListUpdate
                            {
                                cMassar_Up = vc[i, 22],
                                nOreder_Up = int.Parse(vc[i, 25].ToString()),
                                firstName_Up = vc[i, 15],
                                lastName_Up = vc[i, 11],
                                genre_Up = vc[i, 10],
                                dateNaiss_Up = DateTime.FromOADate(vc[i, 4]),
                                lieuNaiss_Up = vc[i, 1],
                                classe_Up = vc[11, 7],
                                niveau_Up = vc[10, 18],
                                annescol_Up = vc[6, 1],
                                gresa_Up = gresa
                            });

                        }
                        

                    }
                }
                stdt.StudentListUpdates.InsertAllOnSubmit(stUp);
                stdt.SubmitChanges();

               // MessageBox.Show("تم جلب اللائحة المحينة بنجاح");
                wb.Close();
                }
                else
                {
                     
                }
            }
           
        }

       

        internal void ImportListStudentsPrimaire()
        {
            Tools.BulkExcel be = new Tools.BulkExcel();

            Workbook wb = be.wb(be.openFileExcel("حدد لائحة الإكسل المتضمنة للوائح الأولية"));
            if (wb != null)
            {
                string etab = wb.Worksheets[1].UsedRange.Value2[8, 6];
                //************
                string message = "المؤسسة هي " + " " + etab;
                string title = "تأكيد المؤسسة";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {



                    //***************
                    string gresa = Tools.Globals.GRESA;
                    StudentsListDataContext stdt = new StudentsListDataContext();

                    List<StudentListPrimaire> stPrToDel = (from st in stdt.StudentListPrimaires where st.gresa_Pr == gresa select st).ToList();
                    if (stPrToDel != null)
                    {
                        stdt.StudentListPrimaires.DeleteAllOnSubmit(stPrToDel);
                        stdt.SubmitChanges();
                    }
                    var allStudents = stdt.StudentListPrimaires.Select(st => st.cMassar_Pr).ToList();

                    List<StudentListPrimaire> stPr = new List<StudentListPrimaire>();
                    for (int j = 1; j <= wb.Worksheets.Count; j++)
                    {
                        var vc = wb.Worksheets[j].UsedRange.Value2;

                        for (int i = 1; i <= vc.GetLength(0); i++)
                        {
                            Boolean IscountainDigit = true;
                            string cm = vc[i, 22];

                            if (cm != null)
                            { IscountainDigit = cm.Any(c => char.IsDigit(c)); }

                            if (IscountainDigit && cm != null)
                            {
                                if (allStudents.Contains(cm))
                                {
                                    StudentListPrimaire todel = stdt.StudentListPrimaires.Where(w => w.cMassar_Pr == cm).First();
                                    stdt.StudentListPrimaires.DeleteOnSubmit(todel);
                                }

                                stPr.Add(new StudentListPrimaire
                                {
                                    cMassar_Pr = vc[i, 22],
                                    nOreder_Pr = int.Parse(vc[i, 25].ToString()),
                                    firstName_Pr = vc[i, 15],
                                    lastName_Pr = vc[i, 11],
                                    genre_Pr = vc[i, 10],
                                    dateNaiss_Pr = DateTime.FromOADate(vc[i, 4]),
                                    lieuNaiss_Pr = vc[i, 1],
                                    classe_Pr = vc[11, 7],
                                    niveau_Pr = vc[10, 18],
                                    annescol_Pr = vc[6, 1],
                                    gresa_Pr = gresa
                                });

                            }


                        }
                    }
                    stdt.StudentListPrimaires.InsertAllOnSubmit(stPr);
                    stdt.SubmitChanges();

                    // MessageBox.Show("تم جلب اللائحة المحينة بنجاح");
                    wb.Close();
                }
                else
                {

                }
            }


        }

        internal void ImportXMLEmployees()
        {

        }
      

        internal void PopulateCBSelectEtab(ComboBox cb)
        {
            try
            {
                EtablissementDataContext etdt = new EtablissementDataContext();

                var etabs = (from et in etdt.InfoEtabs select new { gre = et.gresa_info, eta = et.etabNameAr_info }).ToList();
                if (etabs.Count > 0)
                {
                    cb.DataSource = etabs;
                    cb.DisplayMember = "eta";
                    cb.ValueMember = "gre";
                    if (etabs.Count == 1)
                        cb.SelectedIndex = 0;
                    if (etabs.Count > 1)
                    {
                        cb.SelectedIndex = 0;
                        cb.SelectedIndex = 1;
                        cb.Text = "أختر مؤسسة";
                    }

                }
                if (etabs.Count == 0)
                {
                    //  cb.Text = string.Empty;
                    cb.DataSource = null;
                }

                Tools.Globals.GRESA = cb.GetItemText(cb.SelectedValue);
            }
            catch (Exception ex)
            {

                DialogResult dialogResult = MessageBox.Show(ex.Message, "تأكيد", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                  //  System.Windows.Forms.Application.Run(new Frm_Error());
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }
          
        }
    }
}
