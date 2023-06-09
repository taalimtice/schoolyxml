using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schooly.Pages
{
    public partial class Frm_transaction : Form
    {
        public Frm_transaction()
        {
            InitializeComponent();
        }

        private void Frm_transaction_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            StudentsListDataContext stdc = new StudentsListDataContext();
            var St_trans = stdc.Transactions.Select(s=>
                new
                {
                   رمز_مسار=s.massar_trans_,
                   اسم_التلميذ=s.fname_trans_+" "+s.lname_trans_,
                   تاريخ_التحويل=s.dt_trans_,
                   نوع_التحويل=s.typ_trans_,
                   المؤسسة_الأصلية=s.etabOrig_trans_,
                   مؤسسةçالإستقبال=s.etabRecep_trans_,
                   المديرية=s.direc_orig_recep_trans_,
                   trans=s.part_entr_trans_,
                   المستوى=s.niveau_trans_


                }
                
                ).ToList();
            dataGridView1.DataSource = St_trans;
            btn_show_trans_ent.BackColor = Color.LightGreen;
            btn_show_trans_all.BackColor = Color.Green;
            btn_show_trans_quit.BackColor = Color.LightGreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_show_trans_ent_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            StudentsListDataContext stdc = new StudentsListDataContext();
            var St_trans = stdc.Transactions.Where(w=>w.part_entr_trans_==1).Select(s =>
                new
                {
                    رمز_مسار = s.massar_trans_,
                    اسم_التلميذ = s.fname_trans_ + " " + s.lname_trans_,
                    تاريخ_التحويل = s.dt_trans_,
                    نوع_التحويل = s.typ_trans_,
                    المؤسسة_الأصلية = s.etabOrig_trans_,
                    مؤسسةçالإستقبال = s.etabRecep_trans_,
                    المديرية = s.direc_orig_recep_trans_,
                    الحركية = "وافد",
                    المستوى = s.niveau_trans_


                }

                ).ToList();

            if (St_trans.Count == 0)
            {
                MessageBox.Show("لم تجلب الحركية ");
            }
            else
            {
              
                dataGridView1.DataSource = St_trans;
                btn_show_trans_ent.BackColor = Color.Green;
                btn_show_trans_all.BackColor = Color.LightGreen;
                btn_show_trans_quit.BackColor = Color.LightGreen;
                btn_show_trans_pont.BackColor = Color.LightGreen;
                btn_show_trans_pont0.BackColor = Color.LightGreen;
                btn_trans_athers.BackColor = Color.LightGreen;
            }

           
        }

        private void btn_show_trans_quit_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            StudentsListDataContext stdc = new StudentsListDataContext();
            var St_trans = stdc.Transactions.Where(w => w.part_entr_trans_ == -1).Select(s =>
                    new
                    {
                        رمز_مسار = s.massar_trans_,
                        اسم_التلميذ = s.fname_trans_ + " " + s.lname_trans_,
                        تاريخ_التحويل = s.dt_trans_,
                        نوع_التحويل = s.typ_trans_,
                        المؤسسة_الأصلية = s.etabOrig_trans_,
                        مؤسسةçالإستقبال = s.etabRecep_trans_,
                        المديرية = s.direc_orig_recep_trans_,
                        الحركية = "مغادر",
                        المستوى = s.niveau_trans_


                    }

                ).ToList();
            if (St_trans.Count==0)
            {
                MessageBox.Show("لم تجلب الحركية ");
            }
            else
            {
                dataGridView1.DataSource = St_trans;
                btn_show_trans_ent.BackColor = Color.LightGreen;
                btn_show_trans_all.BackColor = Color.LightGreen;
                btn_show_trans_quit.BackColor = Color.Green;
                btn_show_trans_pont.BackColor = Color.LightGreen;
                btn_show_trans_pont0.BackColor = Color.LightGreen;
                btn_trans_athers.BackColor = Color.LightGreen;
            }
           
        }

        private void btn_show_trans_all_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            StudentsListDataContext stdc = new StudentsListDataContext();
            var St_trans = stdc.Transactions.Select(s =>
                    new
                    {
                        رمز_مسار = s.massar_trans_,
                        اسم_التلميذ = s.fname_trans_ + " " + s.lname_trans_,
                        تاريخ_التحويل = s.dt_trans_,
                        نوع_التحويل = s.typ_trans_,
                        المؤسسة_الأصلية = s.etabOrig_trans_,
                        مؤسسةçالإستقبال = s.etabRecep_trans_,
                        المديرية = s.direc_orig_recep_trans_,
                        الحركية = s.part_entr_trans_ ==1?"وافد":"مغادر",
                        المستوى = s.niveau_trans_

                    }

                ).ToList();

            if (St_trans.Count == 0)
            {
                MessageBox.Show("لم تجلب الحركية ");
            }
            else
            {


                dataGridView1.DataSource = St_trans;
                btn_show_trans_ent.BackColor = Color.LightGreen;
                btn_show_trans_all.BackColor = Color.Green;
                btn_show_trans_quit.BackColor = Color.LightGreen;
                btn_show_trans_pont.BackColor = Color.LightGreen;
                btn_show_trans_pont0.BackColor = Color.LightGreen;
                btn_trans_athers.BackColor = Color.LightGreen;
            }
        }

        private void btn_show_trans_pont_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            StudentsListDataContext stdc = new StudentsListDataContext();

            var pont = stdc.Transactions.GroupBy(x => x.massar_trans_)
                                      .Where(g => g.Count() > 1)
                                      .Select(y => new { Element = y.Key, Counter = y.Count(), y = y })
                                      ;

            var St_trans = stdc.Transactions.Where(w=> pont.Select(s=>s.Element).Contains(w.massar_trans_) ).Select(s =>
                   new
                   {
                       رمز_مسار = s.massar_trans_,
                       اسم_التلميذ = s.fname_trans_ + " " + s.lname_trans_,
                       الحركية = s.part_entr_trans_ == 1 ? "وافد" : "مغادر",
                       المستوى = s.niveau_trans_,
                       المؤسسة_الأصلية = s.etabOrig_trans_,
                       مؤسسةçالإستقبال = s.etabRecep_trans_,
                       المديرية = s.direc_orig_recep_trans_,
                       تاريخ_التحويل = s.dt_trans_,
                       نوع_التحويل = s.typ_trans_,

                   }

               ).OrderBy(o => o.تاريخ_التحويل).OrderBy(oo=>oo.رمز_مسار).ToList();

            if (pont.Count()==0 | St_trans.Count()==0)
            {
                MessageBox.Show("لم تجلب الحركية ");
            }
            else
            {

                dataGridView1.DataSource = St_trans;

                btn_show_trans_ent.BackColor = Color.LightGreen;
                btn_show_trans_all.BackColor = Color.LightGreen;
                btn_show_trans_quit.BackColor = Color.LightGreen;
                btn_show_trans_pont.BackColor = Color.Green;
                btn_show_trans_pont0.BackColor = Color.LightGreen;
                btn_trans_athers.BackColor = Color.LightGreen;
            }

           

        }

        private void btn_show_trans_pont0_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            StudentsListDataContext stdc = new StudentsListDataContext();

            var pont = stdc.Transactions.GroupBy(x => x.massar_trans_)
                                      .Where(g => g.Count() > 1)
                                      .Select(y => new { Element = y.Key });

          
            
            var st = stdc.StudentListUpdates.Select(s => new {massar= s.cMassar_Up } );
         

            var St_trans = stdc.Transactions.Where(w => pont.Select(s => s.Element).Contains(w.massar_trans_)& st.Select(ss=>ss.massar).Contains(w.massar_trans_)).Select(s =>
                     new
                     {
                         رمز_مسار = s.massar_trans_,
                         اسم_التلميذ = s.fname_trans_ + " " + s.lname_trans_,
                         الحركية = s.part_entr_trans_ == 1 ? "وافد" : "مغادر",
                         المستوى = s.niveau_trans_,
                         المؤسسة_الأصلية = s.etabOrig_trans_,
                         مؤسسةçالإستقبال = s.etabRecep_trans_,
                         المديرية = s.direc_orig_recep_trans_,
                         تاريخ_التحويل = s.dt_trans_,
                         نوع_التحويل = s.typ_trans_,

                     }

               ).OrderBy(o => o.تاريخ_التحويل).OrderBy(oo => oo.رمز_مسار).ToList();

            

            if(pont.Count() == 0 | st.Count() == 0)
            {
                MessageBox.Show("لم تجلب الحركية أو اللوائح المحينة أو هما معا");
            }
            else
            {

                dataGridView1.DataSource = St_trans;
                btn_show_trans_ent.BackColor = Color.LightGreen;
                btn_show_trans_all.BackColor = Color.LightGreen;
                btn_show_trans_quit.BackColor = Color.LightGreen;
                btn_show_trans_pont.BackColor = Color.LightGreen;
                btn_show_trans_pont0.BackColor = Color.Green;
                btn_trans_athers.BackColor = Color.LightGreen;
            }
           
        }

        private void btn_trans_athers_Click(object sender, EventArgs e)
        {

            StudentsListDataContext stdc = new StudentsListDataContext();
            var stUp = stdc.StudentListUpdates.Where(w => w.gresa_Up == Tools.Globals.GRESA).Select(s => new { cm = s.cMassar_Up, fn = s.firstName_Up, ln = s.lastName_Up, n = s.niveau_Up }).ToList();
            var stPr = stdc.StudentListPrimaires.Where(w => w.gresa_Pr == Tools.Globals.GRESA).Select(s => new { cm = s.cMassar_Pr, fn = s.firstName_Pr, ln = s.lastName_Pr, n = s.niveau_Pr }).ToList();
            var stEntr = stdc.Transactions.Where(w => w.gresa_trans == Tools.Globals.GRESA && w.part_entr_trans_ == 1).Select(s => new { cm = s.massar_trans_, fn = s.fname_trans_, ln = s.lname_trans_, n = s.niveau_trans_ }).ToList();
            var stQuit = stdc.Transactions.Where(w => w.gresa_trans == Tools.Globals.GRESA && w.part_entr_trans_ == -1).Select(s => new { cm = s.massar_trans_, fn = s.fname_trans_, ln = s.lname_trans_, n = s.niveau_trans_ }).ToList();

            stPr.AddRange(stEntr);
            stUp.AddRange(stQuit);

            var St_others = (from p in stPr
                             where !stUp.Contains(p) && !stQuit.Contains(p)
                             where !(from u in stUp select u.cm).Contains(p.cm) & !(from q in stQuit select q.cm).Contains(p.cm)

                             select new
                             {
                                 رمز_مسار = p.cm,
                                 الإسم = p.fn + " " + p.ln,
                                 المستوى = p.n
                             }
                             ).ToList();

            // var St_others = stPr.Except(stUp).ToList();

            if (stUp.Count() == 0 | stPr.Count() == 0 | stEntr.Count() == 0 | stQuit.Count() == 0)
            {
                MessageBox.Show("لم تجلب الحركية أو لوائح التلاميذ ");
            }
            else
            {

                dataGridView1.DataSource = St_others;

                btn_show_trans_ent.BackColor = Color.LightGreen;
                btn_show_trans_all.BackColor = Color.LightGreen;
                btn_show_trans_quit.BackColor = Color.LightGreen;
                btn_show_trans_pont.BackColor = Color.LightGreen;
                btn_show_trans_pont0.BackColor = Color.LightGreen;
                btn_trans_athers.BackColor = Color.Green;
            }




        }

        private void btn_trans_export_Click(object sender, EventArgs e)
        {
            try
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
        
                
             //worksheet.Name =lbl_export.Text ;
            // storing header part in Excel  
            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value != null ? dataGridView1.Rows[i].Cells[j].Value.ToString() : "";
                }
            }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StudentsListDataContext stdc = new StudentsListDataContext();
            try
            {int lblent= stdc.Transactions.Where(w => w.part_entr_trans_ == 1 & w.gresa_trans == Tools.Globals.GRESA).Count();
                int lblpart = stdc.Transactions.Where(w => w.part_entr_trans_ == -1 & w.gresa_trans == Tools.Globals.GRESA).Count();
                int lblmel = stdc.StudentListUpdates.Where(w => w.genre_Up == "ذكر" & w.gresa_Up == Tools.Globals.GRESA).Count();
                int lblfemel = stdc.StudentListUpdates.Where(w => w.genre_Up == "أنثى" & w.gresa_Up == Tools.Globals.GRESA).Count();
                int lblup = stdc.StudentListUpdates.Where(w => w.gresa_Up == Tools.Globals.GRESA).Count();
                int lblpr = stdc.StudentListPrimaires.Where(w => w.gresa_Pr == Tools.Globals.GRESA).Count();
                lbl_entrants.Text = lblent!=0? lblent.ToString():"#";
                lbl_partants.Text = lblpart!=0? lblpart.ToString():"#";
                lbl_nb_st_mel.Text = lblmel!=0? lblmel.ToString(): "#";
                lbl_nb_st_femel.Text = lblfemel!=0? lblfemel.ToString() : "#";
                lbl_nb_st_up.Text = lblup!=0? lblup.ToString(): "#";
                lbl_nb_st_pr.Text = lblpr!=0? lblpr.ToString(): "#";

                //*****
                var stUp = stdc.StudentListUpdates.Select(s => new { cm = s.cMassar_Up, fn = s.firstName_Up, ln = s.lastName_Up, n = s.niveau_Up }).ToList();
                var stPr = stdc.StudentListPrimaires.Select(s => new { cm = s.cMassar_Pr, fn = s.firstName_Pr, ln = s.lastName_Pr, n = s.niveau_Pr }).ToList();
                var stEntr = stdc.Transactions.Where(w => w.part_entr_trans_ == 1).Select(s => new { cm = s.massar_trans_, fn = s.fname_trans_, ln = s.lname_trans_, n = s.niveau_trans_ }).ToList();
                var stQuit = stdc.Transactions.Where(w => w.part_entr_trans_ == -1).Select(s => new { cm = s.massar_trans_, fn = s.fname_trans_, ln = s.lname_trans_, n = s.niveau_trans_ }).ToList();

                stPr.AddRange(stEntr);
                stPr = stPr.Distinct().ToList();
                int lblabond = (from p in stPr
                                where !stUp.Contains(p) & !stQuit.Contains(p)
                                // where !(from u in stUp select u.cm).Contains(p.cm) & !(from q in stQuit select q.cm).Contains(p.cm)

                                select new
                                {
                                    رمز_مسار = p.cm,
                                    الإسم = p.fn + " " + p.ln,
                                    المستوى = p.n
                                }
                                 ).Count();
                lbl_abondants.Text = lblpart != 0? lblabond.ToString() : "#";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
          
        }

       
    }
}
