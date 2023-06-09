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
    public partial class Frm_print_data_emp : Form
    {
        public Frm_print_data_emp()
        {
            InitializeComponent();
        }
        string gresa = Tools.Globals.GRESA;
        private void Frm_print_data_emp_Load(object sender, EventArgs e)
        {
            EmployeeDataContext edc = new EmployeeDataContext();
            var employees = (from emD in edc.Emp_Datas
                             join emA in edc.Emp_Acts on emD.ppr_dat equals emA.ppr_act
                             where emA.CD_ETAB.Equals(gresa)
                             select new
                             {
                                 ppr = emD.ppr_dat,
                                 nom = emD.NOMA + " " + emD.PRENOMA
                             }).ToList();
            cb_report_select_emp.DataSource = new BindingSource(employees, null);
            cb_report_select_emp.DisplayMember = "nom";
            cb_report_select_emp.ValueMember = "ppr";

          
            if (cb_report_select_emp.Items.Count > 0)
                cb_report_select_emp.SelectedIndex = 0;
        }



        private void btn_view_cert_ar_Click(object sender, EventArgs e)
        {
            //string selectedppr = cb_report_select_emp.GetItemText(cb_report_select_emp.SelectedValue);
            //new Reports.Frm_repport_test(selectedppr, "show_certif_ar").ShowDialog();
        }

        private void btn_view_cert_fr_Click(object sender, EventArgs e)
        {
            //string selectedppr = cb_report_select_emp.GetItemText(cb_report_select_emp.SelectedValue);
            //new Reports.Frm_repport_test(selectedppr, "show_certif_fr").ShowDialog();
        }
        private void btn_print_cert_ar_Click(object sender, EventArgs e)
        {
            if (cb_report_select_emp.Items.Count > 0)
            {
                string selectedppr = cb_report_select_emp.GetItemText(cb_report_select_emp.SelectedValue);
                new Reports.Frm_repport_test(selectedppr, "print_certif_ar").ShowDialog();
            }
        }

        private void btn_print_cert_fr_Click(object sender, EventArgs e)
        {
            if (cb_report_select_emp.Items.Count > 0)
            {
                string selectedppr = cb_report_select_emp.GetItemText(cb_report_select_emp.SelectedValue);
                new Reports.Frm_repport_test(selectedppr, "print_certif_fr").ShowDialog();
            }
        }
    }
}
