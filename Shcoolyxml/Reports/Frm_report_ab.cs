using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Schooly.Tools;
using System.Drawing.Printing;

namespace Schooly.Reports
{
    public partial class Frm_report_ab : Form
    {
        int id;
        string typAb;
        public Frm_report_ab(int id, string ab)
        {
            this.id = id;
            this.typAb = ab;
            InitializeComponent();
        }

        private string getRdlcpath(string rdlc)
        {
           
            return System.IO.Path.Combine(Environment.GetFolderPath(
            Environment.SpecialFolder.ApplicationData), "rdlc\\" + rdlc + ".rdlc");
         
        }

        private void GetRepport(string rpt,DataTable dt,string ds)
        {
            try
            {


                if (dt.Rows.Count > 0)
            {
                EtablissementDataContext edc = new EtablissementDataContext();
                string accad = edc.InfoEtabs.Where(w => w.gresa_info == Tools.Globals.GRESA).Select(s => s.academieAr_info).FirstOrDefault();
                string direct = edc.InfoEtabs.Where(w => w.gresa_info == Tools.Globals.GRESA).Select(s => s.directionAr_info).FirstOrDefault();
                string etabl = edc.InfoEtabs.Where(w => w.gresa_info == Tools.Globals.GRESA).Select(s => s.etabNameAr_info).FirstOrDefault();

                ReportParameter logo = new ReportParameter("logo", new Uri(Properties.Settings.Default.logoAR).AbsoluteUri, true);
                ReportParameter acca = new ReportParameter("acc", accad!=null?accad:"");
                ReportParameter dire = new ReportParameter("dir", direct!=null?direct:"");
                ReportParameter etab = new ReportParameter("eta", etabl!=null?etabl:"");
                ReportParameter[] infoEtab = new ReportParameter[] { logo, acca, dire, etab };

                //  this.reportViewer1.Reset();
                this.reportViewer1.RefreshReport();
                    // this.reportViewer1.LocalReport.EnableHyperlinks = true;
                  //  this.reportViewer1.LocalReport.ReportPath ="rdlc\\"+"rpt_"+ rpt + ".rdlc";

                    this.reportViewer1.LocalReport.ReportPath = getRdlcpath("rpt_" + typAb);

                    this.reportViewer1.LocalReport.EnableExternalImages = true;
                this.reportViewer1.LocalReport.SetParameters(infoEtab);

                this.reportViewer1.LocalReport.DataSources.Clear();

                this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource(ds, dt));
                this.reportViewer1.RefreshReport();

              //  this.reportViewer1.LocalReport.PrintToPrinter();
            }
                //   this.Close();
            }
            catch (Exception ex)
            {
                this.Close();
                MessageBox.Show(ex.Message);

            }
        }

