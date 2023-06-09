using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;

namespace Schooly.Reports
{
    public partial class Frm_repport_test : Form
    {
        private string selectedppr;
        private string rpt;

       
        public Frm_repport_test(string selectedppr, string rpt)
        {
            this.selectedppr = selectedppr;
            this.rpt = rpt;
            InitializeComponent();
        }
        private string getRdlcpath(string rdlc)
        {
           
            return System.IO.Path.Combine(Environment.GetFolderPath(
                     Environment.SpecialFolder.ApplicationData), "rdlc\\" + rdlc + ".rdlc");
        }
        private void Frm_repport_test_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();

            EmployeeDataContext edc = new EmployeeDataContext();
            EtablissementDataContext etedc = new EtablissementDataContext();
         
            if (rpt == "print_certif_ar")
            {
                var etabInfo = (from etin in etedc.InfoEtabs
                                select new
                                {
                                    accad = etin.academieAr_info,
                                    direc = etin.directionAr_info,
                                    commu = etin.comuneAr_info,
                                    etab = etin.etabNameAr_info,
                                    tel = etin.phone_info

                                }).FirstOrDefault();
                var emp = (from emD in edc.Emp_Datas
                           where emD.ppr_dat == selectedppr
                           join emA in edc.Emp_Acts on emD.ppr_dat equals emA.ppr_act
                             
                           join sitf in edc.sitfams on emD.SIT_FAM equals sitf.Sit_Fam
                           join cad in edc.cadres on emD.CD_CADRE equals cad.CD_CADRE
                           join gra in edc.grades on emD.CD_GRADE equals gra.CD_GRADE
                          
                           join fon in edc.fonctions on emA.CD_FONC equals fon.CD_Fonc
                           
                           join matiere in edc.disciplines on emD.CD_DISCIP equals matiere.CD_Discip


                           select new
                           {

                               adress = emD.ADRESSE,
                               nameAR = emD.NOMA + "  " + emD.PRENOMA,
                               nameFR = emD.NOML + "  " + emD.PRENOML,
                               sitfa = sitf.LA_SitFam,
                               cadre = cad.LA_CADRE,
                               grade = gra.LA_GRADE,
                               naissance = (new DateTime(Convert.ToInt32(emD.AN_NAIS), Convert.ToInt32(emD.MOIS_NAIS), Convert.ToInt32(emD.JOUR_NAIS))).ToShortDateString(),
                               decipli = matiere.LA_DISCIP,
                               cin = emD.CINA + emD.CINN,
                               encetab = emA.DT_AFF_ETAB.Value.ToShortDateString(),
                               dt_recrut = emD.DATE_REC.Value.ToShortDateString(),
                             
                               fonc = fon.LA_Fonc,
                               //cy
                           }).FirstOrDefault();


                reportViewer1.Reset();
                reportViewer1.LocalReport.ReportPath =getRdlcpath( "Report_cert_AR");

                ReportParameter newReport1 = new ReportParameter("rp_ppr", selectedppr);
                ReportParameter newReport2 = new ReportParameter("rp_nameAr", emp.nameAR);
                ReportParameter newReport3 = new ReportParameter("rp_adress", emp.adress);
                ReportParameter newReport4 = new ReportParameter("rp_sitfam", emp.sitfa);

                ReportParameter newReport5 = new ReportParameter("rp_nameFr", emp.nameFR);
                ReportParameter newReport6 = new ReportParameter("rp_etab", etabInfo.etab);
                ReportParameter newReport7 = new ReportParameter("rp_academie", etabInfo.accad);
                ReportParameter newReport8 = new ReportParameter("rp_direction", etabInfo.direc);

                ReportParameter newReport10 = new ReportParameter("rp_tel_Admin", etabInfo.tel);
                ReportParameter newReport11 = new ReportParameter("rp_naiss", emp.naissance);
                ReportParameter newReport12 = new ReportParameter("rp_cadre", emp.grade);

                ReportParameter newReport13 = new ReportParameter("rp_fonc", emp.fonc);
                ReportParameter newReport14 = new ReportParameter("rp_descip", emp.decipli);
                ReportParameter newReport15 = new ReportParameter("rp_enc_etab", emp.encetab);
                ReportParameter newReport16 = new ReportParameter("rp_cin", emp.cin);
                ReportParameter newReport17 = new ReportParameter("rp_date_recut", emp.dt_recrut);



                reportViewer1.LocalReport.SetParameters(newReport1);
                reportViewer1.LocalReport.SetParameters(newReport2);
                reportViewer1.LocalReport.SetParameters(newReport3);
                reportViewer1.LocalReport.SetParameters(newReport4);

                reportViewer1.LocalReport.SetParameters(newReport5);
                reportViewer1.LocalReport.SetParameters(newReport6);
                reportViewer1.LocalReport.SetParameters(newReport7);
                reportViewer1.LocalReport.SetParameters(newReport8);

                reportViewer1.LocalReport.SetParameters(newReport10);
                reportViewer1.LocalReport.SetParameters(newReport11);
                reportViewer1.LocalReport.SetParameters(newReport12);

                reportViewer1.LocalReport.SetParameters(newReport13);
                reportViewer1.LocalReport.SetParameters(newReport14);
                reportViewer1.LocalReport.SetParameters(newReport15);
                reportViewer1.LocalReport.SetParameters(newReport16);
                reportViewer1.LocalReport.SetParameters(newReport17);

                this.reportViewer1.RefreshReport();


                //this.reportViewer1.LocalReport.PrintToPrinter();
                //this.Close();

            }
            if (rpt == "print_certif_fr")
            {
                var etabInfo = (from etin in etedc.InfoEtabs
                                select new
                                {
                                    accad = etin.academieFr_info,
                                    direc = etin.directionFr_info,
                                    commu = etin.comuneFr_info,
                                    etab = etin.etabNameFr_info,
                                    tel = etin.phone_info

                                }).FirstOrDefault();
                var emp = (from emD in edc.Emp_Datas
                           where emD.ppr_dat == selectedppr
                           join emA in edc.Emp_Acts on emD.ppr_dat equals emA.ppr_act
                           join sitf in edc.sitfams on emD.SIT_FAM equals sitf.Sit_Fam
                           join cad in edc.cadres on emD.CD_CADRE equals cad.CD_CADRE
                           join gra in edc.grades on emD.CD_GRADE equals gra.CD_GRADE
                           join fon in edc.fonctions on emA.CD_FONC equals fon.CD_Fonc
                           join matiere in edc.disciplines on emD.CD_DISCIP equals matiere.CD_Discip


                           select new
                           {

                               adress = emD.ADRESSE,
                               nameAR = emD.NOMA + "  " + emD.PRENOMA,
                               nameFR = emD.NOML + "  " + emD.PRENOML,
                               sitfa = sitf.LL_SitFam,
                               cadre = cad.LL_CADRE,
                               grade = gra.LL_GRADE,
                               naissance = (new DateTime(Convert.ToInt32(emD.AN_NAIS), Convert.ToInt32(emD.MOIS_NAIS), Convert.ToInt32(emD.JOUR_NAIS))).ToShortDateString(),
                               decipli = matiere.LA_DISCIP,
                               cin = emD.CINA + emD.CINN,
                               encetab = emA.DT_AFF_ETAB.Value.ToShortDateString(),
                               dt_recrut = emD.DATE_REC.Value.ToShortDateString(),
                               fonc = fon.LL_FONC,
                           }).FirstOrDefault();


                reportViewer1.Reset();
                reportViewer1.LocalReport.ReportPath =getRdlcpath( "Report_cert_FR");

                ReportParameter newReport1 = new ReportParameter("rp_ppr", selectedppr);
                ReportParameter newReport2 = new ReportParameter("rp_nameAr", emp.nameAR);
                ReportParameter newReport3 = new ReportParameter("rp_adress", emp.adress);
                ReportParameter newReport4 = new ReportParameter("rp_sitfam", emp.sitfa);
                ReportParameter newReport5 = new ReportParameter("rp_nameFr", emp.nameFR);
                ReportParameter newReport6 = new ReportParameter("rp_etab", etabInfo.etab);
                ReportParameter newReport7 = new ReportParameter("rp_academie", etabInfo.accad);
                ReportParameter newReport8 = new ReportParameter("rp_direction", etabInfo.direc);

                ReportParameter newReport10 = new ReportParameter("rp_tel_Admin", etabInfo.tel);
                ReportParameter newReport11 = new ReportParameter("rp_naiss", emp.naissance);
                ReportParameter newReport12 = new ReportParameter("rp_cadre", emp.grade);

                ReportParameter newReport13 = new ReportParameter("rp_fonc", emp.fonc);
                ReportParameter newReport14 = new ReportParameter("rp_descip", emp.decipli);
                ReportParameter newReport15 = new ReportParameter("rp_enc_etab", emp.encetab);
                ReportParameter newReport16 = new ReportParameter("rp_cin", emp.cin);
                ReportParameter newReport17 = new ReportParameter("rp_date_recut", emp.dt_recrut);



                reportViewer1.LocalReport.SetParameters(newReport1);
                reportViewer1.LocalReport.SetParameters(newReport2);
                reportViewer1.LocalReport.SetParameters(newReport3);
                reportViewer1.LocalReport.SetParameters(newReport4);

                reportViewer1.LocalReport.SetParameters(newReport5);
                reportViewer1.LocalReport.SetParameters(newReport6);
                reportViewer1.LocalReport.SetParameters(newReport7);
                reportViewer1.LocalReport.SetParameters(newReport8);

                reportViewer1.LocalReport.SetParameters(newReport10);
                reportViewer1.LocalReport.SetParameters(newReport11);
                reportViewer1.LocalReport.SetParameters(newReport12);

                reportViewer1.LocalReport.SetParameters(newReport13);
                reportViewer1.LocalReport.SetParameters(newReport14);
                reportViewer1.LocalReport.SetParameters(newReport15);
                reportViewer1.LocalReport.SetParameters(newReport16);
                reportViewer1.LocalReport.SetParameters(newReport17);

                this.reportViewer1.RefreshReport();


              //  this.reportViewer1.LocalReport.PrintToPrinter();
              //  this.Close();


            }

          
        }

