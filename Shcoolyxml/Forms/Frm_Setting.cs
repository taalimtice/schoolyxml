using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schooly.Forms
{


    public partial class Frm_Setting : Form
    {
        Frm_Main frmmain;
        public static Frm_Setting frmsettingInsance;
        public Label lblSetting;

        public Frm_Setting()
        {
            InitializeComponent();

        }
        public Frm_Setting(Frm_Main frm)
        {
            InitializeComponent();
            frmmain = frm;
            frmsettingInsance = this;
            lblSetting = lbl_frmSetting;


        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newEtab()
        {
            lbl_save.Text = "new";
            btn_set_newEtab.Enabled = false;
            btn_set_updateEtab.Visible = false;
            btn_set_deleteEtab.Visible = false;
            btn_set_saveEtab.Visible = true;
            btn_set_return.Visible = true;
            ch_update_gresa.Visible = false;


            txt_set_academie.ReadOnly = false;
            txt_set_academie_fr.ReadOnly = false;
            txt_set_commune.ReadOnly = false;
            txt_set_commune_fr.ReadOnly = false;
            txt_set_direction.ReadOnly = false;
            txt_set_direction_fr.ReadOnly = false;
            txt_set_email.ReadOnly = false;
            txt_set_etabliss.ReadOnly = false;
            txt_set_etabliss_fr.ReadOnly = false;
            txt_set_gresa.ReadOnly = false;
            txt_set_phone.ReadOnly = false;
            rtxt_set_adress.ReadOnly = false;

            txt_set_gresa.Text = "";
            txt_set_academie.Text = "";
            txt_set_academie_fr.Text = "";
            txt_set_commune.Text = "";
            txt_set_commune_fr.Text = "";
            txt_set_direction.Text = "";
            txt_set_direction_fr.Text = "";
            txt_set_email.Text = "";
            txt_set_etabliss.Text = "";
            txt_set_etabliss_fr.Text = "";
            txt_set_phone.Text = "";
            rtxt_set_adress.Text = "";

            //*******forecolor
            txt_set_gresa.ForeColor = Color.Blue;
            txt_set_academie.ForeColor = Color.Blue;
            txt_set_academie_fr.ForeColor = Color.Blue;
            txt_set_commune.ForeColor = Color.Blue;
            txt_set_commune_fr.ForeColor = Color.Blue;
            txt_set_direction.ForeColor = Color.Blue;
            txt_set_direction_fr.ForeColor = Color.Blue;
            txt_set_email.ForeColor = Color.Blue;
            txt_set_etabliss.ForeColor = Color.Blue;
            txt_set_etabliss_fr.ForeColor = Color.Blue;
            txt_set_gresa.ForeColor = Color.Blue;
            txt_set_phone.ForeColor = Color.Blue;
            rtxt_set_adress.ForeColor = Color.Blue;
        }

        private void existEtab()
        {

            btn_set_return.Visible = false;
            btn_set_deleteEtab.Visible = true;
            btn_set_newEtab.Visible = true;
            btn_set_newEtab.Enabled = true;
            btn_set_updateEtab.Visible = true;
            btn_set_updateEtab.Enabled = true;
            ch_update_gresa.Visible = false;



            txt_set_gresa.ReadOnly = true;
            txt_set_academie.ReadOnly = true;
            txt_set_academie_fr.ReadOnly = true;
            txt_set_commune.ReadOnly = true;
            txt_set_commune_fr.ReadOnly = true;
            txt_set_direction.ReadOnly = true;
            txt_set_direction_fr.ReadOnly = true;
            txt_set_email.ReadOnly = true;
            txt_set_etabliss.ReadOnly = true;
            txt_set_etabliss_fr.ReadOnly = true;
            txt_set_gresa.ReadOnly = true;
            txt_set_phone.ReadOnly = true;
            rtxt_set_adress.ReadOnly = true;


            rtxt_set_adress.ForeColor = Color.Black;

        }
        private void updateEtab()
        {
            lbl_save.Text = "update";
            btn_set_newEtab.Visible = false;
            btn_set_updateEtab.Enabled = false;
            btn_set_deleteEtab.Visible = false;
            btn_set_saveEtab.Visible = true;
            btn_set_return.Visible = true;
            ch_update_gresa.Visible = true;


            txt_set_academie.ReadOnly = false;
            txt_set_academie_fr.ReadOnly = false;
            txt_set_commune.ReadOnly = false;
            txt_set_commune_fr.ReadOnly = false;
            txt_set_direction.ReadOnly = false;
            txt_set_direction_fr.ReadOnly = false;
            txt_set_email.ReadOnly = false;
            txt_set_etabliss.ReadOnly = false;
            txt_set_etabliss_fr.ReadOnly = false;
            txt_set_gresa.ReadOnly = true;
            txt_set_phone.ReadOnly = false;
            rtxt_set_adress.ReadOnly = false;

            //*******forecolor
            txt_set_gresa.ForeColor = Color.Green;
            txt_set_academie.ForeColor = Color.Green;
            txt_set_academie_fr.ForeColor = Color.Green;
            txt_set_commune.ForeColor = Color.Green;
            txt_set_commune_fr.ForeColor = Color.Green;
            txt_set_direction.ForeColor = Color.Green;
            txt_set_direction_fr.ForeColor = Color.Green;
            txt_set_email.ForeColor = Color.Green;
            txt_set_etabliss.ForeColor = Color.Green;
            txt_set_etabliss_fr.ForeColor = Color.Green;
            txt_set_gresa.ForeColor = Color.Green;
            txt_set_phone.ForeColor = Color.Green;
            rtxt_set_adress.ForeColor = Color.Green;


        }

        private void Frm_Setting_Load(object sender, EventArgs e)
        {
            // lblSetting.Text = Tools.Globals.GRESA!=null? Tools.Globals.GRESA:string.Empty;
            EtablissementDataContext etab = new EtablissementDataContext();
            var etabs = (from inf in etab.InfoEtabs select new { inf.gresa_info, inf.etabNameAr_info }).ToList();

            if (etabs.Count > 0)
            {
                existEtab();
                PopulateFrmSettinf(Tools.Globals.GRESA);

            }
            else
            {
                newEtab();
            }

        }
        private void btn_set_return_Click(object sender, EventArgs e)
        {
            EtablissementDataContext etab = new EtablissementDataContext();
            var etabs = (from inf in etab.InfoEtabs select new { inf.gresa_info, inf.etabNameAr_info }).ToList();

            if (etabs.Count > 0)
            {
                existEtab();
                PopulateFrmSettinf(Tools.Globals.GRESA);
                btn_set_saveEtab.Visible = false;

            }
            if (etabs.Count == 0)
            {

                newEtab();
                btn_set_saveEtab.Visible = false;
            }
            ch_update_gresa.Checked = false;
        }

        private void btn_set_saveEtab_Click(object sender, EventArgs e)
        {
            EtablissementDataContext etdt = new EtablissementDataContext();
            fetDataContext fdc = new fetDataContext();
            StudentsListDataContext stdc = new StudentsListDataContext();
            EmployeeDataContext emdc = new EmployeeDataContext();

            //*********** new etabb ****
            if (lbl_save.Text == "new")
            {
                var existEtab = (from exe in etdt.InfoEtabs where exe.gresa_info == txt_set_gresa.Text select exe.gresa_info).FirstOrDefault();

                if (existEtab == null)
                {
                    if (txt_set_etabliss.Text != string.Empty & txt_set_gresa.Text != string.Empty)
                    {
                        InfoEtab etab = new InfoEtab
                        {
                            gresa_info = txt_set_gresa.Text,
                            etabNameAr_info = txt_set_etabliss.Text,
                            etabNameFr_info = txt_set_etabliss_fr.Text,
                            comuneAr_info = txt_set_commune.Text,
                            comuneFr_info = txt_set_commune_fr.Text,
                            directionAr_info = txt_set_direction.Text,
                            directionFr_info = txt_set_direction_fr.Text,
                            academieAr_info = txt_set_academie.Text,
                            academieFr_info = txt_set_academie_fr.Text,
                            phone_info = txt_set_phone.Text,
                            email_info = txt_set_email.Text,
                            adress_info = rtxt_set_adress.Text
                        };
                        etdt.InfoEtabs.InsertOnSubmit(etab);




                        MessageBox.Show("لقد أضفت المؤسسة" + " " + txt_set_etabliss.Text + " " + "بنجاح");


                        etdt.SubmitChanges();
                        Models.ImportStudents im = new Models.ImportStudents();
                        im.PopulateCBSelectEtab(frmmain.cb_subMenu_SelectEtab);
                        PopulateFrmSettinf(Tools.Globals.GRESA);
                    }
                    else
                    {

                        MessageBox.Show("لم تدخل المؤسسة أو رمزها");

                    }
                }

                else
                {
                    MessageBox.Show("لا يمكن إدخال مؤسستين لهما نفس الرمز" + " " + "GRESA");
                }


            }
            //******** Update ***********
            if (lbl_save.Text == "update")
            {
                try
                {
                    txt_set_gresa.ReadOnly = false;
                    InfoEtab existEtabli = etdt.InfoEtabs.SingleOrDefault(x => x.gresa_info == Tools.Globals.GRESA);
                    if (ch_update_gresa.Checked == false && existEtabli != null)
                    {
                        // existEtabli.gresa_info = txt_set_gresa.Text;
                        existEtabli.etabNameAr_info = txt_set_etabliss.Text;
                        existEtabli.etabNameFr_info = txt_set_etabliss_fr.Text;
                        existEtabli.comuneAr_info = txt_set_commune.Text;
                        existEtabli.comuneFr_info = txt_set_commune_fr.Text;
                        existEtabli.directionAr_info = txt_set_direction.Text;
                        existEtabli.directionFr_info = txt_set_direction_fr.Text;
                        existEtabli.academieAr_info = txt_set_academie.Text;
                        existEtabli.academieFr_info = txt_set_academie_fr.Text;
                        existEtabli.phone_info = txt_set_phone.Text;
                        existEtabli.email_info = txt_set_email.Text;
                        existEtabli.adress_info = rtxt_set_adress.Text;

                        etdt.SubmitChanges();

                    }
                    if (ch_update_gresa.Checked)
                    {
                        if (txt_set_etabliss.Text != string.Empty & txt_set_gresa.Text != string.Empty)
                        {

                            //******* update gresa by new etab
                            var existEtab = (from exe in etdt.InfoEtabs where exe.gresa_info == txt_set_gresa.Text select exe.gresa_info).FirstOrDefault();
                            etdt.InfoEtabs.DeleteOnSubmit(existEtabli);
                            etdt.SubmitChanges();

                            InfoEtab etab = new InfoEtab
                            {
                                gresa_info = txt_set_gresa.Text,
                                etabNameAr_info = txt_set_etabliss.Text,
                                etabNameFr_info = txt_set_etabliss_fr.Text,
                                comuneAr_info = txt_set_commune.Text,
                                comuneFr_info = txt_set_commune_fr.Text,
                                directionAr_info = txt_set_direction.Text,
                                directionFr_info = txt_set_direction_fr.Text,
                                academieAr_info = txt_set_academie.Text,
                                academieFr_info = txt_set_academie_fr.Text,
                                phone_info = txt_set_phone.Text,
                                email_info = txt_set_email.Text,
                                adress_info = rtxt_set_adress.Text
                            };
                            etdt.InfoEtabs.InsertOnSubmit(etab);
                            etdt.SubmitChanges();


                            // emp
                            (from em in emdc.Emp_Acts
                             where em.CD_ETAB == lbl_oldGRESA.Text
                             select em).ToList()
                               .ForEach(x => x.CD_ETAB = txt_set_gresa.Text);
                            emdc.SubmitChanges();
                            // up
                            (from st in stdc.StudentListUpdates
                             where st.gresa_Up == lbl_oldGRESA.Text
                             select st).ToList()
                                .ForEach(x => x.gresa_Up = txt_set_gresa.Text);
                            // pr
                            (from st in stdc.StudentListPrimaires
                             where st.gresa_Pr == lbl_oldGRESA.Text
                             select st).ToList()
                                .ForEach(x => x.gresa_Pr = txt_set_gresa.Text);
                            stdc.SubmitChanges();
                            //tt
                            (from f in fdc.timeTables
                             where f.gresa_tt_fet == lbl_oldGRESA.Text
                             select f).ToList()
                                .ForEach(x => x.gresa_tt_fet = txt_set_gresa.Text);
                            //sub
                            (from f in fdc.subjects
                             where f.gresa_sub_fet == lbl_oldGRESA.Text
                             select f).ToList()
                               .ForEach(x => x.gresa_sub_fet = txt_set_gresa.Text);
                            //tech
                            (from f in fdc.techers
                             where f.gresa_tech_fet == lbl_oldGRESA.Text
                             select f).ToList()
                               .ForEach(x => x.gresa_tech_fet = txt_set_gresa.Text);
                            //el
                            (from f in fdc.elevesses
                             where f.gresa_el_fet == lbl_oldGRESA.Text
                             select f).ToList()
                               .ForEach(x => x.gresa_el_fet = txt_set_gresa.Text);
                            fdc.SubmitChanges();

                            Models.ImportStudents im = new Models.ImportStudents();
                            im.PopulateCBSelectEtab(frmmain.cb_subMenu_SelectEtab);
                            PopulateFrmSettinf(Tools.Globals.GRESA);
                        }





                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }





            }
            existEtab();
            PopulateFrmSettinf(Tools.Globals.GRESA);
            btn_set_saveEtab.Visible = false;

        }

        private void btn_set_newEtab_Click(object sender, EventArgs e)
        {
            // lbl_save.Text = "new";
            newEtab();

        }

        private void btn_set_updateEtab_Click(object sender, EventArgs e)
        {
            lbl_oldGRESA.Text = txt_set_gresa.Text.Trim();
            if (txt_set_etabliss.Text != string.Empty & txt_set_gresa.Text != string.Empty)
                updateEtab();


        }

        private void btn_set_deleteEtab_Click(object sender, EventArgs e)
        {
            string deletingEtab = txt_set_etabliss.Text;
            EtablissementDataContext etdt = new EtablissementDataContext();
            StudentsListDataContext stdc = new StudentsListDataContext();
            EmployeeDataContext emdc = new EmployeeDataContext();
            fetDataContext fdc = new fetDataContext();


            //InfoEtab existEtab = etdt.InfoEtabs.SingleOrDefault(x => x.gresa_info == frmmain.cb_subMenu_SelectEtab.GetItemText(frmmain.cb_subMenu_SelectEtab.SelectedValue));
            InfoEtab existEtab = etdt.InfoEtabs.SingleOrDefault(x => x.gresa_info == Tools.Globals.GRESA);

            if (existEtab != null)
            {
                DialogResult dialogResult = MessageBox.Show("أنت على وشك حذف مؤسسة" + " " + deletingEtab, "تحذيييير!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    etdt.InfoEtabs.DeleteOnSubmit(existEtab);
                    etdt.SubmitChanges();
                    //***********************
                    // data
                    var empdata = from d in emdc.Emp_Datas
                                  join a in emdc.Emp_Acts on d.ppr_dat equals a.ppr_act
                                  where a.CD_ETAB == Tools.Globals.GRESA
                                  select d;
                    emdc.Emp_Datas.DeleteAllOnSubmit(empdata);
                    // act
                    emdc.Emp_Acts.DeleteAllOnSubmit(emdc.Emp_Acts.Where(em => em.CD_ETAB == Tools.Globals.GRESA));
                    emdc.SubmitChanges();
                    // up
                    stdc.StudentListUpdates.DeleteAllOnSubmit(stdc.StudentListUpdates.Where(st => st.gresa_Up == Tools.Globals.GRESA));
                    // pr
                    stdc.StudentListPrimaires.DeleteAllOnSubmit(stdc.StudentListPrimaires.Where(st => st.gresa_Pr == Tools.Globals.GRESA));
                    stdc.SubmitChanges();
                    //tt
                    fdc.timeTables.DeleteAllOnSubmit(fdc.timeTables.Where(st => st.gresa_tt_fet == Tools.Globals.GRESA));
                    //sub
                    fdc.subjects.DeleteAllOnSubmit(fdc.subjects.Where(st => st.gresa_sub_fet == Tools.Globals.GRESA));
                    //tech
                    fdc.techers.DeleteAllOnSubmit(fdc.techers.Where(st => st.gresa_tech_fet == Tools.Globals.GRESA));
                    //el
                    fdc.elevesses.DeleteAllOnSubmit(fdc.elevesses.Where(st => st.gresa_el_fet == Tools.Globals.GRESA));
                    fdc.SubmitChanges();



                    //********************

                    Models.ImportStudents im = new Models.ImportStudents();
                    im.PopulateCBSelectEtab(frmmain.cb_subMenu_SelectEtab);
                    MessageBox.Show("تم حذف مؤسسة" + " " + deletingEtab + " " + "بنجاح");
                    PopulateFrmSettinf(lbl_frmSetting.Text);
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }

            }


        }

        private void PopulateFrmSettinf(string gre)
        {
            EtablissementDataContext etdt = new EtablissementDataContext();

            InfoEtab existEtabli = etdt.InfoEtabs.SingleOrDefault(x => x.gresa_info == gre);
            if (existEtabli != null)
            {
                txt_set_gresa.Text = existEtabli.gresa_info;
                txt_set_etabliss.Text = existEtabli.etabNameAr_info;
                txt_set_etabliss_fr.Text = existEtabli.etabNameFr_info;
                txt_set_commune.Text = existEtabli.comuneAr_info;
                txt_set_commune_fr.Text = existEtabli.comuneFr_info;
                txt_set_direction.Text = existEtabli.directionAr_info;
                txt_set_direction_fr.Text = existEtabli.directionFr_info;
                txt_set_academie.Text = existEtabli.academieAr_info;
                txt_set_academie_fr.Text = existEtabli.academieFr_info;
                txt_set_phone.Text = existEtabli.phone_info;
                txt_set_email.Text = existEtabli.email_info;
                rtxt_set_adress.Text = existEtabli.adress_info;
            }

        }

        private void lbl_frmSetting_TextChanged(object sender, EventArgs e)
        {
            existEtab();
            PopulateFrmSettinf(lbl_frmSetting.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            OpenFileDialog open = new OpenFileDialog();
            if (pictureBox1 != null)
            {
                open.Filter = "(*.jpg;*.png;*.jpeg | *.jpg;*.png;*.jpeg)";
                open.Multiselect = false;
                if (open.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(open.FileName);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    lbl_logo.Text = open.FileName;
                    btn_save_logo.Visible = true;

                }
            }
        }

        private void btn_save_logo_Click(object sender, EventArgs e)
        {
            //  string namep = Path.GetFileName(lbl_logo.Text);
            FileInfo namep = new FileInfo(lbl_logo.Text);
            System.IO.Directory.CreateDirectory(@"C:\Schooly Media");
            string pth = @"C:\Schooly Media" + @"\" + namep.Name;
            // string pth = Path.Combine("C:\\Schooly Media", namep.Name);


            Image a = pictureBox1.Image;
            a.Save(pth);

            if (rb_logo_ar.Checked)
            {
                Properties.Settings.Default.logoAR = pth;//Path.GetFullPath(pth);
                Properties.Settings.Default.Save();
            }
            if (rb_logo_fr.Checked)
            {
                Properties.Settings.Default.logoFR = pth; //Path.GetFullPath(pth);
                Properties.Settings.Default.Save();
            }
            btn_save_logo.Visible = false;
        }

        private void btn_set_Massar_Click(object sender, EventArgs e)
        {
            new Frm_set_Scrap().ShowDialog();
        }

        private void ch_update_gresa_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_update_gresa.Checked)
            {
                // lbl_oldGRESA.Text = txt_set_gresa.Text.Trim();
                txt_set_gresa.ReadOnly = false;
            }
            else
            {
                txt_set_gresa.ReadOnly = true;
            }
        }

        private void btn_show_eta_Click(object sender, EventArgs e)
        {
            Pages.Frm_show_etab frmShow = new Pages.Frm_show_etab();
            frmShow.ShowDialog();
        }

        private void btn_restAll_Click(object sender, EventArgs e)
        {
            StudentsListDataContext stdc = new StudentsListDataContext();
            EmployeeDataContext emdc = new EmployeeDataContext();
            EtablissementDataContext etdc = new EtablissementDataContext();
            fetDataContext fdc = new fetDataContext();

            int nbEtabs = etdc.InfoEtabs.Count();
            if (nbEtabs > 0)
            {
         
            txtResetall.Visible = true;
            lbl_resetAll.Visible = true;


            if (txtResetall.Text == "Reset All".ToLower().Trim())
            {
                txtResetall.Visible = true;
                lbl_resetAll.Visible = true;

                try
                {
                    this.Close();

                    stdc.StudentListPrimaires.DeleteAllOnSubmit(stdc.StudentListPrimaires);
                    stdc.StudentListUpdates.DeleteAllOnSubmit(stdc.StudentListUpdates);
                    stdc.SubmitChanges();
                    emdc.Emp_Acts.DeleteAllOnSubmit(emdc.Emp_Acts);
                    emdc.Emp_Datas.DeleteAllOnSubmit(emdc.Emp_Datas);
                    emdc.SubmitChanges();
                    etdc.InfoEtabs.DeleteAllOnSubmit(etdc.InfoEtabs);
                    etdc.SubmitChanges();
                    fdc.techers.DeleteAllOnSubmit(fdc.techers);
                    fdc.timeTables.DeleteAllOnSubmit(fdc.timeTables);
                    fdc.elevesses.DeleteAllOnSubmit(fdc.elevesses);
                    fdc.subjects.DeleteAllOnSubmit(fdc.subjects);
                    fdc.SubmitChanges();


                   

                    Models.ImportStudents im = new Models.ImportStudents();
                    im.PopulateCBSelectEtab(frmmain.cb_subMenu_SelectEtab);
                    PopulateFrmSettinf(Tools.Globals.GRESA);
                    MessageBox.Show("تم مسح جميع البيانات");

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

                    txtResetall.Text = "";
                    txtResetall.Visible = false;
                    lbl_resetAll.Visible = false;
                }
                else
                {
                    MessageBox.Show("أكتب العبارة كما هي ");
                    txtResetall.Text = "";
                }
            }
            else
            {
                MessageBox.Show("لا توجد بيانات");
            }
        }
    }
}
