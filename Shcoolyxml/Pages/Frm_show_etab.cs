using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schooly.Pages
{
    public partial class Frm_show_etab : Form
    {
        public Frm_show_etab()
        {
            InitializeComponent();
        }

        private void Frm_show_etab_Load(object sender, EventArgs e)
        {
            EtablissementDataContext etdc = new EtablissementDataContext();
            var etabs = etdc.InfoEtabs.Select(et => new { gresa = et.gresa_info, etabliss = et.etabNameAr_info,card=et.cardN_info }).ToList();

            var bindingSource1 = new BindingSource();
            bindingSource1.DataSource = etabs;
            cb_select_etab.DataSource = bindingSource1.DataSource;
            cb_select_etab.DisplayMember = "etabliss";
            cb_select_etab.ValueMember = "gresa";

            var source = new BindingSource(etabs, null);
            dtgv_etabs.DataSource = source;

        }

        private void cb_select_etab_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (tabControl_show_et.SelectedIndex == 1)
            {
                EmployeeDataContext emdc = new EmployeeDataContext();
                var empolyees = (from em in emdc.Emp_Datas
                                 join ac in emdc.Emp_Acts on em.ppr_dat equals ac.ppr_act
                                 where cb_select_etab.GetItemText(cb_select_etab.SelectedValue)==ac.CD_ETAB
                                 select new
                                 {
                                     nom = em.NOMA + " " + em.PRENOMA,
                                     ppr = em.ppr_dat,
                                     etabliss = ac.CD_ETAB
                                 }).ToList();

            
                var source = new BindingSource(empolyees, null);
                dtgv_empl.DataSource = source;
            }
            if (tabControl_show_et.SelectedIndex == 2)
            {
                StudentsListDataContext stdc = new StudentsListDataContext();
                var students = stdc.StudentListUpdates.Where(st => st.gresa_Up == cb_select_etab.GetItemText(cb_select_etab.SelectedValue)).Select(stt => new
                {
                    gresa = stt.gresa_Up,
                    nom = stt.lastName_Up,
                    prenom = stt.firstName_Up,
                    massar = stt.cMassar_Up,
                    classe = stt.classe_Up,
                    niveau = stt.niveau_Up
                }).ToList();
                var source = new BindingSource(students, null);
                dtgv_st.DataSource = source;

            }
        }

        private void btn_showAll_Click(object sender, EventArgs e)
        {
            if (tabControl_show_et.SelectedIndex == 1)
            {
                EmployeeDataContext emdc = new EmployeeDataContext();
                var empolyees = (from em in emdc.Emp_Datas
                                 join ac in emdc.Emp_Acts on em.ppr_dat equals ac.ppr_act
                                 select new
                                 {
                                     nom = em.NOMA + " " + em.PRENOMA,
                                     ppr = em.ppr_dat,
                                     etabliss = ac.CD_ETAB
                                 }).ToList();


                var source = new BindingSource(empolyees, null);
                dtgv_empl.DataSource = source;
            }
            if (tabControl_show_et.SelectedIndex == 2)
            {
                StudentsListDataContext stdc = new StudentsListDataContext();
                var students = stdc.StudentListUpdates.Select(stt => new
                {
                    gresa = stt.gresa_Up,
                    nom = stt.lastName_Up,
                    prenom = stt.firstName_Up,
                    massar = stt.cMassar_Up,
                    classe = stt.classe_Up,
                    niveau = stt.niveau_Up
                }).ToList();
                var source = new BindingSource(students, null);
                dtgv_st.DataSource = source;

            }
        }
    }
}