        private void ptb_print_Click(object sender, EventArgs e)
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
            printDoc.DefaultPageSettings.PaperSize = new PaperSize("A4", 210, 297);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    public static class LocalReportExtensions
    {
        public static void PrintToPrinter(this LocalReport report)
        {
            PageSettings pageSettings = new PageSettings();
            pageSettings.PaperSize = report.GetDefaultPageSettings().PaperSize;
            pageSettings.Landscape = report.GetDefaultPageSettings().IsLandscape;
            pageSettings.Margins = report.GetDefaultPageSettings().Margins;
            //**********************
            PrinterSettings printerSettings = new PrinterSettings();

            IEnumerable<PaperSize> paperSizes = printerSettings.PaperSizes.Cast<PaperSize>();

            PaperSize sizeA4 = paperSizes.First<PaperSize>(size => size.Kind == PaperKind.A4); // setting paper size to A4 size

            PageSetupDialog pageSetupDialog = new PageSetupDialog();

            pageSetupDialog.PageSettings = new PageSettings() { PaperSize = sizeA4 };

            //******************
            Print(report, pageSettings);
        }

        public static void Print(this LocalReport report, PageSettings pageSettings)
        {
            string deviceInfo =
                $@"<DeviceInfo>
                    <OutputFormat>EMF</OutputFormat>
                    <StartPage>1</StartPage>
                    <EndPage>1</EndPage>
                    <PageWidth>{pageSettings.PaperSize.Width * 100}in</PageWidth>
                    <PageHeight>{pageSettings.PaperSize.Height * 100}in</PageHeight>
                    <MarginTop>{pageSettings.Margins.Top * 100}in</MarginTop>
                    <MarginLeft>{pageSettings.Margins.Left * 100}in</MarginLeft>
                    <MarginRight>{pageSettings.Margins.Right * 100}in</MarginRight>
                    <MarginBottom>{pageSettings.Margins.Bottom * 100}in</MarginBottom>
                </DeviceInfo>";
            Warning[] warnings;
            var streams = new List<Stream>();
            var pageIndex = 0;
            report.Render("Image", deviceInfo,
                (name, fileNameExtension, encoding, mimeType, willSeek) =>
                {
                    MemoryStream stream = new MemoryStream();
                    streams.Add(stream);
                    return stream;
                }, out warnings);
            foreach (Stream stream in streams)
                stream.Position = 0;
            if (streams == null || streams.Count == 0)
                throw new Exception("No stream to print.");
            using (PrintDocument printDocument = new PrintDocument())
            {
                printDocument.DefaultPageSettings = pageSettings;
                if (!printDocument.PrinterSettings.IsValid)
                    throw new Exception("Can't find the default printer.");
                else
                {
                    printDocument.PrintPage += (sender, e) =>
                    {
                        Metafile pageImage = new Metafile(streams[pageIndex]);
                        Rectangle adjustedRect = new Rectangle(e.PageBounds.Left - (int)e.PageSettings.HardMarginX, e.PageBounds.Top - (int)e.PageSettings.HardMarginY, e.PageBounds.Width, e.PageBounds.Height);
                        e.Graphics.FillRectangle(Brushes.White, adjustedRect);
                        e.Graphics.DrawImage(pageImage, adjustedRect);
                        pageIndex++;
                        e.HasMorePages = (pageIndex < streams.Count);
                        e.Graphics.DrawRectangle(Pens.Red, adjustedRect);
                    };
                    printDocument.EndPrint += (Sender, e) =>
                    {
                        if (streams != null)
                        {
                            foreach (Stream stream in streams)
                                stream.Close();
                            streams = null;
                        }
                    };
                    printDocument.Print();
                }
            }
        }
    }
}
