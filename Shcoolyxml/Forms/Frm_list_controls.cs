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
    public partial class Frm_list_controls : Form
    {
        public Frm_list_controls()
        {
            InitializeComponent();
        }

        private void Frm_list_controls_Load(object sender, EventArgs e)
        {
            ch_rb_select.Text = "لجميع الأقسام المدرسة من طرف هذا الأستاذ";
         //   cb_check_select.Enabled = false;
            lbl_what_tt.Text = "All_cls_prof";

            fetDataContext fdc = new fetDataContext();
            var profs = fdc.timeTables.Where(w => w.gresa_tt_fet == Tools.Globals.GRESA).Select(s => s.Teachers).Distinct().ToList();
            var bindingsource1 = new BindingSource();
            bindingsource1.DataSource = profs;
            cb_radio_select.DataSource = bindingsource1.DataSource;
            cb_radio_select.DisplayMember = "Teachers";
          //  cb_radio_select.ValueMember = "Teachers";

        }
        private void prof_all()
        {
            fetDataContext fdc = new fetDataContext();

            var cls = fdc.timeTables.Where(w => w.gresa_tt_fet == Tools.Globals.GRESA && w.Teachers == cb_radio_select.GetItemText(cb_radio_select.SelectedItem)).Select(s => s.StudentsSets).Distinct()
                .ToList();

            var subs = (from c in (fdc.timeTables.Where(w => w.gresa_tt_fet == Tools.Globals.GRESA && w.Teachers == cb_radio_select.GetItemText(cb_radio_select.SelectedItem)).Select(s => s.StudentsSets).Distinct()
                .ToList())
                        join su in fdc.elevesses on c equals su.groups

                        select c == su.Subgroup ? su.groups : c
                        ).Distinct().ToList();

           


            var bindingsource1 = new BindingSource();
            bindingsource1.DataSource = subs;
            cb_check_select.DataSource = bindingsource1.DataSource;
            cb_check_select.DisplayMember = "StudentsSets";
           // cb_check_select.ValueMember = "StudentsSets";
        }
        private void prof_one()
        {

        }
        private void st_all()
        {
            fetDataContext fdc = new fetDataContext();
          
            var subs = fdc.timeTables.Where(w => w.gresa_tt_fet == Tools.Globals.GRESA && w.StudentsSets == cb_radio_select.GetItemText(cb_radio_select.SelectedItem)).Select(s => s.Teachers).Distinct().ToList();
            var bindingsource1 = new BindingSource();
            bindingsource1.DataSource = subs;
            cb_check_select.DataSource = bindingsource1.DataSource;
            cb_check_select.DisplayMember = "Teachers";
           // cb_check_select.ValueMember = "Teachers";
        }
        private void st_one()
        {

        }
        private void sub_all()
        {
            fetDataContext fdc = new fetDataContext();
          //  var cls = fdc.timeTables.Where(w => w.gresa_tt_fet == Tools.Globals.GRESA && w.Subject == cb_radio_select.GetItemText(cb_radio_select.SelectedItem)).Select(s => s.StudentsSets).Distinct().ToList();

          
            var subs = (from c in (fdc.timeTables.Where(w => w.gresa_tt_fet == Tools.Globals.GRESA && w.Subject == cb_radio_select.GetItemText(cb_radio_select.SelectedItem)).Select(s => s.StudentsSets).Distinct().ToList())
                        join su in fdc.elevesses on c equals su.groups
                        select c == su.Subgroup ? su.groups : c
                        ).Distinct().ToList();

            var bindingsource1 = new BindingSource();
            bindingsource1.DataSource = subs;
            cb_check_select.DataSource = bindingsource1.DataSource;
            cb_check_select.DisplayMember = "StudentsSets";
            // cb_check_select.ValueMember = "StudentsSets";
        }
        private void sub_one()
        {

        }
        private void rb_cc_prof_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_cc_prof.Checked)
            {
                ch_rb_select.Text = "لجميع الأقسام المدرسة من طرف هذا الأستاذ";
               // cb_check_select.Enabled = false;
                lbl_what_tt.Text = "All_cls_prof";

                fetDataContext fdc = new fetDataContext();
                var profs = fdc.timeTables.Where(w => w.gresa_tt_fet == Tools.Globals.GRESA).Select(s => s.Teachers).Distinct().ToList();
                var bindingsource1 = new BindingSource();
                bindingsource1.DataSource = profs;
                cb_radio_select.DataSource = bindingsource1.DataSource;
                cb_radio_select.DisplayMember = "Teachers";
              //  cb_radio_select.ValueMember = "Teachers";
            }
        }

        private void rb_cc_cl_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_cc_cl.Checked)
            {
                ch_rb_select.Text = "لجميع مدرسي هذا القسم";
               // cb_check_select.Enabled = false;
                lbl_what_tt.Text = "All_profs_cl";

                fetDataContext fdc = new fetDataContext();
               // var cls = fdc.timeTables.Where(w => w.gresa_tt_fet == Tools.Globals.GRESA).Select(s => s.StudentsSets).Distinct().ToList();

                var subs = (from c in (fdc.timeTables.Where(w => w.gresa_tt_fet == Tools.Globals.GRESA).Select(s => s.StudentsSets).Distinct().ToList())
                            join su in fdc.elevesses on c equals su.groups

                            select c == su.Subgroup ? su.groups : c
                            ).Distinct().ToList();

                var bindingsource1 = new BindingSource();
                bindingsource1.DataSource = subs;
                cb_radio_select.DataSource = bindingsource1.DataSource;
                cb_radio_select.DisplayMember = "StudentsSets";
               // cb_radio_select.ValueMember = "StudentsSets";
            }
        }

        private void rb_cc_mat_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_cc_mat.Checked)
            {
                ch_rb_select.Text = "لجميع الأقسام المقررة عندهم هذه المادة";
              
             //   cb_check_select.Enabled = false;
                lbl_what_tt.Text = "All_mats_cl";

                fetDataContext fdc = new fetDataContext();
                var subs = fdc.timeTables.Where(w => w.gresa_tt_fet == Tools.Globals.GRESA).Select(s => s.Subject).Distinct().ToList();
                var bindingsource1 = new BindingSource();
                bindingsource1.DataSource = subs;
                cb_radio_select.DataSource = bindingsource1.DataSource;
                cb_radio_select.DisplayMember = "Subject";
               // cb_radio_select.ValueMember = "Subject";
            }
        }

      
        private void btn_tt_Click(object sender, EventArgs e)
        {
            fetDataContext fdc = new fetDataContext();

            if (lbl_what_tt.Text == "All_cls_prof")
            {
                var All_cls_prof = (from f in fdc.timeTables
                                    where f.Teachers == cb_radio_select.GetItemText(cb_radio_select.SelectedText)
                                    select f.StudentsSets
                                    ).ToList();
            }
            if (lbl_what_tt.Text == "All_profs_cl")
            {
                var All_profs_cl = (from f in fdc.timeTables
                                    where f.StudentsSets == cb_radio_select.GetItemText(cb_radio_select.SelectedText)
                                    select f.Teachers
                                   ).ToList();
            }
            if (lbl_what_tt.Text == "All_mat_cls")
            {
                var All_mat_cls = (from f in fdc.timeTables
                                    where f.Subject == cb_radio_select.GetItemText(cb_radio_select.SelectedText)
                                    select f.StudentsSets
                                  ).ToList();
            }
            if (lbl_what_tt.Text == "One_cl_prof")
            {
                var One_cl_prof = (from f in fdc.timeTables
                                   where f.StudentsSets == cb_radio_select.GetItemText(cb_radio_select.SelectedText)
                                        && f.Teachers== cb_check_select.GetItemText(cb_check_select.SelectedText)
                                   select f.Teachers
                                  ).FirstOrDefault().ToList();
            }
            if (lbl_what_tt.Text == "One_prof_cl")
            {
                var One_prof_cl = (from f in fdc.timeTables
                                   where f.Teachers == cb_radio_select.GetItemText(cb_radio_select.SelectedText)
                                        && f.StudentsSets == cb_check_select.GetItemText(cb_check_select.SelectedText)
                                   select f.StudentsSets
                                 ).FirstOrDefault().ToList();
            }
            if (lbl_what_tt.Text == "One_niv_cls")
            {
                var One_niv_cls = (from f in fdc.timeTables
                                   where f.Subject == cb_radio_select.GetItemText(cb_radio_select.SelectedText)
                                        && f.StudentsSets == cb_check_select.GetItemText(cb_check_select.SelectedText)
                                   select f.StudentsSets
                                                ).ToList();
            }
        }

        private void cb_radio_select_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ch_rb_select.Checked)
            {
                if (rb_cc_prof.Checked)
                    prof_all();
                if (rb_cc_cl.Checked)
                    st_all();
                if (rb_cc_mat.Checked)
                    sub_all();



            }
        }

        private void ch_rb_select_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_rb_select.Checked)
                cb_radio_select_SelectedIndexChanged(sender, e);
            else
                cb_check_select.DataSource = null;

        }

      
    }
}
