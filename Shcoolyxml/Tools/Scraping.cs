using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schooly.Tools
{
    class Scraping
    {
        internal int etab = 0;

        internal void OpenSelenium(string url, EdgeDriver drv)
        {

            EdgeDriverService service = EdgeDriverService.CreateDefaultService();

            service.HideCommandPromptWindow = true;
            drv.Navigate().GoToUrl(url);
        }

        internal void Login(string username, string password, EdgeDriver drv)
        {
            Thread.Sleep(3000);
            try
            {
             
                drv.FindElement(By.Id("UserName")).SendKeys(username); //Thread.Sleep(3000);
                drv.FindElement(By.Id("Password")).SendKeys(password); //Thread.Sleep(3000);
                drv.FindElement(By.Id("btnSubmit")).Click();
            }
            catch (Exception ex)
            {
                Scraping sc = new Scraping();
                sc.CloseSelenium(drv);

                MessageBox.Show(ex.Message);

            }

        }

        internal bool TestAccount(EdgeDriver drv, int etab0 )
        {
            etab = etab0;
            if (drv.Url == "https://massar.men.gov.ma/Account")
            {
                if (drv.Title == "Choix section")
                {
                    drv.Manage().Window.Maximize();
                    IWebElement select_etab = drv.FindElement(By.XPath("/html/body/div/div/div[1]/div/div/div[" + etab0 + "]/a"));
                    select_etab.Click(); Thread.Sleep(500);
                    return true;
                }
                else
                    return false;
            }
            if (drv.Url == "https://massar.men.gov.ma/General/Modules")
            {
                drv.Manage().Window.Maximize();
                return true;
            }
            

            else
                return false;
        }


        internal void CloseSelenium(EdgeDriver drv)
        {
            drv.Quit();
        }

        internal void SelectOption(string dropdwnId, string opt, EdgeDriver drv)
        {

            dropdwnId = dropdwnId.Trim();
            opt = opt.Trim();
            IWebElement webel = drv.FindElement(By.Id(dropdwnId));

            SelectElement op_primaire = new SelectElement(webel);

            op_primaire.SelectByText(opt);


            Thread.Sleep(200);


        }
        public void DownloadEdgeDriver()
        {
            string edgePath = @"C:\EdgeFolder";
            string filePath = Path.Combine(edgePath, "edgeversion.txt");

            if (File.Exists(filePath))
            {

            }
            else
            {
                if (!Directory.Exists(edgePath))
                {
                    Directory.CreateDirectory(edgePath);

                }

                using (File.Create(filePath)) { }

            }



            //*****************
            System.Diagnostics.FileVersionInfo info = null;
            string version = null;
            string drivername = null;
            // string tmpfolder = @"c:\temp\edgeversion.txt";

            //if (!File.Exists(tmpfolder))
            //         File.Create(tmpfolder + "edgeversion.txt").Close();

            if (Environment.Is64BitOperatingSystem)
            {
                info = FileVersionInfo.GetVersionInfo(@"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe");
                drivername = "edgedriver_win64.zip";
            }
            else
            {
                info = FileVersionInfo.GetVersionInfo(@"C:\Program Files\Microsoft\Edge\Application\msedge.exe");
                drivername = "edgedriver_win32.zip";
            }

            version = info.FileVersion;
            // string current = File.ReadAllText(edgePath + "edgeversion.txt").ToString();
            string current = File.ReadAllText(filePath).ToString();
            // string driverfolder = @"c:\temp";
            if (version != current)
            {
                if (File.Exists(edgePath + "\\*.zip"))
                    File.Delete(edgePath + "\\*.zip");
                if (File.Exists(edgePath + "\\msedgedriver.exe"))
                    File.Delete(edgePath + "\\msedgedriver.exe");

                using (var client = new WebClient())
                {
                    client.DownloadFile("https://msedgedriver.azureedge.net/" + version + "/" + drivername, edgePath + "\\" + drivername);
                }
                if (File.Exists(edgePath + "\\msedgedriver.exe"))
                    File.Delete(edgePath + "\\msedgedriver.exe");
                if (Directory.Exists(edgePath + "\\Driver_Notes"))
                    Directory.Delete(edgePath + "\\Driver_Notes", true);
                ZipFile.ExtractToDirectory(edgePath + "\\" + drivername, edgePath + "\\");

                // File.WriteAllText(edgePath + "edgeversion.txt", version);
                File.WriteAllText(filePath, version);
            }

        }

    }

    class ScrapTransaction
    {
        Thread th;
        EdgeDriver drv;
       

        internal void ScrapTrans()
        {
            string edgeDriverExecutablePath = Path.Combine(Directory.GetCurrentDirectory(), "msedgedriver");
            EdgeDriverService edgeDriverService = EdgeDriverService.CreateDefaultService( edgeDriverExecutablePath);
            edgeDriverService.HideCommandPromptWindow = true;
            EdgeOptions edgeOptions = new EdgeOptions();
            drv = new EdgeDriver(edgeDriverService, edgeOptions);
            try
            {
                //using (drv = new EdgeDriver(edgeDriverService, edgeOptions))
                //{
               
                    // Your Selenium code here
                    th = new Thread(ResultTrans);
                    if (!th.IsAlive)
                    {
                        th.Start();
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
                    ScrapTrans();
                }
                else
                {
                    // If the exception is not related to version compatibility, rethrow the exception
                    throw;
                }
            }
           
        }

        private void ResultTrans()
        {
          
            EtablissementDataContext et = new EtablissementDataContext();
            int nbet =Convert.ToInt16(et.InfoEtabs.Where(w => w.gresa_info == Tools.Globals.GRESA).Select(s => s.cardN_info).FirstOrDefault());
            Scraping sc = new Scraping();

          //  //You can also specify chromedriver.exe path dircly ex: C:/MyProject/Project/drivers

          //  string path = @"c:\temp";//Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

          //  //Creates the ChomeDriver object, Executes tests on Google Chrome

          // drv = new EdgeDriver(path );

          ////  drv = new EdgeDriver();


            sc.OpenSelenium("https://massar.men.gov.ma/Account", drv);
            Thread.Sleep(3000);
            string usr = Properties.Settings.Default.usrMassar;
            string pass = Properties.Settings.Default.passMassar;
            sc.Login(usr, pass, drv);

            if (sc.TestAccount(drv, nbet))
            {
                List_transitions(drv);
            }
            else
            {
                MessageBox.Show("فشل الدخول", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void List_transitions(EdgeDriver drv)
        {
          
            drv.Manage().Window.Maximize();
            drv.Navigate().GoToUrl("https://massar.men.gov.ma/RentreeScolaire/Mobilite/ListeDesTransferts");

            EtablissementDataContext pth = new EtablissementDataContext();
            StudentsListDataContext std = new StudentsListDataContext();

            //var sqlCommand = String.Format("TRUNCATE TABLE {0}", "Transaction");
            //std.ExecuteCommand(sqlCommand);




            //  std.SubmitChanges();
            List<Transaction> tr = new List<Transaction>();
            var classes = (from cl in pth.pathclasses select cl).ToList();

            var nbT = classes.Select(t => t.typeEnseign_path).Distinct().ToList();
            var nbC = classes.Select(c => c.cycle_path).Distinct().ToList();
            var nbN = classes.Select(n => n.niveau_path).Distinct().ToList();
            var nbCl = classes.Select(cl => cl.classe_path).Distinct().ToList();
            Scraping sc = new Scraping();
            foreach (var t in nbT)
            {
                sc.SelectOption("TypeEnseignement", t.Trim(), drv);
                foreach (var c in nbC)
                {
                    var cy_in_typ = classes.Where(ty => ty.typeEnseign_path.Equals(t) && ty.cycle_path.Equals(c));
                    if (cy_in_typ.Any(k => k.cycle_path.Equals(c)))
                    {
                        sc.SelectOption("Cycle", c.Trim(), drv);
                        foreach (var n in nbN)
                        {
                            var niv_in_cy = classes.Where(cyc => cyc.cycle_path.Equals(c) && cyc.niveau_path.Equals(n));
                            if (niv_in_cy.Any(l => l.niveau_path.Equals(n)))
                            {
                                sc.SelectOption("Niveau", n.Trim(), drv);
                                drv.FindElement(By.Id("btnSearch")).Click(); Thread.Sleep(3000);
                                for (int j = 2; j < 4; j++)
                                {
                                    IWebElement tab = drv.FindElement(By.XPath("//*[@id=\"tabs-0\"]/li[" + j + "]"));
                                    tab.Click(); Thread.Sleep(3000);
                                    IList<IWebElement> tbls = drv.FindElements(By.ClassName("table"));
                                    IList<IWebElement> tds = tbls[j - 1].FindElements(By.TagName("td"));

                                    if (tds.Count > 0)
                                    {
                                        for (int i = 0; i < tds.Count; i = i + 8)
                                        {
                                            bool containsInt = tds[i].Text.Any(char.IsDigit);
                                            if (containsInt)
                                            {


                                                tr.Add(new Transaction()
                                                {
                                                    //  massar_trans_id_= tds[i].Text.Trim()+"_"+tds[i + 3].Text.Trim(),
                                                    massar_trans_ = tds[i].Text.Trim(),
                                                    fname_trans_ = tds[i + 1].Text.Trim(),
                                                    lname_trans_ = tds[i + 2].Text.Trim(),
                                                    dt_trans_ = DateTime.ParseExact(tds[i + 3].Text.Trim(), "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture).Date,
                                                    typ_trans_ = tds[i + 4].Text.Trim(),
                                                    etabOrig_trans_ = tds[i + 5].Text.Trim(),
                                                    etabRecep_trans_ = tds[i + 6].Text.Trim(),
                                                    direc_orig_recep_trans_ = tds[i + 7].Text.Trim(),
                                                    part_entr_trans_ = j == 2 ? -1 : 1,
                                                    niveau_trans_ = n,
                                                    gresa_trans = Tools.Globals.GRESA
                                                });

                                            }
                                        }
                                    }
                                }
                            }



                        }
                    }

                }
            }

            sc.CloseSelenium(drv);
            try
            {
               
                std.Transactions.InsertAllOnSubmit(tr);
                std.SubmitChanges();

              
                MessageBox.Show("تم استيراد الحركية بنجاح");
            }
            catch (Exception ex)
            {
                sc.CloseSelenium(drv);
                MessageBox.Show(ex.Message);
            }
           
        }
      
    }
}