        private void Frm_report_ab_Load(object sender, EventArgs e)
        {
            if (typAb == "dem_d_malad")
            {
                try
                {

               
                //// TODO: This line of code loads data into the 'employeeDataSet.dem_malad' table. You can move, or remove it, as needed.
                //this.dem_maladTableAdapter.Fill(this.employeeDataSet.dem_malad, id);
                //this.reportViewer1.RefreshReport();
                //****************************************
                DataTable dt = GetDt_d_malad();
                
                    EtablissementDataContext edc = new EtablissementDataContext();
                    string accad = edc.InfoEtabs.Where(w => w.gresa_info == Tools.Globals.GRESA).Select(s => s.academieAr_info).FirstOrDefault();
                    string direct = edc.InfoEtabs.Where(w => w.gresa_info == Tools.Globals.GRESA).Select(s => s.directionAr_info).FirstOrDefault();
                    string etabl = edc.InfoEtabs.Where(w => w.gresa_info == Tools.Globals.GRESA).Select(s => s.etabNameAr_info).FirstOrDefault();
                    ReportParameter logo = new ReportParameter("logo", new Uri(Properties.Settings.Default.logoAR).AbsoluteUri, true);
                    ReportParameter acca = new ReportParameter("acc", accad);
                    ReportParameter dire = new ReportParameter("dir", direct);
                    ReportParameter etab = new ReportParameter("eta", etabl);
                    ReportParameter[] infoEtab = new ReportParameter[] { logo, acca, dire, etab };

                    DataTable dt1 = GetSPResult1();
                    // this.reportViewer1.LocalReport.ReportPath = "rpt_dem_d_malad.rdlc";
                   
                    this.reportViewer1.LocalReport.ReportPath = getRdlcpath("rpt_"+typAb);

                   
                    this.reportViewer1.LocalReport.EnableExternalImages = true;
                    this.reportViewer1.LocalReport.SetParameters(infoEtab);

                    this.reportViewer1.LocalReport.DataSources.Clear();

                    this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", dt));
                   
                        this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt1));
                  

                    this.reportViewer1.RefreshReport();

                //    this.reportViewer1.LocalReport.PrintToPrinter();
                
                //this.Close();
                }
                catch (Exception ex)
                {
                    this.Close();
                    MessageBox.Show(ex.Message);
                }
            }
            if(typAb == "recu_certif_d_malad")
            {
                try
                {
                    GetRepport( typAb, GetDt_d_malad(), "DataSet1");
                }
                catch (Exception ex)
                {

                    this.Close();
                    MessageBox.Show(ex.Message);
                }
                
            }
            if (typAb == "istinaf_d_malad")
            {
                try
                {


                    GetRepport(typAb, GetDt_d_malad(), "DataSet1");
            }
                catch (Exception ex)
            {

                this.Close();
                MessageBox.Show(ex.Message);
            }
        }
            if (typAb == "istifsar_d_bidon")
            {
                try
                {

               
                GetRepport( typAb, GetDt_d_malad(), "DataSet1");
                }
                catch (Exception ex)
                {

                    this.Close();
                    MessageBox.Show(ex.Message);
                }
            }
            if (typAb == "istifsar_rr")
            {
                try
                {


                    GetRepport( typAb, GetDt_rr(), "DataSet1");
                }
                catch (Exception ex)
                {

                    this.Close();
                    MessageBox.Show(ex.Message);
                }
            }
            if (typAb == "istifsar_ss")
            {
                try
                {


                    GetRepport( typAb, GetDt_ss(), "DataSet1");
                }
                catch (Exception ex)
                {

                    this.Close();
                    MessageBox.Show(ex.Message);
                }
            }
            if (typAb == "dem_d_istitna")
            {
                //// TODO: This line of code loads data into the 'employeeDataSet.dem_malad' table. You can move, or remove it, as needed.
                //this.dem_maladTableAdapter.Fill(this.employeeDataSet.dem_malad, id);
                //this.reportViewer1.RefreshReport();
                //****************************************
                try
                {
                DataTable dt = GetDt_d_malad();
               
                    EtablissementDataContext edc = new EtablissementDataContext();
                    string accad = edc.InfoEtabs.Where(w => w.gresa_info == Tools.Globals.GRESA).Select(s => s.academieAr_info).FirstOrDefault();
                    string direct = edc.InfoEtabs.Where(w => w.gresa_info == Tools.Globals.GRESA).Select(s => s.directionAr_info).FirstOrDefault();
                    string etabl = edc.InfoEtabs.Where(w => w.gresa_info == Tools.Globals.GRESA).Select(s => s.etabNameAr_info).FirstOrDefault();

                    DataTable dt1 = GetSPResult1();
                    ReportParameter logo = new ReportParameter("logo", new Uri(Properties.Settings.Default.logoAR).AbsoluteUri, true);
                    ReportParameter acca = new ReportParameter("acc", accad!=null?accad:"");
                    ReportParameter dire = new ReportParameter("dir", direct!= null? direct:"");
                    ReportParameter etab = new ReportParameter("eta", etabl!=null? etabl:"");
                    ReportParameter[] infoEtab = new ReportParameter[] { logo, acca, dire, etab };

                  //  this.reportViewer1.LocalReport.ReportPath = "rpt_dem_d_istitna.rdlc";


                    this.reportViewer1.LocalReport.ReportPath = getRdlcpath("rpt_" + typAb);
                    this.reportViewer1.LocalReport.EnableExternalImages = true;
                    this.reportViewer1.LocalReport.SetParameters(infoEtab);

                    this.reportViewer1.LocalReport.DataSources.Clear();

                    this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", dt1));
                    this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));

                    this.reportViewer1.RefreshReport();

                    //this.reportViewer1.LocalReport.PrintToPrinter();

                    //this.Close();
                }
                catch (Exception ex)
                {
                    this.Close();
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private DataTable GetDt_d_malad()
        {
            EmployeeDataContext edc = new EmployeeDataContext();

            var absc = (from ab in edc.absence_day_emps
                        where ab.Id == id && ab.regle_ap==true
                        join ed in edc.Emp_Datas on ab.ppr_ab equals ed.ppr_dat
                        join ea in edc.Emp_Acts on ab.ppr_ab equals ea.ppr_act
                        join g in edc.grades on ed.CD_GRADE equals g.CD_GRADE
                        join f in edc.fonctions on ea.CD_FONC equals f.CD_Fonc

                        select new
                        {  id= ab.Id,
                          ppr=  ab.ppr_ab,
                          nmjrs=  ab.nm_jours_ab,
                           debut= ab.debut_ab.Value.Date,
                           fin= ab.fin_ab.Value.Date,
                          nom=  ed.NOMA,
                           prenom= ed.PRENOMA,
                          grd=  g.LA_GRADE,
                          fonc=  f.LA_Fonc,
                          doct=ab.nomDocteur_ab,
                          adress=ed.ADRESSE,
                          typ=ab.type_ab,
                          cin=ed.CINA+ed.CINN,
                          nomll=ed.NOML,
                          prenomll=ed.PRENOML
                        }
                       ).First();

         
            DataTable dt = new DataTable();
          


            dt.Columns.Add("ppr", typeof(System.String));
            dt.Columns.Add("nbjrs", typeof(System.Int32));
            dt.Columns.Add("deb", typeof(System.DateTime));
            dt.Columns.Add("fin", typeof(System.DateTime));
            dt.Columns.Add("nom", typeof(System.String));
            dt.Columns.Add("grad", typeof(System.String));
            dt.Columns.Add("fonc", typeof(System.String));
            dt.Columns.Add("docteur", typeof(System.String));
            dt.Columns.Add("type", typeof(System.String));
            dt.Columns.Add("adress", typeof(System.String));
            dt.Columns.Add("cin", typeof(System.String));
            dt.Columns.Add("noml", typeof(System.String));

            dt.Rows.Add(absc.ppr, absc.nmjrs, absc.debut, absc.fin, absc.nom+""+ absc.prenom, absc.grd, absc.fonc,absc.doct, absc.typ, absc.adress, absc.cin,absc.nomll+" "+absc.prenomll);
           
            return dt;
        }
        private DataTable GetSPResult1()
        {
            EmployeeDataContext edc = new EmployeeDataContext();

            DateTime thisDay =(DateTime) edc.absence_day_emps.Where(w => w.Id == id).Select(s => s.debut_ab).First().Value.Date;

            var docteurs = (from ab in edc.absence_day_emps
                            where ab.Id != id && ab.ppr_ab == edc.absence_day_emps.Where(w=>w.Id==id & w.regle_ap==true ).Select(s=>s.ppr_ab).First() & ab.debut_ab.Value.Date<thisDay
                             
                            select new
                            {
                              doc=ab.nomDocteur_ab,
                              typ=ab.type_ab,
                              jrs=  ab.nm_jours_ab,
                              deb=  ab.debut_ab,
                              fin=  ab.fin_ab,
                               
                            }
                           ).ToList();

          
          
            DataTable dt2 = new DataTable();

            dt2.Columns.Add("doc", typeof(System.String));       
            dt2.Columns.Add("nbjrs2", typeof(System.Int32));
            dt2.Columns.Add("deb2", typeof(System.DateTime));
            dt2.Columns.Add("fin2", typeof(System.DateTime));
           




            foreach (var qItem in docteurs)
            {
                string typ_doc = qItem.doc != "" ? qItem.doc : qItem.typ;

                dt2.Rows.Add(typ_doc, qItem.jrs, qItem.deb, qItem.fin);

            }
            //EmployeeDataContext.dem_malad().clone();
            return dt2;
        }

        private DataTable GetDt_rr()
        {
            EmployeeDataContext edc = new EmployeeDataContext();

            var absc = (from ab in edc.retard_emps
                        where ab.Id == id && ab.regle_ret == true
                        join ed in edc.Emp_Datas on ab.ppr_ret equals ed.ppr_dat
                        join ea in edc.Emp_Acts on ab.ppr_ret equals ea.ppr_act
                        join g in edc.grades on ed.CD_GRADE equals g.CD_GRADE
                        join f in edc.fonctions on ea.CD_FONC equals f.CD_Fonc

                        select new
                        {
                            id = ab.Id,
                            ppr = ab.ppr_ret,
                            nmjrs = ab.nb_minut_ret,
                            debut = ab.debut_ret.Value.Date,
                            fin =DateTime.Now,
                            nom = ed.NOMA,
                            prenom = ed.PRENOMA,
                            grd = g.LA_GRADE,
                            fonc = f.LA_Fonc,
                            doct = "",
                            adress = ed.ADRESSE,
                            typ = "",
                            cin = ed.CINA + ed.CINN,
                            nomll = ed.NOML,
                            prenomll = ed.PRENOML
                        }
                       ).First();


            DataTable dt = new DataTable();



            dt.Columns.Add("ppr", typeof(System.String));
            dt.Columns.Add("nbjrs", typeof(System.Int32));
            dt.Columns.Add("deb", typeof(System.DateTime));
            dt.Columns.Add("fin", typeof(System.DateTime));
            dt.Columns.Add("nom", typeof(System.String));
            dt.Columns.Add("grad", typeof(System.String));
            dt.Columns.Add("fonc", typeof(System.String));
            dt.Columns.Add("docteur", typeof(System.String));
            dt.Columns.Add("type", typeof(System.String));
            dt.Columns.Add("adress", typeof(System.String));
            dt.Columns.Add("cin", typeof(System.String));
            dt.Columns.Add("noml", typeof(System.String));

            dt.Rows.Add(absc.ppr, absc.nmjrs, absc.debut, absc.fin, absc.nom + "" + absc.prenom, absc.grd, absc.fonc, absc.doct, absc.typ, absc.adress, absc.cin, absc.nomll + " " + absc.prenomll);

            return dt;
        }

        private DataTable GetDt_ss()
        {
            EmployeeDataContext edc = new EmployeeDataContext();

            var absc = (from ab in edc.absence_seance_emps
                        where ab.Id == id && ab.regle_ap == true
                        join ed in edc.Emp_Datas on ab.ppr_ab equals ed.ppr_dat
                        join ea in edc.Emp_Acts on ab.ppr_ab equals ea.ppr_act
                        join g in edc.grades on ed.CD_GRADE equals g.CD_GRADE
                        join f in edc.fonctions on ea.CD_FONC equals f.CD_Fonc

                        select new
                        {
                            id = ab.Id,
                            ppr = ab.ppr_ab,
                            nmjrs = ab.nb_seance_ab,
                            debut = ab.debut_ab.Value,
                            fin = DateTime.Now,
                            nom = ed.NOMA,
                            prenom = ed.PRENOMA,
                            grd = g.LA_GRADE,
                            fonc = f.LA_Fonc,
                            doct = ab.seance_ab,
                            adress = ed.ADRESSE,
                            typ = "",
                            cin = ed.CINA + ed.CINN,
                            nomll = ed.NOML,
                            prenomll = ed.PRENOML
                        }
                       ).First();


            DataTable dt = new DataTable();



            dt.Columns.Add("ppr", typeof(System.String));
            dt.Columns.Add("nbjrs", typeof(System.Int32));
            dt.Columns.Add("deb", typeof(System.DateTime));
            dt.Columns.Add("fin", typeof(System.DateTime));
            dt.Columns.Add("nom", typeof(System.String));
            dt.Columns.Add("grad", typeof(System.String));
            dt.Columns.Add("fonc", typeof(System.String));
            dt.Columns.Add("docteur", typeof(System.String));
            dt.Columns.Add("type", typeof(System.String));
            dt.Columns.Add("adress", typeof(System.String));
            dt.Columns.Add("cin", typeof(System.String));
            dt.Columns.Add("noml", typeof(System.String));

            dt.Rows.Add(absc.ppr, absc.nmjrs, absc.debut, absc.fin, absc.nom + "" + absc.prenom, absc.grd, absc.fonc, absc.doct, absc.typ, absc.adress, absc.cin, absc.nomll + " " + absc.prenomll);

            return dt;
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            this.reportViewer1.PrintDialog();
            PageSetupDialog setupDlg = new PageSetupDialog();
            PrintDocument printDoc = new PrintDocument();
            setupDlg.Document = printDoc;
            setupDlg.AllowMargins = false;
            setupDlg.AllowOrientation = false;
            setupDlg.AllowPaper = false;
            setupDlg.AllowPrinter = false;
            setupDlg.Reset();
            printDoc.DefaultPageSettings.PaperSize = new PaperSize("A4",210,297);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}

