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
    public partial class Frm_req_docs_scool : Form
    {
        public Frm_req_docs_scool()
        {
            InitializeComponent();
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            StudentsListDataContext stdc = new StudentsListDataContext();
            int typeTrans = rb_req_docs_st.Checked ? 1 : -1;
            string key_search = txt_search.Text.Trim();
            if (rb_all_nivs.Checked)
            {
                var students = (from st in stdc.Transactions
                                where st.part_entr_trans_ == typeTrans && (st.massar_trans_.Contains(key_search) || st.fname_trans_.Contains(key_search) || st.lname_trans_.Contains(key_search))
                                select new
                                {
                                    رمز_مسار = st.massar_trans_,
                                    النسب = st.fname_trans_,
                                    الإسم = st.lname_trans_,
                                    المؤسسة_الأصلية = st.etabOrig_trans_,
                                    المديرية = st.direc_orig_recep_trans_,
                                    مؤسسة_الاستقبال = st.etabRecep_trans_,
                                    المستوى = st.niveau_trans_,
                                    وافد_مغادر = st.part_entr_trans_,
                                    تاريخ_الحركية = st.dt_trans_,
                                    تم_الإرسال = st.req_send_trans,
                                    عدد_الإرسال = st.nb_req_trans,
                                    تاريخ_الإرسال = st.dt_corres_trans,
                                    رقم_الإرسال = st.num_corres_trans,

                                }
                                          ).ToList();
                var bindingSource1 = new BindingSource();
                bindingSource1.DataSource = students;
                dataGridView1.DataSource = bindingSource1;
                dataGridView1.Refresh();
            }
            else
            {
                var students = (from st in stdc.Transactions
                                where st.part_entr_trans_ == typeTrans && (st.massar_trans_.Contains(key_search) || st.fname_trans_.Contains(key_search) || st.lname_trans_.Contains(key_search)) && st.niveau_trans_==cb_nivs.GetItemText(cb_nivs.SelectedItem)
                                select new
                                {
                                    رمز_مسار = st.massar_trans_,
                                    النسب = st.fname_trans_,
                                    الإسم = st.lname_trans_,
                                    المؤسسة_الأصلية = st.etabOrig_trans_,
                                    المديرية = st.direc_orig_recep_trans_,
                                    مؤسسة_الاستقبال = st.etabRecep_trans_,
                                    المستوى = st.niveau_trans_,
                                    وافد_مغادر = st.part_entr_trans_,
                                    تاريخ_الحركية = st.dt_trans_,
                                    تم_الإرسال = st.req_send_trans,
                                    عدد_الإرسال = st.nb_req_trans,
                                    تاريخ_الإرسال = st.dt_corres_trans,
                                    رقم_الإرسال = st.num_corres_trans,

                                }
                                         ).ToList();
                var bindingSource1 = new BindingSource();
                bindingSource1.DataSource = students;
                dataGridView1.DataSource = bindingSource1;
                dataGridView1.Refresh();
            }
           

        }

      

       
     
        private void rb_req_docs_st_CheckedChanged(object sender, EventArgs e)
        {
            //StudentsListDataContext stdc = new StudentsListDataContext();
           
            //string key_search = txt_search.Text.Trim();

            //var students = (from st in stdc.Transactions
            //                where st.part_entr_trans_ == 1 
            //                select new
            //                {
            //                    رمز_مسار = st.massar_trans_,
            //                    النسب = st.fname_trans_,
            //                    الإسم = st.lname_trans_,
            //                    المؤسسة_الأصلية = st.etabOrig_trans_,
            //                    المديرية_الأصلية = st.direc_orig_recep_trans_,
            //                    وافد_مغادر = st.part_entr_trans_,
            //                    تاريخ_الحركية = st.dt_trans_,
            //                    تم_الإرسال = st.req_send_trans,
            //                    عدد_الإرسال = st.nb_req_trans,
            //                    تاريخ_الإرسال = st.dt_corres_trans,
            //                    رقم_الإرسال = st.num_corres_trans,

            //                }
            //               ).ToList();
            //var bindingSource1 = new BindingSource();
            //bindingSource1.DataSource = students;
            //dataGridView1.DataSource = bindingSource1;
            //dataGridView1.Refresh();
        }
        
         private void cb_nivs_SelectedIndexChanged(object sender, EventArgs e)
        {
            StudentsListDataContext stdc = new StudentsListDataContext();
            int typeTrans = rb_req_docs_st.Checked ? 1 : -1;
            string niv =cb_nivs.GetItemText(cb_nivs.SelectedItem) ;

            var students = (from st in stdc.Transactions
                            where st.niveau_trans_ == niv && st.part_entr_trans_==typeTrans
                            select new
                            {
                                رمز_مسار = st.massar_trans_,
                                النسب = st.fname_trans_,
                                الإسم = st.lname_trans_,
                                المؤسسة_الأصلية = st.etabOrig_trans_,
                                المديرية = st.direc_orig_recep_trans_,
                                مؤسسة_الاستقبال = st.etabRecep_trans_,
                                المستوى = st.niveau_trans_,
                                وافد_مغادر = st.part_entr_trans_,
                                تاريخ_الحركية = st.dt_trans_,
                                تم_الإرسال = st.req_send_trans,
                                عدد_الإرسال = st.nb_req_trans,
                                تاريخ_الإرسال = st.dt_corres_trans,
                                رقم_الإرسال = st.num_corres_trans,

                            }
                           ).ToList();
            var bindingSource1 = new BindingSource();
            bindingSource1.DataSource = students;
            dataGridView1.DataSource = bindingSource1;
            dataGridView1.Refresh();
        }

        private void rb_send_docs_st_CheckedChanged(object sender, EventArgs e)
        {
            StudentsListDataContext stdc = new StudentsListDataContext();
            int typeTrans = rb_req_docs_st.Checked ? 1 : -1;
            if (rb_send_docs_st.Checked)
            {
                if (rb_all_nivs.Checked)
                {
                    var students = (from st in stdc.Transactions
                                    where st.part_entr_trans_ == -1
                                    select new
                                    {
                                        رمز_مسار = st.massar_trans_,
                                        النسب = st.fname_trans_,
                                        الإسم = st.lname_trans_,
                                        المؤسسة_الأصلية = st.etabOrig_trans_,
                                        المديرية = st.direc_orig_recep_trans_,
                                        مؤسسة_الاستقبال = st.etabRecep_trans_,
                                        المستوى = st.niveau_trans_,
                                        وافد_مغادر = st.part_entr_trans_,
                                        تاريخ_الحركية = st.dt_trans_,
                                        تم_الإرسال = st.req_send_trans,
                                        عدد_الإرسال = st.nb_req_trans,
                                        تاريخ_الإرسال = st.dt_corres_trans,
                                        رقم_الإرسال = st.num_corres_trans,

                                    }
                        ).ToList();
                    var bindingSource1 = new BindingSource();
                    bindingSource1.DataSource = students;
                    dataGridView1.DataSource = bindingSource1;
                    dataGridView1.Refresh();
                }
                else
                {
                    var students = (from st in stdc.Transactions
                                    where st.part_entr_trans_ == -1 && st.niveau_trans_==cb_nivs.GetItemText(cb_nivs.SelectedItem)
                                    select new
                                    {
                                        رمز_مسار = st.massar_trans_,
                                        النسب = st.fname_trans_,
                                        الإسم = st.lname_trans_,
                                        المؤسسة_الأصلية = st.etabOrig_trans_,
                                        المديرية = st.direc_orig_recep_trans_,
                                        مؤسسة_الاستقبال = st.etabRecep_trans_,
                                        المستوى = st.niveau_trans_,
                                        وافد_مغادر = st.part_entr_trans_,
                                        تاريخ_الحركية = st.dt_trans_,
                                        تم_الإرسال = st.req_send_trans,
                                        عدد_الإرسال = st.nb_req_trans,
                                        تاريخ_الإرسال = st.dt_corres_trans,
                                        رقم_الإرسال = st.num_corres_trans,

                                    }
                                           ).ToList();
                    var bindingSource1 = new BindingSource();
                    bindingSource1.DataSource = students;
                    dataGridView1.DataSource = bindingSource1;
                    dataGridView1.Refresh();
                }

            }
            else
            {
                if (rb_all_nivs.Checked)
                {
                    var students = (from st in stdc.Transactions
                                    where st.part_entr_trans_ == 1
                                    select new
                                    {
                                        رمز_مسار = st.massar_trans_,
                                        النسب = st.fname_trans_,
                                        الإسم = st.lname_trans_,
                                        المؤسسة_الأصلية = st.etabOrig_trans_,
                                        المديرية = st.direc_orig_recep_trans_,
                                        مؤسسة_الاستقبال = st.etabRecep_trans_,
                                        المستوى = st.niveau_trans_,
                                        وافد_مغادر = st.part_entr_trans_,
                                        تاريخ_الحركية = st.dt_trans_,
                                        تم_الإرسال = st.req_send_trans,
                                        عدد_الإرسال = st.nb_req_trans,
                                        تاريخ_الإرسال = st.dt_corres_trans,
                                        رقم_الإرسال = st.num_corres_trans,

                                    }
                        ).ToList();
                    var bindingSource1 = new BindingSource();
                    bindingSource1.DataSource = students;
                    dataGridView1.DataSource = bindingSource1;
                    dataGridView1.Refresh();
                }
                else
                {
                    var students = (from st in stdc.Transactions
                                    where st.part_entr_trans_ == 1 && st.niveau_trans_ == cb_nivs.GetItemText(cb_nivs.SelectedItem)
                                    select new
                                    {
                                        رمز_مسار = st.massar_trans_,
                                        النسب = st.fname_trans_,
                                        الإسم = st.lname_trans_,
                                        المؤسسة_الأصلية = st.etabOrig_trans_,
                                        المديرية = st.direc_orig_recep_trans_,
                                        مؤسسة_الاستقبال = st.etabRecep_trans_,
                                        المستوى= st.niveau_trans_,
                                        وافد_مغادر = st.part_entr_trans_,
                                        تاريخ_الحركية = st.dt_trans_,
                                        تم_الإرسال = st.req_send_trans,
                                        عدد_الإرسال = st.nb_req_trans,
                                        تاريخ_الإرسال = st.dt_corres_trans,
                                        رقم_الإرسال = st.num_corres_trans,

                                    }
                                           ).ToList();
                    var bindingSource1 = new BindingSource();
                    bindingSource1.DataSource = students;
                    dataGridView1.DataSource = bindingSource1;
                    dataGridView1.Refresh();
                }
            }

           
        }

        private void Frm_req_docs_scool_Load(object sender, EventArgs e)
        {
          

            StudentsListDataContext stdc = new StudentsListDataContext();
            var nivs = stdc.StudentListUpdates.Select(s => new { s.niveau_Up }).Distinct().ToList();

            var bindingSource1 = new BindingSource();
            bindingSource1.DataSource = nivs;
            cb_nivs.DataSource = bindingSource1.DataSource;
            cb_nivs.DisplayMember = "niveau_Up";
            //cb_nivs.ValueMember = "niveau_Up";
            cb_nivs.Text = "اختر مستوى";

            rb_send_docs_st.Checked = true;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rb_all_nivs_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_all_nivs.Checked)
            {
                cb_nivs.Enabled = false;

            }
            else
            {
                cb_nivs.Enabled = true;
            }
        }

        private void txt_nb_Jrs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        
        private void btn_second_req_Click(object sender, EventArgs e)
        {
            //(dataGridView1.DataSource as DataTable).DefaultView.RowFilter = "تاريخ_الإرسال +60>DateTime.Now";//string.Format("Field = '{0}'", textBoxFilter.Text);

        }
    }
}
