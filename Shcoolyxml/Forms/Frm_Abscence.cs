using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schooly.Forms
{
    public partial class Frm_Abscence : Form
    {
        public Frm_Abscence()
        {
            InitializeComponent();
        }
        string gresa = Tools.Globals.GRESA;
        private void Frm_Abscence_Load(object sender, EventArgs e)
        {
            if (DateTime.Now.Hour > 8 | DateTime.Now.Hour < 14)
            {
                dtp_ab_s_1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
                dtp_ab_s_2.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
            }
            if (DateTime.Now.Hour > 14 | DateTime.Now.Hour < 18)
            {
                dtp_ab_s_1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 14, 0, 0);
                dtp_ab_s_2.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 14, 0, 0);
            }
            dtp_ab_today.Value = DateTime.Now;
            dtp_ab_days_1.Value = DateTime.Now;
            dtp_ab_days_2.Value = DateTime.Now;

            txt_ab_duree_days.Text = "";
            //txt_ab_duree_minutes.Text = "";

            EmployeeDataContext edc = new EmployeeDataContext();
            var employees = (from emD in edc.Emp_Datas
                             join emA in edc.Emp_Acts on emD.ppr_dat equals emA.ppr_act
                             where emA.CD_ETAB.Equals(gresa)
                             select new
                             {
                                 ppr = emD.ppr_dat,
                                 nom = emD.NOMA + " " + emD.PRENOMA
                             }).ToList();
            cb_emp_select_Ab.DataSource = new BindingSource(employees, null);
            cb_emp_select_Ab.DisplayMember = "nom";
            cb_emp_select_Ab.ValueMember = "ppr";


            if (cb_emp_select_Ab.Items.Count > 0)
                cb_emp_select_Ab.SelectedIndex = 0;
        }

        private void HidePanel1()
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;

            panel1.Size = panel1.MinimumSize;
            panel2.Size = panel2.MinimumSize;
            panel3.Size = panel3.MinimumSize;
        }
        private void HidePanel()
        {
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;

            panel4.Size = panel4.MinimumSize;
            panel5.Size = panel5.MinimumSize;
            panel6.Size = panel6.MinimumSize;
        }
        private void txt_ab_duree_days_TextChanged(object sender, EventArgs e)
        {
            ch_ab_s1.Checked = false;
            ch_ab_s2.Checked = false;
            ch_ab_s3.Checked = false;
            ch_ab_s4.Checked = false;
            txt_ab_duree_minutes.Clear();
            txt_ab_nb_seances.Clear();

            HidePanel1();
            //ch_ab_half_day.Checked = false;
            //int substrac = Convert.ToInt32(txt_ab_duree_days.Text);
            //if (substrac > 400 | substrac < 0) { txt_ab_duree_days.Text = ""; }

        }

        private void ch_ab_half_day_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_ab_half_day.Checked)
            {
                txt_ab_duree_minutes.Clear();
                txt_ab_nb_seances.Clear();
                rb_ab_matin.Visible = true;
                rb_ab_soir.Visible = true;
                // txt_ab_duree_days.Clear();
                txt_ab_duree_days.Text = "0.5";
            }
            if (ch_ab_half_day.Checked == false)
            {
                txt_ab_duree_days.Clear();
                rb_ab_matin.Visible = false;
                rb_ab_soir.Visible = false;
            }


        }

        private void txt_ab_nb_seances_TextChanged(object sender, EventArgs e)
        {
            txt_ab_duree_minutes.Clear();
            txt_ab_duree_days.Clear();
            ch_ab_half_day.Checked = false;
            if (txt_ab_nb_seances.Text != "")
            {

                lbl_ab_ret_se.Text = "ss";
                btn_save_ab_ret.Enabled = true;
            }


            HidePanel1();

        }
        private void txt_ab_duree_minutes_TextChanged(object sender, EventArgs e)
        {
            ch_ab_s1.Checked = false;
            ch_ab_s2.Checked = false;
            ch_ab_s3.Checked = false;
            ch_ab_s4.Checked = false;

            txt_ab_nb_seances.Clear();
            txt_ab_duree_days.Clear();
            ch_ab_half_day.Checked = false;
            if (txt_ab_duree_minutes.Text != "")
            {
                lbl_ab_ret_se.Text = "rr";
                btn_save_ab_ret.Enabled = true;
            }
            else
            {
                btn_save_ab_ret.Enabled = false;
            }

            HidePanel1();
        }

        private void btn_save_ab_ret_Click(object sender, EventArgs e)
        {

            txt_nom_doc.Enabled = false;
            if (cb_emp_select_Ab.Items.Count > 0)
            {
                EmployeeDataContext edc = new EmployeeDataContext();

                if (txt_ab_duree_days.Text != "")
                {
                    if (ch_ab_half_day.Checked)
                    {
                        absence_day_emp emp_ab_d = new absence_day_emp
                        {
                            ppr_ab = cb_emp_select_Ab.GetItemText(cb_emp_select_Ab.SelectedValue),
                            nm_jours_ab = Convert.ToDouble(txt_ab_duree_days.Text),
                            debut_ab = dtp_ab_days_1.Value,
                            fin_ab = dtp_ab_days_2.Value,
                            nomDocteur_ab = txt_nom_doc.Text,
                            justification_ab = txt_doc_excus.Text,
                            regle_ap = rb_ab_with_rule.Checked ? true : false,
                            ref_ab = txt_ref.Text,
                            type_ab = cb_ab_type.GetItemText(cb_ab_type.SelectedItem),
                            half_day_ab = rb_ab_matin.Checked ? "صباحا" : "مساء",
                            lblToPrint = lbl_ab_ret_se.Text

                        };
                        edc.absence_day_emps.InsertOnSubmit(emp_ab_d);
                        edc.SubmitChanges();
                        int NewID = emp_ab_d.Id;
                        lbl_Id_ab_ret.Text = NewID.ToString();
                        // lbl_ab_ret_se.Text = "d";

                        //  btn_doc_malad.Enabled = true;
                        // MessageBox.Show("تم حفظ الغياب بنجاح");
                    }
                    else
                    {
                        absence_day_emp emp_ab_d = new absence_day_emp
                        {
                            ppr_ab = cb_emp_select_Ab.GetItemText(cb_emp_select_Ab.SelectedValue),
                            nm_jours_ab = Convert.ToDouble(txt_ab_duree_days.Text),
                            debut_ab = dtp_ab_days_1.Value,
                            fin_ab = dtp_ab_days_2.Value,
                            nomDocteur_ab = txt_nom_doc.Text,
                            justification_ab = txt_doc_excus.Text,
                            regle_ap = rb_ab_with_rule.Checked ? true : false,
                            ref_ab = txt_ref.Text,
                            type_ab = cb_ab_type.GetItemText(cb_ab_type.SelectedItem),
                            lblToPrint = lbl_ab_ret_se.Text


                        };
                        edc.absence_day_emps.InsertOnSubmit(emp_ab_d);
                        edc.SubmitChanges();
                        int NewID = emp_ab_d.Id;
                        lbl_Id_ab_ret.Text = NewID.ToString();
                        // lbl_ab_ret_se.Text = "d";

                        //  btn_doc_malad.Enabled = true;


                    }
                }
                if (txt_ab_nb_seances.Text != "")
                {
                    absence_seance_emp emp_ab_s = new absence_seance_emp
                    {
                        ppr_ab = cb_emp_select_Ab.GetItemText(cb_emp_select_Ab.SelectedValue),
                        debut_ab=dtp_ab_today.Value,
                        justification_ab = txt_doc_excus.Text,
                        regle_ap = rb_ab_with_rule.Checked ? true : false,
                        ref_ab = txt_ref.Text,
                        nb_seance_ab = Convert.ToInt16(txt_ab_nb_seances.Text),
                        seance_ab = txt_ab_seances.Text,
                        half_day_ab = rb_ab_s_matin.Checked ? "صباحا" : "مساء",
                        lblToPrint = lbl_ab_ret_se.Text


                    };
                    edc.absence_seance_emps.InsertOnSubmit(emp_ab_s);
                    edc.SubmitChanges();
                    int NewID = emp_ab_s.Id;
                    lbl_Id_ab_ret.Text = NewID.ToString();
                    // lbl_ab_ret_se.Text = "ss";

                    // btn_doc_malad.Enabled = true;
                    //  MessageBox.Show("تم حفظ الغياب بنجاح");

                }
                if (txt_ab_duree_minutes.Text != "")
                {

                    retard_emp retard = new retard_emp
                    {
                        ppr_ret = cb_emp_select_Ab.GetItemText(cb_emp_select_Ab.SelectedValue),
                        nb_minut_ret = Convert.ToInt16(txt_ab_duree_minutes.Text),
                        debut_ret = dtp_ab_s_1.Value,
                        fin_ret = dtp_ab_s_2.Value,
                        regle_ret = rb_ab_with_rule.Checked ? true : false,
                        ref_ret = txt_ref.Text,
                        day_ret = dtp_ab_today.Value,
                        justification_ret = txt_doc_excus.Text,
                        lblToPrint = lbl_ab_ret_se.Text
                    };
                    edc.retard_emps.InsertOnSubmit(retard);
                    edc.SubmitChanges();

                    int NewID = retard.Id;
                    lbl_Id_ab_ret.Text = NewID.ToString();
                    //  lbl_ab_ret_se.Text = "rr";

                    //   btn_doc_malad.Enabled = true;
                    // MessageBox.Show("تم حفظ التأخر بنجاح");

                }
            }
            txt_nom_doc.Text = "";
            string tDB = lbl_ab_ret_se.Text;

            if (tDB == "d_malad") //| tDB == "s_malad")
            {
                panel1.Visible = true;
                panel1.BringToFront();
                panel2.Visible = false;
                panel3.Visible = false;

                panel2.Size = panel2.MinimumSize;
                panel3.Size = panel3.MinimumSize;
            }

            if (tDB == "d_bidon")//| tDB == "s_bidon")
            {
                panel3.Visible = true;
                panel3.BringToFront();
                panel2.Visible = false;
                panel1.Visible = false;

                panel2.Size = panel2.MinimumSize;
                panel1.Size = panel1.MinimumSize;

            }

            if (tDB == "d_istitna")//| tDB == "s_istitna")
            {
                panel2.Visible = true;
                panel2.BringToFront();
                panel3.Visible = false;
                panel1.Visible = false;

                panel1.Size = panel1.MinimumSize;
                panel3.Size = panel3.MinimumSize;
            }

            if (tDB == "rr" | tDB == "ss")
            {
                panel3.Visible = true;
                panel3.BringToFront();
                panel2.Visible = false;
                panel1.Visible = false;

                panel2.Size = panel2.MinimumSize;
                panel1.Size = panel1.MinimumSize;
            }
            if (tDB == "inkita")
            {

            }
            //************************
        }

        TimeSpan getDateDifference(DateTime date1, DateTime date2)
        {
            TimeSpan ts = date1 - date2;

            return ts;
        }

        private void dtp_ab_days_1_ValueChanged(object sender, EventArgs e)
        {
            ch_ab_half_day.Checked = false;
            DateTime dt1 = dtp_ab_days_1.Value.Date;
            DateTime dt2 = dtp_ab_days_2.Value.Date;

            TimeSpan difference = getDateDifference(dt2, dt1);
            double differenceInDays = difference.TotalDays + 1;
            txt_ab_duree_days.Text = differenceInDays.ToString();
            //if (differenceInDays > 400 | differenceInDays < 0) { txt_ab_duree_days.Text = ""; }

        }

        private void dtp_ab_days_2_ValueChanged(object sender, EventArgs e)
        {
            ch_ab_half_day.Checked = false;
            DateTime dt1 = dtp_ab_days_1.Value.Date;
            DateTime dt2 = dtp_ab_days_2.Value.Date;
            TimeSpan difference = getDateDifference(dt2, dt1);
            double differenceInDays = difference.TotalDays + 1;
            txt_ab_duree_days.Text = differenceInDays.ToString();
        }

        private void dtp_ab_s_1_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt1 = dtp_ab_s_1.Value;
            DateTime dt2 = dtp_ab_s_2.Value;
            TimeSpan difference = getDateDifference(dt2, dt1);
            double differenceInRet = difference.TotalMinutes;
            txt_ab_duree_minutes.Text = differenceInRet.ToString();




        }

        private void dtp_ab_s_2_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan difference = getDateDifference(dtp_ab_s_2.Value, dtp_ab_s_1.Value);
            double differenceInRet = difference.TotalMinutes;
            txt_ab_duree_minutes.Text = differenceInRet.ToString();



        }

        private void ch_ab_s1_CheckedChanged(object sender, EventArgs e)
        {
            //var checkedBoxes = tab_save_ab_ret.Controls.OfType<CheckBox>().Count(c => c.Checked);
            // txt_ab_nb_seances.Text = checkedBoxes.ToString();
            string haf = rb_ab_s_matin.Checked ? "صباحا" : "مساء";
            if (ch_ab_s1.Checked)
            {
                // txt_ab_seances.Text = txt_ab_nb_seances.Text != "" ? string.Concat(txt_ab_nb_seances.Text, " ", ("ح1_" + haf)) : ("ح1_" + haf);
                txt_ab_seances.Text += " " + ("ح1_" + haf);
                txt_ab_nb_seances.Text = txt_ab_nb_seances.Text != "" ? (Convert.ToInt16(txt_ab_nb_seances.Text) + 1).ToString() : "1";
            }
            if (ch_ab_s1.Checked == false)
            {
                txt_ab_seances.Text = txt_ab_seances.Text.Replace(("ح1_" + haf), "");
                txt_ab_nb_seances.Text = txt_ab_nb_seances.Text != "" ? (Convert.ToInt16(txt_ab_nb_seances.Text) - 1).ToString() : "";
            }
            if (txt_ab_nb_seances.Text == "0")
            { txt_ab_nb_seances.Text = ""; }
        }


        private void ch_ab_s2_CheckedChanged(object sender, EventArgs e)
        {

            string haf = rb_ab_s_matin.Checked ? "صباحا" : "مساء";
            if (ch_ab_s2.Checked)
            {
                //txt_ab_seances.Text = txt_ab_nb_seances.Text != "" ? string.Concat(txt_ab_nb_seances.Text, " ", ("ح2_" + haf)) : ("ح2_" + haf);
                txt_ab_seances.Text += " " + ("ح2_" + haf);
                txt_ab_nb_seances.Text = txt_ab_nb_seances.Text != "" ? (Convert.ToInt16(txt_ab_nb_seances.Text) + 1).ToString() : "1";
            }
            if (ch_ab_s2.Checked == false)
            {
                txt_ab_seances.Text = txt_ab_seances.Text.Replace(("ح2_" + haf), "");
                txt_ab_nb_seances.Text = txt_ab_nb_seances.Text != "" ? (Convert.ToInt16(txt_ab_nb_seances.Text) - 1).ToString() : "";
            }
            if (txt_ab_nb_seances.Text == "0")
            { txt_ab_nb_seances.Text = ""; }
        }



        private void ch_ab_s3_CheckedChanged(object sender, EventArgs e)
        {
            string haf = rb_ab_s_matin.Checked ? "صباحا" : "مساء";

            if (ch_ab_s3.Checked)
            {

                // txt_ab_seances.Text = txt_ab_nb_seances.Text != "" ? string.Concat(txt_ab_nb_seances.Text, " ", ("ح3_"+haf)) : ("ح3_" + haf);
                txt_ab_seances.Text += " " + ("ح3_" + haf);
                txt_ab_nb_seances.Text = txt_ab_nb_seances.Text != "" ? (Convert.ToInt16(txt_ab_nb_seances.Text) + 1).ToString() : "1";
            }
            if (ch_ab_s3.Checked == false)
            {
                txt_ab_seances.Text = txt_ab_seances.Text.Replace(("ح3_" + haf), "");
                txt_ab_nb_seances.Text = txt_ab_nb_seances.Text != "" ? (Convert.ToInt16(txt_ab_nb_seances.Text) - 1).ToString() : "";
            }
            if (txt_ab_nb_seances.Text == "0")
            { txt_ab_nb_seances.Text = ""; }
        }

        private void ch_ab_s4_CheckedChanged(object sender, EventArgs e)
        {
            string haf = rb_ab_s_matin.Checked ? "صباحا" : "مساء";
            if (ch_ab_s4.Checked)
            {
                //txt_ab_seances.Text = txt_ab_nb_seances.Text != "" ? string.Concat(txt_ab_nb_seances.Text, " ",( "ح4_" + haf)) : ("ح4_" + haf);
                txt_ab_seances.Text += " " + ("ح4_" + haf);
                txt_ab_nb_seances.Text = txt_ab_nb_seances.Text != "" ? (Convert.ToInt16(txt_ab_nb_seances.Text) + 1).ToString() : "1";
            }
            if (ch_ab_s4.Checked == false)
            {
                txt_ab_seances.Text = txt_ab_seances.Text.Replace(("ح4_" + haf), "");
                txt_ab_nb_seances.Text = txt_ab_nb_seances.Text != "" ? (Convert.ToInt16(txt_ab_nb_seances.Text) - 1).ToString() : "";
            }
            if (txt_ab_nb_seances.Text == "0")
            { txt_ab_nb_seances.Text = ""; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void showAb(string emp_ppr)
        {
            // Expression<Func<T, bool>> whereClause = a => a.zip == 23456;
            if (cb_ab_duree.Checked)// duree
            {
                if (rb_ab_ab.Checked)// ab days
                {
                    try
                    {
                        using (var db = new EmployeeDataContext())
                        {
                            var ab_d = from d in db.absence_day_emps
                                       join aa in db.Emp_Acts on d.ppr_ab equals aa.ppr_act
                                       where aa.CD_ETAB == Tools.Globals.GRESA && d.ppr_ab == emp_ppr & d.debut_ab >= dtp_ab_days2_1.Value & d.fin_ab <= dtp_ab_days2_2.Value
                                     //  where d.ppr_ab == emp_ppr & d.debut_ab >= dtp_ab_days2_1.Value & d.fin_ab <= dtp_ab_days2_2.Value
                                       select d;

                            dataGridView1.DataSource = null;

                            dataGridView1.DataSource = ab_d;

                            dataGridView1.Columns[0].HeaderText = "Id";
                            dataGridView1.Columns[1].HeaderText = "ر.التأجير";
                            dataGridView1.Columns[2].HeaderText = "عدد أيام الغياب";
                            dataGridView1.Columns[3].HeaderText = "من";
                            dataGridView1.Columns[4].HeaderText = "إلى";
                            dataGridView1.Columns[5].HeaderText = "اسم الطبيب";
                            dataGridView1.Columns[6].HeaderText = "المبرر";
                            dataGridView1.Columns[7].HeaderText = "المسطرة";
                            dataGridView1.Columns[8].HeaderText = "المرجع";
                            dataGridView1.Columns[9].HeaderText = "نوع الغياب";
                            dataGridView1.Columns[10].HeaderText = "نصف اليوم";

                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                if (rb_ab_s.Checked) // ab seances
                {
                    try
                    {
                        using (var db = new EmployeeDataContext())
                        {
                            var ab_s = from s in db.absence_seance_emps
                                       where s.ppr_ab == emp_ppr & s.debut_ab >= dtp_ab_days2_1.Value
                                       select s;
                            dataGridView1.DataSource = null;
                            dataGridView1.DataSource = ab_s;

                            dataGridView1.Columns[0].HeaderText = "Id";
                            dataGridView1.Columns[1].HeaderText = "ر.التأجير";
                            dataGridView1.Columns[2].HeaderText = "اليوم";
                            dataGridView1.Columns[3].HeaderText = "اسم الطبيب";
                            dataGridView1.Columns[4].HeaderText = "المبرر";
                            dataGridView1.Columns[5].HeaderText = "المسطرة";
                            dataGridView1.Columns[6].HeaderText = "المرجع";
                            dataGridView1.Columns[7].HeaderText = "عدد الحصص";
                            dataGridView1.Columns[8].HeaderText = "الحصص";
                            dataGridView1.Columns[9].HeaderText = "نصف اليوم";


                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                if (rb_ret.Checked) // retard
                {
                    try
                    {
                        using (var db = new EmployeeDataContext())
                        {
                            var ab_r = from r in db.retard_emps
                                       where r.ppr_ret == emp_ppr & r.day_ret >= r.day_ret
                                       select r;
                            dataGridView1.DataSource = null;
                            dataGridView1.DataSource = ab_r;

                            dataGridView1.Columns[0].HeaderText = "Id";
                            dataGridView1.Columns[1].HeaderText = "ر.التأجير";
                            dataGridView1.Columns[2].HeaderText = "دقائق التأخر";
                            dataGridView1.Columns[3].HeaderText = "من الساعة";
                            dataGridView1.Columns[4].HeaderText = "إلى الساعة";
                            dataGridView1.Columns[5].HeaderText = "المسطرة";
                            dataGridView1.Columns[6].HeaderText = "المرجع";
                            dataGridView1.Columns[7].HeaderText = "يوم";
                            dataGridView1.Columns[8].HeaderText = "المبرر";



                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            else
            {
                if (rb_ab_ab.Checked)// ab days
                {
                    try
                    {
                        using (var db = new EmployeeDataContext())
                        {
                            var ab_d = from d in db.absence_day_emps
                                       where d.ppr_ab == emp_ppr
                                       select d;


                            dataGridView1.DataSource = null;
                            dataGridView1.DataSource = ab_d;

                            dataGridView1.Columns[0].HeaderText = "Id";
                            dataGridView1.Columns[1].HeaderText = "ر.التأجير";
                            dataGridView1.Columns[2].HeaderText = "عدد أيام الغياب";
                            dataGridView1.Columns[3].HeaderText = "من";
                            dataGridView1.Columns[4].HeaderText = "إلى";
                            dataGridView1.Columns[5].HeaderText = "اسم الطبيب";
                            dataGridView1.Columns[6].HeaderText = "المبرر";
                            dataGridView1.Columns[7].HeaderText = "المسطرة";
                            dataGridView1.Columns[8].HeaderText = "المرجع";
                            dataGridView1.Columns[9].HeaderText = "نوع الغياب";
                            dataGridView1.Columns[10].HeaderText = "نصف اليوم";

                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }

                }
                if (rb_ab_s.Checked) // ab seances
                {
                    try
                    {
                        using (var db = new EmployeeDataContext())
                        {
                            var ab_s = from s in db.absence_seance_emps
                                       where s.ppr_ab == emp_ppr
                                       select s;

                            dataGridView1.DataSource = null;
                            dataGridView1.DataSource = ab_s;

                            dataGridView1.Columns[0].HeaderText = "Id";
                            dataGridView1.Columns[1].HeaderText = "ر.التأجير";
                            dataGridView1.Columns[2].HeaderText = "اليوم";
                            dataGridView1.Columns[3].HeaderText = "اسم الطبيب";
                            dataGridView1.Columns[4].HeaderText = "المبرر";
                            dataGridView1.Columns[5].HeaderText = "المسطرة";
                            dataGridView1.Columns[6].HeaderText = "المرجع";
                            dataGridView1.Columns[7].HeaderText = "عدد الحصص";
                            dataGridView1.Columns[8].HeaderText = "الحصص";
                            dataGridView1.Columns[9].HeaderText = "نصف اليوم";

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }
                if (rb_ret.Checked) // retard
                {
                    try
                    {
                        using (var db = new EmployeeDataContext())
                        {
                            var ab_r = from r in db.retard_emps
                                       where r.ppr_ret == emp_ppr
                                       select r;

                            dataGridView1.DataSource = null;
                            dataGridView1.DataSource = ab_r;

                            dataGridView1.Columns[0].HeaderText = "Id";
                            dataGridView1.Columns[1].HeaderText = "ر.التأجير";
                            dataGridView1.Columns[2].HeaderText = "دقائق التأخر";
                            dataGridView1.Columns[3].HeaderText = "من الساعة";
                            dataGridView1.Columns[4].HeaderText = "إلى الساعة";
                            dataGridView1.Columns[5].HeaderText = "المسطرة";
                            dataGridView1.Columns[6].HeaderText = "المرجع";
                            dataGridView1.Columns[7].HeaderText = "يوم";
                            dataGridView1.Columns[8].HeaderText = "المبرر";

                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }
            }
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].Visible = false;
                if (rb_ab_ab.Checked) dataGridView1.Columns[11].Visible = false;
                if (rb_ab_s.Checked) dataGridView1.Columns[10].Visible = false;
                if (rb_ret.Checked) dataGridView1.Columns[9].Visible = false;

            }

        }

        //public static List<T> CreateList<T>(params T[] elements)
        //{
        //    return new List<T>(elements);
        //}
        private void btn_ab_show_Click(object sender, EventArgs e)
        {
            string ppr = cb_emp_select_Ab.GetItemText(cb_emp_select_Ab.SelectedValue);

            showAb(ppr);

            try
            {


                if (cb_ab_all.Checked)
                {

                    EmployeeDataContext edc = new EmployeeDataContext();

                    var abd = (from d in edc.absence_day_emps
                               join a in edc.Emp_Datas on d.ppr_ab equals a.ppr_dat
                               join aa in edc.Emp_Acts on a.ppr_dat equals aa.ppr_act
                               where aa.CD_ETAB == Tools.Globals.GRESA
                               
                               select new
                               {
                                   id = d.Id,
                                   nom = a.NOMA + " " + a.PRENOMA,
                                   type = d.type_ab,
                                   a_partir = d.debut_ab.ToString(),
                                   duree = String.Format("{0:F1}", d.nm_jours_ab),
                                   lbl = d.lblToPrint
                               }).ToList();
                    var abs = (from s in edc.absence_seance_emps
                               join a in edc.Emp_Datas on s.ppr_ab equals a.ppr_dat
                               join aa in edc.Emp_Acts on a.ppr_dat equals aa.ppr_act
                               where aa.CD_ETAB == Tools.Globals.GRESA
                               select new
                               {
                                   id = s.Id,
                                   nom = a.NOMA + " " + a.PRENOMA,
                                   type = "غياب بالحصص",
                                   a_partir = s.debut_ab.ToString(),
                                   duree = s.nb_seance_ab.ToString(),
                                   lbl = s.lblToPrint
                               }).ToList();
                    var abr = (from r in edc.retard_emps
                               join a in edc.Emp_Datas on r.ppr_ret equals a.ppr_dat
                               join aa in edc.Emp_Acts on a.ppr_dat equals aa.ppr_act
                               where aa.CD_ETAB == Tools.Globals.GRESA
                               select new
                               {
                                   id = r.Id,
                                   nom = a.NOMA + " " + a.PRENOMA,
                                   type = "تأخر بالدقائق",
                                   a_partir = r.day_ret.Value.ToString(),
                                   duree = r.nb_minut_ret.ToString(),
                                   lbl = r.lblToPrint
                               }).ToList();


                    foreach (var item in abs)
                    {
                        abd.Add(item);
                    }
                    foreach (var item in abr)
                    {
                        abd.Add(item);
                    }

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = abd;

                    dataGridView1.Columns[0].HeaderText = "المعرف";
                    dataGridView1.Columns[1].HeaderText = "الإسم";
                    dataGridView1.Columns[2].HeaderText = "نوع الغياب";
                    dataGridView1.Columns[3].HeaderText = "ابتداء من";
                    dataGridView1.Columns[4].HeaderText = "المدة";
                    dataGridView1.Columns[5].HeaderText = "rpt";

                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[5].Visible = false;

                }
                HidePanel();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }

        }

        private void cb_ab_type_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cb_ab_type.SelectedIndex == 1)//(cb_ab_type.GetItemText(cb_ab_type.SelectedItem) == "رخصة لأسباب صحية")
            {
                lbl_rpt.Text = "malad";
                if (txt_ab_duree_days.Text != "")
                {
                    lbl_ab_ret_se.Text = "d_malad";
                }
                //if (txt_ab_nb_seances.Text!="")
                //{
                //    lbl_ab_ret_se.Text = "s_malad";
                //}

                txt_nom_doc.Enabled = true;
            }
            else if (cb_ab_type.SelectedIndex == 5)//if(cb_ab_type.GetItemText(cb_ab_type.SelectedItem).Contains( "غياب بدون إخبار الإدارة")) 
            {
                lbl_rpt.Text = "bidon";
                if (txt_ab_duree_days.Text != "")
                {
                    lbl_ab_ret_se.Text = "d_bidon";
                }
                //if (txt_ab_nb_seances.Text != "")
                //{
                //    lbl_ab_ret_se.Text = "s_bidon";
                //}

                txt_nom_doc.Text = "";
                txt_nom_doc.Enabled = false;
            }
            else if (cb_ab_type.SelectedIndex == 6)// (cb_ab_type.GetItemText(cb_ab_type.SelectedItem) == "انقطاع عن العمل")
            {
                lbl_rpt.Text = "inkita";

            }
            else
            {
                lbl_rpt.Text = "istitna";
                if (txt_ab_duree_days.Text != "")
                {
                    lbl_ab_ret_se.Text = "d_istitna";
                }
                //if (txt_ab_nb_seances.Text != "")
                //{
                //    lbl_ab_ret_se.Text = "s_istitna";
                //}

            }
            if (txt_ab_duree_days.Text != "" | txt_ab_nb_seances.Text != "" | txt_ab_duree_minutes.Text != "")
            { btn_save_ab_ret.Enabled = true; }
            HidePanel1();
        }

        private void btn_doc_malad_Click(object sender, EventArgs e)
        {
            panel1.Size = panel1.MinimumSize;
            btn_doc_malad.Text = "طبع الوثائق";
            btn_doc_malad.Enabled = false;





        }
        private void btn_doc_istitna_Click(object sender, EventArgs e)
        {
            panel2.Size = panel2.MinimumSize;
            btn_doc_istitna.Text = "طبع الوثائق";
            btn_doc_istitna.Enabled = false;

        }

        private void btn_doc_istifsar_Click(object sender, EventArgs e)
        {
            panel3.Size = panel3.MinimumSize;
            btn_doc_istifsar.Text = "طبع الوثائق";
            btn_doc_istifsar.Enabled = false;



        }

        private void btn_dem_malad_Click(object sender, EventArgs e)
        {
            string tDB = lbl_ab_ret_se.Text;

            int idDB = Convert.ToInt32(lbl_Id_ab_ret.Text);
            new Reports.Frm_report_ab(idDB, "dem_" + lbl_ab_ret_se.Text).ShowDialog();
            btn_doc_malad.Enabled = false;
        }
        private void btn_recu_malad_Click(object sender, EventArgs e)
        {
            int idDB = Convert.ToInt32(lbl_Id_ab_ret.Text);
            new Reports.Frm_report_ab(idDB, "recu_certif_" + lbl_ab_ret_se.Text).ShowDialog();
            btn_doc_malad.Enabled = false;
        }

        private void btn_stinaf_malad_Click(object sender, EventArgs e)
        {
            int idDB = Convert.ToInt32(lbl_Id_ab_ret.Text);
            new Reports.Frm_report_ab(idDB, "istinaf_" + lbl_ab_ret_se.Text).ShowDialog();
            btn_doc_malad.Enabled = false;
        }

        private void btn_istifsar_Click(object sender, EventArgs e)
        {
            int idDB = Convert.ToInt32(lbl_Id_ab_ret.Text);
            new Reports.Frm_report_ab(idDB, "istifsar_" + lbl_ab_ret_se.Text).ShowDialog();
            btn_doc_malad.Enabled = false;
        }

        private void btn_istifsar_istinaf_Click(object sender, EventArgs e)
        {
            int idDB = Convert.ToInt32(lbl_Id_ab_ret.Text);
            new Reports.Frm_report_ab(idDB, "istinaf_" + "d_malad").ShowDialog();
            btn_doc_malad.Enabled = false;
        }

        private void btn_dem_istitna_Click(object sender, EventArgs e)
        {
            int idDB = Convert.ToInt32(lbl_Id_ab_ret.Text);
            new Reports.Frm_report_ab(idDB, "dem_" + lbl_ab_ret_se.Text).ShowDialog();
            btn_doc_malad.Enabled = false;
        }

        private void btn_istitna_istnaf_Click(object sender, EventArgs e)
        {
            int idDB = Convert.ToInt32(lbl_Id_ab_ret.Text);
            new Reports.Frm_report_ab(idDB, "istinaf_" + "d_malad").ShowDialog();
            btn_doc_malad.Enabled = false;
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            panel1.Size = panel1.MaximumSize;
            btn_doc_malad.Enabled = true;
            btn_doc_malad.Text = "تراجع";
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            panel2.Size = panel2.MaximumSize;
            btn_doc_istitna.Enabled = true;
            btn_doc_istitna.Text = "تراجع";
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            panel3.Size = panel3.MaximumSize;
            btn_doc_istifsar.Enabled = true;
            btn_doc_istifsar.Text = "تراجع";
        }

        private void btn_dem_malad2_Click(object sender, EventArgs e)
        {
            btn_dem_malad_Click(sender, e);
        }

        private void btn_recu_malad2_Click(object sender, EventArgs e)
        {
            btn_recu_malad_Click(sender, e);
        }

        private void btn_istinaf_malad2_Click(object sender, EventArgs e)
        {
            btn_stinaf_malad_Click(sender, e);
        }

        private void btn_doc_malad2_Click(object sender, EventArgs e)
        {
            panel4.Size = panel4.MinimumSize;
            btn_doc_malad2.Text = "طبع الوثائق";
            btn_doc_malad2.Enabled = false;
        }

        private void btn_doc_istisna2_Click(object sender, EventArgs e)
        {
            panel5.Size = panel5.MinimumSize;
            btn_doc_istisna2.Text = "طبع الوثائق";
            btn_doc_istisna2.Enabled = false;
        }

        private void btn_dem_ististna2_Click(object sender, EventArgs e)
        {
            btn_dem_istitna_Click(sender, e);
        }

        private void btn_istinaf_istisna2_Click(object sender, EventArgs e)
        {
            btn_istitna_istnaf_Click(sender, e);
        }

        private void btn_doc_istifsar2_Click(object sender, EventArgs e)
        {
            panel6.Size = panel6.MinimumSize;
            btn_doc_istifsar2.Text = "طبع الوثائق";
            btn_doc_istifsar2.Enabled = false;
        }

        private void btn_istifsar2_Click(object sender, EventArgs e)
        {
            btn_istifsar_Click(sender, e);
        }

        private void btn_istinaf_istifsar2_Click(object sender, EventArgs e)
        {
            btn_istifsar_istinaf_Click(sender, e);
        }

       
        private void panel4_Click(object sender, EventArgs e)
        {
            panel4.Size = panel4.MaximumSize;
            btn_doc_malad2.Enabled = true;
            btn_doc_malad2.Text = "تراجع";
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            panel5.Size = panel5.MaximumSize;
            btn_doc_istisna2.Enabled = true;
            btn_doc_istisna2.Text = "تراجع";
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            panel6.Size = panel6.MaximumSize;
            btn_doc_istifsar2.Enabled = true;
            btn_doc_istifsar2.Text = "تراجع";
        }

        private void cb_emp_select_Ab_SelectedIndexChanged(object sender, EventArgs e)
        {

            string ppr = cb_emp_select_Ab.GetItemText(cb_emp_select_Ab.SelectedValue);

            showAb(ppr);
        }

        private void btn_ab_del_Click(object sender, EventArgs e)
        {
            try
            {

          

            if (dataGridView1.Rows.Count > 0)
            {
                int valcelId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                EmployeeDataContext edc = new EmployeeDataContext();
                int row = dataGridView1.CurrentCell.RowIndex;
                int id = Convert.ToInt32(dataGridView1.Rows[row].Cells[0].Value);
                string lbl = "";
                if (cb_ab_all.Checked)
                { lbl = dataGridView1.Rows[row].Cells[5].Value.ToString(); }
              
                    dataGridView1.Columns[0].Visible = false;
                    if (rb_ab_ab.Checked)
                    {
                        lbl = dataGridView1.Rows[row].Cells[11].Value.ToString();
                    }
                    if (rb_ab_s.Checked)
                    {
                        lbl = dataGridView1.Rows[row].Cells[10].Value.ToString();
                    }
                    if (rb_ret.Checked)
                    {
                        lbl = dataGridView1.Rows[row].Cells[9].Value.ToString();
                    }

              



                lbl_ab_ret_se.Text = lbl;


                lbl_Id_ab_ret.Text = id.ToString();

                string tDB = lbl_ab_ret_se.Text;



                if (row < dataGridView1.Rows.Count)
                {

                    if (tDB.StartsWith("d_"))//| tDB == "s_malad")
                    {
                        absence_day_emp abd = edc.absence_day_emps.SingleOrDefault(m => m.Id == valcelId);

                        edc.absence_day_emps.DeleteOnSubmit(abd);
                        edc.SubmitChanges();
                        btn_ab_show_Click(sender, e);
                    }




                    if (tDB == "rr")
                    {
                        retard_emp abr = edc.retard_emps.SingleOrDefault(m => m.Id == valcelId);

                        edc.retard_emps.DeleteOnSubmit(abr);
                        edc.SubmitChanges();
                        btn_ab_show_Click(sender, e);
                    }
                    if (tDB == "ss")
                    {

                        absence_seance_emp abs = edc.absence_seance_emps.SingleOrDefault(m => m.Id == valcelId);

                        edc.absence_seance_emps.DeleteOnSubmit(abs);
                        edc.SubmitChanges();
                        btn_ab_show_Click(sender, e);
                    }

                    if (tDB == "inkita")
                    {

                    }


                }
                    HidePanel();
            }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void rb_ab_ab_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_ab_ab.Checked)
                cb_ab_all.Checked = false;
        }

        private void rb_ab_s_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_ab_s.Checked)
                cb_ab_all.Checked = false;
        }

        private void rb_ret_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_ret.Checked)
                cb_ab_all.Checked = false;
        }

        private void cb_ab_all_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_ab_all.Checked)
                cb_ab_duree.Checked = false;
        }

        private void cb_ab_duree_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_ab_duree.Checked)
                cb_ab_all.Checked = false;
        }

      
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (dataGridView1.Rows.Count > 0)
                {

                    EmployeeDataContext edc = new EmployeeDataContext();
                    int row = dataGridView1.CurrentCell.RowIndex;
                    int id = Convert.ToInt32(dataGridView1.Rows[row].Cells[0].Value);
                    string lbl = "";
                    if (cb_ab_all.Checked)
                    { lbl = dataGridView1.Rows[row].Cells[5].Value.ToString(); }
                    if (dataGridView1.Rows.Count > 0)
                    {
                        dataGridView1.Columns[0].Visible = false;
                        if (rb_ab_ab.Checked)
                        {
                            lbl = dataGridView1.Rows[row].Cells[11].Value.ToString();
                        }
                        if (rb_ab_s.Checked)
                        {
                            lbl = dataGridView1.Rows[row].Cells[10].Value.ToString();
                        }
                        if (rb_ret.Checked)
                        {
                            lbl = dataGridView1.Rows[row].Cells[9].Value.ToString();
                        }

                    }



                    lbl_ab_ret_se.Text = lbl;


                    lbl_Id_ab_ret.Text = id.ToString();

                    string tDB = lbl_ab_ret_se.Text;



                    if (row < dataGridView1.Rows.Count)
                    {

                        if (tDB == "d_malad")//| tDB == "s_malad")
                        {
                            panel4.Visible = true;
                            panel4.BringToFront();
                            panel5.Visible = false;
                            panel6.Visible = false;

                            panel5.Size = panel5.MinimumSize;
                            panel6.Size = panel6.MinimumSize;
                        }

                        if (tDB == "d_bidon")//| tDB == "s_bidon")
                        {
                            panel6.Visible = true;
                            panel6.BringToFront();
                            panel5.Visible = false;
                            panel4.Visible = false;

                            panel5.Size = panel5.MinimumSize;
                            panel4.Size = panel5.MinimumSize;

                        }

                        if (tDB == "d_istitna")//| tDB == "s_istitna")
                        {
                            panel5.Visible = true;
                            panel5.BringToFront();
                            panel6.Visible = false;
                            panel4.Visible = false;

                            panel4.Size = panel4.MinimumSize;
                            panel6.Size = panel6.MinimumSize;
                        }

                        if (tDB == "rr" | tDB == "ss")
                        {
                            panel6.Visible = true;
                            panel6.BringToFront();
                            panel5.Visible = false;
                            panel4.Visible = false;

                            panel5.Size = panel5.MinimumSize;
                            panel4.Size = panel4.MinimumSize;
                        }

                        if (tDB == "inkita")
                        {

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

               
            }
        }
    }
}
