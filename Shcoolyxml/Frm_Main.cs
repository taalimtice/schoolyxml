using Schooly.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schooly
{
    public partial class Frm_Main : Form
    {
        //private Frm_Setting frmSetting;
        //private Frm_Trans_Couriers FrmTransCouriers;
      
       
        public Frm_Main()
        {
            InitializeComponent();
            CustomizeDesing();
          
           
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {

            Models.ImportStudents im = new Models.ImportStudents();
            im.PopulateCBSelectEtab(cb_subMenu_SelectEtab);
            OpenChildForm(new Forms.Frm_zero());



        }



        private  void CustomizeDesing()
        {
            pnl_subMenu_CC.Visible = false;
            pnl_subMenu_Couriers.Visible = false;
            pnl_subMenu_Data.Visible = false;
            pnl_subMenu_Emplyees.Visible = false;
            pnl_subMenu_Students.Visible = false;
            pnl_subMenu_Finance.Visible = false;
            pnl_subMenu_VieScol.Visible = false;
            pnl_subMenu_Emplois.Visible = false;
            pnl_subMenu_Setting.Visible = false;
        }
        private void HideSubmenu()
        {
            if (pnl_subMenu_CC.Visible == true)
            {
                pnl_subMenu_CC.Visible = false;
            }
            if (pnl_subMenu_Couriers.Visible == true)
            {
                pnl_subMenu_Couriers.Visible = false;
            }
            if (pnl_subMenu_Data.Visible == true)
            {
                pnl_subMenu_Data.Visible = false;
            }
            if (pnl_subMenu_Emplyees.Visible == true)
            {
                pnl_subMenu_Emplyees.Visible = false;
            }
            if (pnl_subMenu_Students.Visible == true)
            {
                pnl_subMenu_Students.Visible = false;
            }
            if (pnl_subMenu_Finance.Visible == true)
            {
                pnl_subMenu_Finance.Visible = false;
            }
            if (pnl_subMenu_VieScol.Visible == true)
            {
                pnl_subMenu_VieScol.Visible = false;
            }
            if (pnl_subMenu_Emplois.Visible == true)
            {
                pnl_subMenu_Emplois.Visible = false;
            }
            if (pnl_subMenu_Setting.Visible == true)
            {
                pnl_subMenu_Setting.Visible = false;
            }
        }
        private void ShowSubmenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                HideSubmenu();
                submenu.Visible = true;
            }
        }
        
        private Form acticeForm = null;
        private void OpenChildForm(Form childform)
        {
            if (acticeForm != null)
                acticeForm.Close();
            acticeForm = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            pnl_ChildForm.Controls.Add(childform);
            pnl_ChildForm.Tag = childform;
            childform.BringToFront();
            childform.Show();
            lbl_childForm.Text = childform.Name;
           
           
         

           

        }
        private void restartForm(string lbl)
        {
           
            if (lbl == "Frm_fet_import")
                OpenChildForm(new Forms.Frm_fet_import());
            if (lbl == "Frm_Greve")
                OpenChildForm(new Forms.Frm_Greve());
            if (lbl == "Frm_morasalat_niyaba")
                OpenChildForm(new Forms.Frm_morasalat_niyaba());
            if (lbl == "Frm_name_esise_fet")
                OpenChildForm(new Forms.Frm_name_esise_fet());
            //if (lbl == "Frm_print_data_emp")
            //    OpenChildForm(new Forms.Frm_print_data_emp());
            //if (lbl == "Frm_set_Scrap")
            //    OpenChildForm(new Forms.Frm_set_Scrap());
            if (lbl == "Frm_Trans_Couriers")
                OpenChildForm(new Forms.Frm_Trans_Couriers());
            if (lbl == "Frm_Emp_Fiche")
                OpenChildForm(new Pages.Frm_Emp_Fiche());
            if (lbl == "Frm_fet")
                OpenChildForm(new Pages.Frm_fet());
            if (lbl == "Frm_Statistic_new_list_st")
                OpenChildForm(new Pages.Frm_Statistic_new_list_st());
            if (lbl == "Frm_transaction")
                OpenChildForm(new Pages.Frm_transaction());
          

        }
       

        private void btn_subMenu_Data_Click(object sender, EventArgs e)
        {
            ShowSubmenu(pnl_subMenu_Data);
        }

        private void btn_subMenu_Emplyees_Click(object sender, EventArgs e)
        {
            ShowSubmenu(pnl_subMenu_Emplyees);
        }

        private void btn_subMenu_Students_Click(object sender, EventArgs e)
        {
            ShowSubmenu(pnl_subMenu_Students);
        }

        private void btn_subMenu_Finance_Click(object sender, EventArgs e)
        {
            ShowSubmenu(pnl_subMenu_Finance);
        }

        private void btn_subMenu_CC_Click(object sender, EventArgs e)
        {
            ShowSubmenu(pnl_subMenu_CC);
        }

        private void btn_subMenu_Couriers_Click(object sender, EventArgs e)
        {
            ShowSubmenu(pnl_subMenu_Couriers);
        }

        private void btn_subMenu_VieScol_Click(object sender, EventArgs e)
        {
            ShowSubmenu(pnl_subMenu_VieScol);
        }

        private void btn_subMenu_Emplois_Click(object sender, EventArgs e)
        {
            ShowSubmenu(pnl_subMenu_Emplois);
        }

        private void btn_subMenu_Setting_Click(object sender, EventArgs e)
        {
            ShowSubmenu(pnl_subMenu_Setting);
        }

        private void btn_subm_ListSt_Updte_Click(object sender, EventArgs e)
        {
            try
            {

           
            if (cb_subMenu_SelectEtab.Items.Count > 0)
            {
                var gresa = cb_subMenu_SelectEtab.GetItemText(cb_subMenu_SelectEtab.SelectedValue);
              
                if (gresa != null & gresa!=string.Empty)
                {
                    Models.ImportStudents imp = new Models.ImportStudents();
                    imp.ImportListStudentsUpdate();
                  
                   OpenChildForm(new Forms.Frm_zero());
                }
                else
                {
                    MessageBox.Show("لم تقم بإدخال رمز GRESA للمؤسسة");
                 
                    OpenChildForm(new Forms.Frm_Setting(this));
                   
                }

            }
            else
            {
                MessageBox.Show("قم بتعبئة إعدادات المؤسسة أولا");
               OpenChildForm(new Forms.Frm_Setting(this));
            }



            //****
            HideSubmenu();
            }
            catch (Exception ex)
            {
               
                    MessageBox.Show(ex.Message);
          
                  
              
               
            }
        }

        private void btn_Trans_Couriers_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_Trans_Couriers());
           
            HideSubmenu();
        }

        private void btn_subm_ListEmpl_xml_Click(object sender, EventArgs e)
        {
            try
            {

           
            Tools.Tools_XML ttx = new Tools.Tools_XML();
            string filepath = "";
            if (cb_subMenu_SelectEtab.Items.Count > 0)
            {
                var gresa = cb_subMenu_SelectEtab.GetItemText(cb_subMenu_SelectEtab.SelectedValue);

                if (gresa != null & gresa != string.Empty)


                    filepath = ttx.openFileXML("حدد ملف XML المستخرج من اوسايز");
                if (filepath != "")
                {
                    string xmlGresa = ttx.GetGresaEmployee(filepath);
                    if (xmlGresa.Equals(gresa))
                    {
                        ttx.GetEmployeesData(filepath);
                            OpenChildForm(new Forms.Frm_zero());
                        }
                    else
                    {
                        MessageBox.Show("رمز GRESA للمؤسسة الحالية لا يطابق لائحة الموظفين في هذا الملف، اختر ملفا آخر أو اختر مؤسسة أخرى أو عدل الرمز ");
                    }
                }
                

                
               
            }
            else
            {
                MessageBox.Show("لم تقم بإدخال رمز GRESA للمؤسسة");

              OpenChildForm(new Forms.Frm_Setting(this));

            }
        
          
            HideSubmenu();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btn_subm_Setting_Etab_Click(object sender, EventArgs e)
        {
             OpenChildForm(new Frm_Setting(this));
           
            HideSubmenu();
        }

        private void btn_subm_ListSt_Praim_Click(object sender, EventArgs e)
        {
            try
            {

          
            if (cb_subMenu_SelectEtab.Items.Count > 0)
            {
                var gresa = cb_subMenu_SelectEtab.GetItemText(cb_subMenu_SelectEtab.SelectedValue);

                if (gresa != null & gresa != string.Empty)
                {
                    Models.ImportStudents imp = new Models.ImportStudents();
                    imp.ImportListStudentsPrimaire();

                    OpenChildForm(new Forms.Frm_zero());
                }
                else
                {
                    MessageBox.Show("لم تقم بإدخال رمز GRESA للمؤسسة");

                    OpenChildForm(new Forms.Frm_Setting(this));

                }

            }
            else
            {
                MessageBox.Show("قم بتعبئة إعدادات المؤسسة أولا");
                OpenChildForm(new Forms.Frm_Setting(this));
            }



            //****
            HideSubmenu();
            }
            catch (Exception ex)
            {
               
                MessageBox.Show(ex.Message);
            }
        }
        public static bool FormIsOpen(Type frm_type)
        {
            return Application.OpenForms.Cast<Form>().Any(opFrm => opFrm.GetType() == frm_type);
        }
        private void cb_subMenu_SelectEtab_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tools.Globals.GRESA = cb_subMenu_SelectEtab.GetItemText(cb_subMenu_SelectEtab.SelectedValue);
            string tag0 =" School Moroccan's Organiser System SMOS (Schooly)";
            string tag = tag0 + " " +"GRESA: "+ Tools.Globals.GRESA;
            this.Text = tag;
            if (Tools.Globals.GRESA == string.Empty)
            {
                OpenChildForm(new Frm_Setting(this));
            }

            if (FormIsOpen(typeof(Frm_Setting)))
            {
                string Topass = cb_subMenu_SelectEtab.GetItemText(cb_subMenu_SelectEtab.SelectedValue);
                Frm_Setting.frmsettingInsance.lblSetting.Text = Topass;

            }
            if (FormIsOpen(typeof(Frm_zero)))
            {
                OpenChildForm(new Frm_zero());

            }
            else
            {
                restartForm(lbl_childForm.Text);
            }
           


           

        }

        private void btn_subm_St_statistics_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Pages.Frm_Statistic_new_list_st());
        }

        private void btn_subm_ListEmpl_scrap_Click(object sender, EventArgs e)
        {
            //string currentApplicationpath = Application.StartupPath;
            //string parentpath = Directory.GetParent(Directory.GetParent(currentApplicationpath).FullName).FullName;
            //string mypath = Path.GetFullPath(parentpath+ "\\Models");
            //MessageBox.Show(mypath);
            //Tools.Tools_XML xml = new Tools.Tools_XML();
            //xml.GetEmployeesData(mypath + "\\XML_emp.xml");

        }

        private void btn_subm_Empl_Profil_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Pages.Frm_Emp_Fiche());
        }

        private void btn_subm_Empl_certificat_Click(object sender, EventArgs e)
        {
            Forms.Frm_print_data_emp frmRepport = new Forms.Frm_print_data_emp();
            frmRepport.ShowDialog();
        }

        private void btn_subm_Empl_absence_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Frm_Abscence());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Frm_morasalat_niyaba());
        }

        private void btn_subm_TransSt_scrap_Click(object sender, EventArgs e)
        {
            StudentsListDataContext std = new StudentsListDataContext();
            EtablissementDataContext etdc = new EtablissementDataContext();

            IEnumerable<Transaction> Data = from item in std.Transactions where item.massar_trans_id_ != null && item.gresa_trans==Tools.Globals.GRESA select item;
            std.Transactions.DeleteAllOnSubmit(Data);

            std.SubmitChanges();
            //var sqlCommand = String.Format("TRUNCATE TABLE {0}", "Transaction");
            //std.ExecuteCommand(sqlCommand);
            var inf = (from i in etdc.InfoEtabs select i);
            if (inf.Count() > 0)
            {
                var pth = etdc.pathclasses.Where(w => w.greasa_path == Tools.Globals.GRESA).Select(s => s).ToArray();
                if (pth.Count() > 0)
                {
                   
                    Tools.ScrapTransaction sct = new Tools.ScrapTransaction();
                    if(Properties.Settings.Default.usrMassar!=string.Empty)
                    {
                        sct.ScrapTrans();
                        OpenChildForm(new Pages.Frm_transaction());
                    }
                    else
                    {
                        OpenChildForm(new Forms.Frm_set_Scrap());
                    }
                   
                }
                else
                {
                    MessageBox.Show("سيتم جلب مسارات الفصول أولا، بعدها أعد العملية مجددا");
                    Forms.Frm_set_Scrap fset = new Frm_set_Scrap();
                    fset.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("سيتم جلب معطيات المؤسسةأولا، بعدها أعد العملية مجددا");
                Forms.Frm_set_Scrap fset = new Frm_set_Scrap();
                fset.ShowDialog();
            }
        }

        private void btn_subm_St_Trans_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Pages.Frm_transaction());
        }

        private void btn_subm_Setting_Registration_Click(object sender, EventArgs e)
        {
            new FrmActivate().ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new frmAbout().ShowDialog();
        }

        private void pnl_subMenu_Finance_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_import_fet_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_fet_import());
        }

        private void btn_name_esise_fet_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_name_esise_fet());
        }

        private void pnl_ChildForm_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (pnl_ChildForm.Controls.Count == 0)
                OpenChildForm( new Forms.Frm_zero());
        }

        private void btn_list_controls_Click(object sender, EventArgs e)
        {
            new Forms.Frm_list_controls().ShowDialog();
        }

        private void btn_subm_St_Dem_Env_doc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Frm_req_docs_scool());
        }

        private void btn_subm_St_List_absence_Click(object sender, EventArgs e)
        {

        }

        private void btn_subm_info_waliy_Click(object sender, EventArgs e)
        {

        }

        private void btn_subm_Setting_PathClass_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_set_Scrap());
        }

        private void button43_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_exam());
        }
    }

 
}
