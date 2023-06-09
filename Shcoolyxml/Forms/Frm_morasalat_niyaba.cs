using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schooly.Forms
{
    public partial class Frm_morasalat_niyaba : Form
    {
        public Frm_morasalat_niyaba()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        Nullable<DateTime> MyNullableDate = null;
       
        private void fillcombovide()
        {
            EtablissementDataContext edc = new EtablissementDataContext();
            var masIsvide = (from e in edc.maslahas select e.mas_mas).ToList();
            if (masIsvide.Count == 0)
            {
                casier cas = new casier
                {
                    cas_cas = "غير محدد",
                    raf_id_cas = 1

                };
                edc.casiers.InsertOnSubmit(cas);

                kism kis = new kism
                {
                    kism_kis = "غير محدد",
                    mas_id_kis = 1

                };
                edc.kisms.InsertOnSubmit(kis);

                maslaha mas = new maslaha
                {
                    mas_mas = "غير محدد",
                };
                edc.maslahas.InsertOnSubmit(mas);
                edc.SubmitChanges();

                //create maslaha directory  sub>income sub export
                string targetPath = @"C:\Schooly_Archive\" + "غير محدد";
                System.IO.Directory.CreateDirectory(targetPath);
                System.IO.Directory.CreateDirectory(targetPath + @"\الواردات");
                System.IO.Directory.CreateDirectory(targetPath + @"\الصادرات");


                raf ra = new raf
                {
                    raf_raf = "غير محدد"
                };
                edc.rafs.InsertOnSubmit(ra);

                edc.SubmitChanges();
            }
        }

        private void Frm_morasalat_niyaba_Load(object sender, EventArgs e)
        {
          



        }

       
        private void btn_arch_save1_Click(object sender, EventArgs e)
        {
            EtablissementDataContext etb = new EtablissementDataContext();

        }

     



        private void btn_arch_show_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Rows.Clear();
            EtablissementDataContext edc = new EtablissementDataContext();
           
            if (rb_arch_all_cor.Checked)
            {


                var morasalat = (from mo in edc.morasalas
                                 join r in edc.rafs on mo.classIn_raf_cor equals r.Id_raf
                                 join c in edc.casiers on mo.classIn_case_cor equals c.Id_cas
                                 join m in edc.maslahas on mo.maslaha_cor equals m.Id_mas
                                 join k in edc.kisms on mo._9ism_cor equals k.mas_id_kis
                                 select new
                                 {
                                     المعرف = mo.Id_cor,
                                     الموضوع = mo.subject_cor,
                                     الترتيب_محلي = mo.num_loc_cor,
                                     الترتيب_الخارجي = mo.num_ext_cor,
                                     تاريخ_الوثيقة = mo.dt_cor.Value.Date,
                                     أجل_الوثيقة = mo.dt_delai_cor != null ? mo.dt_delai_cor.Value.ToShortDateString() : mo.dt_delai_cor.ToString(),
                                     تم_التنفيذ = mo.execute_cor,
                                     الجهة_المعنية = mo.jiha_cor,
                                     المصدر = mo.source_cor,
                                     المصلحة = m.mas_mas,
                                     القسم_المكتب = k.kism_kis,
                                     الرف_الخزانة = r.raf_raf,
                                     الدرج_الصندوق = c.cas_cas,
                                     ملف_الأرشفة = mo.classeIn_dossier,
                                     مكان_الحفظ_PC = mo.locationPc_cor,
                                     نوع_الأرشيف = mo.type_arch_cor,
                                     رقم_الحفظ=mo.ref_doc_cor
                                 }
                                 ).ToList();


                //var bindingList = new BindingList<morasala>(morasalat);
                //var source = new BindingSource(bindingList, null);
                //dataGridView1.DataSource = source;

                var source = new BindingSource(morasalat, null);
                //  this.dataGridView1.sort = "[ColumnName] ASC, [ColumnName] DESC";
                this.dataGridView1.DataSource = source;

            }
            if (rb_arch_serach.Checked)
            {
             
                var search_key = txt_search_key_cor.Text.Trim();

                var morasalat = (from mo in edc.morasalas
                                     // where System.Data.Linq.SqlClient.SqlMethods.Like(mo.subject_cor, "%" + search_key[0] + "% " + search_key[1] + "% " + search_key[2])
                                 where mo.subject_cor.Contains(search_key)
                                 join r in edc.rafs on mo.classIn_raf_cor equals r.Id_raf
                                 join c in edc.casiers on mo.classIn_case_cor equals c.Id_cas
                                 join m in edc.maslahas on mo.maslaha_cor equals m.Id_mas
                                 join k in edc.kisms on mo._9ism_cor equals k.mas_id_kis
                                 select new
                                 {
                                     المعرف = mo.Id_cor,
                                     الموضوع = mo.subject_cor,
                                     الرف_الخزانة = r.raf_raf,
                                     الدرج_الصندوق = c.cas_cas,
                                     ملف_الأرشفة = mo.classeIn_dossier,
                                     رقم_الحفظ = mo.ref_doc_cor,
                                     الترتيب_محلي = mo.num_loc_cor,
                                     الترتيب_الخارجي = mo.num_ext_cor,
                                     تاريخ_الوثيقة = mo.dt_cor.Value.Date,
                                     أجل_الوثيقة = mo.dt_delai_cor != null ? mo.dt_delai_cor.Value.ToShortDateString() : mo.dt_delai_cor.ToString(),
                                     تم_التنفيذ = mo.execute_cor,
                                     الجهة_المعنية = mo.jiha_cor,
                                     المصدر = mo.source_cor,
                                     المصلحة = m.mas_mas,
                                     القسم_المكتب = k.kism_kis,
                                     مكان_الحفظ_PC = mo.locationPc_cor,
                                     نوع_الأرشيف = mo.type_arch_cor
                                 }
                                 ).ToList();

                var source = new BindingSource(morasalat, null);
                dataGridView1.DataSource = source;

            }
            if (rb_arch_between.Checked)
            {
                DateTime dt_de = dtp_arc_de.Value.Date;
                DateTime de_jusqu = dtp_arc_jusque.Value.Date;
                var morasalat = (from mo in edc.morasalas
                                 where mo.dt_cor >= dt_de && mo.dt_cor <= de_jusqu
                                 join r in edc.rafs on mo.classIn_raf_cor equals r.Id_raf
                                 join c in edc.casiers on mo.classIn_case_cor equals c.Id_cas
                                 join m in edc.maslahas on mo.maslaha_cor equals m.Id_mas
                                 join k in edc.kisms on mo._9ism_cor equals k.mas_id_kis
                                 select new
                                 {
                                     المعرف = mo.Id_cor,
                                     الموضوع = mo.subject_cor,
                                     الترتيب_محلي = mo.num_loc_cor,
                                     الترتيب_الخارجي = mo.num_ext_cor,
                                     تاريخ_الوثيقة = mo.dt_cor.Value.Date,
                                     أجل_الوثيقة = mo.dt_delai_cor != null ? mo.dt_delai_cor.Value.ToShortDateString() : mo.dt_delai_cor.ToString(),
                                     تم_التنفيذ = mo.execute_cor,
                                     الجهة_المعنية = mo.jiha_cor,
                                     المصدر = mo.source_cor,
                                     المصلحة = m.mas_mas,
                                     القسم_المكتب = k.kism_kis,
                                     الرف_الخزانة = r.raf_raf,
                                     الدرج_الصندوق = c.cas_cas,
                                     ملف_الأرشفة = mo.classeIn_dossier,
                                     مكان_الحفظ_PC = mo.locationPc_cor,
                                     نوع_الأرشيف = mo.type_arch_cor,
                                     رقم_الحفظ = mo.ref_doc_cor
                                 }
                                 ).ToList();

                var source = new BindingSource(morasalat, null);
                dataGridView1.DataSource = source;
            }

            RemovedupGrid();
          }
        
        private void btn_arch_import_Click(object sender, EventArgs e)
        {
            btn_import_data_Click(sender, e);
            btn_arch_show_Click(sender, e);
            //String name = "";
            //string path = "";
            //OpenFileDialog fdlg = new OpenFileDialog();
            //fdlg.Title = "Select file";
            //// fdlg.InitialDirectory = @"c:\";
            ////fdlg.FileName = txtFileName.Text;
            //fdlg.Filter = "Excel Sheet(*.xls)|*.xls|All Files(*.*)|*.*";
            //fdlg.FilterIndex = 1;
            //fdlg.RestoreDirectory = true;
            //if (fdlg.ShowDialog() == DialogResult.OK)
            //{
            //    path = fdlg.FileName;
            //    // name = Path.GetFileNameWithoutExtension(path);//fdlg.SafeFileName) ;

            //}
            //var excelFile = Path.GetFullPath(path);
            //var excel = new Microsoft.Office.Interop.Excel.Application();
            //var workbook = excel.Workbooks.Open(path);
            //var sheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.Item[1]; // 1 is the first item, this is NOT a zero-based collection
            //name = sheet.Name;
            //workbook.Close();
            //String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
            //                path +
            //                ";Extended Properties='Excel 8.0;HDR=YES;';";

            //OleDbConnection con = new OleDbConnection(constr);
            //OleDbCommand oconn = new OleDbCommand("Select * From [" + name + "$]", con);
            //con.Open();

            //OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
            //System.Data.DataTable data = new System.Data.DataTable();
            //sda.Fill(data);
            //dataGridView1.DataSource = data;
            /////************************

            //EtablissementDataContext edc = new EtablissementDataContext();
            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    morasala mos = new morasala
            //    {
            //        subject_cor = dataGridView1.Rows[i].Cells[1].Value.ToString(),
            //        num_ext_cor= dataGridView1.Rows[i].Cells[2].Value.ToString(),
            //        num_loc_cor= dataGridView1.Rows[i].Cells[3].Value.ToString(),
            //        dt_cor=DateTime.FromOADate( dataGridView1.Rows[i].Cells[4].Value.ToString()),

            //    };
            //}




        }
        private void btn_arch_export_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // see the excel sheet behind the program  
            app.Visible = true;
            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets[1];
            worksheet = workbook.ActiveSheet;
            // changing the name of active sheet  
            worksheet.Name = "تصدير الأرشفة"+DateTime.Now.Month.ToString()+" "+ DateTime.Now.Day.ToString();
            // storing header part in Excel  
            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < dataGridView1.Rows.Count ; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value!=null? dataGridView1.Rows[i].Cells[j].Value.ToString():"";
                }
            }

            //// save the application  
            //workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            //// Exit from the application  
            //app.Quit();
        }
       
        
        private void btn_arch_delete_Click(object sender, EventArgs e)
        {
            int valcelId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            EtablissementDataContext edc = new EtablissementDataContext();
            morasala mos = edc.morasalas.SingleOrDefault(m => m.Id_cor == valcelId);
            edc.morasalas.DeleteOnSubmit(mos);
            edc.SubmitChanges();

            btn_arch_show_Click(sender, e);
        }

        private DateTime? GetdatefromcellexcelDT(dynamic vc, int r,int c)
        {
            DateTime temp;
            
            if (vc[r,c] != null)
            {

                if (DateTime.TryParse(vc[r, c].ToString(), out temp))

                {
                    return temp;

                }
                if (vc[r, c] is double)
                {
                    return  DateTime.FromOADate(Convert.ToDouble( vc[r, c].ToString()));
                }
                else
                {
                    return MyNullableDate;
                }

            }
            else {
                return MyNullableDate;
                 }
            

           
        }
        private DateTime? GetdatefromcellGridlDT(int cell, int row)
        {
            DateTime temp;

            if( dataGridView1.Rows[row].Cells[cell] != null)
            {

                if (DateTime.TryParse(dataGridView1.Rows[row].Cells[cell].Value.ToString(), out temp))

                {
                    return temp;

                }
                if (dataGridView1.Rows[row].Cells[cell].Value is double)
                {
                    return DateTime.FromOADate(Convert.ToDouble(dataGridView1.Rows[row].Cells[cell].Value.ToString()));
                }
                else
                {
                    return MyNullableDate;
                }

            }
            else
            {
                return MyNullableDate;
            }



        }

        private string GetdatefromcellexcelSTring(dynamic vc, int r, int c)
        {
            if (vc[r, c] != null)
            {
                if (vc[r, c] is double)
                {
                    return vc[r, c].ToString();
                }
                else
                {
                    return vc[r, c];
                }

            }
            else
            {
                return vc[r, c];
            }
        }

        private string GetdatefromcellGridSTring(int cell, int row)
        {
            if (dataGridView1.Rows[row].Cells[cell].Value != null)
            {
                if (dataGridView1.Rows[row].Cells[cell].Value is double)
                {
                    return dataGridView1.Rows[row].Cells[cell].Value.ToString();
                }
                else
                {
                    return dataGridView1.Rows[row].Cells[cell].Value.ToString();
                }

            }
            else
            {
                return dataGridView1.Rows[row].Cells[cell].Value.ToString();
            }
        }

        private void btn_import_data_Click(object sender, EventArgs e)
        {
            Tools.BulkExcel be = new Tools.BulkExcel();

            Workbook wb = be.wb(be.openFileExcel("حدد مرتب الإكسل الذي قمت بتصديره من البرنامد مسبقا"));
            if (wb != null)
            {
                string gresa = Tools.Globals.GRESA;
                EtablissementDataContext stdt = new EtablissementDataContext();
                List<morasala> stUpToDel = (from st in stdt.morasalas where st.gresa_cor == gresa select st).ToList();
                if (stUpToDel != null)
                {
                    stdt.morasalas.DeleteAllOnSubmit(stUpToDel);
                }
                //********** import maslaha
                var vcmas = wb.Worksheets[1].UsedRange.Columns[10, Type.Missing].Value2;
              
                foreach (var item in vcmas)
                {
                    maslaha mas = new maslaha
                    {
                        mas_mas = item
                    };
                    stdt.maslahas.InsertOnSubmit(mas);
                }
                stdt.SubmitChanges();
                //************* end  import maslaha
                //*********** import raf
                var vcraf = wb.Worksheets[1].UsedRange.Columns[16, Type.Missing].Value2;


                foreach (var item in vcraf)
                {
                    raf ra = new raf
                    {
                        raf_raf = item
                    };
                    stdt.rafs.InsertOnSubmit(ra);
                }
                stdt.SubmitChanges();


                //************end import raf
                //************ import kism
                var vckism = wb.Worksheets[1].UsedRange.Columns[11, Type.Missing].Value2;
               
                for (int i = 1; i < vckism.GetLength(0)+1; i++)
                {
                    string masl = wb.Worksheets[1].UsedRange.Cells[i + 1, 10].Value2;
                    kism ks = new kism
                    {
                        kism_kis = vckism[i,1],
                        mas_id_kis = stdt.maslahas.Where(m => m.mas_mas == masl).Select(s => s.Id_mas).FirstOrDefault()
                    };
                    stdt.kisms.InsertOnSubmit(ks);
                }
                stdt.SubmitChanges();

                //*****************end import kism
               

                // /////////import case

                var vccase = wb.Worksheets[1].UsedRange.Columns[15, Type.Missing].Value2;
                
                for (int i = 1; i < vccase.GetLength(0) + 1; i++)
                {
                    string raf = wb.Worksheets[1].UsedRange.Cells[i + 1, 16].Value2;
                    casier cs = new casier
                    {
                        cas_cas = vccase[i, 1],
                        raf_id_cas = stdt.rafs.Where(r => r.raf_raf == raf).Select(s => s.Id_raf).FirstOrDefault()
                    };
                    stdt.casiers.InsertOnSubmit(cs);
                }
                stdt.SubmitChanges();
                //***********end import case

                //  Nullable<DateTime> MyNullableDate=null;
                var vc = wb.Worksheets[1].UsedRange.Value2;
               
                for (int i = 2; i <= vc.GetLength(0) ; i++)
                {
                    string mm = GetdatefromcellexcelSTring(vc, i, 10);
                    string kk = GetdatefromcellexcelSTring(vc, i, 11);
                    string cc = GetdatefromcellexcelSTring(vc, i, 15);
                    string rr = GetdatefromcellexcelSTring(vc, i, 16);


                    int mas =stdt.maslahas.Where(m => m.mas_mas == mm).Select(s => s.Id_mas).First();
                    int kis= stdt.kisms.Where(k => k.kism_kis ==kk ).Select(s => s.Id_kism).First();
                    int cas = stdt.casiers.Where(c => c.cas_cas ==cc).Select(s => s.Id_cas).First();
                    int rf = stdt.rafs.Where(r => r.raf_raf == rr).Select(s => s.Id_raf).First();

                    morasala mos =new morasala
                    {
                        subject_cor = vc[i, 2],
                        num_loc_cor = GetdatefromcellexcelSTring(vc,i,3),
                        num_ext_cor = GetdatefromcellexcelSTring(vc, i, 4),
                       dt_cor = GetdatefromcellexcelDT(vc,i,5),
                        dt_delai_cor = GetdatefromcellexcelDT(vc, i, 6),
                         execute_cor = vc[i, 7],
                        jiha_cor = GetdatefromcellexcelSTring(vc, i, 8),
                       source_cor = vc[i, 9],
                         maslaha_cor = mas, //vc[i, 10],
                       _9ism_cor = kis, //vc[i, 11],
                        type_arch_cor = GetdatefromcellexcelSTring(vc, i, 12),
                        classeIn_dossier = GetdatefromcellexcelSTring(vc, i, 13),
                       //// ref_doc_cor = vc[10, 14],
                      classIn_case_cor = cas,//vc[i, 15],
                     classIn_raf_cor = rf,//vc[11, 16],
                       locationPc_cor = GetdatefromcellexcelSTring(vc, i, 17),
                       gresa_cor = gresa
                    };




                    stdt.morasalas.InsertOnSubmit(mos);
                    
                }
                stdt.SubmitChanges();

                MessageBox.Show("تم جلب اللائحة  بنجاح");
                wb.Close();
            }
        }

       private void RemovedupGrid()
        {
            for (int i = 0; i < dataGridView1.RowCount; i++) //compare data
            {
                var R = dataGridView1.Rows[i];
                var V = R.Cells[0].Value.ToString();
                var DupRows = dataGridView1.Rows.Cast<DataGridViewRow>().Skip(i + 1).
                                Where(r => r.Cells[0].Value.ToString() == V);


                foreach (var DupRow in DupRows)
                    DupRow.Tag = "Del";
            }

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                var R = dataGridView1.Rows[i];
                if (R.Tag?.ToString() == "Del")
                {
                    dataGridView1.Rows.Remove(R);
                    i--;
                }
            }
        }

        private void txt_search_key_cor_MouseClick(object sender, MouseEventArgs e)
        {
            rb_arch_serach.Checked = true;
        }

      
        private void dtp_arc_jusque_MouseDown(object sender, MouseEventArgs e)
        {
            rb_arch_between.Checked = true;
        }

        private void btn_arch_Update_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Rows.Clear();
            EtablissementDataContext edc = new EtablissementDataContext();

            if (rb_arch_all_cor.Checked)
            {


                var morasalat = (from mo in edc.morasalas
                                 where mo.execute_cor==false
                                 join r in edc.rafs on mo.classIn_raf_cor equals r.Id_raf
                                 join c in edc.casiers on mo.classIn_case_cor equals c.Id_cas
                                 join m in edc.maslahas on mo.maslaha_cor equals m.Id_mas
                                 join k in edc.kisms on mo._9ism_cor equals k.mas_id_kis
                                 select new
                                 {
                                     المعرف = mo.Id_cor,
                                     الموضوع = mo.subject_cor,
                                     الترتيب_محلي = mo.num_loc_cor,
                                     الترتيب_الخارجي = mo.num_ext_cor,
                                     تاريخ_الوثيقة = mo.dt_cor.Value.Date,
                                     أجل_الوثيقة = mo.dt_delai_cor != null ? mo.dt_delai_cor.Value.ToShortDateString() : mo.dt_delai_cor.ToString(),
                                     تم_التنفيذ = mo.execute_cor,
                                     الجهة_المعنية = mo.jiha_cor,
                                     المصدر = mo.source_cor,
                                     المصلحة = m.mas_mas,
                                     القسم_المكتب = k.kism_kis,
                                     الرف_الخزانة = r.raf_raf,
                                     الدرج_الصندوق = c.cas_cas,
                                     ملف_الأرشفة = mo.classeIn_dossier,
                                     مكان_الحفظ_PC = mo.locationPc_cor,
                                     نوع_الأرشيف = mo.type_arch_cor,
                                     رقم_الحفظ = mo.ref_doc_cor
                                 }
                                 ).ToList();


                //var bindingList = new BindingList<morasala>(morasalat);
                //var source = new BindingSource(bindingList, null);
                //dataGridView1.DataSource = source;

                var source = new BindingSource(morasalat, null);
                //  this.dataGridView1.sort = "[ColumnName] ASC, [ColumnName] DESC";
                this.dataGridView1.DataSource = source;

            }
            if (rb_arch_serach.Checked)
            {

                var search_key = txt_search_key_cor.Text.Trim();

                var morasalat = (from mo in edc.morasalas
                                 where mo.execute_cor == false
                                 // where System.Data.Linq.SqlClient.SqlMethods.Like(mo.subject_cor, "%" + search_key[0] + "% " + search_key[1] + "% " + search_key[2])
                                 where mo.subject_cor.Contains(search_key)
                                 join r in edc.rafs on mo.classIn_raf_cor equals r.Id_raf
                                 join c in edc.casiers on mo.classIn_case_cor equals c.Id_cas
                                 join m in edc.maslahas on mo.maslaha_cor equals m.Id_mas
                                 join k in edc.kisms on mo._9ism_cor equals k.mas_id_kis
                                 select new
                                 {
                                     المعرف = mo.Id_cor,
                                     الموضوع = mo.subject_cor,
                                     الرف_الخزانة = r.raf_raf,
                                     الدرج_الصندوق = c.cas_cas,
                                     ملف_الأرشفة = mo.classeIn_dossier,
                                     رقم_الحفظ = mo.ref_doc_cor,
                                     الترتيب_محلي = mo.num_loc_cor,
                                     الترتيب_الخارجي = mo.num_ext_cor,
                                     تاريخ_الوثيقة = mo.dt_cor.Value.Date,
                                     أجل_الوثيقة = mo.dt_delai_cor != null ? mo.dt_delai_cor.Value.ToShortDateString() : mo.dt_delai_cor.ToString(),
                                     تم_التنفيذ = mo.execute_cor,
                                     الجهة_المعنية = mo.jiha_cor,
                                     المصدر = mo.source_cor,
                                     المصلحة = m.mas_mas,
                                     القسم_المكتب = k.kism_kis,
                                     مكان_الحفظ_PC = mo.locationPc_cor,
                                     نوع_الأرشيف = mo.type_arch_cor
                                 }
                                 ).ToList();

                var source = new BindingSource(morasalat, null);
                dataGridView1.DataSource = source;

            }
            if (rb_arch_between.Checked)
            {
                DateTime dt_de = dtp_arc_de.Value.Date;
                DateTime de_jusqu = dtp_arc_jusque.Value.Date;
                var morasalat = (from mo in edc.morasalas
                                 where mo.execute_cor == false
                                 where mo.dt_cor >= dt_de && mo.dt_cor <= de_jusqu
                                 join r in edc.rafs on mo.classIn_raf_cor equals r.Id_raf
                                 join c in edc.casiers on mo.classIn_case_cor equals c.Id_cas
                                 join m in edc.maslahas on mo.maslaha_cor equals m.Id_mas
                                 join k in edc.kisms on mo._9ism_cor equals k.mas_id_kis
                                 select new
                                 {
                                     المعرف = mo.Id_cor,
                                     الموضوع = mo.subject_cor,
                                     الترتيب_محلي = mo.num_loc_cor,
                                     الترتيب_الخارجي = mo.num_ext_cor,
                                     تاريخ_الوثيقة = mo.dt_cor.Value.Date,
                                     أجل_الوثيقة = mo.dt_delai_cor != null ? mo.dt_delai_cor.Value.ToShortDateString() : mo.dt_delai_cor.ToString(),
                                     تم_التنفيذ = mo.execute_cor,
                                     الجهة_المعنية = mo.jiha_cor,
                                     المصدر = mo.source_cor,
                                     المصلحة = m.mas_mas,
                                     القسم_المكتب = k.kism_kis,
                                     الرف_الخزانة = r.raf_raf,
                                     الدرج_الصندوق = c.cas_cas,
                                     ملف_الأرشفة = mo.classeIn_dossier,
                                     مكان_الحفظ_PC = mo.locationPc_cor,
                                     نوع_الأرشيف = mo.type_arch_cor,
                                     رقم_الحفظ = mo.ref_doc_cor
                                 }
                                 ).ToList();

                var source = new BindingSource(morasalat, null);
                dataGridView1.DataSource = source;
            }

            RemovedupGrid();







        }

     
        }
}
