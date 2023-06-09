using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Schooly.Forms
{
    public partial class Frm_set_Scrap : Form
    {

        public Frm_set_Scrap()
        {
            InitializeComponent();
        }

        Thread th;
        EdgeDriver drv;
        string user = string.Empty;
        string pass = string.Empty;
        string gresaa = string.Empty;
        private void Frm_set_Scrap_Load(object sender, EventArgs e)
        {
            txt_pass.Text = Properties.Settings.Default.passMassar;
            txt_usr.Text = Properties.Settings.Default.usrMassar;

            txt_gresa.Text = Tools.Globals.GRESA;

            EtablissementDataContext et = new EtablissementDataContext();
            int card = Convert.ToInt16(et.InfoEtabs.Where(w=>w.gresa_info== Tools.Globals.GRESA).Select(s=>s.cardN_info).FirstOrDefault());
            if (card != 0)
            {
                cb_selectetab_in_card.SelectedIndex = 0;
                cb_selectetab_in_card.Visible = false;
                label5.Visible = false;
            }else
            {
                cb_selectetab_in_card.SelectedIndex = 0;
            }
           
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_pass.PasswordChar == '\0')
            {
                button2.BringToFront();
                txt_pass.PasswordChar = '*';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txt_pass.PasswordChar == '*')
            {
                button1.BringToFront();
                txt_pass.PasswordChar = '\0';
            }
        }

        private void btn_clrear_Click(object sender, EventArgs e)
        {
                 txt_pass.Clear();
                txt_usr.Clear();
                txt_gresa.Clear();
            

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

       
        private void btn_login_Click(object sender, EventArgs e)
        {
            string edgeDriverExecutablePath = Path.Combine(Directory.GetCurrentDirectory(), "msedgedriver");
            EdgeDriverService edgeDriverService = EdgeDriverService.CreateDefaultService(edgeDriverExecutablePath);
            edgeDriverService.HideCommandPromptWindow = true;
            EdgeOptions edgeOptions = new EdgeOptions();
            drv = new EdgeDriver(edgeDriverService, edgeOptions);
            try
            {
                //using (drv = new EdgeDriver(edgeDriverService, edgeOptions))
                //{
             
                // Your Selenium code here
                user = txt_usr.Text.Trim();
                pass = txt_pass.Text.Trim();
                gresaa = txt_gresa.Text.Trim();

                if (txt_gresa.Text.Trim() != "")
                {

                    if (txt_pass.Text != string.Empty)
                    {
                        th = new Thread(Result_setting);
                        if (!th.IsAlive) { th.Start(); }
                        this.Close();
                    }
                }
                else
                {
                    this.Close();
                    MessageBox.Show("أدخل رمز المؤسسة GRESA");

                }
                //}
            }
            catch (WebDriverException ex)
            {
                // Check if the exception message contains the version compatibility error
                if (ex.Message.Contains("only supports Microsoft Edge version"))
                {
                    Console.WriteLine("EdgeDriver is not compatible with the installed Edge browser. Downloading compatible version...");
                    Tools.Tools_scrap.DownloadCompatibleEdgeDriverAsync().Wait();
                    btn_login_Click( sender,  e);
                }
                else
                {
                    // If the exception is not related to version compatibility, rethrow the exception
                    throw;
                }
            }
            //****************
           

        }

        private void Result_setting()
        {
            EtablissementDataContext stdb = new EtablissementDataContext();
            int card = 0;
            int cardNb =Convert.ToInt16(stdb.InfoEtabs.Where(w => w.gresa_info == Tools.Globals.GRESA).Select(s => s.cardN_info).FirstOrDefault());
            Tools.Scraping sc = new Tools.Scraping();
            if (cardNb != 0)
            {
                card = cardNb;
            }
            else
            {
               
                card = Convert.ToInt16(cb_selectetab_in_card.GetItemText(cb_selectetab_in_card.SelectedItem));
            }


            sc.OpenSelenium("https://massar.men.gov.ma", drv);
            Thread.Sleep(3000);

           sc.Login(user, pass, drv);
         
            if (sc.TestAccount(drv,card))
            {

                Properties.Settings.Default.usrMassar = user;
                Properties.Settings.Default.passMassar = pass;
                Properties.Settings.Default.Save();

                getNextSelect();

                //*****************
                sc.CloseSelenium(drv);
          
                var etabs = (from inf in stdb.InfoEtabs select new { inf.etabNameAr_info, inf.gresa_info }).ToList();
                if (etabs.Count > 0)
                {
                   

                    txt_gresa.Text = Tools.Globals.GRESA;
                    Application.Restart();

                }
            }
            else
            {
                MessageBox.Show("فشل الدخول", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void getNextSelect()
        {
            drv.Navigate().GoToUrl("https://massar.men.gov.ma/General/SetCulture?culture=fr&Url=%2FGeneral%2FModules");
            Thread.Sleep(2000);

            //****************

            drv.FindElement(By.Id("CurrentEntite")).Click(); Thread.Sleep(500);

            IList<IWebElement> infoEtab_el = drv.FindElements(By.ClassName("form-control"));

            EtablissementDataContext stdb = new EtablissementDataContext();
            int card =Convert.ToInt16(stdb.InfoEtabs.Where(w => w.gresa_info == Tools.Globals.GRESA).Select(s => s.cardN_info).FirstOrDefault());

            InfoEtab ie = stdb.InfoEtabs.Where(w => w.gresa_info == gresaa).Select(s => s).First();
            try
            {

                ie.etabNameFr_info = infoEtab_el[3].Text;
                ie.comuneFr_info = infoEtab_el[2].Text;
                ie.directionFr_info = infoEtab_el[1].Text;
                ie.academieFr_info = infoEtab_el[0].Text;
                stdb.SubmitChanges();
            }
            catch (Exception ex)
            {
              
                MessageBox.Show(ex.Message);
            }

            //*************************
            drv.Navigate().GoToUrl("https://massar.men.gov.ma/General/SetCulture?culture=ar&Url=%2FGeneral%2FModules");
           
            Thread.Sleep(2000);

            drv.FindElement(By.Id("CurrentEntite")).Click(); Thread.Sleep(500);

             infoEtab_el = drv.FindElements(By.ClassName("form-control"));


            try
            {
                ie.etabNameAr_info = infoEtab_el[3].Text;
                ie.comuneAr_info = infoEtab_el[2].Text;
                ie.directionAr_info = infoEtab_el[1].Text;
                ie.academieAr_info = infoEtab_el[0].Text;
                if (card == 0)
                {
                    ie.cardN_info = Convert.ToInt16(cb_selectetab_in_card.GetItemText(cb_selectetab_in_card.SelectedItem));
                }
              
                stdb.SubmitChanges();
               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            //**********************
            drv.Navigate().GoToUrl("https://massar.men.gov.ma/RentreeScolaire/FicheEleve/ListeEleve");
            Thread.Sleep(2000);


            string annescol = drv.FindElements(By.ClassName("dropdown-toggle")).ToList()[1].Text;
            string EtabName = drv.FindElement(By.Id("CurrentEntite")).Text;
            string adminName = drv.FindElements(By.ClassName("name")).FirstOrDefault().Text;


            IWebElement tE_el = drv.FindElement(By.Id("TypeEnseignement"));
            IWebElement cy_el = drv.FindElement(By.Id("Cycle"));
            IWebElement Niv_el = drv.FindElement(By.Id("Niveau"));
            IWebElement Cl_el = drv.FindElement(By.Id("Classe"));

            SelectElement dropdown_typEn = new SelectElement(tE_el);
            SelectElement dropdown_cycl = new SelectElement(cy_el);
            SelectElement dropdown_niv = new SelectElement(Niv_el);
            SelectElement dropdown_cl = new SelectElement(Cl_el);

            //******

            IList<pathclasse> pc = new List<pathclasse>();
            IList<IWebElement> typ_opts = dropdown_typEn.Options;
            foreach (IWebElement te in typ_opts)
            {
                if (te.Text != "*")
                {
                    dropdown_typEn.SelectByText(te.Text); Thread.Sleep(200);
                    tE_el.Click(); Thread.Sleep(500);
                    IList<IWebElement> cycl_opts = dropdown_cycl.Options;
                    foreach (IWebElement cy in cycl_opts)
                    {
                        if (cy.Text != "*")
                        {
                            dropdown_cycl.SelectByText(cy.Text); Thread.Sleep(200);
                            cy_el.Click(); Thread.Sleep(500);
                            IList<IWebElement> niv_opts = dropdown_niv.Options;
                            foreach (IWebElement nv in niv_opts)
                            {
                                if (nv.Text != "*")
                                {
                                    dropdown_niv.SelectByText(nv.Text); Thread.Sleep(200);
                                    Niv_el.Click(); Thread.Sleep(500);
                                    IList<IWebElement> cl_opts = dropdown_cl.Options;


                                    // dropdown_cl.SelectByText(cl.Text); Thread.Sleep(200);
                                    foreach (IWebElement c in cl_opts)
                                    {
                                        if (c.Text != "*")
                                            pc.Add(new pathclasse
                                            {
                                                cl_pth_id= txt_gresa.Text+"_"+ c.Text,
                                                greasa_path = txt_gresa.Text,
                                                classe_path = c.Text,
                                                niveau_path = nv.Text,
                                                cycle_path = cy.Text,
                                                typeEnseign_path = te.Text,
                                                annescol_path = annescol,

                                            });
                                    }

                                }
                            }
                        }

                    }
                }
            }
            try
            {
                var todel = stdb.pathclasses;
                stdb.pathclasses.DeleteAllOnSubmit(todel);
                stdb.SubmitChanges();
                stdb.pathclasses.InsertAllOnSubmit(pc);
                stdb.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            Tools.Scraping sc = new Tools.Scraping();
            sc.DownloadEdgeDriver();
        }
      
       
    }
}
